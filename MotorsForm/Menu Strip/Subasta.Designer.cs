namespace MotorsForm.Menu_Strip
{
    partial class Subasta
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
            this.txtPlaca = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.txtVInicial = new System.Windows.Forms.NumericUpDown();
            this.btnSubastar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbAutos = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnAlquilar = new System.Windows.Forms.Button();
            this.lsbAutosSubasta = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVInicial)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPlaca);
            this.groupBox1.Controls.Add(this.dtpFinal);
            this.groupBox1.Controls.Add(this.dtpInicial);
            this.groupBox1.Controls.Add(this.txtVInicial);
            this.groupBox1.Controls.Add(this.btnSubastar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lsbAutos);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(95, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 507);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Autos";
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.White;
            this.txtPlaca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtPlaca.ForeColor = System.Drawing.Color.Black;
            this.txtPlaca.Location = new System.Drawing.Point(303, 100);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(184, 27);
            this.txtPlaca.TabIndex = 15;
            // 
            // dtpFinal
            // 
            this.dtpFinal.CustomFormat = "dd-MM-yyyy";
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinal.Location = new System.Drawing.Point(302, 310);
            this.dtpFinal.MaxDate = new System.DateTime(2211, 1, 1, 0, 0, 0, 0);
            this.dtpFinal.MinDate = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(185, 27);
            this.dtpFinal.TabIndex = 14;
            this.dtpFinal.Value = new System.DateTime(2024, 11, 17, 0, 0, 0, 0);
            // 
            // dtpInicial
            // 
            this.dtpInicial.CustomFormat = "dd-MM-yyyy";
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicial.Location = new System.Drawing.Point(302, 237);
            this.dtpInicial.MaxDate = new System.DateTime(2211, 1, 1, 0, 0, 0, 0);
            this.dtpInicial.MinDate = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(185, 27);
            this.dtpInicial.TabIndex = 13;
            this.dtpInicial.Value = new System.DateTime(2024, 10, 17, 0, 0, 0, 0);
            // 
            // txtVInicial
            // 
            this.txtVInicial.DecimalPlaces = 2;
            this.txtVInicial.Location = new System.Drawing.Point(302, 167);
            this.txtVInicial.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtVInicial.Name = "txtVInicial";
            this.txtVInicial.Size = new System.Drawing.Size(185, 27);
            this.txtVInicial.TabIndex = 10;
            this.txtVInicial.ThousandsSeparator = true;
            this.txtVInicial.Leave += new System.EventHandler(this.txtVInicial_Leave_1);
            // 
            // btnSubastar
            // 
            this.btnSubastar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnSubastar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSubastar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubastar.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubastar.Location = new System.Drawing.Point(302, 372);
            this.btnSubastar.Name = "btnSubastar";
            this.btnSubastar.Size = new System.Drawing.Size(184, 47);
            this.btnSubastar.TabIndex = 9;
            this.btnSubastar.Text = "Subastar";
            this.btnSubastar.UseVisualStyleBackColor = true;
            this.btnSubastar.Click += new System.EventHandler(this.btnSubastar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha Final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor Inicial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Placa";
            // 
            // lsbAutos
            // 
            this.lsbAutos.FormattingEnabled = true;
            this.lsbAutos.ItemHeight = 19;
            this.lsbAutos.Location = new System.Drawing.Point(27, 74);
            this.lsbAutos.Name = "lsbAutos";
            this.lsbAutos.Size = new System.Drawing.Size(249, 346);
            this.lsbAutos.TabIndex = 0;
            this.lsbAutos.SelectedIndexChanged += new System.EventHandler(this.lsbAutos_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnVender);
            this.groupBox2.Controls.Add(this.btnAlquilar);
            this.groupBox2.Controls.Add(this.lsbAutosSubasta);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(673, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 506);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de Autos en Subasta";
            // 
            // btnVender
            // 
            this.btnVender.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnVender.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.Location = new System.Drawing.Point(285, 372);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(219, 47);
            this.btnVender.TabIndex = 11;
            this.btnVender.Text = "Mover a Venta";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnAlquilar
            // 
            this.btnAlquilar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAlquilar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnAlquilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlquilar.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlquilar.Location = new System.Drawing.Point(18, 372);
            this.btnAlquilar.Name = "btnAlquilar";
            this.btnAlquilar.Size = new System.Drawing.Size(215, 47);
            this.btnAlquilar.TabIndex = 10;
            this.btnAlquilar.Text = "Mover a Alquiler";
            this.btnAlquilar.UseVisualStyleBackColor = true;
            this.btnAlquilar.Click += new System.EventHandler(this.btnAlquilar_Click);
            // 
            // lsbAutosSubasta
            // 
            this.lsbAutosSubasta.FormattingEnabled = true;
            this.lsbAutosSubasta.ItemHeight = 19;
            this.lsbAutosSubasta.Location = new System.Drawing.Point(18, 35);
            this.lsbAutosSubasta.Name = "lsbAutosSubasta";
            this.lsbAutosSubasta.Size = new System.Drawing.Size(486, 308);
            this.lsbAutosSubasta.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(453, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Seleccione un Auto de la lista para ponerlo en Subasta\r\n";
            // 
            // Subasta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MotorsForm.Properties.Resources.Background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1283, 682);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Subasta";
            this.Text = "g";
            this.Load += new System.EventHandler(this.Subasta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVInicial)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSubastar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbAutos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnAlquilar;
        private System.Windows.Forms.ListBox lsbAutosSubasta;
        private System.Windows.Forms.NumericUpDown txtVInicial;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label txtPlaca;
        private System.Windows.Forms.Label label5;
    }
}