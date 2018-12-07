﻿namespace PalcoNet.Editar_Publicacion
{
    partial class Publicaciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.aceptar = new System.Windows.Forms.Button();
            this.borrar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEspectaculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradoPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alta = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.borrar);
            this.groupBox1.Controls.Add(this.aceptar);
            this.groupBox1.Controls.Add(this.tbDescripcion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCodigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(50, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Búsqueda";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(54, 24);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(100, 20);
            this.tbCodigo.TabIndex = 1;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(261, 24);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(205, 20);
            this.tbDescripcion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion";
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(508, 21);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 4;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            // 
            // borrar
            // 
            this.borrar.Location = new System.Drawing.Point(605, 21);
            this.borrar.Name = "borrar";
            this.borrar.Size = new System.Drawing.Size(75, 23);
            this.borrar.TabIndex = 5;
            this.borrar.Text = "Borrar";
            this.borrar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.descripcion,
            this.FechaPublicacion,
            this.FechaEspectaculo,
            this.Rubro,
            this.Direccion,
            this.GradoPublicacion,
            this.Responsable,
            this.Estado});
            this.dataGridView1.Location = new System.Drawing.Point(50, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(708, 237);
            this.dataGridView1.TabIndex = 1;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            // 
            // FechaPublicacion
            // 
            this.FechaPublicacion.HeaderText = "Fecha de Publicación";
            this.FechaPublicacion.Name = "FechaPublicacion";
            // 
            // FechaEspectaculo
            // 
            this.FechaEspectaculo.HeaderText = "Fecha del espectaculo";
            this.FechaEspectaculo.Name = "FechaEspectaculo";
            // 
            // Rubro
            // 
            this.Rubro.HeaderText = "Rubro";
            this.Rubro.Name = "Rubro";
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.Name = "Direccion";
            // 
            // GradoPublicacion
            // 
            this.GradoPublicacion.HeaderText = "Grado de Publicación";
            this.GradoPublicacion.Name = "GradoPublicacion";
            // 
            // Responsable
            // 
            this.Responsable.HeaderText = "Responsable";
            this.Responsable.Name = "Responsable";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // alta
            // 
            this.alta.Location = new System.Drawing.Point(440, 401);
            this.alta.Name = "alta";
            this.alta.Size = new System.Drawing.Size(75, 23);
            this.alta.TabIndex = 2;
            this.alta.Text = "Alta";
            this.alta.UseVisualStyleBackColor = true;
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(558, 401);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(75, 23);
            this.modificar.TabIndex = 3;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(655, 401);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 4;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            // 
            // Publicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 443);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.alta);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Publicaciones";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button borrar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEspectaculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradoPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button alta;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button cancelar;
    }
}