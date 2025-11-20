namespace LogicaNegocio;

public abstract class Pago
    {
        private int _id;
        private string _descripcion;
        private double _monto;
        private MetodoDePago _metodoDePago;
        private TipoDeGasto _tipoDeGasto;
        private Usuario _usuario;
        private static int _s_ultimoId = 0;

        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Descripcion
        {
            get { return this._descripcion; }
            set { this._descripcion = value; }

        }

        public double Monto
        {
            get { return this._monto; }
            set { this._monto = value; }
        }

        public MetodoDePago MetodoDePago
        {
            get { return this._metodoDePago; }
            set { this._metodoDePago = value; }
        }

        public TipoDeGasto TipoDeGasto
        {
            get { return this._tipoDeGasto; }
            set { this._tipoDeGasto = value; }
        }

        public Usuario Usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }
        }

        public Pago(string descripcion, double monto, MetodoDePago metodoDePago, TipoDeGasto tipoDeGasto, Usuario usuario)
        {
            this._id = Pago._s_ultimoId++;
            this._descripcion = descripcion;
            this._monto = monto;
            this._metodoDePago = metodoDePago;
            this._tipoDeGasto = tipoDeGasto;
            this._usuario = usuario;
        }

        public Pago()
        {
            this._id = Pago._s_ultimoId++;
        }

        public abstract void Validar();
        
        public virtual double CostoMostrar 
        {
            get
            {
                return CalcularCosto();
            } 
        }
        public abstract double CalcularCosto();
    }
    