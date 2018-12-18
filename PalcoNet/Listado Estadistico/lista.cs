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

namespace PalcoNet.Listado_Estadistico
{
    public partial class lista : Form
    {
		private dbmanager db;
		

		public lista(dbmanager db)
        {
			this.db = db;
			
			InitializeComponent();
			this.CargaCombos();
		}
		

		private void CargaCombos()
		{
			// COMBOBOX DE AÑO
			this.cbAno.Items.Add("2013");
			this.cbAno.Items.Add("2014");
			this.cbAno.Items.Add("2015");
			this.cbAno.Items.Add("2016");
			this.cbAno.Items.Add("2017");
			this.cbAno.Items.Add("2018");
			this.cbAno.Items.Add("2019");
			this.cbAno.Items.Add("2020");
			this.cbAno.SelectedIndex = 0;

			// COMBOBOX DE TRIMESTRE
			this.cbTrimestre.Items.Add("Enero-Febrero-Marzo");
			this.cbTrimestre.Items.Add("Abril-Mayo-Junio");
			this.cbTrimestre.Items.Add("Julio-Agosto-Septiembre");
			this.cbTrimestre.Items.Add("Octubre-Noviembre-Diciembre");
			this.cbTrimestre.SelectedIndex = 0;
			// COMBOBOX DE GRADO PUBLICACION
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter("SELECT [Id],[Grado]  FROM[CAMPUS_ANALYTICA].[Grados_publicacion]", this.db.StringConexion());
			da.Fill(ds, "CAMPUS_ANALYTICA.TIPO_DOCUMENTO");
			this.cbGrado.DataSource = ds.Tables[0].DefaultView;
			this.cbGrado.DisplayMember = "Grado";
			this.cbGrado.ValueMember = "Id";
		}
		private void CargaTabla() //CARGA LA GRILLA
		{
			Int32 anio = Int32.Parse(cbAno.Text);
			// OBTIENE EL RANGO DE MESES DEL TRIMESTRE ELEGIDO
			Int32 iniTri = 0;
			Int32 finTri = 0;

			if (cbTrimestre.Text == "Enero-Febrero-Marzo")
			{
				iniTri = 1;
				finTri = 3;
			}
			if (cbTrimestre.Text == "Abril-Mayo-Junio")
			{
				iniTri = 4;
				finTri = 6;
			}
			if (cbTrimestre.Text == "Julio-Agosto-Septiembre")
			{
				iniTri = 7;
				finTri = 9;
			}
			if (cbTrimestre.Text == "Octubre-Noviembre-Diciembre")
			{
				iniTri = 10;
				finTri = 12;
			}

			String grado = cbGrado.Text;
			DataTable dt = new DataTable();

			this.grillaConsulta.Columns.Clear(); // BORRA TODAS LAS COLUMNAS

			if (rbCantCompras.Checked == false && rbNovendidas.Checked == false && rbPuntosVencidos.Checked == false )
			{
				MessageBox.Show("No selecciono ningun listado para ver");
			}
			else
			{
				if (rbNovendidas.Checked == true) // empresa con localidades no vendidas
				{
					String query = "select e.Razon_social,p2.Id,p2.Descripcion, p2.Fecha_inicio fecha " +
							" from CAMPUS_ANALYTICA.Empresa e join CAMPUS_ANALYTICA.Publicaciones p2 " +
							" on p2.Empresa_Id = e.Id	where p2.Id in (select top 5 p.Id" +
							 " from  CAMPUS_ANALYTICA.Publicaciones p	join CAMPUS_ANALYTICA. Ubicacion u on u.Publicaciones_Id = p.Id" +
							" join CAMPUS_ANALYTICA.Grados_publicacion gp on gp.Id = p.Grados_publicacion_Id"+
							  " where u.Comprada like 'N'  group by p.Id,gp.Grado,p.Fecha_inicio  having gp.Grado like '%"+ grado +"%'"+
							  " and year(p.Fecha_inicio) = '"+anio +"'"+
							  " and month(p.Fecha_inicio)  between '"+iniTri +"' and '"+ finTri+"'"+
							  " order by count(distinct u.Id) desc)"+
							 " order by fecha,(select gp2.id from CAMPUS_ANALYTICA.Grados_publicacion gp2 where gp2.Id = p2.Grados_publicacion_Id)";

					SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
					da.SelectCommand.CommandType = CommandType.Text;
					da.Fill(dt);
					this.grillaConsulta.Columns.Add("colRazon_social", "Empresa");
					this.grillaConsulta.Columns.Add("colId", "Codigo publicación");
					this.grillaConsulta.Columns.Add("colDescripcion", "Evento");
					this.grillaConsulta.Columns.Add("colFecha_inicio", "Fecha de inicio");
					this.grillaConsulta.Columns[0].Width = 150;
					this.grillaConsulta.Columns[1].Width = 150;
					this.grillaConsulta.Columns[2].Width = 150;
					this.grillaConsulta.Columns[3].Width = 150;

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						this.grillaConsulta.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString());
					}
				}

