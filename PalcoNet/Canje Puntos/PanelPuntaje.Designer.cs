namespace PalcoNet.Canje_Puntos
{
    partial class PanelPuntaje
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
			this.label2 = new System.Windows.Forms.Label();
			this.boxPuntos = new System.Windows.Forms.TextBox();
			this.gridPremios = new System.Windows.Forms.DataGridView();
			this.label3 = new System.Windows.Forms.Label();
			this.canjear = new System.Windows.Forms.Button();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Condiciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridPremios)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tus puntos acumulados son:";
			// 
			// boxPuntos
			// 
			this.boxPuntos.Enabled = false;
			this.boxPuntos.Location = new System.Drawing.Point(168, 12);
			this.boxPuntos.Name = "boxPuntos";
			this.boxPuntos.Size = new System.Drawing.Size(87, 20);
			this.boxPuntos.TabIndex = 4;
			this.boxPuntos.Text = "cargando...";
			// 
			// gridPremios
			// 
			this.gridPremios.AllowUserToAddRows = false;
			this.gridPremios.AllowUserToDeleteRows = false;
			this.gridPremios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridPremios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Descripcion,
            this.Valor,
            this.Condiciones});
			this.gridPremios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
			this.gridPremios.Location = new System.Drawing.Point(13, 57);
			this.gridPremios.MultiSelect = false;
			this.gridPremios.Name = "gridPremios";
			this.gridPremios.ReadOnly = true;
			this.gridPremios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridPremios.Size = new System.Drawing.Size(353, 182);
			this.gridPremios.TabIndex = 6;
			this.gridPremios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPremios_CellContentClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Selecciona un premio:";
			// 
			// canjear
			// 
			this.canjear.Location = new System.Drawing.Point(289, 247);
			this.canjear.Name = "canjear";
			this.canjear.Size = new System.Drawing.Size(75, 23);
			this.canjear.TabIndex = 7;
			this.canjear.Text = "Canjear";
			this.canjear.UseVisualStyleBackColor = true;
			this.canjear.Click += new System.EventHandler(this.canjear_Click);
			// 
			// Id
			// 
			this.Id.HeaderText = "Id";
			this.Id.Name = "Id";
			this.Id.Visible = false;
			// 
			// Descripcion
			// 
			this.Descripcion.HeaderText = "Descripcion";
			this.Descripcion.Name = "Descripcion";
			// 
			// Valor
			// 
			this.Valor.HeaderText = "Valor (pts)";
			this.Valor.Name = "Valor";
			// 
			// Condiciones
			// 
			this.Condiciones.HeaderText = "Condiciones";
			this.Condiciones.Name = "Condiciones";
			// 
			// PanelPuntaje
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(380, 284);
			this.Controls.Add(this.canjear);
			this.Controls.Add(this.gridPremios);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.boxPuntos);
			this.Controls.Add(this.label2);
			this.Name = "PanelPuntaje";
			this.ShowIcon = false;
			this.Text = "Canjear Puntos";
			this.Load += new System.EventHandler(this.PanelPuntaje_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridPremios)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxPuntos;
		private System.Windows.Forms.DataGridView gridPremios;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button canjear;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
		private System.Windows.Forms.DataGridViewTextBoxColumn Condiciones;
	}
}