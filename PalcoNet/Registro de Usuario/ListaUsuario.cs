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

namespace PalcoNet.Registro_de_Usuario
{
    public partial class ListaUsuario : Form
    {
        dbmanager db;
       
        public ListaUsuario(dbmanager db)
        {
            InitializeComponent();
            this.db = db;
            cargaGrillaUsuario();
        }

        void cargaGrillaUsuario(){
			
			this.grillaUsuarios.AllowUserToAddRows = false;
			limpiarTabla();
			DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT u.[Id],[Username],[Estado], tu.Descripcion "+
                                                    " FROM [CAMPUS_ANALYTICA].[Usuario] u join"+
                                                    " CAMPUS_ANALYTICA.Tipos_usuario tu on tu.Id=u.Tipos_usuario_Id" +
		                                            " where tu.Id <> 1", this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            grillaUsuarios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            grillaUsuarios.RowHeadersVisible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaUsuarios.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
                     , dt.Rows[i][3].ToString());
            }
            grillaUsuarios.RowHeadersVisible = false;
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (tbUsuario.Text!="")
            {
                DataTable dt = new DataTable();
                String query = "SELECT u.[Id],[Username],[Estado], tu.Descripcion " +
                                                    " FROM [CAMPUS_ANALYTICA].[Usuario] u join" +
                                                    " CAMPUS_ANALYTICA.Tipos_usuario tu on tu.Id=u.Tipos_usuario_Id" +
                                                    " where tu.Id <> 1" +
                                                    " and u.username like '" + tbUsuario.Text + "%'";

                SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(dt);
                this.limpiarTabla();
                for (int i = 0; i < dt.Rows.Count; i++)
                {   
                        this.grillaUsuarios.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
                             , dt.Rows[i][3].ToString());   
                }
            }
            else
            {
                MessageBox.Show("Complete un campo de busqueda");
            }
        }
        private void limpiarTabla()
        {
            if (this.grillaUsuarios.Rows.Count > 0)
            {
                this.grillaUsuarios.Rows.Clear();
            }

            
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            if (this.grillaUsuarios.Rows.Count > 0)
            {
                this.grillaUsuarios.Rows.Clear();
            }
            cargaGrillaUsuario();
        }

        private void alta_Click(object sender, EventArgs e)
        {
            PalcoNet.Registro_de_Usuario.AltaUsuario nuevoUsuario = new AltaUsuario(db);
            DialogResult res = nuevoUsuario.ShowDialog();
			
			cargaGrillaUsuario();

		}

        private void modificacion_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaUsuarios.CurrentCell.RowIndex;
            Decimal usrId = Decimal.Parse(this.grillaUsuarios.Rows[fila].Cells[0].Value.ToString());
            PalcoNet.Registro_de_Usuario.AltaUsuario nuevoUsuario = new AltaUsuario(db, usrId);
            DialogResult res = nuevoUsuario.ShowDialog();
			cargaGrillaUsuario();

		}

        private void baja_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaUsuarios.CurrentCell.RowIndex;
            Decimal userID = Decimal.Parse(this.grillaUsuarios.Rows[fila].Cells[0].Value.ToString());
            PalcoNet.Registro_de_Usuario.BajaUsuario usuarioDeBaja = new BajaUsuario(this.db, userID);
            DialogResult res = usuarioDeBaja.ShowDialog();
        }

      
    }
}
