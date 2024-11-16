using MotorsForm.Menu_Strip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorsForm
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void flotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            Flota flota = new Flota();
            flota.MdiParent = this;
            this.toolStripContainer1.ContentPanel.Controls.Add(flota);
            flota.Show();
        }

        private void solicitudesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LimpiarForm();
            Solicitudes solicitud = new Solicitudes();
            solicitud.MdiParent = this;
            this.toolStripContainer1.ContentPanel.Controls.Add(solicitud);
            solicitud.Show();
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            Informes solicitud = new Informes();
            solicitud.MdiParent = this;
            this.toolStripContainer1.ContentPanel.Controls.Add(solicitud);
            solicitud.Show();
        }

        private void manejoDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            Manejo_Usuarios solicitud = new Manejo_Usuarios();
            solicitud.MdiParent = this;
            this.toolStripContainer1.ContentPanel.Controls.Add(solicitud);
            solicitud.Show();
        }

        public void LimpiarForm()
        {
            this.toolStripContainer1.ContentPanel.Controls.Clear();
        }

       
    }
}
