using MotorsForm.Models;
using MotorsForm.Resource;
using MotorsForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorsForm.Menu_Strip
{
    public partial class Manejo_Usuarios : Form
    {
        Herramientas herra = new Herramientas();
        UserServices userServices;
        int usuarioId = 0;
        string correo;
        public Manejo_Usuarios()
        {
            InitializeComponent();
            userServices = new UserServices();
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

        private async void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtApel.Text) && !string.IsNullOrEmpty(txtIID.Text) && !string.IsNullOrEmpty(txtMail.Text) && cmbRol.SelectedIndex != -1)
            {
                int rol;

                if (cmbRol.SelectedIndex == 1)
                {
                    rol = 2;
                }
                else
                {
                    rol = 3;
                }

                var user = new RegistroRequest()
                {
                    nombre = txtName.Text,
                    apellido = txtApel.Text,
                    telefono = txtPhone.Text,
                    contraseña = txtPass.Text,
                    correo = txtMail.Text,
                    identificacion = txtIID.Text,
                    rol = rol,
                };

                var respuesta = await userServices.RegistrarUsuario(user);

                if (respuesta == 1)
                {
                    MessageBox.Show("Registro exitoso.");
                    txtName.Clear();
                    txtApel.Clear();
                    txtPhone.Clear();
                    cmbRol.SelectedIndex = -1;
                    txtMail.Clear();
                    txtIID.Clear();
                    txtPass.Clear();
                }
                else
                {
                    MessageBox.Show("Error al registrar usuario.");
                }

            }
            else
            {
                MessageBox.Show("Debe completar todos los campos");
            }
        }

        private async void btnVerificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCorreo.Text))
            {
                var id = await userServices.VerificarCorreo(txtCorreo.Text);

                if (id > 0)
                {
                    MessageBox.Show("Usuario verificado");
                    usuarioId = id;
                    btnEditar.Visible = true;
                    btnEliminar.Visible = true;
                    
                }
                else
                {
                    MessageBox.Show("Correo no encontrado");
                }

            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            gpEditar.Visible = false;
            gpEliminar.Visible = true;
            gpEliminar.BringToFront();
            var usuario = await userServices.ObternerUserInfo(usuarioId);
            
            foreach(var item in usuario)
            {
                lblName.Text = item.nombre.ToString();
                lblApellido.Text = item.apellido.ToString();
                lblTel.Text = item.telefono.ToString();
                lblCorreo.Text = item.correo.ToString();
                correo = item.correo;
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            gpEliminar.Visible = false;
            gpEditar.Visible = true;
            gpEditar.BringToFront();

            var usuario = await userServices.ObternerUserInfo(usuarioId);

            foreach (var item in usuario)
            {
                lblName2.Text = item.nombre;
                correo = item.correo;
            }


        }

        private async void btnCEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContra.Text) || !string.IsNullOrEmpty(txtTelefono.Text))
            {
                UpdateRequest data = null;

                if (string.IsNullOrEmpty(txtContra.Text) && !string.IsNullOrEmpty(txtTelefono.Text))              
                {
                    data = new UpdateRequest()
                    {
                        telefono = txtTelefono.Text,
                        contraseña = null
                    };
                }
                else if(!string.IsNullOrEmpty(txtContra.Text) && string.IsNullOrEmpty(txtTelefono.Text))
                {
                    data = new UpdateRequest()
                    {
                        telefono = null,
                        contraseña = txtContra.Text
                    };
                }
                else
                {
                    data = new UpdateRequest()
                    {
                        telefono = txtTelefono.Text,
                        contraseña = txtContra.Text
                    };
                }

                DialogResult confirmacion = MessageBox.Show($"¿Deseas editar a {lblName2.Text}?", "Confirmar Edicion", MessageBoxButtons.YesNo);
                if (confirmacion == DialogResult.Yes)
                {
                    var response = await userServices.EditarUser(correo, data);

                    if(response > 0)
                    {
                        MessageBox.Show("Edicion completada con exito");
                        txtTelefono.Clear();
                        txtContra.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error");
                    }
                }
            }
            
        }

        private async void btnCEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show($"¿Deseas eliminar a {lblName.Text}?", "Kill Confirm", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                var response = await userServices.EliminarUsuario(correo);

                if (response > 0)
                {
                    MessageBox.Show("Kill completada con exito");
                    gpEliminar.Visible = false;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtCorreo.Clear();
                }
                else
                {
                    MessageBox.Show("Hubo un error");
                }
            }
        }
    }
}
