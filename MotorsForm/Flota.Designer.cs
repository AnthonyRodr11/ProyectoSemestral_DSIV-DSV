namespace MotorsForm
{
    partial class Flota
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lsvCarros = new System.Windows.Forms.ListView();
            this.Foto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Marca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Modelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Carroceria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kilometraje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Color = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Placa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Estado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::MotorsForm.Properties.Resources.wheel;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(98, 132);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 75);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(201, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "FLOTA";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::MotorsForm.Properties.Resources.Logo_MV;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(1564, 18);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(342, 177);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // lsvCarros
            // 
            this.lsvCarros.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lsvCarros.BackgroundImage = global::MotorsForm.Properties.Resources.Background1;
            this.lsvCarros.BackgroundImageTiled = true;
            this.lsvCarros.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Foto,
            this.Marca,
            this.Modelo,
            this.Carroceria,
            this.Kilometraje,
            this.Color,
            this.Descripcion,
            this.Placa,
            this.Estado});
            this.lsvCarros.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvCarros.ForeColor = System.Drawing.SystemColors.Info;
            this.lsvCarros.GridLines = true;
            this.lsvCarros.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvCarros.HideSelection = false;
            this.lsvCarros.Location = new System.Drawing.Point(98, 228);
            this.lsvCarros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lsvCarros.Name = "lsvCarros";
            this.lsvCarros.Size = new System.Drawing.Size(1740, 755);
            this.lsvCarros.TabIndex = 9;
            this.lsvCarros.UseCompatibleStateImageBehavior = false;
            // 
            // Foto
            // 
            this.Foto.Text = "Foto";
            this.Foto.Width = 105;
            // 
            // Marca
            // 
            this.Marca.Text = "Marca";
            this.Marca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Marca.Width = 100;
            // 
            // Modelo
            // 
            this.Modelo.Text = "Modelo";
            this.Modelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Modelo.Width = 100;
            // 
            // Carroceria
            // 
            this.Carroceria.Text = "Carroceria";
            this.Carroceria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Carroceria.Width = 100;
            // 
            // Kilometraje
            // 
            this.Kilometraje.Text = "Kilometraje";
            this.Kilometraje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Kilometraje.Width = 217;
            // 
            // Color
            // 
            this.Color.Text = "Color";
            this.Color.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Color.Width = 100;
            // 
            // Descripcion
            // 
            this.Descripcion.Text = "Descripcion";
            this.Descripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Descripcion.Width = 217;
            // 
            // Placa
            // 
            this.Placa.Text = "Placa";
            this.Placa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Placa.Width = 100;
            // 
            // Estado
            // 
            this.Estado.Text = "Estado";
            this.Estado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Estado.Width = 100;
            // 
            // Flota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MotorsForm.Properties.Resources.Background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1049);
            this.Controls.Add(this.lsvCarros);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Flota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flota";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListView lsvCarros;
        private System.Windows.Forms.ColumnHeader Foto;
        private System.Windows.Forms.ColumnHeader Marca;
        private System.Windows.Forms.ColumnHeader Modelo;
        private System.Windows.Forms.ColumnHeader Carroceria;
        private System.Windows.Forms.ColumnHeader Kilometraje;
        private System.Windows.Forms.ColumnHeader Color;
        private System.Windows.Forms.ColumnHeader Descripcion;
        private System.Windows.Forms.ColumnHeader Placa;
        private System.Windows.Forms.ColumnHeader Estado;
    }
}