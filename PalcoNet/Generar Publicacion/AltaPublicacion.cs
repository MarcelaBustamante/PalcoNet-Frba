using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private DateTime todayDateTime = DateTime.Now;
        string horaPublicacion;
        string fechaPublicacion;
        string fechaYHora;

        public AltaPublicacion(dbmanager dbmanager,String usr)
        {
            InitializeComponent();
            this.db = dbmanager;
            this.tbLocalidades.Text = "0";
			this.Usr = usr;
            cargarCombos();
            this.mbEspectaculo.MaxSelectionCount = 1;
            this.mbEspectaculo.SelectionStart = todayDateTime;
            this.pickerHora.CustomFormat = "hh:mm";
            this.pickerHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.pickerHora.ShowUpDown = true;
            this.mcPublicacion.MaxSelectionCount = 1;         
            
        }

        public AltaPublicacion(dbmanager dbmanager, decimal id, String usr)
        {
            InitializeComponent();
            this.idPublicacion = id;
            this.db = dbmanager;
            this.Usr = usr;
            cargarCombos();
            inicializar();
            this.mbEspectaculo.MaxSelectionCount = 1;
            this.mcPublicacion.MaxSelectionCount = 1;
            habilitarControlesLocalidades();
            cargarGrilla();
            cargarComboTipoUbicacacion();
            cargarCantLocalidades();
            this.pickerHora.CustomFormat = "hh:mm";
            this.pickerHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.pickerHora.ShowUpDown = true;
        }

        private void habilitarControlesLocalidades()
        {
            this.tbCantidad.Enabled = true;
            this.tbFila.Enabled = true;
            this.tbPrecio.Enabled = true;
            this.cbTipoPublicacion.Enabled = true;
            this.btnEditarLocalidad.Enabled = true;
            this.btnEliminar.Enabled = true;
            btnAgregar.Enabled = true;
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
                this.pickerHora.Value = DateTime.Parse(this.db.ObtenerValor("Fecha_vencimiento"));
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

        private void cargarGrilla()
        {
            this.grillaUbicaciones.AllowUserToAddRows = false;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT  u.Tipo_descripcion, u.Fila, u.Precio, COUNT(u.Id) as Cantidad" +
                " FROM CAMPUS_ANALYTICA.Ubicacion u " +
                "WHERE u.Publicaciones_Id = " + idPublicacion + " " +
                "Group by u.Fila, u.Tipo_descripcion, u.Precio", this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            grillaUbicaciones.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            grillaUbicaciones.RowHeadersVisible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaUbicaciones.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
                     , dt.Rows[i][3].ToString());
            }
            grillaUbicaciones.RowHeadersVisible = false;
        }

        private void cargarComboTipoUbicacacion()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Distinct Tipo_Codigo, Tipo_Descripcion FROM CAMPUS_ANALYTICA.Ubicacion" , this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.Ubicacion");
            this.cbTipoPublicacion.DataSource = ds.Tables[0].DefaultView;
            this.cbTipoPublicacion.DisplayMember = "Tipo_Descripcion";
            this.cbTipoPublicacion.ValueMember = "Tipo_Codigo";
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
            this.horaPublicacion = pickerHora.Value.ToShortTimeString();
            this.fechaPublicacion = mbEspectaculo.SelectionStart.ToShortDateString();
            this.fechaYHora = fechaPublicacion + " " +horaPublicacion;
            string query = "INSERT INTO [CAMPUS_ANALYTICA].[Publicaciones]([Estado],[Fecha_inicio]," +
                "[Fecha_Vencimiento],[Localidades],[Descripcion]," +
                "[Direccion],[Empresa_Id],[Grados_publicacion_Id],[Rubros_Id]) " +
                "VALUES('"+ cbEstado.SelectedItem +"' ,'"+ mcPublicacion.SelectionStart.ToString() +"'," +
                "'"+ fechaYHora +"',"+ tbLocalidades.Text +",'"+ tbDescripcion.Text.ToString() +"'," +
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
            MessageBox.Show("Publicacion Generada");
            DialogResult = DialogResult.OK;
            this.Dispose();
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
            this.horaPublicacion = pickerHora.Value.ToShortTimeString();
            this.fechaPublicacion = mbEspectaculo.SelectionStart.ToShortDateString();
            this.fechaYHora = fechaPublicacion + " " + horaPublicacion;
            string query = "UPDATE [CAMPUS_ANALYTICA].[Publicaciones] SET [Estado] = '" + cbEstado.SelectedItem +"'"+
                ",[Fecha_inicio] = '" + mcPublicacion.SelectionStart.ToString() +"'"+
                ",[Fecha_Vencimiento] ='" + fechaYHora + "'" +
                ",[Localidades] ='" + tbLocalidades.Text + "'"+
                ",[Descripcion] ='" + tbDescripcion.Text + "'" +
                ",[Direccion] ='" + tbDirección.Text + "'" +
                ",[Grados_publicacion_Id] =" + Decimal.Parse(cbGradoPubli.SelectedValue.ToString()) +
                ",[Rubros_Id] =" + Decimal.Parse(cbRubro.SelectedValue.ToString()) +
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
                MessageBox.Show("Publicacion Editada correctamente");
                DialogResult = DialogResult.OK;
            }
        }

        private bool validarCampos()
        {
            if (validarEspectaculosIguales())
            {
                return false;
            }
            if (validaEstado())
            {
                return false;
            }
            if (validarVacios())
            {
                return false;
            }
            if (validarFecha())
            {
                return false;
            }
            return true;
        }

        private bool validarFecha()
        {
            this.horaPublicacion = pickerHora.Value.ToShortTimeString();
            this.fechaPublicacion = mbEspectaculo.SelectionStart.ToShortDateString();
            this.fechaYHora = fechaPublicacion + " " + horaPublicacion;
            if (DateTime.Parse(fechaYHora) < todayDateTime)
            {
                MessageBox.Show("La fecha del Espectualo no puede ser menor a la fecha actual");
                return true;
            }
            if(mbEspectaculo.SelectionStart < todayDateTime && aceptar.Text == "Aceptar")
            {
                MessageBox.Show("La fecha de una nueva publicacion no puede ser menor a la fecha actual");
                return true;
            }
            return false;
        }

        private bool validarVacios()
        {
            if (tbDescripcion.Text == "")
            {
                MessageBox.Show("Complete campo descripcion");
                return true;
            }
            else if (tbDirección.Text == "")
            {
                MessageBox.Show("Complete campo direccion");
                return true;
            }
            else if (cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un estado");
                return true;
            }
            else if (cbGradoPubli.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un grado de publicacion");
                return true;
            }
            else if (cbRubro.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rubro");
                return true;
            }
            return false;

        }

        private bool validaEstado()
        {
            if(aceptar.Text == "Editar")
            {
                string query = "select [Estado] from [CAMPUS_ANALYTICA].[Publicaciones] WHERE [Id] =" + idPublicacion;
                Boolean r = this.db.Consultar(query);
                if (r)
                {
                    this.db.Leer();
                    if(cbEstado.SelectedText == "Borrador" && this.db.ObtenerValor("Estado") != "Borrador")
                    {
                        MessageBox.Show("No es posible cambiar a estado Borrador una publicacion Activa o Finalizada");
                        return true;
                    }
                    if(cbEstado.SelectedText != "Finalizada" && this.db.ObtenerValor("Estado") == "Finalizada")
                    {
                        MessageBox.Show("No es posible modificar una publicacion finalizada");
                        return true;
                    }
                }
            }
            return false;
        }

        private Boolean validarEspectaculosIguales()
        {
            string query = "select * from [CAMPUS_ANALYTICA].[Publicaciones] WHERE [Descripcion] ='" + tbDescripcion.Text+"'";
            Boolean r = this.db.Consultar(query);
            if (r)
            {
                this.db.Leer();
                if(this.db.ObtenerValor("Fecha_Vencimiento") == mcPublicacion.SelectionStart.ToString() && aceptar.Text != "Editar")
                {
                    MessageBox.Show("Seleccione otra fecha para el espectaculo, ya se encuentra un espectaculo publicado con esa fecha");
                    return true;
                }
                return false;
            }
            return false;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validarCamposLocalidad())
            {
                decimal cantAsientos = Decimal.Parse(tbCantidad.Text);
                string fila = tbFila.Text;
                double precio = Double.Parse(tbPrecio.Text);
                
                decimal tipoUbicacionCodigo = Decimal.Parse(cbTipoPublicacion.SelectedValue.ToString());
                string tipoUbicacionDescripcion = obtenerTipoDescripcion(tipoUbicacionCodigo);
                if (btnAgregar.Text == "Agregar")
                {
                    for (int i = 1; i <= cantAsientos; i++)
                    {
                        string query = "INSERT INTO [CAMPUS_ANALYTICA].[Ubicacion]" +
                            "([Fila],[Asiento],[Precio],[Comprada],[Publicaciones_Id]," +
                            "[sin_numerar],[Tipo_Codigo],[Tipo_descripcion]) VALUES" +
                            "('" + fila + "'," + i + "," + precio + "," + "'N'" + "" +
                            "," + idPublicacion + "," + "'0'" + "," + tipoUbicacionCodigo + ", '" + tipoUbicacionDescripcion + "')";
                        this.db.Ejecutar(query);
                    }
                }
                else if (btnAgregar.Text == "Aceptar")
                {
                    this.tbCantidad.Enabled = true;
                    for (int i = 1; i <= cantAsientos; i++)
                    {
                        string query = "UPDATE[CAMPUS_ANALYTICA].[Ubicacion] SET " +
                            "[Fila]=" + fila + "," +
                            "[Asiento]=" + i + "," +
                            "[Precio]=" + precio + "," +
                            "[Comprada]=" + "'N'" + "," +
                            "[Publicaciones_Id]=" + idPublicacion + "," +
                            "[sin_numerar]=" + "'0'" + "," +
                            "[Tipo_Codigo]=" + tipoUbicacionCodigo + ", '" +
                            "[Tipo_descripcion]=" + tipoUbicacionCodigo + "'" +
                            "WHERE [Comprada] = 'N' ";
                        this.db.Ejecutar(query);
                    }
                }

                limpiarCampos();
                this.grillaUbicaciones.Rows.Clear();
                cargarGrilla();
                cargarCantLocalidades();
            }
        }

        private string obtenerTipoDescripcion(decimal tipoUbicacionCodigo)
        {
            string query = "Select distinct u.Tipo_descripcion From CAMPUS_ANALYTICA.Ubicacion u where u.Tipo_Codigo =" + tipoUbicacionCodigo;
            Boolean r = this.db.Consultar(query);
            if (r)
            {
                this.db.Leer();
                return this.db.ObtenerValor("Tipo_descripcion");
            }
            return "Sin Definir";
     
        }

        private void limpiarCampos()
        {
            this.tbCantidad.Clear();
            this.tbFila.Clear();
            this.tbPrecio.Clear();
            this.cbTipoPublicacion.SelectedIndex = -1;
            btnAgregar.Text = "Agregar";
        }

        private bool validarCamposLocalidad()
        {
            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaUbicaciones.CurrentCell.RowIndex;
            String tipoLocalidad = this.grillaUbicaciones.Rows[fila].Cells[0].Value.ToString();
            String filaLocalidad = this.grillaUbicaciones.Rows[fila].Cells[1].Value.ToString();
            String precioLocalidad = this.grillaUbicaciones.Rows[fila].Cells[2].Value.ToString();
            Boolean existeR;
            existeR = this.db.Consultar("SELECT Count([Id]) as Cantidad from [CAMPUS_ANALYTICA].[Ubicacion] WHERE [Publicaciones_Id]" + idPublicacion + "" +
                "AND [Comprada] = 'N'");
            if (existeR)
            {
                this.db.Leer();
                decimal cantidadLocalidadesABorrar = Decimal.Parse(this.db.ObtenerValor("Cantidad"));
                for (int i = 0; i < cantidadLocalidadesABorrar; i++)
                {
                    this.db.Ejecutar("DELETE FROM [CAMPUS_ANALYTICA].[Ubicacion] WHERE [Publicaciones_Id] =" + idPublicacion + " " +
                        "AND [Comprada] = 'N'" +
                        " AND [Fila] = " + filaLocalidad + " " +
                        "AND [Precio] = " + precioLocalidad + "" +
                        "AND [Tipo_descripcion] =" + tipoLocalidad);
                }

            }
        }

        private void brnEditar_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaUbicaciones.CurrentCell.RowIndex;
            String tipoLocalidad = this.grillaUbicaciones.Rows[fila].Cells[0].Value.ToString();
            String filaLocalidad = this.grillaUbicaciones.Rows[fila].Cells[1].Value.ToString();
            String precioLocalidad = this.grillaUbicaciones.Rows[fila].Cells[2].Value.ToString();

            Boolean existeR;
            existeR = this.db.Consultar("SELECT TOP 1 [Fila] ,[Precio],[Tipo_Descripcion],COUNT([Id]) as Cantidad " +
                "FROM [GD2C2018].[CAMPUS_ANALYTICA].[Ubicacion]" +
                "WHERE [Publicaciones_Id] = " + idPublicacion + " " +
                "AND [Fila] = " + filaLocalidad + "  " +
                "AND [Precio] = " + precioLocalidad + " " +
                "AND [Tipo_descripcion] = " + tipoLocalidad);
            if (existeR)
            {
                this.db.Leer();
                btnAgregar.Text = "Editar";
                this.tbCantidad.Text = this.db.ObtenerValor("Cantidad");
                this.tbFila.Text = this.db.ObtenerValor("Fila");
                this.tbPrecio.Text = this.db.ObtenerValor("Precio");
                this.cbTipoPublicacion.SelectedText = this.db.ObtenerValor("Tipo_Descripcion");
                this.tbCantidad.Enabled = false;
            }
        }
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
    }
}
