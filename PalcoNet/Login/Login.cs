using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PalcoNet.Login
{
    public partial class Login : Form
    {
        private dbmanager db;
        private String _username;
        private String _password;
        private String _hashPass;
        private Boolean _consulta;
        public static Decimal RolSeleccionado;

        public Login(dbmanager db)
        {
            this.db = db;
            InitializeComponent();
        }


        private void aceptar_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                MessageBox.Show(@"Ingrese un usuario.");
                return;
            }

            _username = tbUsername.Text;
            Boolean existeUsuario = this.db.Consultar("SELECT Id, Username, Password, Cant_Login_Fallidos FROM [CAMPUS_ANALYTICA].[Usuario] WHERE Username = '" + _username + "' AND Cant_Login_Fallidos < 3 AND Estado = 'A'");
            if (!existeUsuario)
            {
                MessageBox.Show(@"El usuario no existe en la base de datos o está bloqueado.");
                tbPassword.Text = "";
                tbUsername.Text = "";
                tbUsername.Focus();

                return;
            }

            if (tbPassword.Text == "")
            {
                MessageBox.Show(@"Ingrese el password.");
                return;
            }

            _hashPass = this.Hash(tbPassword.Text.Trim());
            _password = tbPassword.Text.Trim();
            _consulta = this.db.Consultar("SELECT Id, Username, Password, Cant_Login_Fallidos FROM [CAMPUS_ANALYTICA].[Usuario] WHERE Username = '" + _username + "' AND Cant_Login_Fallidos < 3 AND Estado = 'A'");
            if (!_consulta)
            {
                MessageBox.Show(@"Usuario no existe o está bloqueado.");
                return;
            }

            this.db.Leer();
            String dbUsername = this.db.ObtenerValor("Username");
            String dbPassword = this.db.ObtenerValor("Password");
            int dbUsuarioId = Int32.Parse(this.db.ObtenerValor("Id"));
            int dbIntentosFallidos = Int32.Parse(this.db.ObtenerValor("Cant_Login_Fallidos"));

            if ((_password == dbPassword) || (_hashPass == dbPassword)) // Pregunta por el password (para usuarios migrados) o por el hash (nuevos usuarios)
            {
                if (dbIntentosFallidos > 0) // Si ingresó correctamente su password, y si tenía intentos fallidos, los resetea
                {
                    this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Usuario] SET Cant_Login_Fallidos = 0 WHERE Username = '" + _username + "'");
                }

                // Revisa si el usuario tiene más de un Rol
                _consulta = this.db.Consultar("SELECT COUNT(*) 'Cantidad' FROM [CAMPUS_ANALYTICA].[Usuario_Rol] WHERE Usuario_Id = " + dbUsuarioId);
                this.db.Leer();
                Int32 cantidadRoles = Int32.Parse(this.db.ObtenerValor("Cantidad"));

                if (cantidadRoles == 0)
                {
                    MessageBox.Show(@"El usuario no tiene roles asignados.");
                    return;
                }

                if (cantidadRoles > 1)
                {
                    MessageBox.Show(@"El usuario tiene más de un rol asignado, por favor seleccione uno.");
                    PalcoNet.Login.SelRol f = new PalcoNet.Login.SelRol(this.db, this._username);
                    f.pasarRol += new SelRol.delegar(GuardarRolAsignado); // Asignar evento guardarRolAsignado al tipo SelRol.delegar para obtener el valor del otro form
                    DialogResult res = f.ShowDialog(); // Comunicación entre formularios
                    if (res == DialogResult.OK) // Cuando vuelve del otro Form
                    {
                        GuardarRolAsignado(RolSeleccionado);
                    }
                }
                else
                {
                    Boolean existeR = this.db.Consultar("SELECT Rol_Id FROM [CAMPUS_ANALYTICA].[Usuario_Rol] WHERE Usuario_Id = " + dbUsuarioId);
                    if (existeR)
                    {
                        this.db.Leer();
                        GuardarRolAsignado(Decimal.Parse(this.db.ObtenerValor("Rol_Id")));
                    }
                }


                this.db.Ejecutar("INSERT [dbo].[Logins] ([User],[FechaHora],[LoginCorrecto],[NroLoginFallido]) VALUES (" + dbUsuarioId + ", GETDATE(), 'S', 0)");








            }




            MessageBox.Show(@"Fin acciones.");
        }


















        // Funciones

        public string Hash(string input)
        {
            SHA256 hash = SHA256.Create();

            // Convertir la cadena en un array de bytes y calcular hash
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Copiar cada elemento del array a un StringBuilder en formato hexadecimal
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            db.Desconectar();
            Environment.Exit(0);
        }

        void GuardarRolAsignado(Decimal rol) // Evento basado en SelRol.delegar para obtener el Rol seleccionado en el otro Form
        {
            RolSeleccionado = rol;
        }
    }
}
