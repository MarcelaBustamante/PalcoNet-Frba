using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class BajaEmpresa : Form
    {
		private dbmanager db;
		private Decimal Empresa_Id;
        public BajaEmpresa(dbmanager db,Decimal empr_id)
        {
            InitializeComponent();
			this.db = db;
			this.Empresa_Id = empr_id;
        }

		private void acepar_Click(object sender, EventArgs e)
		{
			int resEmp = this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[empresa]   SET [Estado] = 'B' WHERE id=" + this.Empresa_Id);
			int resUsr = this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Usuario]   SET [Estado] = 'B'  WHERE id =" +
								"(select Usuarios_Id from CAMPUS_ANALYTICA.empresa where id=" + this.Empresa_Id + ")");
			if (resEmp == 1 && resUsr == 1) { MessageBox.Show("El usuario se dió de baja correctamente."); }
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
