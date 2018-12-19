using System;
using System.Configuration;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class pagarCompra : Form
    {
        private dbmanager db;
        private string username;
        private int ubiId;
        private generarCompra generarCompra;
        private int clientId;

        public pagarCompra(dbmanager db, string username, int ubiId, generarCompra generarCompra)
        {
            InitializeComponent();
            this.db = db;
            this.username = username;
            this.ubiId = ubiId;
            this.generarCompra = generarCompra;
        }

        private DateTime todayDateTime = DateTime.Now;
        private void GetTodayDate()
        {
            string date = ConfigurationManager.AppSettings["FechaSistema"];
            try
            {
                todayDateTime = DateTime.Parse(date);
            }
            catch (Exception e)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetTodayDate();

            if (username == "admin")
            {
                MessageBox.Show(@"No debe realizar compras con el usuario Administrador si no es para Testing!");
            }

            db.Consultar(
                "SELECT Cliente.Id FROM CAMPUS_ANALYTICA.Usuario LEFT JOIN CAMPUS_ANALYTICA.Cliente ON Usuario.Id = Cliente.Usuarios_Id WHERE Username = '" +
                username + "'");

            if (db.Leer())
            {
                if (db.ObtenerValor("Id") is DBNull || db.ObtenerValor("Id") == null)
                {
                    MessageBox.Show(@"El usuario no tiene un cliente asignado.");
                    this.Dispose();
                }
                else
                {
                    clientId = int.Parse(db.ObtenerValor("Id"));
                }

            }
            else
            {
                this.Dispose();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBoxTarjeta.Enabled = true;
                comboBox1.Enabled = true;
                textBox1.Enabled = true;
            }
            else
            {
                textBoxTarjeta.Enabled = false;
                comboBox1.Enabled = false;
                textBox1.Enabled = false;

            }
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            string nroTarjeta = textBoxTarjeta.Text;

            string query =
                "INSERT INTO [CAMPUS_ANALYTICA].[Compra]([Fecha],[Tajetas_Nro_tarjeta],[Cliente_Id],[Cantidad],[Ubicacion_Id])" +
                " VALUES ( '" + todayDateTime.Date.ToString() + " ' ";


            if (radioButton2.Checked)
            {
                query = query + " , " + textBoxTarjeta.Text + " ";
            }
            else
            {
                query = query + " , null ";
            }

            query = query +
                    " , " + clientId.ToString() +
                    " , 1 " +
                    " , " + ubiId.ToString() + ")";

            db.Ejecutar(query);


            query = "UPDATE CAMPUS_ANALYTICA.Ubicacion SET Comprada = 's' WHERE Id = " + ubiId.ToString();

            db.Ejecutar(query);


            // summo 10 ptos al cliente
            query = "UPDATE CAMPUS_ANALYTICA.Cliente SET Puntos = Puntos + 10, Fecha_venc_puntos = '" + todayDateTime.AddDays(30).Date.ToString() + "' WHERE ID = " + clientId.ToString();

            db.Ejecutar(query);

            generarCompra.SeComproUbicacion(ubiId);

            this.Dispose();
        }
    }
}
