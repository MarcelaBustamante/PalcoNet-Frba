using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PalcoNet.Login
{
    public partial class SelRol : Form
    {
        private dbmanager db;
        private String username;
        public delegate void delegar(Decimal rolAsignado); // Se crea el delegado para pasar valor al form llamador.

        public event delegar pasarRol; // Se define el evento que va a pasar valor al form llamador.

        public SelRol(dbmanager db, String username)
        {
            InitializeComponent();
            this.db = db;
            this.username = username;
            this.CargaRoles();
        }

        private void CargaRoles() // CARGA CHECKEDLISTBOX DE ROLES
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT r.Rol_Nombre FROM BENDECIDOS.USUARIO_ROL ur JOIN BENDECIDOS.ROL r ON ur.Rol_Id = r.Rol_Id WHERE ur.Username = '" + username + "'", this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.roles.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void roles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.roles.CheckedItems.Count > 1) // Valida que no se seleccione más de un item
            {
                MessageBox.Show("Debe seleccionarse sólo un rol.");
            }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            String rolNombre;
            foreach (var item in this.roles.CheckedItems)
            {
                rolNombre = item.ToString().Trim();
                Boolean existeU = this.db.Consultar("SELECT Rol_Id FROM BENDECIDOS.ROL WHERE Rol_Nombre = '" + rolNombre + "'");
                if (existeU)
                {
                    this.db.Leer();
                    Decimal rolId = Decimal.Parse(this.db.ObtenerValor("Rol_Id"));
                    this.pasarRol(rolId); // Envía Rol asignado al form llamador
                }

            }
        }
    }
}
