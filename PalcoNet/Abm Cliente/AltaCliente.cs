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
        public AltaCliente(dbmanager db)
        {
            InitializeComponent();
            this.db = db;
            CargaComboTipoDoc();
        }
        public AltaCliente(dbmanager db,decimal Cliente_id)
        {
            MessageBox.Show(Cliente_id.ToString());
            InitializeComponent();
            this.db = db;
            CargaComboTipoDoc();
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
                //validar que no exista cuil
                Boolean existeCuil = this.db.Consultar("SELECT c.id, [Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad FROM [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where c.CUIL like '"+ tbCuil.Text+"'");
                if (existeCuil)
                {
                    MessageBox.Show("El Cuil ya se encuentra dado de alta con otro usuario");
                    return;
                }
                //validar que no exista dni
                Boolean existeDNI = this.db.Consultar("SELECT c.id, [Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad FROM [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where c.Nro_documento = '" + tbNumeroDNI.Text + "'");
                if (existeDNI)
                {
                    MessageBox.Show("El DNI ya se encuentra dado de alta con otro usuario");
                    return;
                }
                //validar que no exista mail
                Boolean existeMail = this.db.Consultar("SELECT c.id, [Nombre],[Apellido],[Nro_documento],[CUIL],[Mail],[Telefono],[Fecha_nacimiento],c.[Fecha_alta],d.Calle,d.Numero,d.Piso,d.Localidad FROM [GD2C2018].[CAMPUS_ANALYTICA].[Cliente] c join CAMPUS_ANALYTICA.ClienteDireccion cd on Cliente_id=Id join CAMPUS_ANALYTICA.Direccion  d on Direccion_id=d.Id where c.mail like '" + tbMail.Text + "'");
                if (existeMail)
                {
                    MessageBox.Show("El Mail ya se encuentra dado de alta con otro usuario");
                    return;
                }
            }else
                   {                                if (aceptar.Text == "Editar")
                                                    {
                                                      //TODO
                                                    //this.editarCliente();
                                                    MessageBox.Show("Cliente actualizado correctamente.");
                                                    DialogResult = DialogResult.OK;
                                                }
                                                else
                                                {
                                                    this.guardarCliente();
                                                    MessageBox.Show("Cliente guardado.");
                                                    DialogResult = DialogResult.OK;
                                                }
                                            }
                 
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
                MessageBox.Show(result.ToString());
                int digito = (int)char.GetNumericValue(nums[size]);
                MessageBox.Show(digito.ToString());
                return (digito == result) ? 0 : 1;
            }
            catch (FormatException e)
            {
                MessageBox.Show("ocurrio un error: " + e.Message);
                return 1;
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void guardarCliente()
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
            String cliFecNac = auxCliFecNac.ToString("yyyy-MM-dd");
            this.db.Ejecutar("INSERT INTO [CAMPUS_ANALYTICA].[Cliente] ([Nombre]" +
                                    " ,[Apellido],[Tipo_documento],[Nro_documento],[CUIL],[Mail],[Telefono]"+
                                    ",[Fecha_nacimiento],[Fecha_alta],[Fecha_baja],[Estado],[Cliente_frecuente]"+
                                    ",[Puntos],[Fecha_venc_puntos],[Usuarios_Id]) VALUES ('" + cliNombre + "', '" + cliApellido + "', " + cliTipoDoc + ", " + cliDoc + ", '" + cliCuil + "', '" + cliMail + "', '" +
                                    cliTelefono + "', '" + cliFecNac + "'," + "SYSDATETIME()" + "," + "null" + ", '" + cliHabilitado + "', " +
                                    "0," + "100," + "DATEADD(month, 1, SYSDATETIME()),null)");
            
            //este id es para insertar la direccion y el usuario nuevo
            Decimal cliId = UltimoCliID();
            //TODO INSERTARDIRECCION
          

        }

        //secuenciador de cliente
        private Decimal UltimoCliID() // Obtiene el ultimo ID de CLIENTE
        {
            Boolean existe = this.db.Consultar("SELECT TOP 1 Id FROM CAMPUS_ANALYTICA.Cliente ORDER BY  Id DESC");
            if (existe)
            {
                this.db.Leer();
            }
            return Decimal.Parse(this.db.ObtenerValor("Id"));
                }

          public void    nuevoUsuario(int cliId){
              PalcoNet.Registro_de_Usuario.AltaUsuario nuevoUsuario = new Registro_de_Usuario.AltaUsuario(this.db,2,cliId);
              DialogResult res = nuevoUsuario.ShowDialog();
         }

    }
}
    