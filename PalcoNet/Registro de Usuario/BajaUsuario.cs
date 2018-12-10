using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class BajaUsuario : Form
    {
        dbmanager db;
        Decimal usuarioId;
        public BajaUsuario(dbmanager db, Decimal userID)
        {
            InitializeComponent();
            this.db = db;
            this.usuarioId = userID;
            
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Usuario]   SET [Estado] = 'B' WHERE Id = " + this.usuarioId);
            MessageBox.Show("El usuario fué dado de baja");
            this.Dispose();
        }

        
    }
}
