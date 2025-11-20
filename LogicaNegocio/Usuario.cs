namespace LogicaNegocio;

public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _contrasena;
        private string _email;
        private Equipo _equipo;
        private DateTime _fechaIncorporacion;
        private static string _s_dominio = "@laEmpresa.com";
        private int _repetidos = 1;
        private Rol _rol;
        
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }
        public string Contrasena
        {
            get { return this._contrasena; }
            set { this._contrasena = value; }
        }
        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }
        public Equipo Equipo
        {
            get { return this._equipo; }
            set { this._equipo = value; }
        }
        public DateTime FechaIncorporacion
        {
            get { return this._fechaIncorporacion; }
            set { this._fechaIncorporacion = value; }
        }

        public int Repetidos
        {
            get { return this._repetidos; }
            set { this._repetidos = value; }
        }
        
        public Rol Rol
        {
          get { return this._rol; }
          set { this._rol = value; }
        }
        public Usuario(string nombre, string apellido, string contrasena, Equipo equipo,
            DateTime fechaIncorporacion, Rol rol)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._contrasena = contrasena;
            this._equipo = equipo;
            this._fechaIncorporacion = fechaIncorporacion;
            this._rol = rol;
        }
        public void Validar()
        {
            this.ValidarContrasena();
            this.ValidarEquipo();
            this.ValidarNombre();
            this.ValidarApellido();
        }
        private void ValidarEquipo()
        {
            if (this._equipo == null)
            {
                throw new Exception("El usuario debe pertenecer a un equipo");
            }
        }
        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(this._nombre)){
                throw new Exception("Debe ingresar un nombre valido.");
            }
        }
        private void ValidarApellido()
        {
            if (string.IsNullOrWhiteSpace(this._apellido)){
                throw new Exception("Debe ingresar un apellido valido.");
            }
        }
        private void ValidarContrasena()
        {
            if (this.Contrasena.Length < 8)
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres");
            }
        }

        //Recibe 2 parametros. Dependiendo del valor de esRepetido, se genera un email con contador o sin el.
        public string GenerarEmail(bool esRepetido, int contador)
        {
            string nuevoNombre;
            string nuevoApellido;
            string emailARetornar = "";
            if (this._nombre.Length < 3)
            {
                nuevoNombre = this._nombre;
            }
            else
            {
                nuevoNombre = this._nombre.Substring(0, 3);
            }

            if (this._apellido.Length < 3)
            {
                nuevoApellido = this._apellido;
            }
            else
            {
                nuevoApellido = this._apellido.Substring(0, 3);
            }

            if (!esRepetido)
            {
                emailARetornar = $"{nuevoNombre}{nuevoApellido}{Usuario._s_dominio}";
            }
            else
            {
                emailARetornar = $"{nuevoNombre}{nuevoApellido}{contador}{Usuario._s_dominio}";
            }
            return emailARetornar;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Usuario))
            {
                return false;
            }

            Usuario user = obj as Usuario;
            return this.Email == user.Email;
        }
    }