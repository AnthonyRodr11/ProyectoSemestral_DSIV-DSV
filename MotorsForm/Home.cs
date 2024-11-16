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

        private void solicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            this.toolStripContainer1.ContentPanel.Controls.Clear();
            this.toolStripContainer1.ContentPanel.Controls.Add(flota);
            flota.Show();
        }

        private void alquilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler
            {
                MdiParent = this
            };
            this.toolStripContainer1.ContentPanel.Controls.Clear();
            this.toolStripContainer1.ContentPanel.Controls.Add(alquiler);
            alquiler.Show();
        }
    }
}
