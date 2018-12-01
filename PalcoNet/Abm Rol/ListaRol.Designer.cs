namespace PalcoNet.Abm_Rol
{
    partial class ListaRol
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
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.habilitados = new System.Windows.Forms.CheckBox();
            this.tbRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grillaRoles = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alta = new System.Windows.Forms.Button();
            this.editar = new System.Windows.Forms.Button();
            this.borrar = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.limpiar);
            this.gbFiltros.Controls.Add(this.buscar);
            this.gbFiltros.Controls.Add(this.habilitados);
            this.gbFiltros.Controls.Add(this.tbRol);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Location = new System.Drawing.Point(51, 25);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(814, 78);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros de Búsqueda";
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(681, 36);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(82, 23);
            this.limpiar.TabIndex = 4;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(546, 36);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(84, 23);
            this.buscar.TabIndex = 3;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click_1);
            // 
            // habilitados
            // 
            this.habilitados.AutoSize = true;
            this.habilitados.Location = new System.Drawing.Point(349, 36);
            this.habilitados.Name = "habilitados";
            this.habilitados.Size = new System.Drawing.Size(100, 17);
            this.habilitados.TabIndex = 2;
            this.habilitados.Text = "Sólo habilitados";
            this.habilitados.UseVisualStyleBackColor = true;
            // 
            // tbRol
            // 
            this.tbRol.Location = new System.Drawing.Point(118, 31);
            this.tbRol.Name = "tbRol";
            this.tbRol.Size = new System.Drawing.Size(198, 20);
            this.tbRol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = " Nombre de rol";
            // 
            // grillaRoles
            // 
            this.grillaRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Descripción,
            this.habilitado});
            this.grillaRoles.Location = new System.Drawing.Point(51, 132);
            this.grillaRoles.Name = "grillaRoles";
            this.grillaRoles.Size = new System.Drawing.Size(814, 203);
            this.grillaRoles.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Descripción
            // 
            this.Descripción.HeaderText = "Desripción";
            this.Descripción.Name = "Descripción";
            // 
            // habilitado
            // 
            this.habilitado.HeaderText = "habilitado";
            this.habilitado.Name = "habilitado";
            // 
            // alta
            // 
            this.alta.Location = new System.Drawing.Point(442, 348);
            this.alta.Name = "alta";
            this.alta.Size = new System.Drawing.Size(75, 23);
            this.alta.TabIndex = 2;
            this.alta.Text = "Alta";
            this.alta.UseVisualStyleBackColor = true;
            this.alta.Click += new System.EventHandler(this.alta_Click);
            // 
            // editar
            // 
            this.editar.Location = new System.Drawing.Point(597, 348);
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(75, 23);
            this.editar.TabIndex = 3;
            this.editar.Text = "Editar";
            this.editar.UseVisualStyleBackColor = true;
            this.editar.Click += new System.EventHandler(this.editar_Click);
            // 
            // borrar
            // 
            this.borrar.Location = new System.Drawing.Point(732, 347);
            this.borrar.Name = "borrar";
            this.borrar.Size = new System.Drawing.Size(75, 23);
            this.borrar.TabIndex = 4;
            this.borrar.Text = "Borrar";
            this.borrar.UseVisualStyleBackColor = true;
            this.borrar.Click += new System.EventHandler(this.borrar_Click);
            // 
            // ListaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 383);
            this.Controls.Add(this.borrar);
            this.Controls.Add(this.editar);
            this.Controls.Add(this.alta);
            this.Controls.Add(this.grillaRoles);
            this.Controls.Add(this.gbFiltros);
            this.Name = "ListaRol";
            this.Text = "Form1";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox habilitados;
        private System.Windows.Forms.TextBox tbRol;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.DataGridView grillaRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitado;
        private System.Windows.Forms.Button alta;
        private System.Windows.Forms.Button editar;
        private System.Windows.Forms.Button borrar;
    }
}