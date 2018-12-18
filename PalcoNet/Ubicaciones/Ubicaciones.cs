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

namespace PalcoNet.Ubicaciones
{
    public partial class Ubicaciones : Form
    {
        private dbmanager db;
        private Decimal publicacionId = 0;

        public Ubicaciones(dbmanager dbMng, Decimal idPublicacion)
        {
            InitializeComponent();
            this.db = dbMng;
            this.publicacionId = idPublicacion;
            cargarComboTipoUbicacacion();
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            this.grillaUbicaciones.AllowUserToAddRows = false;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT  u.Tipo_descripcion, u.Fila, u.Precio, COUNT(u.Id) as Cantidad" +
                " FROM CAMPUS_ANALYTICA.Ubicacion u " +
                "WHERE u.Publicaciones_Id = " + publicacionId + " " +
                "Group by u.Fila, u.Tipo_descripcion, u.Precio", this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            grillaUbicaciones.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            grillaUbicaciones.RowHeadersVisible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaUbicaciones.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()
                     , dt.Rows[i][3].ToString());
            }
            grillaUbicaciones.RowHeadersVisible = false;
        }

        private void cargarComboTipoUbicacacion()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Tipo_Codigo, Tipo_Descripcion FROM CAMPUS_ANALYTICA.Ubicacion", this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.Ubicacion");
            this.cbTipoPublicacion.DataSource = ds.Tables[0].DefaultView;
            this.cbTipoPublicacion.DisplayMember = "Tipo_Descripcion";
            this.cbTipoPublicacion.ValueMember = "Tipo_Codigo";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                decimal cantAsientos = Decimal.Parse(tbCantidad.Text);
                string fila = tbFila.Text;
                double precio = Double.Parse(tbPrecio.Text);
                String tipoUbicacionDescripcion = cbTipoPublicacion.SelectedText;
                decimal tipoUbicacionCodigo = Decimal.Parse(cbTipoPublicacion.SelectedValue.ToString());
                if (btnAgregar.Text == "Agregar")
                {
                    for (int i = 1; i <= cantAsientos; i++)
                    {
                        this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Ubicacion]" +
                            "([Fila],[Asiento],[Precio],[Comprada],[Publicaciones_Id]," +
                            "[sin_numerar],[Tipo_Codigo],[Tipo_descripcion],[Compra_Id]) VALUES" +
                            "(" + fila + "," + i + "," + precio + "," + "'N'" + "" +
                            "," + publicacionId + "," + "'0'" + "," + tipoUbicacionCodigo + "," + tipoUbicacionDescripcion + ",null");
                    }
                } else if (btnAgregar.Text == "Aceptar")
                {
                    for (int i = 1; i <= cantAsientos; i++)
                    {
                        this.db.Ejecutar("UPDATE[CAMPUS_ANALYTICA].[Ubicacion] SET " +
                            "([Fila],[Asiento],[Precio],[Comprada],[Publicaciones_Id]," +
                            "[sin_numerar],[Tipo_Codigo],[Tipo_descripcion],[Compra_Id]) VALUES" +
                            "(" + fila + "," + i + "," + precio + "," + "'N'" + "" +
                            "," + publicacionId + "," + "'0'" + "," + tipoUbicacionCodigo + "," + tipoUbicacionDescripcion + ",null" +
                            "WHERE [Comprada] = 'N' ");
                    }
                }             
                
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            this.tbCantidad.Clear();
            this.tbFila.Clear();
            this.tbPrecio.Clear();
            this.cbTipoPublicacion.SelectedIndex = -1;
            btnAceptar.Text = "Agregar";
        }

        private bool validarCampos()
        {
            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaUbicaciones.CurrentCell.RowIndex;
            String tipoLocalidad = this.grillaUbicaciones.Rows[fila].Cells[0].Value.ToString();
            String filaLocalidad = this.grillaUbicaciones.Rows[fila].Cells[1].Value.ToString();
            String precioLocalidad = this.grillaUbicaciones.Rows[fila].Cells[2].Value.ToString();
            Boolean existeR;
            existeR = this.db.Consultar("SELECT Count([Id]) as Cantidad from [CAMPUS_ANALYTICA].[Ubicacion] WHERE [Publicaciones_Id]" + publicacionId + "" +
                "AND [Comprada] = 'N'");
            if (existeR)
            {
                this.db.Leer();
                 decimal cantidadLocalidadesABorrar = Decimal.Parse(this.db.ObtenerValor("Cantidad"));
                for(int i = 0; i < cantidadLocalidadesABorrar; i++)
                {
                    this.db.Ejecutar("DELETE FROM [CAMPUS_ANALYTICA].[Ubicacion] WHERE [Publicaciones_Id] =" + publicacionId + " " +
                        "AND [Comprada] = 'N'" +
                        " AND [Fila] = " + filaLocalidad + " " +
                        "AND [Precio] = " + precioLocalidad + "" +
                        "AND [Tipo_descripcion] =" + tipoLocalidad);
                }

            }
        }

        private void brnEditar_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaUbicaciones.CurrentCell.RowIndex;
            String tipoLocalidad = this.grillaUbicaciones.Rows[fila].Cells[0].Value.ToString();
            String filaLocalidad = this.grillaUbicaciones.Rows[fila].Cells[1].Value.ToString();
            String precioLocalidad = this.grillaUbicaciones.Rows[fila].Cells[2].Value.ToString();
            
            Boolean existeR;
            existeR = this.db.Consultar("SELECT TOP 1 [Fila] ,[Precio],[Tipo_Descripcion],COUNT([Id]) as Cantidad " +
                "FROM [GD2C2018].[CAMPUS_ANALYTICA].[Ubicacion]" +
                "WHERE [Publicaciones_Id] = " + publicacionId +" " +
                "AND [Fila] = " + filaLocalidad + "  " +
                "AND [Precio] = " + precioLocalidad + " " +
                "AND [Tipo_descripcion] = " + tipoLocalidad);
            if (existeR)
            {
                this.db.Leer();
                btnAgregar.Text = "Aceptar";
                this.tbCantidad.Text = this.db.ObtenerValor("Cantidad");
                this.tbFila.Text = this.db.ObtenerValor("Fila");
                this.tbPrecio.Text = this.db.ObtenerValor("Precio");
                this.cbTipoPublicacion.SelectedText = this.db.ObtenerValor("Tipo_Descripcion");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
