using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class DarDeAltaRol : Form
    {
        public DarDeAltaRol(dbmanager db)
        {
            InitializeComponent();
        }
        public DarDeAltaRol(dbmanager db, Decimal rol_id, Char rolHabilitado)
        {
        }
    }
}
