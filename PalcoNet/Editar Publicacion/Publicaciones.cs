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

namespace PalcoNet.Editar_Publicacion
{
    public partial class Publicaciones : Form
    {
        private dbmanager db;
		private String usr;
        decimal idPublicacion = 0;
        public Publicaciones(dbmanager dbMng, String usr)
        {
            InitializeComponent();
            this.db = dbMng;
			this.usr = usr;
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            this.grillaPublicaciones.AllowUserToAddRows = false;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT p.[Id], p.[Descripcion],p.[Fecha_inicio]," +
                "[Fecha_Vencimiento], r.descripcion , r.[Direccion], p.[Estado] " +
                "FROM [GD2C2018].[CAMPUS_ANALYTICA].[Publicaciones] p join CAMPUS_ANALYTICA.Rubros r on r.id=p.Rubros_Id" +
                " join CAMPUS_ANALYTICA.Grados_publicaciones gd on gd.[Grado]=p.[Grados_publicacion_Id]", this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            grillaPublicaciones.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            grillaPublicaciones.RowHeadersVisible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaPublicaciones.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
                     , dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString()
                     , dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString());
            }
            grillaPublicaciones.RowHeadersVisible = false;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if(tbCodigo.Text != "" || tbDescripcion.Text !="")
            {
                DataTable dt = new DataTable();
                String query;
                if(tbCodigo.Text != "")
                {
                    query = "SELECT p.[Id], p.[Descripcion],p.[Fecha_inicio]," +
                "[Fecha_Vencimiento], r.descripcion , r.[Direccion], p.[Estado] " +
                "FROM [GD2C2018].[CAMPUS_ANALYTICA].[Publicaciones] p join CAMPUS_ANALYTICA.Rubros r on r.id=p.Rubros_Id" +
                " join CAMPUS_ANALYTICA.Grados_publicaciones gd on gd.[Grado]=p.[Grados_publicacion_Id] WHERE p.[Id] = " + tbCodigo.Text.ToString();
                }
                else
                {
                    query = "SELECT p.[Id], p.[Descripcion],p.[Fecha_inicio]," +
                "[Fecha_Vencimiento], r.descripcion , r.[Direccion], p.[Estado] " +
                "FROM [GD2C2018].[CAMPUS_ANALYTICA].[Publicaciones] p join CAMPUS_ANALYTICA.Rubros r on r.id=p.Rubros_Id" +
                " join CAMPUS_ANALYTICA.Grados_publicaciones gd on gd.[Grado]=p.[Grados_publicacion_Id] WHERE p.[Descripcion] = " + tbDescripcion.Text.ToString();
                }
                SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(dt);
                this.limpiarTabla();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.grillaPublicaciones.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
                        , dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString()
                        , dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString());
                }
            }
            else
            {
                MessageBox.Show("Complete un campo de busqueda");
            }
        }

        private void limpiarTabla()
        {
            if (this.grillaPublicaciones.Rows.Count > 0)
            {
                this.grillaPublicaciones.Rows.Clear();
            }
        }

        private void borrar_Click(object sender, EventArgs e)
        {
            this.tbCodigo.Clear();
            this.tbDescripcion.Clear();
        }

        private void alta_Click(object sender, EventArgs e)
        {
            PalcoNet.Generar_Publicacion.AltaPublicacion nuevaPublicacion = new Generar_Publicacion.AltaPublicacion(this.db,usr);
            DialogResult res = nuevaPublicacion.ShowDialog();
            this.cargarGrilla();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaPublicaciones.CurrentCell.RowIndex;
            this.idPublicacion = Decimal.Parse(this.grillaPublicaciones.Rows[fila].Cells[0].Value.ToString());
            PalcoNet.Generar_Publicacion.AltaPublicacion publciacionEditada = new Generar_Publicacion.AltaPublicacion(this.db, this.idPublicacion);
            DialogResult res = publciacionEditada.ShowDialog();
            this.cargarGrilla();
        }
    }
}

