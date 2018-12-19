namespace PalcoNet.Historial_Cliente
{
    partial class HistrorialCliente
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
            this.grillaHistorial = new System.Windows.Forms.DataGridView();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medio_Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.principio = new System.Windows.Forms.Button();
            this.siguiente = new System.Windows.Forms.Button();
            this.anterior = new System.Windows.Forms.Button();
            this.fin = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grillaHistorial)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaHistorial
            // 
            this.grillaHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.Codigo_compra,
            this.Precio,
            this.Fecha_compra,
            this.Medio_Pago});
            this.grillaHistorial.Location = new System.Drawing.Point(12, 12);
            this.grillaHistorial.Name = "grillaHistorial";
            this.grillaHistorial.Size = new System.Drawing.Size(543, 268);
            this.grillaHistorial.TabIndex = 0;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // Codigo_compra
            // 
            this.Codigo_compra.HeaderText = "Codigo Compra";
            this.Codigo_compra.Name = "Codigo_compra";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Fecha_compra
            // 
            this.Fecha_compra.HeaderText = "Fecha Compra";
            this.Fecha_compra.Name = "Fecha_compra";
            // 
            // Medio_Pago
            // 
            this.Medio_Pago.HeaderText = "Medio de Pago";
            this.Medio_Pago.Name = "Medio_Pago";
            // 
            // principio
            // 
            this.principio.Location = new System.Drawing.Point(3, 3);
            this.principio.Name = "principio";
            this.principio.Size = new System.Drawing.Size(75, 23);
            this.principio.TabIndex = 1;
            this.principio.Text = "Principio";
            this.principio.UseVisualStyleBackColor = true;
            this.principio.Click += new System.EventHandler(this.principio_Click);
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(165, 3);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(75, 23);
            this.siguiente.TabIndex = 2;
            this.siguiente.Text = "Siguiente";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // anterior
            // 
            this.anterior.Location = new System.Drawing.Point(84, 3);
            this.anterior.Name = "anterior";
            this.anterior.Size = new System.Drawing.Size(75, 23);
            this.anterior.TabIndex = 3;
            this.anterior.Text = "Anterior";
            this.anterior.UseVisualStyleBackColor = true;
            this.anterior.Click += new System.EventHandler(this.anterior_Click);
            // 
            // fin
            // 
            this.fin.Location = new System.Drawing.Point(246, 3);
            this.fin.Name = "fin";
            this.fin.Size = new System.Drawing.Size(75, 23);
            this.fin.TabIndex = 4;
            this.fin.Text = "Fin";
            this.fin.UseVisualStyleBackColor = true;
            this.fin.Click += new System.EventHandler(this.fin_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.principio);
            this.flowLayoutPanel1.Controls.Add(this.anterior);
            this.flowLayoutPanel1.Controls.Add(this.siguiente);
            this.flowLayoutPanel1.Controls.Add(this.fin);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(227, 298);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 31);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // HistrorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 355);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.grillaHistorial);
            this.Name = "HistrorialCliente";
            this.Text = "Historial Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.grillaHistorial)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaHistorial;
        private System.Windows.Forms.Button principio;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Button anterior;
        private System.Windows.Forms.Button fin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medio_Pago;
    }
}