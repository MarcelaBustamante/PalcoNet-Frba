using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class Form1 : Form
    {
        private dbmanager db;

        public Form1(dbmanager dbMng)
        {
            this.db = dbMng;
            InitializeComponent();
            CargaCombo();
            this.tbComisionGradoPublicacion.Text = CargarComision(Decimal.Parse(this.cbGradoPublicaccion.SelectedValue.ToString()));
        }

        public String CargarComision(object idGrado)
        {
            string query = "SELECT [Comision] FROM [CAMPUS_ANALYTICA].[Grados_Publicacion] WHERE [Id] = " + idGrado.ToString();

            Boolean existeT = this.db.Consultar(query);
            if (existeT)
            {
                this.db.Leer();
            }
            else
            {
                MessageBox.Show("Error al encontrar el grado de la publicacion.");
                return "0";
            }
            return this.db.ObtenerValor("Comision");
        }

        public void CargaCombo()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Grado FROM CAMPUS_ANALYTICA.Grados_publicacion", this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.PAIS");
            this.cbGradoPublicaccion.DataSource = ds.Tables[0].DefaultView;
            this.cbGradoPublicaccion.DisplayMember = "Grado";
            this.cbGradoPublicaccion.ValueMember = "Id";
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if(tbComisionGradoPublicacion.Text != null)
            {
                string query = "update  CAMPUS_ANALYTICA.Grados_Publicacion SET (Id, Grado, Comision) values ('" +
                    this.cbGradoPublicaccion.ValueMember+ "', '" + this.cbGradoPublicaccion.Text + "', '" + this.tbComisionGradoPublicacion.Text + "')";
                db.Ejecutar(query);
            }
            else
            {
                MessageBox.Show("Se debe ingresar un valor mayor igual a 0 para la comisión");
            }
        }
    }
}
