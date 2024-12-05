namespace MotorsForm
{
    partial class Alquiler
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
            this.txtTarifaEdit = new System.Windows.Forms.NumericUpDown();
            this.btnEditar = new System.Windows.Forms.Button();
            this.cmbTipoAuto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSubastaAdd = new System.Windows.Forms.NumericUpDown();
            this.lsblistAlquiler = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMoverSubasta = new System.Windows.Forms.Button();
            this.btnVenta = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTarifaAdd = new System.Windows.Forms.NumericUpDown();
            this.btnAgragar = new System.Windows.Forms.Button();
            this.txtTipoAuto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lsbEspera = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAlquilar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarifaEdit)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubastaAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarifaAdd)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtTarifaEdit);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.cmbTipoAuto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(14, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editar Tarifa";
            // 
            // txtTarifaEdit
            // 
            this.txtTarifaEdit.DecimalPlaces = 2;
            this.txtTarifaEdit.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarifaEdit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtTarifaEdit.Location = new System.Drawing.Point(58, 192);
            this.txtTarifaEdit.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtTarifaEdit.Name = "txtTarifaEdit";
            this.txtTarifaEdit.Size = new System.Drawing.Size(162, 30);
            this.txtTarifaEdit.TabIndex = 23;
            this.txtTarifaEdit.ThousandsSeparator = true;
            // 
            // btnEditar
            // 
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(63, 282);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(151, 44);
            this.btnEditar.TabIndex = 22;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cmbTipoAuto
            // 
            this.cmbTipoAuto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoAuto.FormattingEnabled = true;
            this.cmbTipoAuto.Location = new System.Drawing.Point(54, 105);
            this.cmbTipoAuto.Name = "cmbTipoAuto";
            this.cmbTipoAuto.Size = new System.Drawing.Size(167, 27);
            this.cmbTipoAuto.TabIndex = 21;
            this.cmbTipoAuto.SelectedIndexChanged += new System.EventHandler(this.cmbTipoAuto_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tarifa Diaria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tipo de Auto:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtSubastaAdd);
            this.groupBox2.Controls.Add(this.lsblistAlquiler);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnMoverSubasta);
            this.groupBox2.Controls.Add(this.btnVenta);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(608, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 440);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editar Estado";
            // 
            // txtSubastaAdd
            // 
            this.txtSubastaAdd.DecimalPlaces = 2;
            this.txtSubastaAdd.Font = new System.Drawing.Font("Tahoma", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubastaAdd.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtSubastaAdd.Location = new System.Drawing.Point(131, 331);
            this.txtSubastaAdd.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtSubastaAdd.Name = "txtSubastaAdd";
            this.txtSubastaAdd.Size = new System.Drawing.Size(120, 26);
            this.txtSubastaAdd.TabIndex = 25;
            // 
            // lsblistAlquiler
            // 
            this.lsblistAlquiler.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsblistAlquiler.FormattingEnabled = true;
            this.lsblistAlquiler.ItemHeight = 14;
            this.lsblistAlquiler.Location = new System.Drawing.Point(38, 67);
            this.lsblistAlquiler.Name = "lsblistAlquiler";
            this.lsblistAlquiler.Size = new System.Drawing.Size(297, 214);
            this.lsblistAlquiler.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "Lista de Autos en Alquiler";
            // 
            // btnMoverSubasta
            // 
            this.btnMoverSubasta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnMoverSubasta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnMoverSubasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoverSubasta.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoverSubasta.ForeColor = System.Drawing.Color.White;
            this.btnMoverSubasta.Location = new System.Drawing.Point(207, 363);
            this.btnMoverSubasta.Name = "btnMoverSubasta";
            this.btnMoverSubasta.Size = new System.Drawing.Size(151, 59);
            this.btnMoverSubasta.TabIndex = 24;
            this.btnMoverSubasta.Text = "Mover a Subasta";
            this.btnMoverSubasta.UseVisualStyleBackColor = true;
            this.btnMoverSubasta.Click += new System.EventHandler(this.btnMoverSubasta_Click);
            // 
            // btnVenta
            // 
            this.btnVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenta.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.ForeColor = System.Drawing.Color.White;
            this.btnVenta.Location = new System.Drawing.Point(24, 364);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(151, 58);
            this.btnVenta.TabIndex = 23;
            this.btnVenta.Text = "Mover a venta";
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(433, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(437, 58);
            this.label3.TabIndex = 4;
            this.label3.Text = "Alquiler de Autos";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::MotorsForm.Properties.Resources.Logo_MV;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(927, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(259, 154);
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtTarifaAdd);
            this.groupBox3.Controls.Add(this.btnAgragar);
            this.groupBox3.Controls.Add(this.txtTipoAuto);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(989, 172);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 387);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Agregar tipo de auto";
            // 
            // txtTarifaAdd
            // 
            this.txtTarifaAdd.DecimalPlaces = 2;
            this.txtTarifaAdd.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarifaAdd.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtTarifaAdd.Location = new System.Drawing.Point(54, 192);
            this.txtTarifaAdd.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtTarifaAdd.Name = "txtTarifaAdd";
            this.txtTarifaAdd.Size = new System.Drawing.Size(162, 30);
            this.txtTarifaAdd.TabIndex = 24;
            this.txtTarifaAdd.ThousandsSeparator = true;
            // 
            // btnAgragar
            // 
            this.btnAgragar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAgragar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnAgragar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgragar.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgragar.ForeColor = System.Drawing.Color.White;
            this.btnAgragar.Location = new System.Drawing.Point(63, 282);
            this.btnAgragar.Name = "btnAgragar";
            this.btnAgragar.Size = new System.Drawing.Size(151, 44);
            this.btnAgragar.TabIndex = 22;
            this.btnAgragar.Text = "Agregar";
            this.btnAgragar.UseVisualStyleBackColor = true;
            this.btnAgragar.Click += new System.EventHandler(this.btnAgragar_Click);
            // 
            // txtTipoAuto
            // 
            this.txtTipoAuto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoAuto.Location = new System.Drawing.Point(54, 105);
            this.txtTipoAuto.MaxLength = 20;
            this.txtTipoAuto.Name = "txtTipoAuto";
            this.txtTipoAuto.Size = new System.Drawing.Size(168, 27);
            this.txtTipoAuto.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tarifa Diaria:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tipo de Auto:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.lsbEspera);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnAlquilar);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(299, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(303, 440);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Editar Estado";
            // 
            // lsbEspera
            // 
            this.lsbEspera.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbEspera.FormattingEnabled = true;
            this.lsbEspera.ItemHeight = 14;
            this.lsbEspera.Location = new System.Drawing.Point(18, 67);
            this.lsbEspera.Name = "lsbEspera";
            this.lsbEspera.Size = new System.Drawing.Size(255, 214);
            this.lsbEspera.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "Lista de Autos en Alquiler";
            // 
            // btnAlquilar
            // 
            this.btnAlquilar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAlquilar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnAlquilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlquilar.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlquilar.ForeColor = System.Drawing.Color.White;
            this.btnAlquilar.Location = new System.Drawing.Point(67, 363);
            this.btnAlquilar.Name = "btnAlquilar";
            this.btnAlquilar.Size = new System.Drawing.Size(151, 58);
            this.btnAlquilar.TabIndex = 23;
            this.btnAlquilar.Text = "Mover a Alquiler";
            this.btnAlquilar.UseVisualStyleBackColor = true;
            this.btnAlquilar.Click += new System.EventHandler(this.btnAlquilar_Click);
            // 
            // Alquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MotorsForm.Properties.Resources.Background1;
            this.ClientSize = new System.Drawing.Size(1283, 648);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Alquiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alquiler";
            this.Load += new System.EventHandler(this.Alquiler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarifaEdit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubastaAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarifaAdd)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoAuto;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnMoverSubasta;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtTarifaEdit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown txtTarifaAdd;
        private System.Windows.Forms.Button btnAgragar;
        private System.Windows.Forms.TextBox txtTipoAuto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lsblistAlquiler;
        private System.Windows.Forms.NumericUpDown txtSubastaAdd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lsbEspera;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAlquilar;
    }
}