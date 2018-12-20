namespace PalcoNet.Generar_Publicacion
{
    partial class AltaPublicacion
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
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.mcPublicacion = new System.Windows.Forms.MonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mbEspectaculo = new System.Windows.Forms.MonthCalendar();
            this.cbRubro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDirección = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGradoPubli = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbUserRespon = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.aceptar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLocalidades = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditarLocalidad = new System.Windows.Forms.Button();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grillaUbicaciones = new System.Windows.Forms.DataGridView();
            this.Tipo_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbFila = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbTipoPublicacion = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaUbicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(84, 14);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(534, 20);
            this.tbDescripcion.TabIndex = 1;
            // 
            // mcPublicacion
            // 
            this.mcPublicacion.Location = new System.Drawing.Point(12, 31);
            this.mcPublicacion.Name = "mcPublicacion";
            this.mcPublicacion.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mcPublicacion);
            this.groupBox1.Location = new System.Drawing.Point(84, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 205);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de Publicación";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.mbEspectaculo);
            this.groupBox2.Location = new System.Drawing.Point(359, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 236);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha del Espectaculo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 203);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Hora";
            // 
            // mbEspectaculo
            // 
            this.mbEspectaculo.Location = new System.Drawing.Point(12, 31);
            this.mbEspectaculo.Name = "mbEspectaculo";
            this.mbEspectaculo.TabIndex = 2;
            // 
            // cbRubro
            // 
            this.cbRubro.FormattingEnabled = true;
            this.cbRubro.Location = new System.Drawing.Point(110, 301);
            this.cbRubro.Name = "cbRubro";
            this.cbRubro.Size = new System.Drawing.Size(164, 21);
            this.cbRubro.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rubro";
            // 
            // tbDirección
            // 
            this.tbDirección.Location = new System.Drawing.Point(398, 300);
            this.tbDirección.Name = "tbDirección";
            this.tbDirección.Size = new System.Drawing.Size(238, 20);
            this.tbDirección.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dirección";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Grado Publicación";
            // 
            // cbGradoPubli
            // 
            this.cbGradoPubli.FormattingEnabled = true;
            this.cbGradoPubli.Location = new System.Drawing.Point(110, 333);
            this.cbGradoPubli.Name = "cbGradoPubli";
            this.cbGradoPubli.Size = new System.Drawing.Size(164, 21);
            this.cbGradoPubli.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 366);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Responsable";
            // 
            // cbUserRespon
            // 
            this.cbUserRespon.FormattingEnabled = true;
            this.cbUserRespon.Location = new System.Drawing.Point(110, 363);
            this.cbUserRespon.Name = "cbUserRespon";
            this.cbUserRespon.Size = new System.Drawing.Size(164, 21);
            this.cbUserRespon.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Estado";
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(398, 331);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(238, 21);
            this.cbEstado.TabIndex = 13;
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(355, 418);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(60, 23);
            this.aceptar.TabIndex = 15;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(569, 418);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(65, 23);
            this.cancelar.TabIndex = 16;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Aceptar y agregar otra";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(804, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Localidades";
            // 
            // tbLocalidades
            // 
            this.tbLocalidades.Enabled = false;
            this.tbLocalidades.Location = new System.Drawing.Point(874, 331);
            this.tbLocalidades.Name = "tbLocalidades";
            this.tbLocalidades.Size = new System.Drawing.Size(238, 20);
            this.tbLocalidades.TabIndex = 21;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(1007, 80);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 34;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(955, 285);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 33;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditarLocalidad
            // 
            this.btnEditarLocalidad.Enabled = false;
            this.btnEditarLocalidad.Location = new System.Drawing.Point(1036, 285);
            this.btnEditarLocalidad.Name = "btnEditarLocalidad";
            this.btnEditarLocalidad.Size = new System.Drawing.Size(75, 23);
            this.btnEditarLocalidad.TabIndex = 32;
            this.btnEditarLocalidad.Text = "Editar";
            this.btnEditarLocalidad.UseVisualStyleBackColor = true;
            this.btnEditarLocalidad.Click += new System.EventHandler(this.brnEditar_Click);
            // 
            // tbPrecio
            // 
            this.tbPrecio.Enabled = false;
            this.tbPrecio.Location = new System.Drawing.Point(966, 44);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(116, 20);
            this.tbPrecio.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(885, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Precio";
            // 
            // grillaUbicaciones
            // 
            this.grillaUbicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaUbicaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo_descripcion,
            this.Fila,
            this.Precio,
            this.Cantidad});
            this.grillaUbicaciones.Location = new System.Drawing.Point(672, 109);
            this.grillaUbicaciones.Name = "grillaUbicaciones";
            this.grillaUbicaciones.Size = new System.Drawing.Size(439, 150);
            this.grillaUbicaciones.TabIndex = 28;
            // 
            // Tipo_descripcion
            // 
            this.Tipo_descripcion.HeaderText = "Tipo";
            this.Tipo_descripcion.Name = "Tipo_descripcion";
            // 
            // Fila
            // 
            this.Fila.HeaderText = "Fila";
            this.Fila.Name = "Fila";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // tbFila
            // 
            this.tbFila.Enabled = false;
            this.tbFila.Location = new System.Drawing.Point(966, 17);
            this.tbFila.Name = "tbFila";
            this.tbFila.Size = new System.Drawing.Size(116, 20);
            this.tbFila.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(884, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Fila";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Enabled = false;
            this.tbCantidad.Location = new System.Drawing.Point(754, 44);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(116, 20);
            this.tbCantidad.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(670, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Cantidad";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(673, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Tipo";
            // 
            // cbTipoPublicacion
            // 
            this.cbTipoPublicacion.Enabled = false;
            this.cbTipoPublicacion.FormattingEnabled = true;
            this.cbTipoPublicacion.Location = new System.Drawing.Point(754, 17);
            this.cbTipoPublicacion.Name = "cbTipoPublicacion";
            this.cbTipoPublicacion.Size = new System.Drawing.Size(116, 21);
            this.cbTipoPublicacion.TabIndex = 22;
            // 
            // AltaPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 473);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditarLocalidad);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grillaUbicaciones);
            this.Controls.Add(this.tbFila);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbCantidad);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbTipoPublicacion);
            this.Controls.Add(this.tbLocalidades);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbUserRespon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbGradoPubli);
            this.Controls.Add(this.tbDirección);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbRubro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.label1);
            this.Name = "AltaPublicacion";
            this.Text = "Alta Publicacion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaUbicaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.MonthCalendar mcPublicacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MonthCalendar mbEspectaculo;
        private System.Windows.Forms.ComboBox cbRubro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDirección;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGradoPubli;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbUserRespon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbLocalidades;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditarLocalidad;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView grillaUbicaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.TextBox tbFila;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbTipoPublicacion;
    }
}