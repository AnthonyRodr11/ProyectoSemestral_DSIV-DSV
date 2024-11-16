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
    public partial class Manejo_Usuarios : Form
    {
        Herramientas herra = new Herramientas();
        public Manejo_Usuarios()
        {
            InitializeComponent();
        }

        private void txtPhone_MouseDown(object sender, MouseEventArgs e)
        {
            herra.InicioDeCadena(txtPhone);
        }

        private void txtTelefono_MouseDown(object sender, MouseEventArgs e)
        {
            herra.InicioDeCadena(txtTelefono);
        }
    }
}
