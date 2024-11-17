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

        public void LimpiarForm()
        {
            this.toolStripContainer1.ContentPanel.Controls.Clear();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.MdiParent = this;
            this.toolStripContainer1.ContentPanel.Controls.Clear();
            this.toolStripContainer1.ContentPanel.Controls.Add(registro);
            registro.Show();
        }

        private void verFlotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flota flota = new Flota
            {
                MdiParent = this
            };
            LimpiarForm();
            this.toolStripContainer1.ContentPanel.Controls.Add(flota);
            flota.Show();
        }

        private void solicitudesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LimpiarForm();
            Solicitudes_Primero solicitud = new Solicitudes_Primero();
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

        private void alquilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler
            {
                MdiParent = this
            };
            LimpiarForm();
            this.toolStripContainer1.ContentPanel.Controls.Add(alquiler);
            alquiler.Show();
        }

        private void subastaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            Subasta subasta = new Subasta
            {
                MdiParent = this
            };
            this.toolStripContainer1.ContentPanel.Controls.Add(subasta);
            subasta.Show();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            Venta venta = new Venta
            {
                MdiParent = this
            };
            this.toolStripContainer1.ContentPanel.Controls.Add(venta);
            venta.Show();
        }
    }
}
