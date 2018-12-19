using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class generarFactura : Form
    {
        private dbmanager db;
        private string username;
        private int empId;

        public generarFactura(dbmanager db, string username, int empId)
        {
            InitializeComponent();
            this.db = db;
            this.username = username;
            this.empId = empId;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void generarFactura_Load(object sender, EventArgs e)
        {
            cantFacturar.Minimum = 1;
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            this.grillaCompras.AllowUserToAddRows = false;

            DataTable dt = new DataTable();

            String query = "  SELECT C.Id, C.Fecha, U.Asiento, U.Fila, P.Descripcion, U.Precio, U.Precio/10"
                          + "  FROM CAMPUS_ANALYTICA.Compra C LEFT JOIN CAMPUS_ANALYTICA.Ubicacion U ON C.Ubicacion_Id = U.Id LEFT JOIN CAMPUS_ANALYTICA.Publicaciones P ON U.Publicaciones_Id = P.Id"
                          + "  WHERE C.Id NOT IN (SELECT Compras_Id FROM CAMPUS_ANALYTICA.Items_factura) AND P.Empresa_Id = " + empId.ToString()
                           + " ORDER BY C.Fecha"
                ;

            SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);

            grillaCompras.Rows.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaCompras.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString());
            }
        }


        private void btnGenerarFact_Click(object sender, EventArgs e)
        {

        }

        private void insertFactura(int cantidadItems)
        {
            DataTable dt = new DataTable();

            String query = "  SELECT TOP " + cantidadItems.ToString() + " C.Id, C.Fecha, U.Asiento, U.Fila, P.Descripcion, U.Precio, U.Precio/10"
                           + "  FROM CAMPUS_ANALYTICA.Compra C LEFT JOIN CAMPUS_ANALYTICA.Ubicacion U ON C.Ubicacion_Id = U.Id LEFT JOIN CAMPUS_ANALYTICA.Publicaciones P ON U.Publicaciones_Id = P.Id"
                           + "  WHERE C.Id NOT IN (SELECT Compras_Id FROM CAMPUS_ANALYTICA.Items_factura) AND P.Empresa_Id = " + empId.ToString()
                           + " ORDER BY C.Fecha"
                ;

            SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);

            int montoTotal = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                montoTotal = montoTotal + int.Parse(dt.Rows[i][5].ToString());
            }

            query = "INSERT INTO [CAMPUS_ANALYTICA].[Facturas] ([Fecha],[Empresa_Id],[Numero],[Total]) VALUES ('2018-01-01', " + empId.ToString() + ", 0, " + montoTotal.ToString() + ")";
            db.Ejecutar(query);
        }

    }
}
