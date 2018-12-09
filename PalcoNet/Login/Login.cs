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
            }
            else
            {
                _username = tbUsername.Text;
                Boolean existeUsuario = this.db.Consultar("SELECT Username, Password, Usu_Cant_Login_Fallidos FROM BENDECIDOS.USUARIO WHERE Username = '" + _username + "' AND Usu_Cant_Login_Fallidos < 3 AND Usu_Activo = 'S'");
                if (!existeUsuario)
                {
                    MessageBox.Show("El usuario no existe en la base de datos.");
                    tbPassword.Text = "";
                    tbUsername.Text = "";
                    tbUsername.Focus();
                }








            }








        }




















        void GuardarRolAsignado(Decimal rol) // Evento basado en SelRol.delegar para obtener el Rol seleccionado en el otro Form
        {
            RolSeleccionado = rol;
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

        private void Cancelar_Click(object sender, EventArgs e)
        {
            db.Desconectar();
            Environment.Exit(0);
        }

    }
}
