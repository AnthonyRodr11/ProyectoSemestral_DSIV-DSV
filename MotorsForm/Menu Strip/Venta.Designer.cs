namespace MotorsForm.Menu_Strip
{
    partial class Venta
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
            this.lblMatricula = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.NumericUpDown();
            this.btnVender = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbVender = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtPrecioSubasta = new System.Windows.Forms.NumericUpDown();
            this.btnAlquilar = new System.Windows.Forms.Button();
            this.btnSubastar = new System.Windows.Forms.Button();
            this.lsbVenta = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioSubasta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblMatricula);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.btnVender);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lsbVender);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(85, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 549);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vender Nuevo Auto";
            // 
            // lblMatricula
            // 
            this.lblMatricula.BackColor = System.Drawing.Color.White;
            this.lblMatricula.ForeColor = System.Drawing.Color.Black;
            this.lblMatricula.Location = new System.Drawing.Point(311, 130);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(188, 26);
            this.lblMatricula.TabIndex = 7;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(311, 276);
            this.txtPrecio.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(188, 27);
            this.txtPrecio.TabIndex = 6;
            this.txtPrecio.ThousandsSeparator = true;
            this.txtPrecio.Leave += new System.EventHandler(this.numericUpDown1_Leave);
            // 
            // btnVender
            // 
            this.btnVender.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnVender.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.Location = new System.Drawing.Point(305, 431);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(194, 42);
            this.btnVender.TabIndex = 5;
            this.btnVender.Text = "Vender Auto";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Precio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matrícula";
            // 
            // lsbVender
            // 
            this.lsbVender.FormattingEnabled = true;
            this.lsbVender.ItemHeight = 19;
            this.lsbVender.Location = new System.Drawing.Point(36, 46);
            this.lsbVender.Name = "lsbVender";
            this.lsbVender.Size = new System.Drawing.Size(237, 441);
            this.lsbVender.TabIndex = 0;
            this.lsbVender.SelectedIndexChanged += new System.EventHandler(this.lsbVender_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblValor);
            this.groupBox2.Controls.Add(this.txtPrecioSubasta);
            this.groupBox2.Controls.Add(this.btnAlquilar);
            this.groupBox2.Controls.Add(this.btnSubastar);
            this.groupBox2.Controls.Add(this.lsbVenta);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(662, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 549);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de Autos en Venta";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(52, 363);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(105, 19);
            this.lblValor.TabIndex = 8;
            this.lblValor.Text = "Valor inicial";
            this.lblValor.Visible = false;
            // 
            // txtPrecioSubasta
            // 
            this.txtPrecioSubasta.Location = new System.Drawing.Point(56, 385);
            this.txtPrecioSubasta.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.txtPrecioSubasta.Name = "txtPrecioSubasta";
            this.txtPrecioSubasta.Size = new System.Drawing.Size(188, 27);
            this.txtPrecioSubasta.TabIndex = 8;
            this.txtPrecioSubasta.ThousandsSeparator = true;
            this.txtPrecioSubasta.Visible = false;
            // 
            // btnAlquilar
            // 
            this.btnAlquilar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAlquilar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnAlquilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlquilar.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlquilar.Location = new System.Drawing.Point(290, 431);
            this.btnAlquilar.Name = "btnAlquilar";
            this.btnAlquilar.Size = new System.Drawing.Size(194, 42);
            this.btnAlquilar.TabIndex = 7;
            this.btnAlquilar.Text = "Mover a Alquiler";
            this.btnAlquilar.UseVisualStyleBackColor = true;
            this.btnAlquilar.Click += new System.EventHandler(this.btnAlquilar_Click);
            // 
            // btnSubastar
            // 
            this.btnSubastar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnSubastar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSubastar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubastar.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubastar.Location = new System.Drawing.Point(56, 431);
            this.btnSubastar.Name = "btnSubastar";
            this.btnSubastar.Size = new System.Drawing.Size(194, 42);
            this.btnSubastar.TabIndex = 6;
            this.btnSubastar.Text = "Mover a Subasta";
            this.btnSubastar.UseVisualStyleBackColor = true;
            this.btnSubastar.Click += new System.EventHandler(this.btnSubastar_Click);
            this.btnSubastar.MouseEnter += new System.EventHandler(this.btnSubastar_MouseEnter);
            // 
            // lsbVenta
            // 
            this.lsbVenta.FormattingEnabled = true;
            this.lsbVenta.ItemHeight = 19;
            this.lsbVenta.Location = new System.Drawing.Point(56, 46);
            this.lsbVenta.Name = "lsbVenta";
            this.lsbVenta.Size = new System.Drawing.Size(428, 289);
            this.lsbVenta.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(413, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(436, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Seleccione un Auto de la lista para ponerlo en Venta";
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MotorsForm.Properties.Resources.Background1;
            this.ClientSize = new System.Drawing.Size(1283, 682);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Venta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.Venta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioSubasta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbVender;
        private System.Windows.Forms.Button btnAlquilar;
        private System.Windows.Forms.Button btnSubastar;
        private System.Windows.Forms.ListBox lsbVenta;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.NumericUpDown txtPrecio;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.NumericUpDown txtPrecioSubasta;
        private System.Windows.Forms.Label label3;
    }
}