namespace PalcoNet.Abm_Rol
{
    partial class DarDeAltaRol
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
            this.gbNombre = new System.Windows.Forms.GroupBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.active = new System.Windows.Forms.CheckBox();
            this.gbFuncionalidades = new System.Windows.Forms.GroupBox();
            this.funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.cancelar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.gbNombre.SuspendLayout();
            this.gbFuncionalidades.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNombre
            // 
            this.gbNombre.Controls.Add(this.active);
            this.gbNombre.Controls.Add(this.nombre);
            this.gbNombre.Controls.Add(this.lbNombre);
            this.gbNombre.Location = new System.Drawing.Point(29, 28);
            this.gbNombre.Name = "gbNombre";
            this.gbNombre.Size = new System.Drawing.Size(407, 117);
            this.gbNombre.TabIndex = 0;
            this.gbNombre.TabStop = false;
            this.gbNombre.Text = "Nombre";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(36, 31);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(44, 13);
            this.lbNombre.TabIndex = 0;
            this.lbNombre.Text = "Nombre";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(39, 58);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(245, 20);
            this.nombre.TabIndex = 1;
            // 
            // active
            // 
            this.active.AutoSize = true;
            this.active.Location = new System.Drawing.Point(211, 84);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(73, 17);
            this.active.TabIndex = 2;
            this.active.Text = "Habilitado";
            this.active.UseVisualStyleBackColor = true;
            // 
            // gbFuncionalidades
            // 
            this.gbFuncionalidades.Controls.Add(this.funcionalidades);
            this.gbFuncionalidades.Location = new System.Drawing.Point(29, 162);
            this.gbFuncionalidades.Name = "gbFuncionalidades";
            this.gbFuncionalidades.Size = new System.Drawing.Size(554, 142);
            this.gbFuncionalidades.TabIndex = 1;
            this.gbFuncionalidades.TabStop = false;
            this.gbFuncionalidades.Text = "Funcionalidades";
            // 
            // funcionalidades
            // 
            this.funcionalidades.FormattingEnabled = true;
            this.funcionalidades.Location = new System.Drawing.Point(25, 20);
            this.funcionalidades.Name = "funcionalidades";
            this.funcionalidades.Size = new System.Drawing.Size(513, 109);
            this.funcionalidades.TabIndex = 0;
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(507, 323);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 2;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(426, 323);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 3;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // DarDeAltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 358);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.gbFuncionalidades);
            this.Controls.Add(this.gbNombre);
            this.Name = "DarDeAltaRol";
            this.Text = "DarDeAltaRol";
            this.gbNombre.ResumeLayout(false);
            this.gbNombre.PerformLayout();
            this.gbFuncionalidades.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNombre;
        private System.Windows.Forms.CheckBox active;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.GroupBox gbFuncionalidades;
        private System.Windows.Forms.CheckedListBox funcionalidades;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
    }
}