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
    public partial class Subasta : Form
    {
        Herramientas herra = new Herramientas();
        public Subasta()
        {
            InitializeComponent();
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtPlaca);
        }

        private void txtVInicial_Leave_1(object sender, EventArgs e)
        {
            herra.ValidarNumeric(txtVInicial);
        }

        /*
        private async void btnSubastar_Click(object sender, EventArgs e)
        {
           
        }
        */
    }
}
