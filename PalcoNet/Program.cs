using PalcoNet.Generar_Rendicion_Comisiones;
using System;
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
            Application.Run(new Generar_Publicacion.AltaPublicacion(db,"userEmpresa"));
           // Application.Run(new Login.Login(db));
            //Application.Run(new generarCompra(db, "admin"));
        }
    }
}
