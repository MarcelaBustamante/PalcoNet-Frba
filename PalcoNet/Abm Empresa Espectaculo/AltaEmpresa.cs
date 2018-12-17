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
    public partial class AltaEmpresa : Form
    {
		private dbmanager db;
		private Decimal Empresa_Id; 
        public AltaEmpresa(dbmanager db)
        {
            InitializeComponent();
			this.db = db;
        }

		public AltaEmpresa(dbmanager db,Decimal emp_id)
		{
			InitializeComponent();
			this.db = db;
			this.Empresa_Id = emp_id;
			Boolean existeR;
			//buscar la empresa a modificar 
			existeR = this.db.Consultar("SELECT e.[Id],[Razon_social],[Mail], isnull([Telefono], 0) as telefono,[CUIT],[Estado], e.[Fecha_alta],d.Calle,d.Codigo_postal,d.Piso,d.Depoto,d.Localidad  FROM[GD2C2018].[CAMPUS_ANALYTICA].[Empresa] e join CAMPUS_ANALYTICA.EmpresaDireccion" +
										"  on Empresa_id = e.Id join CAMPUS_ANALYTICA.Direccion d  on Direccion_id = d.Id where e.Id =" + emp_id);
			if (existeR)
			{
				this.db.Leer();
				tbRazonSocial.Text = this.db.ObtenerValor("Razon_social");
				tbMail.Text = this.db.ObtenerValor("Mail");
				tbTelefono.Text = this.db.ObtenerValor("telefono");
				tbCuit.Text = this.db.ObtenerValor("CUIT");
				tbCalle.Text = this.db.ObtenerValor("Calle");
				tbnroPiso.Text = this.db.ObtenerValor("Piso");
				tbLocalidad.Text = this.db.ObtenerValor("Localidad");
				tbcodPostal.Text = this.db.ObtenerValor("Codigo_postal");
				char cliHabilitado = Char.Parse(this.db.ObtenerValor("Estado"));

				if (cliHabilitado == 'A')
				{
					cbHabilitado.Checked = true;
				}
				else
				{
					cbHabilitado.Checked = false;
				}
			}
				aceptar.Text = "Editar";
			}

		private void aceptar_Click(object sender, EventArgs e)
		{

			//valida campos vacios, formato de fecha y formato cuil
			int valForm = validarForm();

			if (valForm == 0)
			{
				if (aceptar.Text == "Editar")
				{

					this.editarEmpresa();

					DialogResult = DialogResult.OK;
				}
				else
				{
					this.guardarEmpresa();

					DialogResult = DialogResult.OK;
				}

			}
			else
			{
				MessageBox.Show("No se pudo crear la empresa.");
			}

		}

		
		public int validarForm()
		{
			if (this.tbRazonSocial.Text == "")
			{
				MessageBox.Show("Debe ingresar  Razon social");
				return 1;
			}
			
			if (this.tbCalle.Text == "" && this.tbnroPiso.Text == "" && this.tbDepto.Text == "")
			{
				MessageBox.Show("Debe ingresar un Direccion");
				return 1;
			}
			if (this.tbCuit.Text == "")
			{
				MessageBox.Show("Debe ingresar un Cuit");
				return 1;
			}
			
			if (this.tbMail.Text == "")
			{
				MessageBox.Show("Debe ingresar Mail");
				return 1;

			}

			//validar que el cuil sea correcto
			if (CalcularDigitoCuit(tbCuit.Text.Replace("-","")) > 0)
			{
				MessageBox.Show("El formato de cuit es incorrecto");
				return 1;
			}
			
			//validar que no exista cuit
			Boolean existeCuit = this.db.Consultar("SELECT e.id,e.CUIT,e.Estado,e.Fecha_alta,e.Fecha_baja,e.Mail,e.Telefono,e.Usuarios_Id FROM [GD2C2018].[CAMPUS_ANALYTICA].[Empresa] e join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where e.CUIT like '" + tbCuit.Text + "'" + " and e.Id <> " + Empresa_Id);
			if (existeCuit)
			{
				MessageBox.Show("El Cuit ya se encuentra dado de alta con otro usuario");
				return 1;
			}
			
			//validar que no exista mail
			Boolean existeMail = this.db.Consultar("SELECT e.id,e.CUIT,e.Estado,e.Fecha_alta,e.Fecha_baja,e.Mail,e.Telefono,e.Usuarios_Id FROM [GD2C2018].[CAMPUS_ANALYTICA].[Empresa] e join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where e.Mail like '" + tbMail.Text + "'" + " and e.Id <> " + Empresa_Id);
			if (existeMail)
			{
				MessageBox.Show("El Mail ya se encuentra dado de alta con otro usuario");
				return 1;
			}

			Boolean existeRazonSocial= this.db.Consultar("SELECT e.id,e.CUIT,e.Estado,e.Fecha_alta,e.Fecha_baja,e.Mail,e.Telefono,e.Usuarios_Id FROM [GD2C2018].[CAMPUS_ANALYTICA].[Empresa] e join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where e.Razon_social like  '" + tbRazonSocial.Text + "'" + " and e.Id <> " + Empresa_Id);
			if (existeRazonSocial)
			{
				MessageBox.Show("La razon social ya se encuentra dado de alta con otro usuario");
				return 1;
			}


			else
			{
				return 0;
			}

		}
		public static int CalcularDigitoCuit(string cuit)
		{
			try
			{
				int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
				char[] nums = cuit.ToCharArray();
				int total = 0;
				int size = mult.Length;
				for (int i = 0; i < size; i++)
				{
					total += int.Parse(nums[i].ToString()) * mult[i];
				}
				var resto = total % 11;
				int result = resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
				//MessageBox.Show(result.ToString());
				int digito = (int)char.GetNumericValue(nums[size]);
				//MessageBox.Show(digito.ToString());
				return (digito == result) ? 0 : 1;
			}
			catch (Exception e)
			{
				MessageBox.Show("CUIT invalido: " + e.Message);
				return 1;
			}
		}

		public void editarEmpresa() {
			String razonSocial=tbRazonSocial.Text;
			String mail=tbMail.Text;
			String telefono=tbTelefono.Text ;
			String cuit=tbCuit.Text ;
			String calle=tbCalle.Text;
			Decimal nroPiso=Decimal.Parse(tbnroPiso.Text) ;
			String depto = tbDepto.Text;
			String localidad=tbLocalidad.Text ;
			String codgoPostal=tbcodPostal.Text ;
			

		char habilitado;

			if (cbHabilitado.Checked == true)
			{
				habilitado = 'A';
			}
			else
			{
				habilitado = 'B';
			}
			

			int res = this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Empresa]   SET[Razon_social] ='"+razonSocial+
									   "',[Mail] = '"+mail+"',[Telefono] ='"+telefono +"' ,[CUIT] ='"+ cuit+ 
									   "',[Estado] ='"+habilitado+  
									   "' WHERE id= "+ Empresa_Id);

			//modifica direccion
			int resdir = this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Direccion]   SET  [Calle] ='" + calle + "'" +
												",[Piso] = " + nroPiso +
												",[Codigo_postal] ='" + codgoPostal + "'" +
												",[Localidad] = '" + localidad + "'"+
												",[Depoto] ='" + depto + "'" + " WHERE id=(select direccion_Id from CAMPUS_ANALYTICA.EmpresaDireccion where Empresa_id=" + Empresa_Id + ")");
			
			if (res == 1 && resdir == 1 ) { MessageBox.Show("Empresa actualizada correctamente."); }

		}
		
		public void guardarEmpresa() {

			String razonSocial = tbRazonSocial.Text;
			String mail = tbMail.Text;
			String telefono = tbTelefono.Text;
			String cuit = tbCuit.Text;
			String calle = tbCalle.Text;
			String depto = tbDepto.Text;
			String codPostal = tbcodPostal.Text;
			String localidad = tbLocalidad.Text;
			
			Decimal NroPiso;
			Char cliHabilitado = 'A';
				if (tbnroPiso.Text == "")
				{
					NroPiso = 0;
				}
				else
				{
				NroPiso  = Decimal.Parse(tbnroPiso.Text);
				}
				this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Empresa] ([Razon_social],[Mail],[Telefono],[CUIT],[Estado],[Fecha_alta],[Fecha_baja],[Usuarios_Id]"+
								 ",[Fecha_Creacion])  VALUES ('"+razonSocial+"','"+mail+"','"+  telefono+"','"+
								 cuit+"','"+cliHabilitado+ "',SYSDATETIME(),null,0,SYSDATETIME())");
				//este id es para insertar la direccion y el usuario nuevo
				Decimal emplId = UltimoEmpl();
				Decimal dirId = UltimaDir();
				this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Direccion]  ([Id],[Calle],[Piso],[Codigo_postal]" +
									",[Localidad],[Depoto])	VALUES(" + dirId + ",'" + calle + "'," + NroPiso + ",'" + codPostal + "','" +
									localidad + "','" + depto + "')");
				this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[empresaDireccion] ([Empresa_id],[Direccion_id] ,[Fecha_Alta]" +
									",[Fecha_Baja])	 VALUES (" + emplId + "," + dirId + ",SYSDATETIME(),null)");
				
				if (emplId != 0 && dirId != 0)
				{
					MessageBox.Show("Usuario guardado.");
				}

				nuevoUsuario(emplId);

			}
		

	private Decimal UltimoEmpl() // Obtiene el ultimo ID de CLIENTE
	{
		Boolean existe = this.db.Consultar("SELECT TOP 1 Id FROM CAMPUS_ANALYTICA.empresa where mail like '" + tbMail.Text + "'  ORDER BY  Id DESC");
		if (existe)
		{
			this.db.Leer();
		}
		return Decimal.Parse(this.db.ObtenerValor("Id"));
	}

	//secuenciador de direccion
	private Decimal UltimaDir() // Obtiene el ultimo ID de direccion
	{
		Boolean existe = this.db.Consultar("SELECT TOP 1 Id FROM CAMPUS_ANALYTICA.Direccion ORDER BY  Id DESC");
		if (existe)
		{
			this.db.Leer();
		}
		return Decimal.Parse(this.db.ObtenerValor("Id")) + 1;
	}

	public void nuevoUsuario(Decimal cliId)
	{
		PalcoNet.Registro_de_Usuario.AltaUsuario nuevoUsuario = new Registro_de_Usuario.AltaUsuario(this.db, 2, cliId);
		DialogResult res = nuevoUsuario.ShowDialog();
	}

	private void cancelar_Click(object sender, EventArgs e)
		{
			Dispose();
		}

	}
}
