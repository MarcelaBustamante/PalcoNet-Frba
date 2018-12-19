namespace PalcoNet.Generar_Rendicion_Comisiones
{
    partial class generarFactura
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
            this.aceptar = new System.Windows.Forms.Button();
            this.tbPublicacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbcompra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NroCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerarFact = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.limpiar);
            this.groupBox1.Controls.Add(this.aceptar);
            this.groupBox1.Controls.Add(this.tbPublicacion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbcompra);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de búsqueda";
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(350, 51);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(350, 24);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 4;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            // 
            // tbPublicacion
            // 
            this.tbPublicacion.Location = new System.Drawing.Point(178, 53);
            this.tbPublicacion.Name = "tbPublicacion";
            this.tbPublicacion.Size = new System.Drawing.Size(133, 20);
            this.tbPublicacion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero de publicacion";
            // 
            // tbcompra
            // 
            this.tbcompra.Location = new System.Drawing.Point(178, 28);
            this.tbcompra.Name = "tbcompra";
            this.tbcompra.Size = new System.Drawing.Size(133, 20);
            this.tbcompra.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de compra";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroCompra,
            this.FechaCompra,
            this.idUbicacion,
            this.fila,
            this.asiento,
            this.precio,
            this.codigoPublicacion,
            this.descripcionPublicacion,
            this.importeComision});
            this.dataGridView1.Location = new System.Drawing.Point(28, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(786, 197);
            this.dataGridView1.TabIndex = 1;
            // 
            // NroCompra
            // 
            this.NroCompra.HeaderText = "Nro de compra";
            this.NroCompra.Name = "NroCompra";
            // 
            // FechaCompra
            // 
            this.FechaCompra.HeaderText = "Fecha de compra";
            this.FechaCompra.Name = "FechaCompra";
            // 
            // idUbicacion
            // 
            this.idUbicacion.HeaderText = "Id ubicación";
            this.idUbicacion.Name = "idUbicacion";
            // 
            // fila
            // 
            this.fila.HeaderText = "fila";
            this.fila.Name = "fila";
            // 
            // asiento
            // 
            this.asiento.HeaderText = "asiento";
            this.asiento.Name = "asiento";
            // 
            // precio
            // 
            this.precio.HeaderText = "precio";
            this.precio.Name = "precio";
            // 
            // codigoPublicacion
            // 
            this.codigoPublicacion.HeaderText = "codigo de prublicación";
            this.codigoPublicacion.Name = "codigoPublicacion";
            // 
            // descripcionPublicacion
            // 
            this.descripcionPublicacion.HeaderText = "Descripción de publicación";
            this.descripcionPublicacion.Name = "descripcionPublicacion";
            // 
            // importeComision
            // 
            this.importeComision.HeaderText = "Importe Comisión";
            this.importeComision.Name = "importeComision";
            // 
            // btnGenerarFact
            // 
            this.btnGenerarFact.Location = new System.Drawing.Point(562, 388);
            this.btnGenerarFact.Name = "btnGenerarFact";
            this.btnGenerarFact.Size = new System.Drawing.Size(114, 23);
            this.btnGenerarFact.TabIndex = 3;
            this.btnGenerarFact.Text = "Generar factura";
            this.btnGenerarFact.UseVisualStyleBackColor = true;
            this.btnGenerarFact.Click += new System.EventHandler(this.btnGenerarFact_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(701, 388);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 4;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            // 
            // generarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 443);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.btnGenerarFact);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "generarFactura";
            this.Text = "Generar pago Comisiones";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGenerarFact;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeComision;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.TextBox tbPublicacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbcompra;
        private System.Windows.Forms.Label label1;
    }
}