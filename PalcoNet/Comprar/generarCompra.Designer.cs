namespace PalcoNet.Comprar
{
    partial class generarCompra
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
            this.grillaPublicaciones = new System.Windows.Forms.DataGridView();
            this.CodigoPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEspectaculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.primero = new System.Windows.Forms.Button();
            this.anterior = new System.Windows.Forms.Button();
            this.siguiente = new System.Windows.Forms.Button();
            this.ultimo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCurrentPage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTotalPages = new System.Windows.Forms.Label();
            this.comprar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grillaUbicaciones = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPublicaciones)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaUbicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaPublicaciones
            // 
            this.grillaPublicaciones.AllowUserToAddRows = false;
            this.grillaPublicaciones.AllowUserToDeleteRows = false;
            this.grillaPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaPublicaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoPublicacion,
            this.descripcionPublicacion,
            this.FechaPublicacion,
            this.FechaEspectaculo});
            this.grillaPublicaciones.Location = new System.Drawing.Point(3, 27);
            this.grillaPublicaciones.Name = "grillaPublicaciones";
            this.grillaPublicaciones.ReadOnly = true;
            this.grillaPublicaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaPublicaciones.Size = new System.Drawing.Size(462, 446);
            this.grillaPublicaciones.TabIndex = 2;
            this.grillaPublicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaPublicaciones_CellContentClick);
            // 
            // CodigoPublicacion
            // 
            this.CodigoPublicacion.HeaderText = "Codigo Publicacion";
            this.CodigoPublicacion.Name = "CodigoPublicacion";
            this.CodigoPublicacion.ReadOnly = true;
            this.CodigoPublicacion.Visible = false;
            // 
            // descripcionPublicacion
            // 
            this.descripcionPublicacion.HeaderText = "Espectáculo";
            this.descripcionPublicacion.Name = "descripcionPublicacion";
            this.descripcionPublicacion.ReadOnly = true;
            this.descripcionPublicacion.Width = 250;
            // 
            // FechaPublicacion
            // 
            this.FechaPublicacion.HeaderText = "Fecha Publicacion";
            this.FechaPublicacion.Name = "FechaPublicacion";
            this.FechaPublicacion.ReadOnly = true;
            this.FechaPublicacion.Width = 80;
            // 
            // FechaEspectaculo
            // 
            this.FechaEspectaculo.HeaderText = "Fecha Espectaculo";
            this.FechaEspectaculo.Name = "FechaEspectaculo";
            this.FechaEspectaculo.ReadOnly = true;
            this.FechaEspectaculo.Width = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selecciona el espectaculo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.grillaPublicaciones);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.labelCurrentPage);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.labelTotalPages);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(465, 518);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.primero);
            this.flowLayoutPanel2.Controls.Add(this.anterior);
            this.flowLayoutPanel2.Controls.Add(this.siguiente);
            this.flowLayoutPanel2.Controls.Add(this.ultimo);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 479);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(327, 32);
            this.flowLayoutPanel2.TabIndex = 12;
            // 
            // primero
            // 
            this.primero.Location = new System.Drawing.Point(3, 3);
            this.primero.Name = "primero";
            this.primero.Size = new System.Drawing.Size(75, 23);
            this.primero.TabIndex = 8;
            this.primero.Text = "Primero";
            this.primero.UseVisualStyleBackColor = true;
            this.primero.Click += new System.EventHandler(this.primero_Click);
            // 
            // anterior
            // 
            this.anterior.Location = new System.Drawing.Point(84, 3);
            this.anterior.Name = "anterior";
            this.anterior.Size = new System.Drawing.Size(75, 23);
            this.anterior.TabIndex = 10;
            this.anterior.Text = "Anterior";
            this.anterior.UseVisualStyleBackColor = true;
            this.anterior.Click += new System.EventHandler(this.anterior_Click);
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(165, 3);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(75, 23);
            this.siguiente.TabIndex = 9;
            this.siguiente.Text = "Siguiente";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // ultimo
            // 
            this.ultimo.Location = new System.Drawing.Point(246, 3);
            this.ultimo.Name = "ultimo";
            this.ultimo.Size = new System.Drawing.Size(75, 23);
            this.ultimo.TabIndex = 11;
            this.ultimo.Text = "Último";
            this.ultimo.UseVisualStyleBackColor = true;
            this.ultimo.Click += new System.EventHandler(this.ultimo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Página";
            // 
            // labelCurrentPage
            // 
            this.labelCurrentPage.AutoSize = true;
            this.labelCurrentPage.Location = new System.Drawing.Point(382, 476);
            this.labelCurrentPage.Name = "labelCurrentPage";
            this.labelCurrentPage.Size = new System.Drawing.Size(13, 13);
            this.labelCurrentPage.TabIndex = 15;
            this.labelCurrentPage.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 476);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "/";
            // 
            // labelTotalPages
            // 
            this.labelTotalPages.AutoSize = true;
            this.labelTotalPages.Location = new System.Drawing.Point(419, 476);
            this.labelTotalPages.Name = "labelTotalPages";
            this.labelTotalPages.Size = new System.Drawing.Size(19, 13);
            this.labelTotalPages.TabIndex = 17;
            this.labelTotalPages.Text = "10";
            // 
            // comprar
            // 
            this.comprar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comprar.Enabled = false;
            this.comprar.Location = new System.Drawing.Point(583, 471);
            this.comprar.Name = "comprar";
            this.comprar.Size = new System.Drawing.Size(281, 35);
            this.comprar.TabIndex = 5;
            this.comprar.Text = "Comprar";
            this.comprar.UseVisualStyleBackColor = true;
            this.comprar.Click += new System.EventHandler(this.comprar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(487, 477);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 6;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.Controls.Add(this.labelDescripcion);
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.grillaUbicaciones);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(487, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(377, 465);
            this.flowLayoutPanel3.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "                                                            ";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcion.ForeColor = System.Drawing.Color.DarkRed;
            this.labelDescripcion.Location = new System.Drawing.Point(3, 13);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(244, 20);
            this.labelDescripcion.TabIndex = 4;
            this.labelDescripcion.Text = "Haz doble click en un evento.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "                                                            ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecciona la ubicacion";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grillaUbicaciones
            // 
            this.grillaUbicaciones.AllowUserToAddRows = false;
            this.grillaUbicaciones.AllowUserToDeleteRows = false;
            this.grillaUbicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaUbicaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column2,
            this.Column1,
            this.Column4,
            this.Column3});
            this.grillaUbicaciones.Location = new System.Drawing.Point(3, 73);
            this.grillaUbicaciones.Name = "grillaUbicaciones";
            this.grillaUbicaciones.ReadOnly = true;
            this.grillaUbicaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaUbicaciones.Size = new System.Drawing.Size(374, 365);
            this.grillaUbicaciones.TabIndex = 2;
            this.grillaUbicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaUbicaciones_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fila";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Asiento";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tipo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Precio ($)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // generarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 518);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.comprar);
            this.Name = "generarCompra";
            this.Text = "Comprar";
            this.Load += new System.EventHandler(this.generarCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaPublicaciones)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaUbicaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grillaPublicaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button comprar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button primero;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Button anterior;
        private System.Windows.Forms.Button ultimo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCurrentPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTotalPages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grillaUbicaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEspectaculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Label label6;
    }
}