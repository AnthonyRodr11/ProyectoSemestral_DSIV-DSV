namespace MotorsForm
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.flotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alquilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subastaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitudesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manejoDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flotaToolStripMenuItem,
            this.serviciosToolStripMenuItem,
            this.solicitudesToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.manejoDeUsuariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1283, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // flotaToolStripMenuItem
            // 
            this.flotaToolStripMenuItem.Image = global::MotorsForm.Properties.Resources.car;
            this.flotaToolStripMenuItem.Name = "flotaToolStripMenuItem";
            this.flotaToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
            this.flotaToolStripMenuItem.Text = "Flota";
            // 
            // serviciosToolStripMenuItem
            // 
            this.serviciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventaToolStripMenuItem,
            this.alquilerToolStripMenuItem,
            this.subastaToolStripMenuItem});
            this.serviciosToolStripMenuItem.Image = global::MotorsForm.Properties.Resources.key;
            this.serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            this.serviciosToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.serviciosToolStripMenuItem.Text = "Servicios";
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Image = global::MotorsForm.Properties.Resources.venta;
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ventaToolStripMenuItem.Text = "Venta";
            // 
            // alquilerToolStripMenuItem
            // 
            this.alquilerToolStripMenuItem.Image = global::MotorsForm.Properties.Resources.alquiler;
            this.alquilerToolStripMenuItem.Name = "alquilerToolStripMenuItem";
            this.alquilerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.alquilerToolStripMenuItem.Text = "Alquiler";
            // 
            // subastaToolStripMenuItem
            // 
            this.subastaToolStripMenuItem.Image = global::MotorsForm.Properties.Resources.subasta;
            this.subastaToolStripMenuItem.Name = "subastaToolStripMenuItem";
            this.subastaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.subastaToolStripMenuItem.Text = "Subasta";
            // 
            // solicitudesToolStripMenuItem
            // 
            this.solicitudesToolStripMenuItem.Image = global::MotorsForm.Properties.Resources.solicitud;
            this.solicitudesToolStripMenuItem.Name = "solicitudesToolStripMenuItem";
            this.solicitudesToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.solicitudesToolStripMenuItem.Text = "Solicitudes";
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.Image = global::MotorsForm.Properties.Resources.informe;
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // manejoDeUsuariosToolStripMenuItem
            // 
            this.manejoDeUsuariosToolStripMenuItem.Image = global::MotorsForm.Properties.Resources.usuario;
            this.manejoDeUsuariosToolStripMenuItem.Name = "manejoDeUsuariosToolStripMenuItem";
            this.manejoDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.manejoDeUsuariosToolStripMenuItem.Text = "Manejo de Usuarios";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MotorsForm.Properties.Resources.Home__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1283, 682);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem flotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alquilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subastaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitudesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manejoDeUsuariosToolStripMenuItem;
    }
}