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
            this.grillaCompras = new System.Windows.Forms.DataGridView();
            this.btnGenerarFact = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cantFacturar = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NroCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantFacturar)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaCompras
            // 
            this.grillaCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroCompra,
            this.FechaCompra,
            this.asiento,
            this.fila,
            this.descripcionPublicacion,
            this.precio,
            this.importeComision});
            this.grillaCompras.Location = new System.Drawing.Point(31, 37);
            this.grillaCompras.Name = "grillaCompras";
            this.grillaCompras.Size = new System.Drawing.Size(786, 345);
            this.grillaCompras.TabIndex = 1;
            // 
            // btnGenerarFact
            // 
            this.btnGenerarFact.Location = new System.Drawing.Point(622, 388);
            this.btnGenerarFact.Name = "btnGenerarFact";
            this.btnGenerarFact.Size = new System.Drawing.Size(114, 23);
            this.btnGenerarFact.TabIndex = 3;
            this.btnGenerarFact.Text = "Generar factura";
            this.btnGenerarFact.UseVisualStyleBackColor = true;
            this.btnGenerarFact.Click += new System.EventHandler(this.btnGenerarFact_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(742, 388);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 4;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Compras sin facturar:";
            // 
            // cantFacturar
            // 
            this.cantFacturar.Location = new System.Drawing.Point(208, 388);
            this.cantFacturar.Name = "cantFacturar";
            this.cantFacturar.Size = new System.Drawing.Size(120, 20);
            this.cantFacturar.TabIndex = 6;
            this.cantFacturar.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Facturar las primeras:";
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
            // asiento
            // 
            this.asiento.HeaderText = "asiento";
            this.asiento.Name = "asiento";
            // 
            // fila
            // 
            this.fila.HeaderText = "fila";
            this.fila.Name = "fila";
            // 
            // descripcionPublicacion
            // 
            this.descripcionPublicacion.HeaderText = "Descripción de publicación";
            this.descripcionPublicacion.Name = "descripcionPublicacion";
            // 
            // precio
            // 
            this.precio.HeaderText = "precio";
            this.precio.Name = "precio";
            // 
            // importeComision
            // 
            this.importeComision.HeaderText = "Importe Comisión";
            this.importeComision.Name = "importeComision";
            // 
            // generarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 443);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cantFacturar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.btnGenerarFact);
            this.Controls.Add(this.grillaCompras);
            this.Name = "generarFactura";
            this.Text = "Generar pago Comisiones";
            this.Load += new System.EventHandler(this.generarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantFacturar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView grillaCompras;
        private System.Windows.Forms.Button btnGenerarFact;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cantFacturar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeComision;
    }
}