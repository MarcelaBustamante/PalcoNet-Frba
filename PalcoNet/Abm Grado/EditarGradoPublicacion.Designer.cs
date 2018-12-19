namespace PalcoNet.Abm_Grado
{
    partial class Form1
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
			this.tbComisionGradoPublicacion = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbGradoPublicaccion = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.aceptar = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbComisionGradoPublicacion
			// 
			this.tbComisionGradoPublicacion.Location = new System.Drawing.Point(119, 63);
			this.tbComisionGradoPublicacion.Name = "tbComisionGradoPublicacion";
			this.tbComisionGradoPublicacion.Size = new System.Drawing.Size(153, 20);
			this.tbComisionGradoPublicacion.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Comision (%)";
			// 
			// cbGradoPublicaccion
			// 
			this.cbGradoPublicaccion.FormattingEnabled = true;
			this.cbGradoPublicaccion.Location = new System.Drawing.Point(119, 31);
			this.cbGradoPublicaccion.Name = "cbGradoPublicaccion";
			this.cbGradoPublicaccion.Size = new System.Drawing.Size(153, 21);
			this.cbGradoPublicaccion.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 34);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Grado Publicación";
			// 
			// aceptar
			// 
			this.aceptar.Location = new System.Drawing.Point(116, 185);
			this.aceptar.Name = "aceptar";
			this.aceptar.Size = new System.Drawing.Size(75, 23);
			this.aceptar.TabIndex = 10;
			this.aceptar.Text = "Aceptar";
			this.aceptar.UseVisualStyleBackColor = true;
			this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(197, 185);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "Cancelar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 220);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.aceptar);
			this.Controls.Add(this.cbGradoPublicaccion);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbComisionGradoPublicacion);
			this.Name = "Form1";
			this.Text = "Grado Publicacion";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbComisionGradoPublicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGradoPublicaccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button button1;
    }
}