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

namespace PalcoNet.Abm_Cliente
{
    public partial class AltaCliente : Form
    {
        private dbmanager db;
		private Decimal cliId = 0;
        public AltaCliente(dbmanager db)
        {
            InitializeComponent();
            this.db = db;
            CargaComboTipoDoc();
        }
        public AltaCliente(dbmanager db,Decimal Cliente_id)
        {
            InitializeComponent();
            this.db = db;
            CargaComboTipoDoc();
			this.cliId = Cliente_id;

            //buscar el cliente a modificar 
            Boolean existeR = this.db.Consultar("SELECT c.id, [Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad,c.estado,d.Codigo_postal FROM [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where c.id =" + Cliente_id);
            if (existeR)
            {
                this.db.Leer();
                tbNombre.Text = this.db.ObtenerValor("Nombre");
                tbApellido.Text = this.db.ObtenerValor("Apellido");
                tbNumeroDNI.Text = this.db.ObtenerValor("Nro_documento");
                tbCuil.Text = this.db.ObtenerValor("CUIL");
                tbMail.Text = this.db.ObtenerValor("Mail");
                tbTelefono.Text = this.db.ObtenerValor("Telefono");
                Int32 cliDiaFecNac = DateTime.Parse(this.db.ObtenerValor("Fecha_nacimiento")).Day;
                Int32 cliMesFecNac = DateTime.Parse(this.db.ObtenerValor("Fecha_nacimiento")).Month;
                Int32 cliAnioFecNac = DateTime.Parse(this.db.ObtenerValor("Fecha_nacimiento")).Year;
                tbDia.Text = cliDiaFecNac.ToString();
                tbMes.Text = cliMesFecNac.ToString();
                tbAno.Text = cliAnioFecNac.ToString();
                tbCalle.Text = this.db.ObtenerValor("Calle");
                tbNroPiso.Text = this.db.ObtenerValor("Piso");
                tbLocalidad.Text = this.db.ObtenerValor("Localidad");
                tbCodigoPostal.Text = this.db.ObtenerValor("Codigo_postal");
                char cliHabilitado = Char.Parse( this.db.ObtenerValor("Estado"));
                tbNroTarjeta.Text = "********";

                if (cliHabilitado == 'A')
                {
                    cbHabilitar.Checked = true;
                }
                else
                {
                    cbHabilitar.Checked = false;
                }
            }
            
            aceptar.Text = "Editar";
            tbNumeroDNI.Enabled = false;
            cbTipodoc.Enabled = false;
        }



        public void CargaComboTipoDoc()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, descripcion FROM CAMPUS_ANALYTICA.TIPO_DOCUMENTO", this.db.StringConexion());
            da.Fill(ds, "CAMPUS_ANALYTICA.TIPO_DOCUMENTO");
            this.cbTipodoc.DataSource = ds.Tables[0].DefaultView;
            this.cbTipodoc.DisplayMember = "descripcion";
            this.cbTipodoc.ValueMember = "Id";
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            //valida campos vacios, formato de fecha y formato cuil
            int valForm =  validarForm();
      
            if (valForm == 0)
            {
				if (aceptar.Text == "Editar")
				{

					this.editarCliente();
					MessageBox.Show("Cliente actualizado correctamente.");
					DialogResult = DialogResult.OK;
				}
				else
				{
					this.guardarCliente();
					
					DialogResult = DialogResult.OK;
				}

			}
			else
                   {
				MessageBox.Show("No se pudo crear el cliente.");
			}
                 
        }

        
        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        public void guardarCliente()
        {
            String cliNombre = tbNombre.Text;
            String cliApellido = tbApellido.Text;
            Decimal cliTipoDoc = Decimal.Parse(cbTipodoc.SelectedValue.ToString());
            Decimal cliDoc = Decimal.Parse(tbNumeroDNI.Text);
            String cliMail = tbMail.Text;
            String cliCuil = tbCuil.Text;
            String cliTelefono = tbTelefono.Text;
            Int32 cliDiaFecNac = Int32.Parse(tbDia.Text);
            Int32 cliMesFecNac = Int32.Parse(tbMes.Text);
            Int32 cliAnioFecNac = Int32.Parse(tbAno.Text);
            String cliCalle = tbCalle.Text;
            Decimal cliPiso = Decimal.Parse(tbNroPiso.Text);
            String cliLocalidad = tbLocalidad.Text;
            String cliDepto = tbDepto.Text;
            String cliPostal = tbCodigoPostal.Text;
            Decimal cliNroTarjeta = Decimal.Parse(tbNroTarjeta.Text);
            Char cliHabilitado = 'A';
            if (tbNroPiso.Text == "")
            {
                cliPiso = 0;
            }
            else
            {
                cliPiso = Decimal.Parse(tbNroPiso.Text);
            }
           
            DateTime auxCliFecNac = new DateTime(cliAnioFecNac, cliMesFecNac, cliDiaFecNac); // ARMA FECHA
          //  String cliFecNac = auxCliFecNac.ToString("yyyy/MM/dd");
            this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Cliente] ([Nombre]" +
                                    " ,[Apellido],[Tipo_documento],[Nro_documento],[CUIL],[Mail],[Telefono]"+
                                    ",[Fecha_nacimiento],[Fecha_alta],[Fecha_baja],[Estado],[Cliente_frecuente]"+
                                    ",[Puntos],[Fecha_venc_puntos],[Usuarios_Id]) VALUES ('" + cliNombre + "', '" + cliApellido + "', " + cliTipoDoc + ", " + cliDoc + ", '" + cliCuil + "', '" + cliMail + "', '" +
                                    cliTelefono + "', '" + auxCliFecNac + "'," + "SYSDATETIME()" + "," + "null" + ", '" + cliHabilitado + "', " +
                                    "0," + "100," + "DATEADD(month, 1, SYSDATETIME()),0)");
            
