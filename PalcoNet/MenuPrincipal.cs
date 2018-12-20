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
            RecorrerItemsMenu(menuStrip1.Items, _username, _rolId); // Oculta las opciones del menu a las cuales el usuario no tiene acceso
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
                String consulta = "SELECT F.Id " +
                                  "FROM CAMPUS_ANALYTICA.Usuario U " +
                                  "LEFT JOIN CAMPUS_ANALYTICA.Usuario_Rol UR ON U.Id = UR.Usuario_Id " +
                                  "LEFT JOIN CAMPUS_ANALYTICA.Rol_Funcionalidad RF ON UR.Rol_Id = RF.Rol_id " +
                                  "LEFT JOIN CAMPUS_ANALYTICA.Funcionalidad F ON RF.Funcionalidad_id = F.Id " +
                                  "WHERE U.Username = '" + username + "' AND F.Nombre = '" + funcionalidad + "' ";

                String consulta2 = "SELECT F.Funcionalidad_Id FROM BENDECIDOS.USUARIO_ROL UR " +
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

                if ((item.Text == "Administracion") || (item.Text == "Cliente") || (item.Text == "Empresa"))
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

      

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            facturarEmpresa f = new facturarEmpresa(_db, _username);
            f.Show();
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista f = new lista(_db);
            f.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generarCompra f = new generarCompra(_db, _username);
            f.Show();
        }

        private void canjeDePuntosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PanelPuntaje f = new PanelPuntaje();
            f.Show();
        }

        private void publicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AltaPublicacion f = new AltaPublicacion(_db,_username);
            f.Show();
        }

        private void comisionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Publicaciones f = new Publicaciones(_db,_username);
            f.Show();
        }

		private void historialDelClienteToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			Historial_Cliente.HistrorialCliente f = new Historial_Cliente.HistrorialCliente(_db, _username);
			f.Show();
		}
	}
}
