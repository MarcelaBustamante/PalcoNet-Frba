using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
	
    
    public partial class AltaUsuario : Form
    {
		private String pass= "123"; 
		private dbmanager db;
        private Decimal cliId = 0;
        private Decimal empId = 0;
        private Decimal usrId;
        char Habilitado;
        public AltaUsuario(dbmanager db)
        {
            InitializeComponent();
            this.db = db;
            comboTipoUsuario(0);
			tbPassword.Text = pass;
        }

        //para alta desde modulo cliente o empresa
        public AltaUsuario(dbmanager db, int tipoCliente, decimal id)
        {
            InitializeComponent();
            this.db = db;
            comboTipoUsuario(tipoCliente - 1);
			if (tipoCliente == 3)
			{
				this.cliId = id;
			} else
			{
				this.empId = id;
			}
			tbPassword.Text = pass;
		}

        public AltaUsuario(dbmanager db, decimal usrId)
        {
            InitializeComponent();
            this.db = db;
            comboTipoUsuario(1);
            this.usrId = usrId;
			
			// busar el usuario a modificar
			Boolean existeR = this.db.Consultar("select u.Id,u.Username,u.Password,u.Estado,u.Tipos_usuario_Id from CAMPUS_ANALYTICA.Usuario u where u.Id = " + usrId);
            if (existeR)
            {
                this.db.Leer();
                tbUsername.Text = this.db.ObtenerValor("Username");
                tbPassword.Text = "********";
                cbTipoCliente.SelectedValue = Int16.Parse(this.db.ObtenerValor("Tipos_usuario_Id"));
                Habilitado = Char.Parse(this.db.ObtenerValor("Estado").ToString());
            }
            //tbUsername.Enabled = false;
            aceptar.Text = "Editar";
            if ( Habilitado== 'A')
            {
                cbhabilitado.Checked = true;
            }
            else
            {
                cbhabilitado.Checked = false;
            }
        }

        public void comboTipoUsuario(int index)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select id,Descripcion from CAMPUS_ANALYTICA.Tipos_usuario where id<>1", this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.Tipos_usuario");
            cbTipoCliente.DataSource = ds.Tables[0].DefaultView;
            this.cbTipoCliente.DisplayMember = "Descripcion";
            this.cbTipoCliente.ValueMember = "id";
            this.cbTipoCliente.SelectedIndex = index;
        }
        

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
           int respVal= validaciones();
           if (respVal == 0)
           {
               if (aceptar.Text == "Editar")
               {
                   this.editarUsuario();
                   DialogResult = DialogResult.OK;
               }
               else
               {
                   this.guardarUsuario();
                   DialogResult = DialogResult.OK;
               }
           }
        }

        int validaciones()
        {
            if (tbUsername.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Debe ingresar usuario y password");
                return 1;
            }
            Boolean existeUser = this.db.Consultar("select id,Username from CAMPUS_ANALYTICA.Usuario u where u.Username like '" + tbUsername.Text + "'");
            if (existeUser && aceptar.Text != "Editar")
            {
                MessageBox.Show("El Usuario ya se encuentra dado de alta");
                return 1;
            }
            else
            {
                return 0 ;
            }
        }

        void guardarUsuario()
        {
            String passHash = hash(tbPassword.Text);
            decimal tipoUsua= Decimal.Parse(cbTipoCliente.SelectedValue.ToString());
            //MessageBox.Show(passHash);//encripto la pass que deseo guardar
            //creo el usuario
            this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Usuario] ([Username]"+
							  ",[Password],[Estado],[Tipos_usuario_Id],[Cant_Login_Fallidos]) VALUES ( '" + tbUsername.Text+"','"+passHash+"','A',"+
                              tipoUsua + ",0)"); 
            Decimal idUser = obtenerIDUSR(); 
            //creo el rol del usuario
            this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Usuario_Rol] ([Rol_Id],[Usuario_Id],[Fecha_alta],[Fecha_baja])"+
                                "VALUES ("+tipoUsua+","+idUser+","+"SYSDATETIME(),null)");
            if (this.cliId != 0) {
                this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Cliente]  SET [Usuarios_Id] =" + idUser + " WHERE id =" + cliId);
            }
            if (this.empId != 0)
            {
                this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Empresa]   SET [Usuarios_Id] ="+ idUser + "WHERE Id = " + empId);
            }

            if (idUser != 0)
            {
                MessageBox.Show("Usuario creado.");
            }
        }


        void editarUsuario(){
            if(cbhabilitado.Checked==true){
                this.Habilitado = 'A';
            } else{
                this.Habilitado= 'B';
            }

			if (tbPassword.Text != "********")
			{
				String passHash = hash(tbPassword.Text);
				this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Usuario]   " +
				 "SET [Username] = '" + tbUsername.Text +
				 "' ,[Password] = '" + passHash +
				 "' ,[Estado] = '" + Habilitado +
				 "' ,[Tipos_usuario_Id] = " + cbTipoCliente.SelectedValue +
					" WHERE Id = " + usrId);
			}
			else
			{
				int resp = this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Usuario]   " +
				 "SET [Username] = '" + tbUsername.Text +
				 "' ,[Estado] = '" + Habilitado +
				 "' ,[Tipos_usuario_Id] = " + cbTipoCliente.SelectedValue +
					" WHERE Id = " + usrId);
				if (resp == 1)
				{
					MessageBox.Show("Usuario Modificado.");
				}
			}
        }

        private Decimal obtenerIDUSR() // Obtiene el ultimo ID de usuario
        {
            Decimal res = 0;
            Boolean existe = this.db.Consultar("SELECT TOP 1 Id FROM CAMPUS_ANALYTICA.Usuario u where u.Username like '" + tbUsername.Text + "' ORDER BY  u.Id DESC");
            if (existe)
            {
                this.db.Leer();
                res = Decimal.Parse(this.db.ObtenerValor("Id"));
            }
            return res;
        }

        public string hash(string input)
        {
            SHA256 hash = SHA256.Create();

            // Convertir la cadena en un array de bytes y calcular hash
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Copiar cada elemento del array a un StringBuilder en formato hexadecimal
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
