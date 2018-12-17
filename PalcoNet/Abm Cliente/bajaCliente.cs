using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class bajaCliente : Form
    {
        private dbmanager db = new dbmanager();
        private Decimal cliId ;
        public bajaCliente(dbmanager db,Decimal id)
        {
            InitializeComponent();
            this.db = db;
            this.cliId = id;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            int resCli= this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Cliente]   SET [Estado] = 'B' WHERE id=" + cliId);
            int resUsr= this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Usuario]   SET [Estado] = 'B'  WHERE id ="+
                                "(select Usuarios_Id from CAMPUS_ANALYTICA.Cliente where id="+cliId+")");
			if(resCli==1 && resUsr == 1) { MessageBox.Show("El usuario se dió de baja correctamente."); }
			else
			{
				MessageBox.Show("Ocurrió un problema con la baja del ciente.");
			}
			DialogResult = DialogResult.OK;
		}

		private void cancelar_Click(object sender, EventArgs e)
		{
			Dispose();
		}
	}
}
