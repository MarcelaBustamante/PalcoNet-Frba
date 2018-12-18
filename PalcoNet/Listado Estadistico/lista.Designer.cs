namespace PalcoNet.Listado_Estadistico
{
    partial class lista
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
			this.consultar = new System.Windows.Forms.Button();
			this.rbCantCompras = new System.Windows.Forms.RadioButton();
			this.rbPuntosVencidos = new System.Windows.Forms.RadioButton();
			this.rbNovendidas = new System.Windows.Forms.RadioButton();
			this.cbTrimestre = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbAno = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grillaConsulta = new System.Windows.Forms.DataGridView();
			this.cbGrado = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grillaConsulta)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbGrado);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.consultar);
			this.groupBox1.Controls.Add(this.rbCantCompras);
			this.groupBox1.Controls.Add(this.rbPuntosVencidos);
			this.groupBox1.Controls.Add(this.rbNovendidas);
			this.groupBox1.Controls.Add(this.cbTrimestre);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cbAno);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(24, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(696, 131);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Estadisticas";
			// 
			// consultar
			// 
			this.consultar.Location = new System.Drawing.Point(513, 96);
			this.consultar.Name = "consultar";
			this.consultar.Size = new System.Drawing.Size(118, 23);
			this.consultar.TabIndex = 7;
			this.consultar.Text = "Consultar";
			this.consultar.UseVisualStyleBackColor = true;
			this.consultar.Click += new System.EventHandler(this.consultar_Click);
			// 
			// rbCantCompras
			// 
			this.rbCantCompras.AutoSize = true;
			this.rbCantCompras.Location = new System.Drawing.Point(256, 71);
			this.rbCantCompras.Name = "rbCantCompras";
			this.rbCantCompras.Size = new System.Drawing.Size(156, 17);
			this.rbCantCompras.TabIndex = 6;
			this.rbCantCompras.TabStop = true;
			this.rbCantCompras.Text = "Mayor cantidad de compras";
			this.rbCantCompras.UseVisualStyleBackColor = true;
			// 
			// rbPuntosVencidos
			// 
			this.rbPuntosVencidos.AutoSize = true;
			this.rbPuntosVencidos.Location = new System.Drawing.Point(243, 99);
			this.rbPuntosVencidos.Name = "rbPuntosVencidos";
			this.rbPuntosVencidos.Size = new System.Drawing.Size(206, 17);
			this.rbPuntosVencidos.TabIndex = 5;
			this.rbPuntosVencidos.TabStop = true;
			this.rbPuntosVencidos.Text = "Clientes con mayores puntos vencidos";
			this.rbPuntosVencidos.UseVisualStyleBackColor = true;
			// 
			// rbNovendidas
			// 
			this.rbNovendidas.AutoSize = true;
			this.rbNovendidas.Location = new System.Drawing.Point(15, 99);
			this.rbNovendidas.Name = "rbNovendidas";
			this.rbNovendidas.Size = new System.Drawing.Size(204, 17);
			this.rbNovendidas.TabIndex = 4;
			this.rbNovendidas.TabStop = true;
			this.rbNovendidas.Text = "Empresa con localidades no vendidas";
			this.rbNovendidas.UseVisualStyleBackColor = true;
			// 
			// cbTrimestre
			// 
			this.cbTrimestre.FormattingEnabled = true;
			this.cbTrimestre.Location = new System.Drawing.Point(60, 46);
			this.cbTrimestre.Name = "cbTrimestre";
			this.cbTrimestre.Size = new System.Drawing.Size(121, 21);
			this.cbTrimestre.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Trimestre";
			// 
			// cbAno
			// 
			this.cbAno.FormattingEnabled = true;
			this.cbAno.Location = new System.Drawing.Point(60, 19);
			this.cbAno.Name = "cbAno";
			this.cbAno.Size = new System.Drawing.Size(121, 21);
			this.cbAno.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Año";
			// 
			// grillaConsulta
			// 
			this.grillaConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grillaConsulta.Location = new System.Drawing.Point(24, 149);
			this.grillaConsulta.Name = "grillaConsulta";
			this.grillaConsulta.Size = new System.Drawing.Size(696, 246);
			this.grillaConsulta.TabIndex = 1;
			// 
			// cbGrado
			// 
			this.cbGrado.FormattingEnabled = true;
			this.cbGrado.Location = new System.Drawing.Point(304, 24);
			this.cbGrado.Name = "cbGrado";
			this.cbGrado.Size = new System.Drawing.Size(121, 21);
			this.cbGrado.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(248, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Grado";
			// 
			// lista
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 417);
			this.Controls.Add(this.grillaConsulta);
			this.Controls.Add(this.groupBox1);
			this.Name = "lista";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grillaConsulta)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTrimestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbCantCompras;
        private System.Windows.Forms.RadioButton rbPuntosVencidos;
        private System.Windows.Forms.RadioButton rbNovendidas;
        private System.Windows.Forms.DataGridView grillaConsulta;
        private System.Windows.Forms.Button consultar;
		private System.Windows.Forms.ComboBox cbGrado;
		private System.Windows.Forms.Label label3;
	}
}