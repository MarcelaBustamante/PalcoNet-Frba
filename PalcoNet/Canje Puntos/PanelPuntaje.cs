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

namespace PalcoNet.Canje_Puntos
{
    public partial class PanelPuntaje : Form
    {
		private dbmanager db;
		private string username;
		private int premioSeleccionado = 0;
		private int puntosSeleccionado = 0;
		private DateTime todayDateTime = DateTime.Now;
		private int ptos = 0;
		private string clieteId;

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

		public PanelPuntaje(dbmanager db, String username)
        {
			this.db = db;
			this.username = username;
            InitializeComponent();
        }

		private void PanelPuntaje_Load(object sender, EventArgs e)
		{
			ActualizarPuntos();
			CargarGrilla();
		}


		private void CargarGrilla()
		{

			this.gridPremios.AllowUserToAddRows = false;

			DataTable dt = new DataTable();

			String query = "SELECT [Id],[Descripcion],[Puntos_necesarios],[Condiciones],[Fecha_alta],[Fecha_baja] FROM [GD2C2018].[CAMPUS_ANALYTICA].[Premios] "
				+ "WHERE Fecha_baja is null OR Fecha_baja > '" + todayDateTime.Date.ToString() + "' "
				;

			SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
			da.SelectCommand.CommandType = CommandType.Text;
			da.Fill(dt);

			gridPremios.Rows.Clear();

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				this.gridPremios.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString());
			}
		}

		private void ActualizarPuntos()
		{
			string query = "SELECT Puntos, Cliente.Id as Id FROM CAMPUS_ANALYTICA.Cliente JOIN CAMPUS_ANALYTICA.Usuario ON Cliente.Usuarios_Id = Usuario.Id "
					+ " WHERE Usuario.Username = '" + username + "' ";

			db.Consultar(query);
			if (!db.Leer())
			{
				MessageBox.Show(@"Error.");
				return;
			}


			int ptos = int.Parse(db.ObtenerValor("Puntos"));

			boxPuntos.Text = ptos.ToString();
			this.ptos = ptos;
			clieteId = db.ObtenerValor("Id");
		}

		private void canjear_Click(object sender, EventArgs e)
		{
			if(premioSeleccionado == 0)
			{
				MessageBox.Show(@"Selecciones un premio haciendo doble click en el nombre.");
				return;
			}

			if (ptos < puntosSeleccionado)
			{
				MessageBox.Show(@"No tienes suficientes puntos.");
				return;

			}
			string query = "INSERT INTO [CAMPUS_ANALYTICA].[Canjes]([Fecha_canje],[Puntos_canjeados],[Cliente_Id],[Premios_Id]) "
				+ "VALUES ('" + todayDateTime.Date.ToString() + "', "
				+ puntosSeleccionado.ToString() + ", "
				+ clieteId + ", "
				+ premioSeleccionado.ToString() + ")"
				;

			db.Ejecutar(query);

			query = "UPDATE CAMPUS_ANALYTICA.Cliente SET Puntos = Puntos - " + puntosSeleccionado.ToString() + " WHERE Id = " + clieteId.ToString();

			db.Ejecutar(query);

			MessageBox.Show(@"Canje realizado con exito. Puede retirar el premio con su DNI.");

			ActualizarPuntos();
		}

		private void gridPremios_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			premioSeleccionado = int.Parse(gridPremios.Rows[e.RowIndex].Cells[0].Value.ToString());
			puntosSeleccionado = int.Parse(gridPremios.Rows[e.RowIndex].Cells[2].Value.ToString());
		}
	}
}
