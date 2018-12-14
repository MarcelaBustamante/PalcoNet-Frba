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

namespace PalcoNet.Generar_Publicacion
{
    public partial class AltaPublicacion : Form
    {
        private dbmanager db;
        
        public AltaPublicacion(dbmanager dbmanager)
        {
            InitializeComponent();
            this.db = dbmanager;
            cargarCombos();
        }

        private void cargarCombos()
        {
            cargarComboRubro();
            cargarComboGrado();
            cargarComboResponsable();
            cargarComboEstado();
        }

        private void cargarComboEstado()
        {
            this.cbEstado.Items.AddRange(new object[] {"Borrador",
                        "Publicada",
                        "Finalizada"});
        }

        private void cargarComboResponsable()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Username FROM CAMPUS_ANALYTICA.Usuario", this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.Usuario");
            this.cbGradoPubli.DataSource = ds.Tables[0].DefaultView;
            this.cbGradoPubli.DisplayMember = "Username";
            this.cbGradoPubli.ValueMember = "Id";
        }

        private void cargarComboGrado()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Grado FROM CAMPUS_ANALYTICA.Grados_publicacion", this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.Grados_Publicacion");
            this.cbGradoPubli.DataSource = ds.Tables[0].DefaultView;
            this.cbGradoPubli.DisplayMember = "Grado";
            this.cbGradoPubli.ValueMember = "Id";
        }

        private void cargarComboRubro()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Descripcion FROM CAMPUS_ANALYTICA.Rubros", this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.Rubros");
            this.cbGradoPubli.DataSource = ds.Tables[0].DefaultView;
            this.cbGradoPubli.DisplayMember = "Descripcion";
            this.cbGradoPubli.ValueMember = "Id";
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if(tbDescripcion.Text != null){
                this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Publicaciones]" +
           "([Estado]" +
           ",[Fecha_inicio]" +
           ",[Fecha_Vencimiento]" +
           ",[Localidades]" +
           ",[Descripcion]" +
           ",[Direccion]" +
           ",[Grados_publicacion_Id]" +
           ",[Rubros_Id])" +
     "VALUES" +
           "(< " + cbEstado.SelectedText + ",>" +
           ",<" + mcPublicacion.SelectionStart.ToString() + ",>" +
           ",< " + mbEspectaculo.SelectionStart.ToString() + ",>" +
           ",< " + tbLocalidades.Text + ",>" +
           ",< " + tbDescripcion.Text + ",>" +
           ",< " + tbDirección.Text + ",>" +
           ",< " + cbGradoPubli.SelectedText + ",>" +
           ",< " + cbRubro.SelectedItem + ",>)");
            }
        }
    }
}
