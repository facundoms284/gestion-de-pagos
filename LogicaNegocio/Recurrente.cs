namespace LogicaNegocio;

public class Recurrente : Pago
    {
        private DateTime _fechaDesde;
        private DateTime? _fechaHasta;
        private int _mesesTotales;
        
        public DateTime FechaDesde
        {
            get { return this._fechaDesde; }
            set { this._fechaDesde = value; }
        }

        public DateTime? FechaHasta
        {
            get { return this._fechaHasta; }
            set { this._fechaHasta = value; }
        }

        public int MesesTotales
        {
            get { return this._mesesTotales; }
        }
        public Recurrente(string descripcion, double monto, MetodoDePago metodo, TipoDeGasto tipo, Usuario usuario, DateTime desde, DateTime? hasta)
        : base(descripcion, monto, metodo, tipo, usuario)
        {
            this._fechaDesde = desde;
            this._fechaHasta = hasta;

            if (_fechaHasta.HasValue)
            {
                //Value asegura que atributo FechaHasta no venga null, se almacena un entero con la cantidad de meses totales por pagar cuota.
                this._mesesTotales = ((FechaHasta.Value.Year - FechaDesde.Year) * 12) +
                                     (FechaHasta.Value.Month - FechaDesde.Month) + 1;
            }
            else
            {
                this._mesesTotales = 0;
            }
        }

        public Recurrente(DateTime? hasta)
        {
            this._fechaDesde = DateTime.Now;
            this._fechaHasta = hasta;
        }

        public override void Validar()
        {
            this.ValidarFechaHasta();
            this.ValidarMonto();
            this.ValidarDescripcion();
        }

        private void ValidarFechaHasta()
        {
            if (this._fechaHasta < this._fechaDesde)
            {
                throw new Exception("Fecha inválida.");
            }
        }
        
        private void ValidarMonto()
        {
            if (this.Monto < 1)
            {
                throw new Exception("Monto inválido.");
            }
        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(this.Descripcion))
            {
                throw new Exception("Descripción inválida.");
            }
        }
        public int CalcularPagosPendientes()
        {
            //0 pagos pendientes.
            if (this._fechaHasta.HasValue && DateTime.Now > this._fechaHasta)
            {
                return 0;
            }

            if (this._mesesTotales != 0)
            {
                int mesesPasados = ((DateTime.Now.Year - FechaDesde.Year) * 12) + DateTime.Now.Month - FechaDesde.Month;
                return this._mesesTotales - mesesPasados; 
            }

            return -1; // para hacer referencia que es indefinido.
        }
        public override double CostoMostrar => CalcularCostoMensual();

        public override double CalcularCosto()
        {
            double recargo = this.Monto * CalcularRecargo();
            double totalConRecargo = this.Monto + recargo;

            if (this._mesesTotales == 0)
            {
                return totalConRecargo;
            }

            return (totalConRecargo) * this._mesesTotales;
        }

        public double CalcularCostoMensual()
        {
            double recargo = this.Monto * CalcularRecargo();
            double totalConRecargo = this.Monto + recargo;
            
            if (this._mesesTotales == 0)
            {
                return totalConRecargo;
            }

            return totalConRecargo / this._mesesTotales;
        }
        public double CalcularRecargo()
        {
            double aRetornar = 0.03;
            if (this._fechaHasta != null)
            {
                if (this._mesesTotales > 10)
                {
                    aRetornar = 0.10;
                }else if (this._mesesTotales >= 6 && this._mesesTotales <= 9)
                {
                    aRetornar = 0.05;
                }
            }

            return aRetornar;
        }
    }