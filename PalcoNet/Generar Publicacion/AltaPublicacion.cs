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
        private decimal idPublicacion;
		private String Usr;
        
        public AltaPublicacion(dbmanager dbmanager,String usr)
        {
            InitializeComponent();
            this.db = dbmanager;
            this.tbLocalidades.Text = "0";
			this.Usr = usr;
            cargarCombos();
            this.mbEspectaculo.MaxSelectionCount = 1;
            this.mcPublicacion.MaxSelectionCount = 1;
        }

        public AltaPublicacion(dbmanager dbmanager, decimal id)
        {
            InitializeComponent();
            this.idPublicacion = id;
            this.db = dbmanager;
            cargarCombos();
            inicializar();
            this.mbEspectaculo.MaxSelectionCount = 1;
            this.mcPublicacion.MaxSelectionCount = 1;
        }

        private void inicializar()
        {
            Boolean existeR;
            string query = "SELECT[Estado]," +
                "[Fecha_inicio]," +
                "[Fecha_Vencimiento]," +
                "[Localidades]," +
                "[Descripcion]," +
                "[Direccion]," +
                "[Grado]," +
                "[Rubros_Id] " +
                "FROM [GD2C2018].[CAMPUS_ANALYTICA].[Publicaciones] p " +
                "JOIN [GD2C2018].[CAMPUS_ANALYTICA].[Grados_publicacion] gp ON gp.[Id] = [Grados_Publicacion_Id] WHERE p.[Id] = " + idPublicacion;
            existeR = this.db.Consultar(query);
            if (existeR)
            {
                this.db.Leer();
                this.tbDescripcion.Text = this.db.ObtenerValor("Descripcion");
                this.tbDirección.Text = this.db.ObtenerValor("Direccion");
                this.tbLocalidades.Text = this.db.ObtenerValor("Localidades");
                this.cbEstado.SelectedItem = this.db.ObtenerValor("Estado");
                this.cbGradoPubli.SelectedText = this.db.ObtenerValor("Grado");
                this.cbRubro.SelectedItem = this.db.ObtenerValor("Rubros_Id");
                this.mbEspectaculo.SelectionStart = DateTime.Parse(this.db.ObtenerValor("Fecha_Vencimiento"));
                this.mbEspectaculo.SelectionEnd =  DateTime.Parse(this.db.ObtenerValor("Fecha_Vencimiento"));
                this.mcPublicacion.SelectionStart = DateTime.Parse(this.db.ObtenerValor("Fecha_inicio"));
                this.mcPublicacion.SelectionEnd = DateTime.Parse(this.db.ObtenerValor("Fecha_inicio"));
                this.aceptar.Text = "Editar";
            }
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
            this.cbEstado.SelectedIndex = 0;
        }

        private void cargarComboResponsable()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Username FROM CAMPUS_ANALYTICA.Usuario where username like '"+this.Usr+"'", this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.Usuario");
            this.cbUserRespon.DataSource = ds.Tables[0].DefaultView;
            this.cbUserRespon.DisplayMember = "Username";
            this.cbUserRespon.ValueMember = "Id";
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
            this.cbRubro.DataSource = ds.Tables[0].DefaultView;
            this.cbRubro.DisplayMember = "Descripcion";
            this.cbRubro.ValueMember = "Id";
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (guardarPublicacion())
            {
                limpiarPantalla();
            }
            
        }

        private void limpiarPantalla()
        {
            this.tbDescripcion.Clear();
            this.tbDirección.Clear();
            this.tbLocalidades.Text = "0";
            this.tbLocalidades.Enabled = false;
            this.aceptar.Text = "Aceptar";
            this.cbEstado.SelectedIndex = 0;
            this.cbGradoPubli.SelectedIndex = 0;
            this.cbEstado.SelectedIndex = 0;
        }

        private void nuevaPublicacion()
        {
            string query = "INSERT INTO [CAMPUS_ANALYTICA].[Publicaciones]([Estado],[Fecha_inicio]," +
                "[Fecha_Vencimiento],[Localidades],[Descripcion]," +
                "[Direccion],[Empresa_Id],[Grados_publicacion_Id],[Rubros_Id]) " +
                "VALUES('"+ cbEstado.SelectedItem +"' ,'"+ mbEspectaculo.SelectionStart.ToString() +"'," +
                "'"+ mcPublicacion.SelectionStart.ToString() +"',"+ tbLocalidades.Text +",'"+ tbDescripcion.Text.ToString() +"'," +
                "'"+ tbDirección.Text.ToString() +"',"+obtenerEmpresaId()+","+ Decimal.Parse(cbGradoPubli.SelectedValue.ToString()) +","+ Decimal.Parse(cbRubro.SelectedValue.ToString()) +")";
            
            int res = this.db.Ejecutar(query);
            if (res == 1)
            {
                Boolean r = this.db.Consultar("select top 1 Id from [CAMPUS_ANALYTICA].Ubicacion order by 1 desc");
                if (r)
                {
                    this.db.Leer();
                    this.idPublicacion = Decimal.Parse(this.db.ObtenerValor("Id"));
                    
                }
            }
        }

        private string obtenerEmpresaId()
        {
            string q = "SELECT e.[Id] FROM [GD2C2018].[CAMPUS_ANALYTICA].[Empresa] e where e.[Usuarios_Id] =" + cbUserRespon.SelectedValue;
            Boolean r = this.db.Consultar(q);
            if (r)
            {
                this.db.Leer();
                return  this.db.ObtenerValor("Id").ToString();
            }
            return "";
        }

        private Boolean guardarPublicacion()
        {
            if (validarCampos())
            {
                if (aceptar.Text == "Aceptar")
                {
                    nuevaPublicacion();
                }
                else if (aceptar.Text == "Editar")
                {
                    editarPublicacion();
                }
            }
            return true;
        }

        private void editarPublicacion()
        {
            string query = "UPDATE [CAMPUS_ANALYTICA].[Publicaciones] SET [Estado] = '" + cbEstado.SelectedItem +"'"+
                ",[Fecha_inicio] = '" + mbEspectaculo.SelectionStart.ToString() +"'"+
                ",[Fecha_Vencimiento] ='" + mcPublicacion.SelectionStart.ToString() + "'" +
                ",[Localidades] =" + tbLocalidades.Text +
                ",[Descripcion] =" + tbDescripcion.Text +
                ",[Direccion] =" + tbDirección.Text +
                ",[Grados_publicacion_Id] =" + cbGradoPubli.SelectedText +
                ",[Rubros_Id] =" + cbRubro.SelectedItem +
                "WHERE [Id] = " + idPublicacion;
            int res = this.db.Ejecutar(query);
            if (res == 1)
            {
                Boolean r = this.db.Consultar("select top 1 Id from [CAMPUS_ANALYTICA].Ubicacion order by 1 desc");
                if (r)
                {
                    this.db.Leer();
                    this.idPublicacion = Decimal.Parse(this.db.ObtenerValor("Id"));
                }
            }
        }

        private bool validarCampos()
        {
            return true;
        }
 

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (guardarPublicacion())
            {
                this.aceptar.Text = "Aceptar";
            }
        }

		private void bnLocalidades_Click(object sender, EventArgs e)
		{
            Ubicaciones.Ubicaciones u = new Ubicaciones.Ubicaciones(db, idPublicacion);
            DialogResult res = u.ShowDialog();
            cargarCantLocalidades();
        }

        private void cargarCantLocalidades()
        {
            string query = "SELECT COUNT([Id]) as Cantidad FROM [CAMPUS_ANALYTICA].[Ubicacion] WHERE [Publicaciones_Id] =" + idPublicacion;
            Boolean resultado = this.db.Consultar(query);
            if (resultado)
            {
                this.db.Leer();
                this.tbLocalidades.Text = this.db.ObtenerValor("Cantidad");
            }
        }
    }
}
