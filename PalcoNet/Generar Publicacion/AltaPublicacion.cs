﻿using System;
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

        
        public AltaPublicacion(dbmanager dbmanager)
        {
            InitializeComponent();
            this.db = dbmanager;
            this.btAgregarLocalidades.Enabled = false;
            this.tbLocalidades.Text = "0";
            cargarCombos();
        }

        public AltaPublicacion(dbmanager dbmanager, decimal id)
        {
            InitializeComponent();
            this.idPublicacion = id;
            this.db = dbmanager;
            this.btAgregarLocalidades.Enabled = false;
            cargarCombos();
            inicializar();
        }

        private void inicializar()
        {
            Boolean existeR;
            existeR = this.db.Consultar("SELECT[Estado]," +
                "[Fecha_inicio]," +
                "[Fecha_Vencimiento]," +
                "[Localidades]," +
                "[Descripcion]," +
                "[Direccion]," +
                "[Grado]," +
                "[Rubros_Id] " +
                "FROM[GD2C2018].[CAMPUS_ANALYTICA].[Publicaciones]" +
                "JOIN [GD2C2018].[CAMPUS_ANALYTICA].[Grados_publicaciones] gp ON gp.[Id] = [Grados_Publicacion_Id] WHERE [Id] = " + idPublicacion);
            if (existeR)
            {
                this.db.Leer();
                this.tbDescripcion.Text = this.db.ObtenerValor("Descripcion");
                this.tbDirección.Text = this.db.ObtenerValor("Direccion");
                this.tbLocalidades.Text = this.db.ObtenerValor("Localidades");
                this.cbEstado.SelectedText = this.db.ObtenerValor("Estado");
                this.cbGradoPubli.SelectedText = this.db.ObtenerValor("Grado");
                this.cbRubro.SelectedItem = this.db.ObtenerValor("Rubros_Id");
                this.mcPublicacion.SelectionStart = new DateTime(long.Parse( this.db.ObtenerValor("Fecha_Vencimiento")));
                this.mcPublicacion.SelectionEnd = new DateTime(long.Parse(this.db.ObtenerValor("Fecha_Vencimiento")));
                this.btAgregarLocalidades.Enabled = true;
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
            int res = this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Publicaciones]" +
         "([Estado]" +
         ",[Fecha_inicio]" +
         ",[Fecha_Vencimiento]" +
         ",[Localidades]" +
         ",[Descripcion]" +
         ",[Direccion]" +
         ",[Grados_publicacion_Id]" +
         ",[Rubros_Id])" +
   "VALUES" +
         "( " + cbEstado.SelectedText + "," +
         "," + mcPublicacion.SelectionStart.ToString() + "," +
         ", " + mbEspectaculo.SelectionStart.ToString() + "," +
         ", " + tbLocalidades.Text + "," +
         ", " + tbDescripcion.Text + "," +
         ", " + tbDirección.Text + "," +
         ", " + cbGradoPubli.SelectedText + "," +
         ", " + cbRubro.SelectedItem + ")");
            if (res == 1)
            {
                Boolean r = this.db.Consultar("select top 1 Id from [CAMPUS_ANALYTICA].Ubicacion order by 1 desc");
                if (r)
                {
                    this.db.Leer();
                    this.idPublicacion = Decimal.Parse(this.db.ObtenerValor("Id"));
                    btAgregarLocalidades.Enabled = true;
                }
            }
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
            int res = this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Publicaciones] SET" +
      "[Estado] =" + cbEstado.SelectedText +
      ",[Fecha_inicio] =" + mcPublicacion.SelectionStart.ToString() +
      ",[Fecha_Vencimiento] =" + mbEspectaculo.SelectionStart.ToString() +
      ",[Localidades] =" + tbLocalidades.Text +
      ",[Descripcion] =" + tbDescripcion.Text +
      ",[Direccion] =" + tbDirección.Text +
      ",[Grados_publicacion_Id] =" + cbGradoPubli.SelectedText +
      ",[Rubros_Id] =" + cbRubro.SelectedItem + 
      "WHERE [Id] = " + idPublicacion);
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

        private void button2_Click(object sender, EventArgs e)
        {
            PalcoNet.Ubicaciones.Ubicaciones localidades = new Ubicaciones.Ubicaciones(this.db, this.idPublicacion);
            DialogResult res = localidades.ShowDialog();
            if (res.Equals(DialogResult.OK))
            {
                this.db.Consultar("SELECT COUNT(u.Id) FROM CAMPUS_ANALYTICA.Ubicacion u WHERE u.Publicaciones_Id = " + idPublicacion );
                this.db.Leer();
                this.tbLocalidades.Text = this.db.ObtenerValor("Cantidad");
            }
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
    }
}
