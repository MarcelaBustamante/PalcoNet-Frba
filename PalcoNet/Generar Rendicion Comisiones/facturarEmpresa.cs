using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class facturarEmpresa : Form
    {
        private dbmanager db;
        private string username;
        private int grillaSelectedRow = 0;

        public facturarEmpresa(dbmanager db, String username)
        {
            InitializeComponent();
            this.db = db;
            this.username = username;
        }

        private void facturarEmpresa_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {

            this.grillaEmpresas.AllowUserToAddRows = false;

            DataTable dt = new DataTable();

            String query = "SELECT Id, Razon_social FROM CAMPUS_ANALYTICA.Empresa";

            SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);

            grillaEmpresas.Rows.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaEmpresas.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
            }
        }

        private void continuar_Click(object sender, EventArgs e)
        {
            continuar.Text = @"Espere...";
            int empId = int.Parse(grillaEmpresas.Rows[grillaSelectedRow].Cells[0].Value.ToString());
            continuar.Enabled = false;
            generarFactura generarFactura = new generarFactura(db, username, empId);
            generarFactura.Show();
        }

        private void grillaEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grillaSelectedRow = e.RowIndex;
        }
    }
}
