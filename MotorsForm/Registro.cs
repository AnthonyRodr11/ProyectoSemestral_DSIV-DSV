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
using MotorsForm.Models;
using MotorsForm.Services;

namespace MotorsForm
{
    public partial class Registro : Form
    {

        CarroService carroService;
        Herramientas herra = new Herramientas();
        public Registro()
        {
            InitializeComponent();
            carroService = new CarroService();
        }

        private void txtMarca_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtMarca);
        }

        private void txtModelo_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtModelo);
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtPlaca);
        }

        private void txtColor_Leave(object sender, EventArgs e)
        {
            herra.ValidarTextBox(txtColor);
        }

        private void txtKm_Leave(object sender, EventArgs e)
        {
            herra.ValidarNumeric(txtKm, "No se permiten kilometrajes menores a cero");
        }

        private void cmbTransmision_Leave(object sender, EventArgs e)
        {
            herra.ValidarComboBox(cmbTransmision);
        }

        private void cmbCombustible_Leave(object sender, EventArgs e)
        {
            herra.ValidarComboBox(cmbCombustible);
        }

        private void cmbCarroceria_Leave(object sender, EventArgs e)
        {
            herra.ValidarComboBox(cmbCarroceria);
        }

        private void cmbEstado_Leave(object sender, EventArgs e)
        {
            herra.ValidarComboBox(cmbEstado);
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            var user = new CarroFlotaRequest()
            {
                marca = txtMarca.Text,
                modelo = txtModelo.Text,
                color = txtColor.Text,
                km = Convert.ToDouble(txtKm.Text),
                transmision = cmbTransmision.Text,
                tipo_gas = cmbCombustible.Text,
                carroceria = cmbCarroceria.Text,
                estado = cmbEstado.Text,
                descripcion = txtDescripcion.Text,
                foto = pictureBox2.ToString()
            };

            var respuesta = await carroService.obtenerEspec(user);
            MessageBox.Show(respuesta.Mensaje, respuesta.Titulo);


        }

    }

}
