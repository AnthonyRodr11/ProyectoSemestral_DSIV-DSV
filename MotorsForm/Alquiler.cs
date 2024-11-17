using MotorsForm.Resource;
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
    public partial class Alquiler : Form
    {
        Herramientas herra = new Herramientas();
        public Alquiler()
        {
            InitializeComponent();
        }

        private void cmbTipoAuto_Leave(object sender, EventArgs e)
        {
            herra.ValidarComboBox(cmbTipoAuto);
        }

        private void txtTarifa_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtTarifa);
        }
    }
}
