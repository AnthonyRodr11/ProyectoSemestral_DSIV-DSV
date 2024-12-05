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



        private async void btnEditar_Click(object sender, EventArgs e)
        {
            // Validar selección de tipo de auto
            if (cmbTipoAuto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de auto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar tarifa ingresada
            if (!double.TryParse(txtTarifaEdit.Text, out double tarifaNueva) || tarifaNueva <= 0)
            {
                MessageBox.Show("Debe ingresar una tarifa válida mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                dynamic seleccionado = cmbTipoAuto.SelectedItem;
                if (seleccionado.Data is ValueTuple<double, int> datos)
                {
                    int id_tipo = datos.Item2;

                    // Enviar nueva tarifa
                    await carrin.enviarNuevaTarifa(id_tipo, new TarifasAlquilerRequest { tarifaxauto = tarifaNueva });
                    MessageBox.Show("Tarifa actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarTarifas();
                }
                else
                {
                    MessageBox.Show("Error al procesar el elemento seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.cargarListBoxAutos();
        }


        private async Task cargarListBoxAutos()
        {

            var autitos = await carrin.RecibirCarrosAlquiler();

            lsblistAlquiler.Items.Clear();
            lsbEspera.Items.Clear();

            foreach (var c in autitos)
            {
                lsblistAlquiler.Items.Add(new { Display = (c.marca, c.modelo), Data = (c.placa, c.estado) });
            }

            lsblistAlquiler.DisplayMember = "Display";

            autitos = await carrin.RecibirCarros();

            foreach(var c in autitos)
            {
                lsbEspera.Items.Add(new { Display = (c.marca, c.modelo), Data = (c.placa, c.estado) });
            }

            lsbEspera.DisplayMember = "Display";

        }

        private async void btnVenta_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un elemento
            if (lsblistAlquiler.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un auto de la lista para moverlo a venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSubastaAdd.Value == 0) 
            {
                MessageBox.Show("Debe poner un precio minimo para moverlo a venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener los datos seleccionados
                var seleccionado = lsblistAlquiler.SelectedItem.GetType().GetProperty("Data")?.GetValue(lsblistAlquiler.SelectedItem);

                if (seleccionado is ValueTuple<string, string> TuplaDatos)
                {
                    string placa = TuplaDatos.Item1;
                    double precio = Convert.ToDouble(txtSubastaAdd.Value);

                    // Actualizar el estado del auto a "venta"
                    await carrin.actualizarEstado(new AlquilerRecue { id_vehiculo = placa }, "venta");

                    // Crear una nueva venta
                    carrin.nuevaVenta(placa, precio);

                    // Actualizar los ListBox
                    await cargarListBoxAutos();

                    MessageBox.Show("El auto ha sido movido correctamente a venta.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al procesar el elemento seleccionado. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private async void btnMoverSubasta_Click(object sender, EventArgs e)
        {
            if (lsblistAlquiler.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un auto de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSubastaAdd.Value <= 0)
            {
                MessageBox.Show("Debe ingresar un valor inicial válido para la subasta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var seleccionado = lsblistAlquiler.SelectedItem.GetType().GetProperty("Data")?.GetValue(lsblistAlquiler.SelectedItem);
                if (seleccionado is ValueTuple<string, string> TuplaDatos)
                {
                    await carrin.enviarNuevaSubasta(new SubastaRequest
                    {
                        id_placa = TuplaDatos.Item1,
                        valor_inicial = Convert.ToDouble(txtSubastaAdd.Value)
                    });
                    await carrin.actualizarEstado(new AlquilerRecue { id_vehiculo = TuplaDatos.Item1 }, "subasta");
                    MessageBox.Show("El auto se movió a subasta correctamente.", "Éxito");
                    await cargarListBoxAutos();
                }
                else
                {
                    MessageBox.Show("Error al procesar el elemento seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgragar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipoAuto.Text))
            {
                MessageBox.Show("Debe ingresar un tipo de auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtTarifaAdd.Value <= 0)
            {
                MessageBox.Show("Debe ingresar una tarifa diaria válida mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var nuevoAuto = new TarifasAlquilerRequest
                {
                    tipo_auto = txtTipoAuto.Text,
                    tarifaxauto = Convert.ToDouble(txtTarifaAdd.Value)
                };

                var respuesta = await carrin.nuevaTarifa(nuevoAuto);
                if (respuesta.code == 200)
                {
                    MessageBox.Show("Nuevo tipo de auto agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTipoAuto.Clear();
                    txtTarifaAdd.Value = 0;
                    cargarTarifas();
                }
                else
                {
                    MessageBox.Show($"Error al agregar: {respuesta.mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAlquilar_Click(object sender, EventArgs e)
        {
            if (lsbEspera.SelectedItem != null)
            {
                var seleccionado = lsbEspera.SelectedItem.GetType().GetProperty("Data")?.GetValue(lsbEspera.SelectedItem);

                if (seleccionado is ValueTuple<string, string> TuplaDatos)
                {
                    if(TuplaDatos.Item2 == "subasta")
                    {
                        await carrin.actualizarEstado(new AlquilerRecue() { id_vehiculo = TuplaDatos.Item1 }, "alquiler");

                        carrin.EliminarDeSubasta(TuplaDatos.Item1);

                    }
                    else if(TuplaDatos.Item2 == "venta")
                    {

                        await carrin.actualizarEstado(new AlquilerRecue() { id_vehiculo = TuplaDatos.Item1 }, "alquiler");

                        carrin.EliminarDeVentas(TuplaDatos.Item1);

                        

                    }
                    else
                    {
                        carrin.actualizarEstado(new AlquilerRecue() { id_vehiculo = TuplaDatos.Item1 }, "alquiler");
                    }

                    await cargarListBoxAutos();

                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un auto para continuar", "Despierta, estás en una simulación");
            }
        }
    }



}

    

