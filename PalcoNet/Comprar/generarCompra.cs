using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class generarCompra : Form
    {
        private dbmanager db;
        private string username;
        private int PgSize = 15;
        private int CurrentPageIndex = 1;
        private int CantidadPaginas = 10;
        private DateTime todayDateTime = DateTime.Now;

        public generarCompra(dbmanager db, String username)
        {
            InitializeComponent();
            this.db = db;
            this.username = username;
            this.CargaGrilla(1);
            this.CalcularCantidadPaginas();

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void generarCompra_Load(object sender, EventArgs e)
        {

        }

        private void CalcularCantidadPaginas()
        {
            String query = "  select count(*) as nro" +
            " FROM[GD2C2018].[CAMPUS_ANALYTICA].[Publicaciones]" +
            " where Fecha_inicio > GETDATE() and Fecha_Vencimiento<getdate()";

            db.Consultar(query);
            if (db.Leer())
            {
                CantidadPaginas = int.Parse(db.ObtenerValor("nro")) / PgSize;
                if (CantidadPaginas % PgSize > 0)
                    CantidadPaginas += 1;
                labelTotalPages.Text = CantidadPaginas.ToString();
            }
            else
            {
                return;
            }
        }

        public void CargaGrilla(int page)
        {
            this.grillaPublicaciones.AllowUserToAddRows = false;

            DataTable dt = new DataTable();

            String query = "SELECT TOP " + PgSize + " [Id] " +
                           " ,[Estado] " +
                           " ,[Fecha_inicio]" +
                           " ,[Fecha_Vencimiento]" +
                           " ,[Localidades]" +
                           " ,[Descripcion]" +
                           " ,[Direccion]" +
                           " ,[Empresa_Id]" +
                           " ,[Grados_publicacion_Id]" +
                           " ,[Rubros_Id]" +
                           " FROM[GD2C2018].[CAMPUS_ANALYTICA].[Publicaciones]" +
                           " where Fecha_inicio > GETDATE() and Fecha_Vencimiento < GETDATE()";

            if (page > 1)
            {
                query = query + "AND Id NOT IN " +
                        "(Select TOP " + (page - 1) * PgSize +
                        " Id from [CAMPUS_ANALYTICA].[Publicaciones] " +
                        " where Fecha_inicio > GETDATE() and Fecha_Vencimiento < GETDATE()"
                        + " ORDER BY Id) ";
            }


            SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);

            grillaPublicaciones.Rows.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaPublicaciones.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString());
            }

            labelCurrentPage.Text = page.ToString();
        }

        private void primero_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            this.CargaGrilla(CurrentPageIndex);
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                CurrentPageIndex = CurrentPageIndex - 1;
            }

            this.CargaGrilla(CurrentPageIndex);
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < CantidadPaginas)
            {
                CurrentPageIndex = CurrentPageIndex + 1;

            }

            this.CargaGrilla(CurrentPageIndex);
        }

        private void ultimo_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = CantidadPaginas;
            this.CargaGrilla(CurrentPageIndex);
        }

        private void grillaPublicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comprar_Click(object sender, EventArgs e)
        {

        }


        public void CargaGrillaUbicaciones(int pubId)
        {
            this.grillaUbicaciones.AllowUserToAddRows = false;

            DataTable dt = new DataTable();

            String query = "SELECT TOP " + PgSize + " [Id] " +
                           " ,[Estado] " +
                           " ,[Fecha_inicio]" +
                           " ,[Fecha_Vencimiento]" +
                           " ,[Localidades]" +
                           " ,[Descripcion]" +
                           " ,[Direccion]" +
                           " ,[Empresa_Id]" +
                           " ,[Grados_publicacion_Id]" +
                           " ,[Rubros_Id]" +
                           " FROM[GD2C2018].[CAMPUS_ANALYTICA].[Publicaciones]" +
                           " where Fecha_inicio > GETDATE() and Fecha_Vencimiento < GETDATE()";

            SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);

            grillaPublicaciones.Rows.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaPublicaciones.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString());
            }
            
        }

    }
}