				if (rbPuntosVencidos.Checked == true) //clientes con mayores puntos vencidos
				{
					String query = "select top 5 c.Id,c.Nombre,c.Apellido,c.Puntos,c.Fecha_venc_puntos	from CAMPUS_ANALYTICA.Cliente c"+
									" where c.Fecha_venc_puntos <= getdate()	and YEAR(c.Fecha_venc_puntos) = '"+ anio+"'"+
									"and MONTH(c.Fecha_venc_puntos) between '"+ iniTri+"' and '"+ finTri+"' order by Puntos desc";

					SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
					da.SelectCommand.CommandType = CommandType.Text;
					da.Fill(dt);

					this.grillaConsulta.Columns.Add("colId", "Código de cliente");
					this.grillaConsulta.Columns.Add("colNombre", "Nombre");
					this.grillaConsulta.Columns.Add("colApellido", "Apellido");
					this.grillaConsulta.Columns.Add("colPuntos", "Puntos");
					this.grillaConsulta.Columns.Add("colFecha_venc_puntos", "Fecha vencimiento puntos");
					
					this.grillaConsulta.Columns[0].Width = 100;
					this.grillaConsulta.Columns[1].Width = 100;
					this.grillaConsulta.Columns[2].Width = 100;
					this.grillaConsulta.Columns[3].Width = 100;
					this.grillaConsulta.Columns[4].Width = 100;

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						this.grillaConsulta.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString());
					}
				}

				if (rbCantCompras.Checked == true) // cliente con mayor cantidad decompras
				{
					String query = "select top 5 c.Id,c.Nombre, c.Apellido,count(distinct comp.Id) cantCompras,p.Empresa_Id" +
									" from CAMPUS_ANALYTICA.Cliente c	join CAMPUS_ANALYTICA.Compra comp" +
									" on comp.Cliente_Id = c.Id		join CAMPUS_ANALYTICA.Ubicacion u" +
									" on u.Id = comp.Ubicacion_id 	join CAMPUS_ANALYTICA.Publicaciones p" +
									" on p.Id = u.Publicaciones_Id  group by c.id,c.Nombre,c.Apellido,p.Empresa_Id ,p.Fecha_inicio" +
									" having  year(p.Fecha_inicio) = '" + anio + "'" +
									" and month(p.Fecha_inicio)  between '" + iniTri + "' and '" + finTri + "' order by cantCompras desc";

					SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
					da.SelectCommand.CommandType = CommandType.Text;
					da.Fill(dt);

					this.grillaConsulta.Columns.Add("colId", "Codigo cliente");
					this.grillaConsulta.Columns.Add("colNombre", "Nombre");
					this.grillaConsulta.Columns.Add("colApellido", "Apellido");
					this.grillaConsulta.Columns.Add("colCantCompr", "Cantidad de compras");
					this.grillaConsulta.Columns.Add("colempresaId", "Codigo empresa");
					this.grillaConsulta.Columns[0].Width = 50;
					this.grillaConsulta.Columns[1].Width = 200;
					this.grillaConsulta.Columns[2].Width = 200;
					this.grillaConsulta.Columns[3].Width = 200;
					this.grillaConsulta.Columns[4].Width = 200;

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						this.grillaConsulta.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString());
					}
				}

			}

		}

		private void consultar_Click(object sender, EventArgs e)
		{
			CargaTabla();
		}
	}
}
