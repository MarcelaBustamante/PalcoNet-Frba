namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class BajaEmpresa
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
			this.label1 = new System.Windows.Forms.Label();
			this.acepar = new System.Windows.Forms.Button();
			this.cancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(86, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(220, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "¿Esta seguro que desea eliminar la empresa?";
			// 
			// acepar
			// 
			this.acepar.Location = new System.Drawing.Point(89, 83);
			this.acepar.Name = "acepar";
			this.acepar.Size = new System.Drawing.Size(75, 27);
			this.acepar.TabIndex = 2;
			this.acepar.Text = "Aceptar";
			this.acepar.UseVisualStyleBackColor = true;
			this.acepar.Click += new System.EventHandler(this.acepar_Click);
			// 
			// cancelar
			// 
			this.cancelar.Location = new System.Drawing.Point(221, 83);
			this.cancelar.Name = "cancelar";
			this.cancelar.Size = new System.Drawing.Size(75, 27);
			this.cancelar.TabIndex = 3;
			this.cancelar.Text = "Cancelar";
			this.cancelar.UseVisualStyleBackColor = true;
			this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
			// 
			// BajaEmpresa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(371, 154);
			this.Controls.Add(this.cancelar);
			this.Controls.Add(this.acepar);
			this.Controls.Add(this.label1);
			this.Name = "BajaEmpresa";
			this.Text = "BajaEmpresa";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button acepar;
        private System.Windows.Forms.Button cancelar;
    }
}