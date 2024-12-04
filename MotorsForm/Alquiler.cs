using MotorsForm.Models;
using MotorsForm.Resource;
using MotorsForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorsForm
{
    public partial class Alquiler : Form
    {
        CarroService carrin = new CarroService();
        Herramientas herra = new Herramientas();
        public Alquiler()
        {
            InitializeComponent();
            CarroService carrin;
        }

        private void cmbTipoAuto_Leave(object sender, EventArgs e)
        {
            herra.ValidarComboBox(cmbTipoAuto);
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            // Intentar convertir el valor de txtTarifaEdit a double
            if (!double.TryParse(txtTarifaEdit.Text, out double tarifaNueva))
            {
                MessageBox.Show("El valor ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newInfoCage = new TarifasAlquilerRequest
            {
                tarifaxauto = tarifaNueva
            };

            // Validar si hay un elemento seleccionado en cmbTipoAuto
            if (cmbTipoAuto.SelectedItem != null)
            {
                dynamic seleccionado = cmbTipoAuto.SelectedItem; // Usar dinámico para acceder a propiedades anónimas
                if (seleccionado.Data is ValueTuple<double, int> datos)
                {
                    double tarifaxauto = datos.Item1; // Datos del ValueTuple
                    int id_tipo = datos.Item2;

                    // Llamar al método asincrónico
                    var respuesta = await carrin.enviarNuevaTarifa(id_tipo, new TarifasAlquilerRequest() { tarifaxauto = tarifaxauto });

                    // Mostrar el resultado al usuario
                    MessageBox.Show(respuesta.Mensaje, respuesta.Titulo);
                    this.cargarTarifas(); // Recargar tarifas después de editar
                }
                else
                {
                    MessageBox.Show("Error al procesar el elemento seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de auto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        private async void cargarTarifas()
        {
            cmbTipoAuto.Items.Clear(); // Limpiar los elementos anteriores del combo box
            var tarifin = await carrin.obtenerTarifasAll();

            foreach (var tarif in tarifin)
            {
                cmbTipoAuto.Items.Add(new
                {
                    Display = tarif.tipo_auto,
                    Data = (tarif.tarifaxauto, tarif.id_tipo)
                });
            }

            cmbTipoAuto.DisplayMember = "Display"; // Mostrar la propiedad "Display" en el combo box
        }




        private void cmbTipoAuto_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (cmbTipoAuto.SelectedItem != null)
            {
                var seleccionado = cmbTipoAuto.SelectedItem.GetType().GetProperty("Data")?.GetValue(cmbTipoAuto.SelectedItem);
                if (seleccionado is ValueTuple<double, int> datos)
                {
                    txtTarifaEdit.Value = Convert.ToDecimal(datos.Item1);



                }
            }

        }

        private void Alquiler_Load(object sender, EventArgs e)
        {
            this.cargarTarifas();
        }


        private async void cargarListBox()
        {
            cmbTipoAuto.Items.Clear(); // Limpiar los elementos anteriores del combo box
            var tarifin = await carrin.obtenerTarifasAll();

            foreach (var tarif in tarifin)
            {
                cmbTipoAuto.Items.Add(new
                {
                    Display = tarif.tipo_auto,
                    Data = (tarif.tarifaxauto, tarif.id_tipo)
                });
            }

            cmbTipoAuto.DisplayMember = "Display"; // Mostrar la propiedad "Display" en el combo box
        }








    }



}
