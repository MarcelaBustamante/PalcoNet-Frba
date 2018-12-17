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
            this.label1 = new System.Windows.Forms.Label();
            this.cbEspectaculo = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEspectaculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comprar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Categorías = new System.Windows.Forms.CheckedListBox();
            this.primero = new System.Windows.Forms.Button();
            this.siguiente = new System.Windows.Forms.Button();
            this.anterior = new System.Windows.Forms.Button();
            this.ultimo = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Espectaculo";
            // 
            // cbEspectaculo
            // 
            this.cbEspectaculo.FormattingEnabled = true;
            this.cbEspectaculo.Location = new System.Drawing.Point(168, 43);
            this.cbEspectaculo.Name = "cbEspectaculo";
            this.cbEspectaculo.Size = new System.Drawing.Size(228, 21);
            this.cbEspectaculo.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Fila,
            this.Asiento,
            this.Precio,
            this.Vendida,
            this.Tipo_Descripcion,
            this.CodigoPublicacion,
            this.descripcionPublicacion,
            this.FechaPublicacion,
            this.FechaEspectaculo});
            this.dataGridView1.Location = new System.Drawing.Point(78, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(712, 232);
            this.dataGridView1.TabIndex = 2;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            // 
            // Fila
            // 
            this.Fila.HeaderText = "Fila";
            this.Fila.Name = "Fila";
            // 
            // Asiento
            // 
            this.Asiento.HeaderText = "Asiento";
            this.Asiento.Name = "Asiento";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Vendida
            // 
            this.Vendida.HeaderText = "Vendida";
            this.Vendida.Name = "Vendida";
            // 
            // Tipo_Descripcion
            // 
            this.Tipo_Descripcion.HeaderText = "tipo de descripción";
            this.Tipo_Descripcion.Name = "Tipo_Descripcion";
            // 
            // CodigoPublicacion
            // 
            this.CodigoPublicacion.HeaderText = "Codigo Publicacion";
            this.CodigoPublicacion.Name = "CodigoPublicacion";
            // 
            // descripcionPublicacion
            // 
            this.descripcionPublicacion.HeaderText = "descripcion Publicación";
            this.descripcionPublicacion.Name = "descripcionPublicacion";
            // 
            // FechaPublicacion
            // 
            this.FechaPublicacion.HeaderText = "Fecha Publicacion";
            this.FechaPublicacion.Name = "FechaPublicacion";
            // 
            // FechaEspectaculo
            // 
            this.FechaEspectaculo.HeaderText = "Fecha Espectaculo";
            this.FechaEspectaculo.Name = "FechaEspectaculo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selecciona el espectaculo y luego las ubicaciones";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(78, 11);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 80);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // comprar
            // 
            this.comprar.Location = new System.Drawing.Point(79, 450);
            this.comprar.Name = "comprar";
            this.comprar.Size = new System.Drawing.Size(551, 35);
            this.comprar.TabIndex = 5;
            this.comprar.Text = "Comprar";
            this.comprar.UseVisualStyleBackColor = true;
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(679, 462);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 6;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.limpiar);
            this.groupBox1.Controls.Add(this.buscar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Categorías);
            this.groupBox1.Location = new System.Drawing.Point(412, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 149);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de búsqueda";
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(246, 111);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 3;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(143, 111);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 2;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(133, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 83);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda por fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Inicio";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(44, 51);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(45, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(178, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // Categorías
            // 
            this.Categorías.FormattingEnabled = true;
            this.Categorías.Location = new System.Drawing.Point(7, 20);
            this.Categorías.Name = "Categorías";
            this.Categorías.Size = new System.Drawing.Size(100, 124);
            this.Categorías.TabIndex = 0;
            // 
            // primero
            // 
            this.primero.Location = new System.Drawing.Point(3, 3);
            this.primero.Name = "primero";
            this.primero.Size = new System.Drawing.Size(75, 23);
            this.primero.TabIndex = 8;
            this.primero.Text = "Primero";
            this.primero.UseVisualStyleBackColor = true;
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(165, 3);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(75, 23);
            this.siguiente.TabIndex = 9;
            this.siguiente.Text = "Siguiente";
            this.siguiente.UseVisualStyleBackColor = true;
            // 
            // anterior
            // 
            this.anterior.Location = new System.Drawing.Point(84, 3);
            this.anterior.Name = "anterior";
            this.anterior.Size = new System.Drawing.Size(75, 23);
            this.anterior.TabIndex = 10;
            this.anterior.Text = "Anterior";
            this.anterior.UseVisualStyleBackColor = true;
            // 
            // ultimo
            // 
            this.ultimo.Location = new System.Drawing.Point(246, 3);
            this.ultimo.Name = "ultimo";
            this.ultimo.Size = new System.Drawing.Size(75, 23);
            this.ultimo.TabIndex = 11;
            this.ultimo.Text = "Último";
            this.ultimo.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.primero);
            this.flowLayoutPanel2.Controls.Add(this.anterior);
            this.flowLayoutPanel2.Controls.Add(this.siguiente);
            this.flowLayoutPanel2.Controls.Add(this.ultimo);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(300, 404);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(327, 32);
            this.flowLayoutPanel2.TabIndex = 12;
            // 
            // generarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 518);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.comprar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbEspectaculo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "generarCompra";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEspectaculo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Descripcion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button comprar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckedListBox Categorías;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPublicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEspectaculo;
        private System.Windows.Forms.Button primero;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Button anterior;
        private System.Windows.Forms.Button ultimo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}