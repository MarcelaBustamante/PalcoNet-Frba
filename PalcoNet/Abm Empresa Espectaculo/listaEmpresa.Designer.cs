namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class listaEmpresa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.limpiar = new System.Windows.Forms.Button();
			this.buscar = new System.Windows.Forms.Button();
			this.tbMail = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbCuit = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbRazonSocial = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grillaEmpresa = new System.Windows.Forms.DataGridView();
			this.alta = new System.Windows.Forms.Button();
			this.modificar = new System.Windows.Forms.Button();
			this.eliminar = new System.Windows.Forms.Button();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Razon_Social = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CUIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigoPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.depto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grillaEmpresa)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.limpiar);
			this.groupBox1.Controls.Add(this.buscar);
			this.groupBox1.Controls.Add(this.tbMail);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbCuit);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbRazonSocial);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(64, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(711, 142);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Flitro de busqueda";
			// 
			// limpiar
			// 
			this.limpiar.Location = new System.Drawing.Point(500, 100);
			this.limpiar.Name = "limpiar";
			this.limpiar.Size = new System.Drawing.Size(75, 23);
			this.limpiar.TabIndex = 7;
			this.limpiar.Text = "Limpiar";
			this.limpiar.UseVisualStyleBackColor = true;
			this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
			// 
			// buscar
			// 
			this.buscar.Location = new System.Drawing.Point(392, 100);
			this.buscar.Name = "buscar";
			this.buscar.Size = new System.Drawing.Size(75, 23);
			this.buscar.TabIndex = 6;
			this.buscar.Text = "Buscar";
			this.buscar.UseVisualStyleBackColor = true;
			this.buscar.Click += new System.EventHandler(this.buscar_Click_1);
			// 
			// tbMail
			// 
			this.tbMail.Location = new System.Drawing.Point(440, 30);
			this.tbMail.Name = "tbMail";
			this.tbMail.Size = new System.Drawing.Size(219, 20);
			this.tbMail.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(389, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Email";
			// 
			// tbCuit
			// 
			this.tbCuit.Location = new System.Drawing.Point(122, 63);
			this.tbCuit.Name = "tbCuit";
			this.tbCuit.Size = new System.Drawing.Size(219, 20);
			this.tbCuit.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "CUIT";
			// 
			// tbRazonSocial
			// 
			this.tbRazonSocial.Location = new System.Drawing.Point(122, 29);
			this.tbRazonSocial.Name = "tbRazonSocial";
			this.tbRazonSocial.Size = new System.Drawing.Size(219, 20);
			this.tbRazonSocial.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Razon social";
			// 
			// grillaEmpresa
			// 
			this.grillaEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grillaEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Razon_Social,
            this.Mail,
            this.Telefono,
            this.CUIT,
            this.Estado,
            this.FechaAlta,
            this.Calle,
            this.codigoPostal,
            this.depto,
            this.localidad});
			this.grillaEmpresa.Location = new System.Drawing.Point(64, 191);
			this.grillaEmpresa.Name = "grillaEmpresa";
			this.grillaEmpresa.Size = new System.Drawing.Size(711, 212);
			this.grillaEmpresa.TabIndex = 1;
			// 
			// alta
			// 
			this.alta.Location = new System.Drawing.Point(424, 422);
			this.alta.Name = "alta";
			this.alta.Size = new System.Drawing.Size(75, 23);
			this.alta.TabIndex = 8;
			this.alta.Text = "Alta";
			this.alta.UseVisualStyleBackColor = true;
			this.alta.Click += new System.EventHandler(this.alta_Click);
			// 
			// modificar
			// 
			this.modificar.Location = new System.Drawing.Point(538, 422);
			this.modificar.Name = "modificar";
			this.modificar.Size = new System.Drawing.Size(75, 23);
			this.modificar.TabIndex = 9;
			this.modificar.Text = "Modificar";
			this.modificar.UseVisualStyleBackColor = true;
			this.modificar.Click += new System.EventHandler(this.modificar_Click);
			// 
			// eliminar
			// 
			this.eliminar.Location = new System.Drawing.Point(648, 422);
			this.eliminar.Name = "eliminar";
			this.eliminar.Size = new System.Drawing.Size(75, 23);
			this.eliminar.TabIndex = 10;
			this.eliminar.Text = "Eliminar";
			this.eliminar.UseVisualStyleBackColor = true;
			this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
			// 
			// id
			// 
			this.id.HeaderText = "Id";
			this.id.Name = "id";
			// 
			// Razon_Social
			// 
			this.Razon_Social.HeaderText = "Razon social";
			this.Razon_Social.Name = "Razon_Social";
			// 
			// Mail
			// 
			this.Mail.HeaderText = "Mail";
			this.Mail.Name = "Mail";
			// 
			// Telefono
			// 
			this.Telefono.HeaderText = "Telefono";
			this.Telefono.Name = "Telefono";
			// 
			// CUIT
			// 
			this.CUIT.HeaderText = "CUIT";
			this.CUIT.Name = "CUIT";
			// 
			// Estado
			// 
			this.Estado.HeaderText = "Estado";
			this.Estado.Name = "Estado";
			// 
			// FechaAlta
			// 
			this.FechaAlta.HeaderText = "Fecha de alta";
			this.FechaAlta.Name = "FechaAlta";
			// 
			// Calle
			// 
			this.Calle.HeaderText = "calle";
			this.Calle.Name = "Calle";
			// 
			// codigoPostal
			// 
			this.codigoPostal.HeaderText = "codigo postal";
			this.codigoPostal.Name = "codigoPostal";
			// 
			// depto
			// 
			this.depto.HeaderText = "depto";
			this.depto.Name = "depto";
			// 
			// localidad
			// 
			this.localidad.HeaderText = "localidad";
			this.localidad.Name = "localidad";
			// 
			// listaEmpresa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(876, 486);
			this.Controls.Add(this.eliminar);
			this.Controls.Add(this.modificar);
			this.Controls.Add(this.alta);
			this.Controls.Add(this.grillaEmpresa);
			this.Controls.Add(this.groupBox1);
			this.Name = "listaEmpresa";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grillaEmpresa)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.DataGridView grillaEmpresa;
        private System.Windows.Forms.Button alta;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button eliminar;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn Razon_Social;
		private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
		private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
		private System.Windows.Forms.DataGridViewTextBoxColumn CUIT;
		private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
		private System.Windows.Forms.DataGridViewTextBoxColumn FechaAlta;
		private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigoPostal;
		private System.Windows.Forms.DataGridViewTextBoxColumn depto;
		private System.Windows.Forms.DataGridViewTextBoxColumn localidad;
	}
}