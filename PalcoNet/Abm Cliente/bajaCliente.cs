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
        public bajaCliente(dbmanager db,decimal id)
        {
            InitializeComponent();
            this.db = db;
        }
    }
}
