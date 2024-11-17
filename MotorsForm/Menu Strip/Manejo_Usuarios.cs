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

        private void txtMail_Leave(object sender, EventArgs e)
        {
            herra.ValidarTxtMail(txtMail);
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            herra.ValidarTxtMail(txtCorreo);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtName);
        }

        private void txtApel_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtApel);
        }

        private void txtIID_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtIID);
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            herra.ValidarMasked(txtPhone);
            string tel = txtPhone.Text;
            MessageBox.Show(tel);
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtPass);
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            herra.ValidarMasked(txtTelefono);
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtContra);
        }

        private void cmbRol_Leave_1(object sender, EventArgs e)
        {
            herra.ValidarComboBox(cmbRol);
        }
    }
}
