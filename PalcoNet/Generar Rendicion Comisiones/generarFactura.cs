using System;
using System.Configuration;
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

        private DateTime todayDateTime = DateTime.Now;
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
                           + "  WHERE P.Empresa_Id = " + empId.ToString() + " AND (C.Facturada is null OR C.Facturada != 'S') "
                           + " ORDER BY C.Fecha, C.Id"
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
            btnGenerarFact.Text = @"Espere...";
            btnGenerarFact.Enabled = false;
            insertFactura((int)cantFacturar.Value);


            this.Dispose();
        }

        private void insertFactura(int cantidadItems)
        {
            DataTable dt = new DataTable();

            String query = "  SELECT TOP " + cantidadItems.ToString() + " C.Id, C.Fecha, U.Asiento, U.Fila, P.Descripcion, U.Precio, U.Precio/10"
                           + "  FROM CAMPUS_ANALYTICA.Compra C LEFT JOIN CAMPUS_ANALYTICA.Ubicacion U ON C.Ubicacion_Id = U.Id LEFT JOIN CAMPUS_ANALYTICA.Publicaciones P ON U.Publicaciones_Id = P.Id"
                           + "  WHERE P.Empresa_Id = " + empId.ToString() + " AND (C.Facturada is null OR C.Facturada != 'S') "
                           + " ORDER BY C.Fecha, C.Id"
                ;

            SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);

            int montoTotal = 0;
            double comisionTotal = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                montoTotal = montoTotal + int.Parse(dt.Rows[i][5].ToString());
                comisionTotal = comisionTotal + double.Parse(dt.Rows[i][5].ToString()) / 10;
            }

            query = "INSERT INTO [CAMPUS_ANALYTICA].[Facturas] ([Fecha],[Empresa_Id],[Numero],[Total],[TotalComision]) VALUES ('" + todayDateTime.Date.ToString() + "', " + empId.ToString() + ", 0, " + montoTotal.ToString() + ", "+ comisionTotal +")";
            db.Ejecutar(query);



            query = "SELECT Id FROM [GD2C2018].[CAMPUS_ANALYTICA].[Facturas] "
                    + "WHERE Empresa_Id = " + empId.ToString()
                    + " AND Total = " + montoTotal.ToString()
                    + " AND Numero = 0";

            db.Consultar(query);
            if (!db.Leer())
            {
                MessageBox.Show(@"Error al generar la factura.");
                return;
            }

            int factId = int.Parse(db.ObtenerValor("Id"));

            query = "UPDATE [GD2C2018].[CAMPUS_ANALYTICA].[Facturas] SET Numero = " + factId.ToString()
                                                                                    + " WHERE Empresa_Id = " + empId.ToString()
                                                                                    + " AND Total = " + montoTotal.ToString()
                                                                                    + " AND Numero = 0";

            db.Ejecutar(query);


            double itemMonto;
            string itemCompraId;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                itemMonto = double.Parse(dt.Rows[i][5].ToString());
                itemCompraId = dt.Rows[i][0].ToString();

                query = "INSERT INTO [CAMPUS_ANALYTICA].[Items_factura] ([Monto],[Cantidad],[Facturas_Id],[Compras_Id],[Descripcion],[Comision])"
                    + " VALUES (" + itemMonto.ToString() + ", 1, "+ factId.ToString() +", "+ itemCompraId +", 'Comision por compra.', "+ (itemMonto/10).ToString() +")";

                db.Ejecutar(query);

                query = "UPDATE CAMPUS_ANALYTICA.Compra SET Facturada = 'S' WHERE Id = " + itemCompraId;

                db.Ejecutar(query);

            }




            MessageBox.Show(@"Se generó la factura nro: " + factId.ToString() + @" por un total de: $" + montoTotal.ToString() + @" y una comisión de: $" + comisionTotal.ToString());
        }

    }
}