            //este id es para insertar la direccion y el usuario nuevo
            Decimal cliId = UltimoCliID();
			Decimal dirId = UltimaDir();
			this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Direccion]  ([Id],[Calle],[Piso],[Codigo_postal]" +
								",[Localidad],[Depoto])	VALUES("+dirId+",'"+cliCalle+"',"+cliPiso+",'"+cliPostal+"','"+
								cliLocalidad+"','"+cliDepto+"')");
			this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[ClienteDireccion] ([Cliente_id],[Direccion_id] ,[Fecha_Alta]" +
								",[Fecha_Baja])	 VALUES ("+cliId+","+dirId+ ",SYSDATETIME(),null)");
            //inserto la tarjeta nueva
            this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Tajetas] ([Nro_tarjeta],[Banco],[Tipo],[Fecha_vencimiento]" +
                                ",[Estado],[Cliente_Id])  VALUES (" + cliNroTarjeta + "," + "'TORIN','CREDITO','10/12','A'," + cliId);
			if(cliId!=0 && dirId != 0)
			{
				MessageBox.Show("Cliente guardado.");
			}

			nuevoUsuario(cliId);

        }
        public void editarCliente()
        {
            String cliNombre = tbNombre.Text;
            String cliApellido = tbApellido.Text;
            Decimal cliTipoDoc = Decimal.Parse(cbTipodoc.SelectedValue.ToString());
            Decimal cliDoc = Decimal.Parse(tbNumeroDNI.Text);
            String cliMail = tbMail.Text;
            String cliCuil = tbCuil.Text;
            Decimal cliTelefono = Decimal.Parse(tbTelefono.Text);
            Int32 cliDiaFecNac = Int32.Parse(tbDia.Text);
            Int32 cliMesFecNac = Int32.Parse(tbMes.Text);
            Int32 cliAnioFecNac = Int32.Parse(tbAno.Text);
            String cliCalle = tbCalle.Text;
            Decimal cliPiso = Decimal.Parse(tbNroPiso.Text);
            String cliLocalidad = tbLocalidad.Text;
            String cliDepto = tbDepto.Text;
            String cliPostal = tbCodigoPostal.Text;
            Decimal cliNroTarjeta = Decimal.Parse(tbNroTarjeta.Text);
            char Habilitado;

            if (cbHabilitar.Checked == true)
            {
                Habilitado = 'A';
            }
            else
            {
                Habilitado = 'B';
            }
            DateTime auxCliFecNac = new DateTime(cliAnioFecNac, cliMesFecNac, cliDiaFecNac); // ARMA FECHA
            String cliFecNac = auxCliFecNac.ToString("yyyy-MM-dd");

            int res = this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Cliente]   SET [Nombre] = '" + cliNombre + "'," +
                             "[Apellido] = '" + cliApellido + "'," + "[Tipo_documento] = " + cliTipoDoc + "," +
                              "[Nro_documento] =" + cliDoc + "," + "[CUIL] ='" + cliCuil + "'," + "[Mail] = '" +
                              cliMail + "'," + "[Telefono] = '" + cliTelefono + "'," + "[Fecha_nacimiento] ='" +
                              cliFecNac + "'," + "[Estado] ='" + Habilitado + "'," + "WHERE id =" + cliId);

            //modifica direccion
            int resdir = this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Direccion]   SET  [Calle] ='" + cliCalle + "'" +
                                                ",[Piso] = " + cliPiso +
                                                ",[Codigo_postal] ='" + cliPostal + "'" +
                                                ",[Localidad] = '" + cliLocalidad + "'" +
                                                ",[Depoto] ='" + cliDepto + " WHERE id=(select direccion_Id from CAMPUS_ANALYTICA.ClienteDireccion where Cliente_id=" + cliId + ")");
            //modifico la tarjeta
            int restjt = this.db.Ejecutar("UPDATE [CAMPUS_ANALYTICA].[Tajetas]  SET [Nro_tarjeta] = " + cliNroTarjeta +
                                            "WHERE Cliente_Id =" + cliId);
        }
		//secuenciador de cliente
		private Decimal UltimoCliID() // Obtiene el ultimo ID de CLIENTE
        {
            Boolean existe = this.db.Consultar("SELECT TOP 1 Id FROM CAMPUS_ANALYTICA.Cliente where mail like '" + tbMail.Text + "'  ORDER BY  Id DESC");
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
			return Decimal.Parse(this.db.ObtenerValor("Id"))+1;
		}

		public void    nuevoUsuario(Decimal cliId){
              PalcoNet.Registro_de_Usuario.AltaUsuario nuevoUsuario = new Registro_de_Usuario.AltaUsuario(this.db,2,cliId);
              DialogResult res = nuevoUsuario.ShowDialog();
         }
		public int validarForm()
		{
			if (this.tbNombre.Text == "")
			{
				MessageBox.Show("Debe ingresar  Nombre");
				return 1;
			}
			if (this.tbApellido.Text == "")
			{
				MessageBox.Show("Debe ingresar  Apellido");
				return 1;
			}
			if (this.tbCalle.Text == "" && this.tbNroPiso.Text == "" && this.tbDepto.Text == "")
			{
				MessageBox.Show("Debe ingresar un Direccion");
				return 1;
			}
			if (this.tbCuil.Text == "")
			{
				MessageBox.Show("Debe ingresar un Cuil");
				return 1;
			}
			if (this.tbDia.Text == "" && this.tbMes.Text == "" && this.tbAno.Text == "")
			{

				MessageBox.Show("Debe ingresar una Fecha de cumpleaños");
				return 1;
			}
			if (this.tbNumeroDNI.Text == "")
			{
				MessageBox.Show("Debe ingresar un DNI");
				return 1;
			}
			if (this.tbMail.Text == "")
			{
				MessageBox.Show("Debe ingresar Mail");
				return 1;

			}

			//validar que el cuil sea correcto
			if (CalcularDigitoCuil(tbCuil.Text) > 0)
			{
				MessageBox.Show("El formato de cuil es incorrecto");
				return 1;
			}
			if (!controlarFecha())
			{
				return 1;
			}
			//validar que no exista cuil
			Boolean existeCuil = this.db.Consultar("SELECT c.id, [Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad FROM [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where c.CUIL like '" + tbCuil.Text + "'");
			if (existeCuil && aceptar.Text!="Editar")
			{
				MessageBox.Show("El Cuil ya se encuentra dado de alta con otro usuario");
				return 1;
			}
			//validar que no exista dni
			Boolean existeDNI = this.db.Consultar("SELECT c.id, [Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad FROM [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where c.Nro_documento = '" + tbNumeroDNI.Text + "'");
            if (existeDNI && aceptar.Text != "Editar")
			{
				MessageBox.Show("El DNI ya se encuentra dado de alta con otro usuario");
				return 1;
			}
			//validar que no exista mail
			Boolean existeMail = this.db.Consultar("SELECT c.id, [Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad FROM [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where c.mail like '" + tbMail.Text + "'");
            if (existeMail && aceptar.Text != "Editar")
			{
				MessageBox.Show("El Mail ya se encuentra dado de alta con otro usuario");
				return 1;
			}

			else
			{
				return 0;
			}

		}
		private bool controlarFecha()
		{
			Decimal dia = Decimal.Parse(tbDia.Text);
			Decimal mes = Decimal.Parse(tbMes.Text);
			if (mes == 02) //mes de 28 dias
			{
				if (dia < 1 || dia > 28)
				{
					MessageBox.Show("El dia ingresado es incorrecto");
					return false;
				}
			}
			if (mes == 04 || mes == 06 || mes == 09 || mes == 11)
			{ //meses con 30 dias
				if (dia < 1 || dia > 30)
				{
					MessageBox.Show("El dia ingresado es incorrecto");
					return false;
				}

			}
			if (mes == 01 || mes == 03 || mes == 05 || mes == 07 || mes == 08 || mes == 10 || mes == 12)
			{
				if (dia < 1 || dia > 31)
				{
					MessageBox.Show("El dia ingresado es incorrecto");
					return false;
				}

			}


			if (mes < 1 || mes > 12)
			{
				MessageBox.Show("El mes ingresado es incorrecto");
				return false;
			}

			return true;
		}

		public static int CalcularDigitoCuil(string cuil)
		{
			try
			{
				int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
				char[] nums = cuil.ToCharArray();
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
			catch (FormatException e)
			{
				MessageBox.Show("ocurrio un error: " + e.Message);
				return 1;
			}
		}


	}
}
    