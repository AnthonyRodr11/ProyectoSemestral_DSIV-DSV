using MotorsForm.Services;
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
    public partial class Login : Form
    {
        UserServices userServices;
        public Login()
        {
            InitializeComponent();
            userServices = new UserServices();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                string correo = txtCorreo.Text;
                string password = txtPassword.Text;
                var respuesta = await userServices.ObtenerAcceso(correo, password);
                if (respuesta == 1 || respuesta == 2) {
                    Home home = new Home();
                    if (respuesta == 1) {
                        MessageBox.Show("Bienvenido Admin");
                        this.Hide();
                        home.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bienvenido Vendedor");
                        this.Hide();
                        home.Show();
                    }
                    
                }
                else
                {
                    MessageBox.Show("El usuario no esta autorizado");
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos para iniciar sesión");
            }
            
            
        }
    }
}
