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

namespace PalcoNet.Historial_Cliente
{
    public partial class HistrorialCliente : Form
    {
        private dbmanager db;
        decimal Cliente_Id = 0;
        int filasPorPagina = 10;
        int numeroPagina = 1;
        int inicioPaginado = 0;
        int finPaginado = 0;
        int numeroRegistro;
        DataTable dt = new DataTable();

        public HistrorialCliente(dbmanager dbMng, decimal idCliente)
        {
            InitializeComponent();
            this.db = dbMng;
            this.Cliente_Id = idCliente;
            cargaGrilla();
        }

        private void cargaGrilla()
        {
            this.grillaHistorial.AllowUserToAddRows = false;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select p.Descripcion," +
                " c.Id," +
                " u.Precio," +
                " c.Fecha, " +
                "CASE c.Tajetas_Nro_tarjeta " +
                "WHEN null THEN 'EFECTIVO' " +
                "ELSE (SELECT CONCAT (t.Tipo,t.Banco) FROM CAMPUS_ANALYTICA.Tajetas t where t.Nro_tarjeta = c.Tajetas_Nro_tarjeta) " +
                "END as 'Medio de Pago'  " +
                " from CAMPUS_ANALYTICA.Compra c " +
                "join CAMPUS_ANALYTICA.Ubicacion u " +
                "on u.Id = c.Ubicacion_Id " +
                "join CAMPUS_ANALYTICA.Publicaciones p " +
                "on p.Id = u.Publicaciones_Id " +
                "where c.Cliente_Id =" + Cliente_Id, this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            grillaHistorial.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            grillaHistorial.RowHeadersVisible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaHistorial.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), 
                    dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString());
            }
            grillaHistorial.RowHeadersVisible = false;
        }

        private void paginar()
        {
            if (dt.Rows.Count > filasPorPagina)
            {
                this.inicioPaginado = numeroPagina * filasPorPagina - filasPorPagina;
                this.finPaginado = numeroPagina * filasPorPagina;
                if (finPaginado > dt.Rows.Count)
                    finPaginado = dt.Rows.Count;
            }
            else
            {
                this.inicioPaginado = 0;
                this.finPaginado = dt.Rows.Count;
            }

            grillaHistorial.Rows.Clear();
            int indiceInsertar;//
            numeroRegistro = this.inicioPaginado;
            for (int i = inicioPaginado; i < finPaginado; i++)
            {
                numeroRegistro = numeroRegistro + 1;
                indiceInsertar = grillaHistorial.Rows.Count - 1;
                this.grillaHistorial.Rows.Add(dt.Rows[indiceInsertar][0].ToString(), dt.Rows[indiceInsertar][1].ToString(),
                    dt.Rows[indiceInsertar][2].ToString(), dt.Rows[indiceInsertar][3].ToString(), dt.Rows[indiceInsertar][4].ToString());

            }

        }

        private int numPaginas()
        {
            if (dt.Rows.Count % filasPorPagina == 0)
                return (dt.Rows.Count / filasPorPagina);
            else
            {
                int valor = (dt.Rows.Count / filasPorPagina)+1;
                return valor;

            }
        }

        private void principio_Click(object sender, EventArgs e)
        {
            this.numeroPagina = 1;
            this.paginar();
        }

        private void fin_Click(object sender, EventArgs e)
        {
            this.numeroPagina = numPaginas();
            this.paginar();
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            if(numeroPagina > 1)
            {
                this.numeroPagina -= 1;
                this.paginar();
            }
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            if(numeroPagina < numPaginas())
            {
                this.numeroPagina++;
                this.paginar();
            }
        }
    }
}
