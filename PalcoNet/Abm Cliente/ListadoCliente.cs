using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PalcoNet.Abm_Cliente
{
    public partial class ListadoCliente : Form
    {
        private dbmanager db;
        decimal Cliente_Id = 0;
        public ListadoCliente(dbmanager db)
        {   
            InitializeComponent();
            this.db = db;
            cargaGrilla();
            CargaCombo();
        }
        public void CargaCombo()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, descripcion FROM CAMPUS_ANALYTICA.TIPO_DOCUMENTO", this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.TIPO_DOCUMENTO");
            this.cbTipoDoc.DataSource = ds.Tables[0].DefaultView;
            this.cbTipoDoc.DisplayMember = "descripcion";
            this.cbTipoDoc.ValueMember = "Id";
        }
        public void cargaGrilla()
        {
            this.grillaClientes.AllowUserToAddRows = false;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT c.id, [Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad,c.estado FROM [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id", this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
           grillaClientes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            grillaClientes.RowHeadersVisible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaClientes.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
                     , dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString()
                     , dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString()
                     , dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString(), dt.Rows[i][11].ToString(), dt.Rows[i][12].ToString(), dt.Rows[i][13].ToString());
            }
            grillaClientes.RowHeadersVisible = false;
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text != "" || tbApellido.Text != "" || tbDoc.Text != "" || tbEmail.Text !="")
            {
                DataTable dt = new DataTable();
				String query;
				if (tbDoc.Text != "")
				{
					 query = " SELECT  c.Id,[Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad" +
					 ",c.estado from [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id WHERE"+
					 " Nro_documento =" + tbDoc.Text ;
				}
				else
				{
					 query = " SELECT  c.Id,[Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad" +
                     "c.estado from [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id WHERE Nombre LIKE '%" + tbNombre.Text + "%' " +
					 " AND Apellido LIKE '%" + tbApellido.Text + "%' " +
					 "AND Mail LIKE '%" + tbEmail.Text + "%'";

				}
                
                SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(dt);
                this.limpiarTabla();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.grillaClientes.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
                        , dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString()
                        , dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString()
                        , dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString(), dt.Rows[i][11].ToString(), dt.Rows[i][12].ToString(), dt.Rows[i][13].ToString());
                }
            }
            else
            {
                MessageBox.Show("Complete un campo de busqueda");
            }
        }

      
        private void limpiar_Click(object sender, EventArgs e)
        {
            this.tbApellido.Clear();
            this.tbDoc.Clear();
            this.tbEmail.Clear();
            this.tbNombre.Clear();
            while (this.grillaClientes.RowCount > 0)
            {
                this.grillaClientes.Rows.Remove(this.grillaClientes.CurrentRow);    
            }
            this.cargaGrilla();
        }

        private void limpiarTabla()
        {
            if (this.grillaClientes.Rows.Count > 0)
            {
                this.grillaClientes.Rows.Clear();
            }
        }

        

        private void alta_Click(object sender, EventArgs e)
        {
            PalcoNet.Abm_Cliente.AltaCliente nuevoCliente = new AltaCliente(db);
            DialogResult res = nuevoCliente.ShowDialog();
			cargaGrilla();

		}

        private void editar_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaClientes.CurrentCell.RowIndex;
            this.Cliente_Id = Decimal.Parse(this.grillaClientes.Rows[fila].Cells[0].Value.ToString());
            PalcoNet.Abm_Cliente.AltaCliente clienteEditado = new AltaCliente(this.db, this.Cliente_Id);
            DialogResult res = clienteEditado.ShowDialog();
			cargaGrilla();
		}

        private void borrar_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaClientes.CurrentCell.RowIndex;
            Decimal clieID = Decimal.Parse(this.grillaClientes.Rows[fila].Cells[0].Value.ToString());
            PalcoNet.Abm_Cliente.bajaCliente clienteDadoDeBaja = new bajaCliente(this.db, clieID);
            DialogResult res = clienteDadoDeBaja.ShowDialog();
        }

        private void grillaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
      

}
