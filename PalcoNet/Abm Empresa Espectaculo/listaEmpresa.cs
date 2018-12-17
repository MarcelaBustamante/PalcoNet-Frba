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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
	public partial class listaEmpresa : Form
	{
		private dbmanager db;
		private Decimal Empresa_Id;
		public listaEmpresa(dbmanager db)
		{
			InitializeComponent();
			this.db = db;
			cargaGrilla();
		}

		public void cargaGrilla()
		{
			this.grillaEmpresa.AllowUserToAddRows = false;
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter("SELECT e.[Id],[Razon_social],[Mail], isnull([Telefono], 0) as telefono,[CUIT],[Estado], e.[Fecha_alta],d.Calle" +
													",d.Codigo_postal,d.Piso,d.Depoto  FROM[GD2C2018].[CAMPUS_ANALYTICA].[Empresa] e join CAMPUS_ANALYTICA.EmpresaDireccion" +
														" on Empresa_id= e.Id join CAMPUS_ANALYTICA.Direccion d	on Direccion_id = d.Id", this.db.StringConexion());
			da.SelectCommand.CommandType = CommandType.Text;
			da.Fill(dt);
			grillaEmpresa.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
			grillaEmpresa.RowHeadersVisible = false;
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				this.grillaEmpresa.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
					 , dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString()
					 , dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString()
					 , dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString());
			}
			grillaEmpresa.RowHeadersVisible = false;
		}


		private void buscar_Click_1(object sender, EventArgs e)
		{
			if (tbCuit.Text != "" || tbMail.Text != "" || tbRazonSocial.Text != "")
			{
				DataTable dt = new DataTable();

				SqlDataAdapter da = new SqlDataAdapter("SELECT e.[Id],[Razon_social],[Mail], isnull([Telefono], 0) as telefono,[CUIT],[Estado], e.[Fecha_alta],d.Calle" +
														", d.Codigo_postal, d.Piso, d.Depoto  FROM[GD2C2018].[CAMPUS_ANALYTICA].[Empresa] e join CAMPUS_ANALYTICA.EmpresaDireccion" +
													" on Empresa_id = e.Id join CAMPUS_ANALYTICA.Direccion d   on Direccion_id = d.Id" +
														" where e.Razon_social like '%" + tbRazonSocial.Text + "%'" +
														" and e.CUIT like '%" + tbCuit.Text + "%'" +
														" and e.Mail like '%" + tbMail.Text + "%'", this.db.StringConexion());
				da.SelectCommand.CommandType = CommandType.Text;
				da.Fill(dt);
				this.limpiarTabla();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					this.grillaEmpresa.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
						, dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString()
						, dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString()
						, dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString());
				}
			}
			else
			{
				MessageBox.Show("Complete un campo de busqueda");
			}
			
		}	

		private void limpiar_Click(object sender, EventArgs e)
		{
			tbCuit.Clear();
			tbMail.Clear();
			tbRazonSocial.Clear();
			while (this.grillaEmpresa.RowCount > 0)
			{
				this.grillaEmpresa.Rows.Remove(this.grillaEmpresa.CurrentRow);
			}
			this.cargaGrilla();
		}

		private void alta_Click(object sender, EventArgs e)
		{
			AltaEmpresa nuevaEmpresa = new AltaEmpresa(db);
			DialogResult res = nuevaEmpresa.ShowDialog();
			cargaGrilla();
		}

		private void modificar_Click(object sender, EventArgs e)
		{
			Int32 fila = this.grillaEmpresa.CurrentCell.RowIndex;
			this.Empresa_Id = Decimal.Parse(this.grillaEmpresa.Rows[fila].Cells[0].Value.ToString());
			PalcoNet.Abm_Empresa_Espectaculo.AltaEmpresa empresaEditada = new AltaEmpresa(this.db, this.Empresa_Id);
			DialogResult res = empresaEditada.ShowDialog();
			cargaGrilla();
		}

		private void eliminar_Click(object sender, EventArgs e)
		{
			Int32 fila = this.grillaEmpresa.CurrentCell.RowIndex;
			Decimal empId = Decimal.Parse(this.grillaEmpresa.Rows[fila].Cells[0].Value.ToString());
			PalcoNet.Abm_Empresa_Espectaculo.BajaEmpresa empresaDadaBaja = new BajaEmpresa(this.db, empId);
			DialogResult res = empresaDadaBaja.ShowDialog();
		}

		private void limpiarTabla()
		{
			if (this.grillaEmpresa.Rows.Count > 0)
			{
				this.grillaEmpresa.Rows.Clear();
			}
		}
	}
}

