using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dbmanager db = new dbmanager();//se coneta la base
            Application.Run(new Registro_de_Usuario.ListaUsuario(db));//Application.Run(new Login.Login(db));new Abm_Cliente.ListadoCliente(db);
        }
    }
}
