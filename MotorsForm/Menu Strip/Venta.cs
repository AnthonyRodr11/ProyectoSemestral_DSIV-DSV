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

namespace MotorsForm.Menu_Strip
{
    public partial class Venta : Form
    {
        Herramientas herra = new Herramientas();
        public Venta()
        {
            InitializeComponent();
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            herra.ValidarNumeric(txtPrecio, null);
        }
    }
}
