using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Abm_Grado;
using PalcoNet.Abm_Rol;
using PalcoNet.Canje_Puntos;
using PalcoNet.Comprar;
using PalcoNet.Editar_Publicacion;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Generar_Rendicion_Comisiones;
using PalcoNet.Listado_Estadistico;
using PalcoNet.Registro_de_Usuario;
using System;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class MenuPrincipal : Form
    {
        private dbmanager _db;
        private String _username;
        private Decimal _rolId;

        public MenuPrincipal(dbmanager db, String username)
        {
            InitializeComponent();
            this._db = db;
            this._username = username;
        }

        public void Ingreso(String username, Decimal rolId)
        {
            this._rolId = rolId;
            //RecorrerItemsMenu(barraMenu.Items, Username, RolId); // Oculta las opciones del menu a las cuales el usuario no tiene acceso
        }

        public void CierraMenu(Object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void RecorrerItemsMenu(ToolStripItemCollection barraMenu, String username, Decimal rol)
        {
            foreach (ToolStripItem item in barraMenu)
            {

                Boolean existe = false;
                String funcionalidad = item.Text;
                String consulta = "SELECT F.Funcionalidad_Id FROM BENDECIDOS.USUARIO_ROL UR " +
                                  "JOIN BENDECIDOS.ROL_FUNCIONALIDAD RF ON RF.Rol_Id = UR.Rol_Id " +
                                  "JOIN BENDECIDOS.FUNCIONALIDAD F ON F.Funcionalidad_Id = RF.Funcionalidad_Id " +
                                  "WHERE UR.Username = '" + username + "' AND F.Funcionalidad_Nombre = '" + funcionalidad + "'" +
                                  "AND UR.Rol_Id = '" + rol + "'";
                existe = this._db.Consultar(consulta);

                if (existe) //Oculta si el usuario no tiene acceso a esa función
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }

                if ((item.Text == "Funcionalidades") || (item.Text == "Maestros") || (item.Text == "Listado estadistico" && rol != 2))
                {
                    item.Visible = true;
                }

                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem item2 = (ToolStripMenuItem)item;
                    RecorrerItemsMenu(item2.DropDown.Items, username, rol);
                }
            }
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaRol f = new ListaRol(_db, _username);
            f.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaUsuario f = new ListaUsuario(_db);
            f.Show();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListadoCliente f = new ListadoCliente(_db);
            f.Show();
        }

        private void empresaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listaEmpresa f = new listaEmpresa(_db);
            f.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Rubro.Form1 f = new Abm_Rubro.Form1();
            f.Show();
        }

        private void publicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(_db);
            f.Show();
        }

        private void historialDelClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Historial_Cliente.Form1 f = new Historial_Cliente.Form1();
            f.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generarFactura f = new generarFactura();
            f.Show();
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista f = new lista();
            f.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generarCompra f = new generarCompra();
            f.Show();
        }

        private void canjeDePuntosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PanelPuntaje f = new PanelPuntaje();
            f.Show();
        }

        private void publicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaPublicacion f = new AltaPublicacion();
            f.Show();
        }

        private void comisionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Publicaciones f = new Publicaciones();
            f.Show();
        }
    }
}
