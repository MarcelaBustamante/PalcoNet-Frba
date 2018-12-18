using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class pagarCompra : Form
    {
        private dbmanager db;
        private string username;
        private DateTime todayDateTime = DateTime.Now;

        public pagarCompra(dbmanager db, String username)
        {
            InitializeComponent();
            this.db = db;
            this.username = username;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBoxTarjeta.Enabled = true;
                comboBox1.Enabled = true;
                textBox1.Enabled = true;
            }
            else
            {
                textBoxTarjeta.Enabled = false;
                comboBox1.Enabled = false;
                textBox1.Enabled = false;

            }
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            string nroTarjeta = textBoxTarjeta.Text;

            string query = "" +
                           "" +
                           "" +
                           "" +
                           "" ;
            
            if (radioButton2.Checked)
            {
                // Pago con tarjeta
            }
            else
            {
                // Pago efectivo
            }

            db.Ejecutar(query);

            // summo 10 ptos al cliente
            query = "";

            db.Ejecutar(query);
        }
    }
}
