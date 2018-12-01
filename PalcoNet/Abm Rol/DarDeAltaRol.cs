using System;
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
    public partial class DarDeAltaRol : Form
    {
        private dbmanager db;
        public DarDeAltaRol(dbmanager db)
        {
            InitializeComponent();
            this.db = db;
            this.cargaGrillaFuncionalidades();
        }
        public DarDeAltaRol(dbmanager db, Decimal rol_id, Char rolHabilitado)//modificación
        {
            InitializeComponent();
            this.db = db;
            this.cargaGrillaFuncionalidades();
            //para mostrar que funcionalidades tiene actualmente , se busca y se marca
            for (int j = 0; j < this.funcionalidades.Items.Count; j++)
            {
                Boolean existe = false;

                String funcionalidadNombre = this.funcionalidades.Items[j].ToString();
                existe = this.db.Consultar("SELECT f.Id FROM CAMPUS_ANALYTICA.ROL_FUNCIONALIDAD rf JOIN CAMPUS_ANALYTICA.FUNCIONALIDAD f ON rf.Funcionalidad_Id = f.Id WHERE rf.Rol_Id = " + rol_id + " AND f.Nombre = '" + funcionalidadNombre.Trim() + "'");
                if (existe)
                {
                    this.funcionalidades.SetItemChecked(j, true);
                }
                else
                {
                    this.funcionalidades.SetItemChecked(j, false);
                }
            }
            // TILDA LAS FUNCIONALIDADES QUE TIENE EL ROL ACTUALMENTE
            Boolean existeR = this.db.Consultar("SELECT Nombre FROM CAMPUS_ANALYTICA.ROL WHERE Id = " + rol_id);
            if (existeR)
            {
                this.db.Leer();
                nombre.Text = this.db.ObtenerValor("Nombre");
            }
            nombre.Enabled = false;
            aceptar.Text = "Editar";
            if (rolHabilitado == 'A')
            {
                active.Checked = true;
            }
            else
            {
                active.Checked = false;
            }

        }

        public void cargaGrillaFuncionalidades()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Id,Nombre from [CAMPUS_ANALYTICA].[FUNCIONALIDAD]", this.db.StringConexion());
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.funcionalidades.Items.Add(dt.Rows[i][1].ToString());
            }
        }
        
        private void aceptar_Click(object sender, EventArgs e)
        {
            if (nombre.Text == "")
            {
                MessageBox.Show("Ingrese un nombre para el ROL");
            }
            else
            {
                if (this.funcionalidades.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos una funcionalidad.");
                }
                else
                {
                    if (aceptar.Text == "Editar")
                    {
                        this.editarRol(nombre.Text);
                        MessageBox.Show("Rol actualizado correctamente.");
                    }
                    else
                    {
                        this.guardarRol();
                       
                    }
                    this.Dispose();
                }
            }
        }
        private void guardarRol()
        {
            String Rol_Nombre = nombre.Text.Trim();
            Char Rol_Habilitado;
            if (active.Checked == true)
            {
                Rol_Habilitado = 'A';
            }
            else
            {
                Rol_Habilitado = 'B';
            }

            Decimal Rol_Id = 0;
            Boolean existeT = this.db.Consultar("SELECT Id FROM CAMPUS_ANALYTICA.ROL WHERE Nombre = '" + Rol_Nombre + "'");
            if (existeT) {
                MessageBox.Show("El rol que desea crear ya existe actualmente, puede intentar con la opcion modificar");
                return;
            }
            else {
                try
                {
                    this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Rol] ([Nombre],[Estado]) VALUES('" + Rol_Nombre + "','" + Rol_Habilitado + "')");
                    MessageBox.Show("Rol guardado.");
                }
                catch (SqlException e)
                {
                    MessageBox.Show("No se pudo agregar el usuario");
                }
           
             existeT = this.db.Consultar("SELECT Id FROM CAMPUS_ANALYTICA.ROL WHERE Nombre = '" + Rol_Nombre + "'");
            if (existeT)
            {
                this.db.Leer();
                Rol_Id = Decimal.Parse(this.db.ObtenerValor("Id"));
                MessageBox.Show("Rol creado");
            }
            else
            {
                MessageBox.Show("No se pudo crear rol nuevo.");
                return;
            }

            foreach (var item in this.funcionalidades.CheckedItems)
            {
                String Funcionalidad_Nombre = item.ToString();
                Boolean existe = this.db.Consultar("SELECT Id FROM CAMPUS_ANALYTICA.FUNCIONALIDAD WHERE Nombre = '" + Funcionalidad_Nombre + "'");

                if (existe)
                {
                    try
                    {
                        this.db.Leer();
                        Decimal Funcionalidad_Id = Decimal.Parse(this.db.ObtenerValor("Id"));
                        this.db.Ejecutar("INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (" + Funcionalidad_Id + ", " + Rol_Id + ", " + "GETDATE())");
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("Este rol ya tiene dicha funcionalidad");
                    }
               }
            }
          } 
        }

        private void editarRol(String RolNombre)
        {
            String Rol_Nombre = nombre.Text.Trim();
            Char Rol_Habilitado;
            if (active.Checked == true)
            {
                Rol_Habilitado = 'A';
            }
            else
            {
                Rol_Habilitado = 'B';
            }

            Decimal Rol_Id = 0;
            Boolean existeT = this.db.Consultar("SELECT Id FROM CAMPUS_ANALYTICA.ROL WHERE Nombre = '" + Rol_Nombre + "'");
            if (existeT)
            {
                this.db.Leer();
                Rol_Id = Decimal.Parse(this.db.ObtenerValor("Id"));
            }


            this.db.Ejecutar("UPDATE CAMPUS_ANALYTICA.ROL SET Estado = '" + Rol_Habilitado + "' WHERE Id = " + Rol_Id);
            this.db.Ejecutar("DELETE CAMPUS_ANALYTICA.ROL_FUNCIONALIDAD WHERE Rol_Id = " + Rol_Id);

            foreach (var item in this.funcionalidades.CheckedItems)
            {
                String Funcionalidad_Nombre = item.ToString().Trim();
                Boolean existe = this.db.Consultar("SELECT Id FROM CAMPUS_ANALYTICA.FUNCIONALIDAD WHERE Nombre = '" + Funcionalidad_Nombre + "'");
                if (existe)
                {
                    this.db.Leer();
                    int Funcionalidad_Codigo = Int32.Parse(this.db.ObtenerValor("Id"));
               
                    try
                    {
                     
                        this.db.Ejecutar("INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (" + Funcionalidad_Codigo + ", " + Rol_Id + ", " + "GETDATE())");
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("Este rol ya tiene dicha funcionalidad");
                    }
                }

            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
