﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class ListaRol : Form
    {
        private dbmanager db;
        private string username;
        public ListaRol(dbmanager db, String username)
        {
            InitializeComponent();
            this.db = db;
            this.username = username;
            this.cargaGrilla();

        }

        public void cargaGrilla()
        {
            this.grillaRoles.AllowUserToAddRows = false;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT [Id],[Nombre],[Estado]  FROM [GD2C2018].[CAMPUS_ANALYTICA].[Rol]", this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaRoles.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString());
            }
        }

        private void CargaTablaFiltrada(String filtroNombre, Char filtroSoloHabilitados)
        {
            DataTable dt = new DataTable();
            if (filtroSoloHabilitados == 'A')
            {
                String query;
                if (filtroNombre == "") {
                    query = "SELECT Id, Nombre, Estado FROM CAMPUS_ANALYTICA.ROL WHERE Estado = '" + filtroSoloHabilitados.ToString() + "'";
                }
                else{ 
                  query = "SELECT Id, Nombre, Estado FROM CAMPUS_ANALYTICA.ROL WHERE Nombre LIKE '%" + filtroNombre + "%' AND Estado = '" + filtroSoloHabilitados.ToString() + "'";
                }
                SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(dt);
            }
            else
            {
                String query = "SELECT Id, Nombre, Estado FROM CAMPUS_ANALYTICA.ROL WHERE Nombre LIKE '%" + filtroNombre + "%'";
                SqlDataAdapter da = new SqlDataAdapter(query, this.db.StringConexion());
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(dt);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.grillaRoles.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString());
            }

        }

        private void buscar_Click_1(object sender, EventArgs e)
        
        {
            
            String filtroNombre = tbRol.Text;
            Char filtroSoloHabilitados;

            if (habilitados.Checked == true)
            {
                filtroSoloHabilitados = 'A';
            }
            else
            {
                filtroSoloHabilitados = 'B';
            }

            while (this.grillaRoles.RowCount > 0) // ELIMINA LAS FILAS EXISTENTES EN LA GRILLA
            {
                this.grillaRoles.Rows.Remove(this.grillaRoles.CurrentRow);
            }

            if (filtroNombre != "" || filtroSoloHabilitados == 'A')
            {
                this.CargaTablaFiltrada(filtroNombre, filtroSoloHabilitados);
            }
            else
            {
                this.cargaGrilla();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            this.tbRol.Text = "";
            this.habilitados.Checked = false;
            this.buscar_Click_1(sender, e);
        }

        private void alta_Click(object sender, EventArgs e)
        {
            PalcoNet.Abm_Rol.DarDeAltaRol nuevoRol = new DarDeAltaRol(this.db);
            DialogResult res = nuevoRol.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.buscar_Click_1(sender, e);
            }
        }

        private void editar_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaRoles.CurrentCell.RowIndex;
            Decimal rol_id = Decimal.Parse(this.grillaRoles.Rows[fila].Cells[0].Value.ToString());
            Char rol_estado = Char.Parse(this.grillaRoles.Rows[fila].Cells[2].Value.ToString());
            PalcoNet.Abm_Rol.DarDeAltaRol f = new DarDeAltaRol(this.db, rol_id, rol_estado);
            Console.Out.WriteLine(rol_estado);
            DialogResult res = f.ShowDialog(); // Comunicación entre formularios
           
                this.buscar_Click_1(sender, e); // Actualiza la grilla
            
        }
 
        private void borrar_Click(object sender, EventArgs e)
        {
            Int32 fila = this.grillaRoles.CurrentCell.RowIndex;
            Decimal rol_id = Decimal.Parse(this.grillaRoles.Rows[fila].Cells[0].Value.ToString());
			MessageBox.Show("Recuerde que al dar de baja el rol se dara de baja para los usuarios también.");
			this.db.Ejecutar("UPDATE CAMPUS_ANALYTICA.ROL SET Estado = 'B' WHERE Id = " + rol_id);
            this.db.Ejecutar("delete CAMPUS_ANALYTICA.Usuario_Rol where Rol_Id = " + rol_id);
            MessageBox.Show("Rol eliminad.");
            this.buscar_Click_1(sender, e); // Actualiza la grilla
        }

    }
}
