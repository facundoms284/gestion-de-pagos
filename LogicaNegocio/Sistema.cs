using LogicaNegocio.Ordenamiento;

namespace LogicaNegocio;

public class Sistema
    {
        private List<Usuario> _usuarios;
        private List<Pago> _pagos;
        private List<Equipo> _equipos;
        private List<TipoDeGasto> _tiposDeGastos;
        private static Sistema _s_instancia;

        public List<Usuario> Usuarios
        {
            get { return new List<Usuario>(this._usuarios); }
        }

        public List<Equipo> Equipos
        {
            get { return new List<Equipo>(this._equipos); }
        }

        public List<Pago> Pagos
        {
            get { return new List<Pago>(this._pagos); }
        }

        public static Sistema Instancia
        {
            get
            {
                if (_s_instancia == null)
                {
                    _s_instancia = new Sistema();
                }
                return _s_instancia;
            }
        }

        private Sistema()
        {
            _usuarios = new List<Usuario>();
            _equipos = new List<Equipo>();
            _pagos = new List<Pago>();
            _tiposDeGastos = new List<TipoDeGasto>();
            this.PrecargarEquipos();
            this.PrecargarUsuarios();
            this.PrecargarTiposDeGastos();
            this.PrecargarPagos();
        }

        public void PrecargarUsuarios()
        {
            this.AltaUsuario(new Usuario("Ana", "Lopez", "seguro12", this._equipos[0], DateTime.Now.AddDays(-400), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Bruno", "Perez", "clave789", this._equipos[0], DateTime.Now.AddDays(-300), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Camila", "Ramos", "seguro12", this._equipos[1], DateTime.Now.AddDays(-200), Rol.GERENTE));
            this.AltaUsuario(new Usuario("Diego", "Suarez", "xyz789ba0", this._equipos[1], DateTime.Now.AddDays(-150), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Elena", "Martinez", "elena212kj", this._equipos[2], DateTime.Now.AddDays(-120), Rol.GERENTE));
            this.AltaUsuario(new Usuario("Federico", "Gomez", "fede456hajw", this._equipos[2], DateTime.Now.AddDays(-100), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Gabriela", "Diaz", "gaby789n", this._equipos[3], DateTime.Now.AddDays(-90), Rol.GERENTE));
            this.AltaUsuario(new Usuario("Hector", "Torres", "htorres1", this._equipos[0], DateTime.Now.AddDays(-80), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Isabel", "Vega", "isavega7", this._equipos[0], DateTime.Now.AddDays(-75), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Javier", "Rosa", "javiro521", this._equipos[1], DateTime.Now.AddDays(-60), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Karen", "Nuñez", "karenn999", this._equipos[1], DateTime.Now.AddDays(-50), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Leonardo", "Paz", "leopaz666", this._equipos[2], DateTime.Now.AddDays(-40), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Maria", "Quintero", "maria1010", this._equipos[2], DateTime.Now.AddDays(-30), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Nicolas", "Rivero", "nrivero8", this._equipos[3], DateTime.Now.AddDays(-25), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Olga", "Fernandez", "olga12345", this._equipos[0], DateTime.Now.AddDays(-20), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Pablo", "Lopez", "pablo2211", this._equipos[1], DateTime.Now.AddDays(-15), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Rocio", "Santos", "rocio33n1", this._equipos[1], DateTime.Now.AddDays(-10), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Sergio", "Herrera", "sergioa7", this._equipos[2], DateTime.Now.AddDays(-8), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Tamara", "Rey", "tammy44455", this._equipos[3], DateTime.Now.AddDays(-5), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Ulises", "Roldan", "ulises101", this._equipos[3], DateTime.Now.AddDays(-3), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Valeria", "Mendez", "valm123jas", this._equipos[2], DateTime.Now.AddDays(-2), Rol.EMPLEADO));
            this.AltaUsuario(new Usuario("Walter", "Iglesias", "walter9walter", this._equipos[0], DateTime.Now, Rol.EMPLEADO));

        }
        public void PrecargarEquipos()
        {
            this._equipos.Add(new Equipo(1, "Desarrollo"));
            this._equipos.Add(new Equipo(2, "Marketing"));
            this._equipos.Add(new Equipo(3, "Finanzas"));
            this._equipos.Add(new Equipo(4, "Recursos Humanos"));

        }
        public void PrecargarPagos()
        {
            List<Usuario> u = this._usuarios;
            List<TipoDeGasto> g = this._tiposDeGastos;

            // ---- 17 Pagos Únicos ----
            this._pagos.Add(new Unico("Alquiler Octubre", 1200, MetodoDePago.CREDITO, g[0], u[0], DateTime.Now.AddDays(-30), "REC001"));
            this._pagos.Add(new Unico("Factura de Luz", 300, MetodoDePago.DEBITO, g[1], u[2], DateTime.Now.AddDays(-13), "REC002"));
            this._pagos.Add(new Unico("Campaña Facebook", 500, MetodoDePago.CREDITO, g[2], u[3], DateTime.Now.AddDays(-20), "REC003"));
            this._pagos.Add(new Unico("Pago de Sueldo Elena", 2200, MetodoDePago.EFECTIVO, g[3], u[4], DateTime.Now.AddDays(-15), "REC004"));
            this._pagos.Add(new Unico("Taxi reunión cliente", 80, MetodoDePago.DEBITO, g[4], u[2], DateTime.Now.AddDays(-10), "REC005"));
            this._pagos.Add(new Unico("Comida equipo", 150, MetodoDePago.EFECTIVO, g[5], u[6], DateTime.Now.AddDays(-5), "REC006"));
            this._pagos.Add(new Unico("Licencia Photoshop", 400, MetodoDePago.CREDITO, g[6], u[7], DateTime.Now.AddDays(-45), "REC007"));
            this._pagos.Add(new Unico("Reparación PC", 250, MetodoDePago.DEBITO, g[7], u[8], DateTime.Now.AddDays(-35), "REC008"));
            this._pagos.Add(new Unico("Evento Team Building", 1000, MetodoDePago.CREDITO, g[8], u[9], DateTime.Now.AddDays(-60), "REC009"));
            this._pagos.Add(new Unico("Papel y útiles", 90, MetodoDePago.EFECTIVO, g[9], u[10], DateTime.Now.AddDays(-7), "REC010"));
            this._pagos.Add(new Unico("Mantenimiento aire", 350, MetodoDePago.DEBITO, g[7], u[11], DateTime.Now.AddDays(-40), "REC011"));
            this._pagos.Add(new Unico("Publicidad Instagram", 270, MetodoDePago.CREDITO, g[2], u[12], DateTime.Now.AddDays(-12), "REC012"));
            this._pagos.Add(new Unico("Snacks oficina", 50, MetodoDePago.EFECTIVO, g[5], u[13], DateTime.Now.AddDays(-3), "REC013"));
            this._pagos.Add(new Unico("Taxi aeropuerto", 60, MetodoDePago.DEBITO, g[4], u[14], DateTime.Now.AddDays(-8), "REC014"));
            this._pagos.Add(new Unico("Hosting web", 200, MetodoDePago.CREDITO, g[6], u[15], DateTime.Now.AddDays(-6), "REC015"));
            this._pagos.Add(new Unico("Desinfección oficina", 180, MetodoDePago.EFECTIVO, g[7], u[16], DateTime.Now.AddDays(-4), "REC016"));
            this._pagos.Add(new Unico("Cafetera nueva", 120, MetodoDePago.DEBITO, g[9], u[17], DateTime.Now.AddDays(-2), "REC017"));

            // ---- 25 Pagos Recurrentes ----
            // 5 totalmente pagados (fechaHasta ya vencida)
            this._pagos.Add(new Recurrente("Internet mensual", 60, MetodoDePago.DEBITO, g[1], u[0], DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(-1)));
            this._pagos.Add(new Recurrente("Servicio limpieza", 100, MetodoDePago.CREDITO, g[7], u[1], DateTime.Now.AddMonths(-5), DateTime.Now.AddMonths(-1)));
            this._pagos.Add(new Recurrente("Netflix oficina", 15, MetodoDePago.CREDITO, g[6], u[2], DateTime.Now.AddMonths(-4), DateTime.Now.AddMonths(-1)));
            this._pagos.Add(new Recurrente("Seguro empresa", 300, MetodoDePago.DEBITO, g[9], u[3], DateTime.Now.AddMonths(-12), DateTime.Now.AddMonths(-2)));
            this._pagos.Add(new Recurrente("Plan telefonía", 80, MetodoDePago.EFECTIVO, g[1], u[4], DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(-1)));

            // 20 activos (aún no vencen)
            this._pagos.Add(new Recurrente("Alquiler mensual", 1200, MetodoDePago.CREDITO, g[0], u[5], DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(4)));
            this._pagos.Add(new Recurrente("Electricidad", 250, MetodoDePago.DEBITO, g[1], u[6], DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(5)));
            this._pagos.Add(new Recurrente("Spotify", 10, MetodoDePago.CREDITO, g[6], u[7], DateTime.Now.AddMonths(-3), DateTime.Now.AddMonths(3)));
            this._pagos.Add(new Recurrente("Publicidad Google", 400, MetodoDePago.CREDITO, g[2], u[8], DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(6)));
            this._pagos.Add(new Recurrente("Plan comida", 180, MetodoDePago.EFECTIVO, g[5], u[9], DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(5)));
            this._pagos.Add(new Recurrente("Hosting servidor", 220, MetodoDePago.CREDITO, g[6], u[10], DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(6)));
            this._pagos.Add(new Recurrente("Mantenimiento impresora", 90, MetodoDePago.DEBITO, g[7], u[11], DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(5)));
            this._pagos.Add(new Recurrente("Capacitación equipo", 350, MetodoDePago.CREDITO, g[8], u[12], DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(3)));
            this._pagos.Add(new Recurrente("Suscripción diseño", 45, MetodoDePago.CREDITO, g[6], u[13], DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(4)));
            this._pagos.Add(new Recurrente("Transporte interno", 100, MetodoDePago.EFECTIVO, g[4], u[14], DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(3)));
            this._pagos.Add(new Recurrente("Snacks oficina", 60, MetodoDePago.DEBITO, g[5], u[15], DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(5)));
            this._pagos.Add(new Recurrente("Publicidad mensual", 300, MetodoDePago.CREDITO, g[2], u[16], DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(6)));
            this._pagos.Add(new Recurrente("Limpieza vidrios", 80, MetodoDePago.EFECTIVO, g[7], u[17], DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(4)));
            this._pagos.Add(new Recurrente("Software contable", 250, MetodoDePago.CREDITO, g[6], u[18], DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(5)));
            this._pagos.Add(new Recurrente("Asesoría legal", 500, MetodoDePago.DEBITO, g[9], u[19], DateTime.Now.AddMonths(-3), DateTime.Now.AddMonths(3)));
            this._pagos.Add(new Recurrente("Mantenimiento ascensor", 120, MetodoDePago.CREDITO, g[7], u[20], DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(5)));
            this._pagos.Add(new Recurrente("Plan de salud", 350, MetodoDePago.DEBITO, g[9], u[21], DateTime.Now.AddMonths(-4), DateTime.Now.AddMonths(2)));
            this._pagos.Add(new Recurrente("Correo corporativo", 30, MetodoDePago.CREDITO, g[6], u[0], DateTime.Now.AddMonths(-5), DateTime.Now.AddMonths(5)));
            this._pagos.Add(new Recurrente("Publicidad local", 150, MetodoDePago.EFECTIVO, g[2], u[1], DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(3)));
            this._pagos.Add(new Recurrente("Combustible mensual", 200, MetodoDePago.DEBITO, g[4], u[2], DateTime.Now.AddMonths(-3), DateTime.Now.AddMonths(2)));
        }

        public void PrecargarTiposDeGastos()
        {
            this._tiposDeGastos.Add(new TipoDeGasto("Alquiler", "Pago mensual del local u oficina"));
            this._tiposDeGastos.Add(new TipoDeGasto("Servicios", "Luz, agua, internet, etc."));
            this._tiposDeGastos.Add(new TipoDeGasto("Marketing", "Publicidad y redes sociales"));
            this._tiposDeGastos.Add(new TipoDeGasto("Salarios", "Pago de sueldos a empleados"));
            this._tiposDeGastos.Add(new TipoDeGasto("Transporte", "Gastos de movilidad"));
            this._tiposDeGastos.Add(new TipoDeGasto("Comida", "Snacks y almuerzos de equipo"));
            this._tiposDeGastos.Add(new TipoDeGasto("Software", "Licencias y herramientas digitales"));
            this._tiposDeGastos.Add(new TipoDeGasto("Mantenimiento", "Reparaciones o limpieza"));
            this._tiposDeGastos.Add(new TipoDeGasto("Eventos", "Capacitaciones y eventos corporativos"));
            this._tiposDeGastos.Add(new TipoDeGasto("Otros", "Gastos varios no categorizados"));
        }
        public bool existeEmail(Usuario usuario)
        {
            foreach (Usuario unUsuario in this._usuarios)
            {
                if (unUsuario.Email == usuario.Email)
                {
                    return true;
                }
            }

            return false;
        }
        public void AltaUsuario(Usuario usuario)
        {
            usuario.Validar();
            int contador = 1;
            string email = usuario.GenerarEmail(false, contador);
            usuario.Email = email;

            //Mientras se encuentre una coincidencia, regeneramos el email
            while (existeEmail(usuario))
            {
                email = usuario.GenerarEmail(true, contador);
                usuario.Email = email;
                contador++;
            }

            this._usuarios.Add(usuario);
        }
        public void AgregarPago(Pago pago)
        {
            pago.Validar();
            if (pago != null)
            {
                this._pagos.Add(pago);
            }
        }

        public void AgregarTipoDeGasto(TipoDeGasto tipoDeGasto)
        {
            tipoDeGasto.Validar();
            if (tipoDeGasto != null)
            {
                this._tiposDeGastos.Add(tipoDeGasto);
            }
        }

        public List<Pago> ObtenerPagos()
        {
            List<Pago> aRetornar = new List<Pago>();
            
            foreach (Pago pago in this._pagos)
            {
                aRetornar.Add(pago);
            }

            return aRetornar;
        }
        
        public List<Pago> ObtenerPagosDeUsuario(string email)
        {
            List<Pago> aRetornar = new List<Pago>();

            foreach (Pago pago in this._pagos)
            {
                if (pago.Usuario.Email == email)
                {
                    aRetornar.Add(pago);
                }
            }

            return aRetornar;
        }
        public List<Usuario> ObtenerListaUsuarios()
        {
            List<Usuario> nuevaLista = new List<Usuario>();
            foreach (Usuario usuario in this._usuarios)
            {
                nuevaLista.Add(usuario);
            }
            return nuevaLista;
        }
        //Devuelve una lista nueva que contiene todos los equipos almacenados
        public List<Equipo> ObtenerEquiposExistentes()
        {
            List<Equipo> aRetornar = new List<Equipo>();
            foreach (Equipo equipo in this._equipos)
            {
                aRetornar.Add(equipo);
            }
            return aRetornar;
        }
        //Devuelve una nueva lista de usuarios que contiene los pertenecientes a determinado equipo
        public List<Usuario> ObtenerUsuariosPorEquipo(string nombreEquipo)
        {
            List<Usuario> nuevaLista = new List<Usuario>();
            foreach (Usuario usuario in this._usuarios)
            {
                if (usuario.Equipo.Nombre.ToLower() == nombreEquipo.ToLower())
                {
                    nuevaLista.Add(usuario);
                }
            }
            return nuevaLista;
        }
        //Se encarga de buscar y devolver el equipo cuyo nombre coincida con el recibido por parametro
        public Equipo ObtenerEquipoPorNombre(string nombreEquipo)
        {
            foreach (Equipo equipo in this._equipos)
            {
                if (equipo.Nombre.ToLower() == nombreEquipo.ToLower())
                {
                    return equipo;
                }
            }
            throw new Exception("No se encontro el equipo");
        }

        public List<Pago> ObtenerPagosMes(List<Pago> pagos)
        {
            List<Pago> aRetornar = new List<Pago>();
            DateTime hoy = DateTime.Now;
            int añoActual = hoy.Year;
            int mesActual = hoy.Month;

            // Determinamos el primer y último día del mes actual
            DateTime inicioMes = new DateTime(añoActual, mesActual, 1);
            DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);
            
            foreach (Pago pago in pagos)
            {
                if (pago is Recurrente recurrente)
                {
                    if (recurrente.FechaDesde <= finMes &&
                        (recurrente.FechaHasta >= inicioMes || recurrente.FechaHasta == null))
                    {
                        aRetornar.Add(pago);
                    }
                }
                else if(pago is Unico unico)
                {
                    if (unico.FechaPago >= inicioMes && unico.FechaPago <= finMes)
                    {
                        aRetornar.Add(pago);
                    }
                }
            } 
            return  aRetornar;
        }
        
        public List<TipoDeGasto> ListarGastos()
        {
            List<TipoDeGasto> aRetornar = new List<TipoDeGasto>();
            List<Pago> pagosMes = ObtenerPagosMes(this._pagos);

            foreach (Pago pago in pagosMes)
            {
                aRetornar.Add(pago.TipoDeGasto);
            }
            
            return aRetornar;
        }
        
        public Usuario BuscarUsuario(string email, string contrasena)
        {
            Usuario usuario = null;
            foreach (Usuario u in this._usuarios)
            {
                if (u.Email == email && u.Contrasena == contrasena)
                {
                    return u;
                }
            }
            return usuario;
        }
        
        public List<Pago> ObtenerPagosMesPorUsuario(string email)
        {
            List<Pago> pagosMensuales = new List<Pago>(ObtenerPagosMes(this._pagos));
            List<Pago> aRetornar = new List<Pago>();
            foreach (Pago pago in pagosMensuales)
            {
                if (pago.Usuario.Email == email)
                {
                    aRetornar.Add(pago);
                }
            }
            return aRetornar;
        }
        
        public double ObtenerTotalPagosMesPorUsuario(string email)
        {
            double total = 0;
            List<Pago> pagosMes = new List<Pago>(ObtenerPagosMesPorUsuario(email));
            foreach (Pago pago in pagosMes)
            {
                if (pago is Recurrente recurrente)
                {
                    total += recurrente.CalcularCostoMensual();
                }else if (pago is Unico unico)
                {
                    total += unico.CalcularCosto();
                }
            }
            return total;
        }

        public List<Pago> OrdenarPagosPorMontoDesc(List<Pago> pagos)
        {
            pagos.Sort(new PagoOrdenPorMonto());
            return pagos;
        }
        
        public List<Usuario> OrdenarUsuariosEquipoPorEmailAsc(List<Usuario> usuarios)
        {
            usuarios.Sort(new EquipoUsuariosPorEmailAsc());

            return usuarios;
        }

        public List<TipoDeGasto> ObtenerTiposDeGastos()
        {
            List<TipoDeGasto> aRetornar = new List<TipoDeGasto>();
            foreach (TipoDeGasto tipoDeGasto in this._tiposDeGastos)
            {
                aRetornar.Add(tipoDeGasto);
            }
            return aRetornar;
        }

        public TipoDeGasto ObtenerTipoDeGastoPorNombre(string nombre)
        {
            foreach (TipoDeGasto tipo in this._tiposDeGastos)
            {
                if (tipo.Nombre.ToLower() == nombre.ToLower())
                {
                    return tipo;
                }
            }

            return null;
        }

        public void EliminarTipoDeGastoPorNombre(string nombre)
        {
            for (int i = 0; i < _tiposDeGastos.Count; i++)
            {
                if (_tiposDeGastos[i].Nombre == nombre)
                {
                    _tiposDeGastos.RemoveAt(i);
                    break;
                }
            }
        }
        
        public List<Pago> ObtenerPagosPorEquipo(string nombre)
        {
            List<Pago> aRetornar = new List<Pago>();

            foreach (Pago pago in this._pagos)
            {
                Usuario usuario = pago.Usuario;
                if (usuario.Equipo.Nombre == nombre)
                {
                    aRetornar.Add(pago);
                }
            }
            
            return aRetornar;
        }

        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            Usuario aRetornar = null;
            
            foreach (Usuario usuario in this._usuarios)
            {
                if (usuario.Email == email)
                {
                    aRetornar = usuario;
                    break;
                }
            }

            return aRetornar;
        }
        
        public List<Pago> ObtenerPagosPorFecha(DateTime fecha)
        {
            List<Pago> aRetornar = new List<Pago>();

            foreach (Pago pago in this._pagos)
            {
                if (pago is Recurrente recurrente)
                {
                    if (recurrente.FechaDesde.Month == fecha.Month && recurrente.FechaDesde.Year == fecha.Year)
                    {
                        if (recurrente.FechaDesde.Month >= DateTime.Now.Month && recurrente.FechaHasta?.Month <= DateTime.Now.Month)
                        {
                        aRetornar.Add(pago);
                        }
                    }
                }
                else if(pago is  Unico unico)
                {
                    if (unico.FechaPago.Month == fecha.Month && unico.FechaPago.Year == fecha.Year)
                    {
                        aRetornar.Add(pago);
                    }
                }
            }
            return aRetornar;
        }
    }