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
            this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Cliente]   SET [Estado] = 'B' WHERE id=" + cliId);
            this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Usuario]   SET [Estado] = 'B'  WHERE id ="+
                                "(select Usuarios_Id from CAMPUS_ANALYTICA.Cliente where id="+cliId+")");
        }
    }
}
