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

namespace MotorsForm.Menu_Strip
{
    public partial class Subasta : Form
    {
        Herramientas herra = new Herramientas();
        SubastaService subastaService = new SubastaService();
        public Subasta()
        {
            InitializeComponent();
            // Inicializar los DateTimePicker con la fecha actual
            dtpFinal.MinDate = DateTime.Now;
            dtpInicial.MinDate = DateTime.Now;
            dtpFinal.Value = dtpFinal.Value.AddDays(1);

            dtpInicial.ValueChanged += ValidarFechas;
            dtpFinal.ValueChanged += ValidarFechas;
        }

        private void txtVInicial_Leave_1(object sender, EventArgs e)
        {
            herra.ValidarNumeric(txtVInicial, "No se permiten valores menores o iguales a cero");
        }

        
        private async void btnSubastar_Click(object sender, EventArgs e)
        {
            

            if ((txtPlaca.Text != null || txtPlaca.Text != "") && !(txtVInicial.Value <= 0))
            {
                var subasta = new SubastaRequest()
                {
                    id_placa = txtPlaca.Text,
                    valor_inicial = Convert.ToDouble(txtVInicial.Value),
                    t_inicio = dtpInicial.Value,
                    t_final = dtpFinal.Value,
                };

                if (lsbAutos.SelectedItem != null)
                {
                    var seleccionado = lsbAutos.SelectedItem.GetType().GetProperty("Data")?.GetValue(lsbAutos.SelectedItem);

                    if (seleccionado is ValueTuple<string, string> datosTuple)
                    {
                        if (datosTuple.Item2.Equals("venta"))
                        {
                            subastaService.EliminarDeVentas(datosTuple.Item1);
                        }
                        var respuesta = await subastaService.EnviarNuevaSubasta(subasta);
                        if (respuesta.code == 200)
                        {
                            await subastaService.ActualizarEstado(new SubastaRequest() { id_placa = datosTuple.Item1 }, "subasta");
                        }
                    }
                }
                MessageBox.Show("Carro Agregado a Subasta con éxito","Que bien!");
                txtPlaca.ResetText();
                CargarListBoxAutosAsync();
            }
            else
            {
                MessageBox.Show("Llene todos los campos", "Error en Cayo Perico");
            }

            
        }

        private async Task CargarListBoxAutosAsync()
        {
            // Obtener los datos asincrónicamente
            var carritos = await subastaService.RecibirCarros();

            lsbAutos.Items.Clear();

            foreach (var c in carritos)
            {
                lsbAutos.Items.Add(new { Display = (c.marca, c.modelo), Data = (c.placa, c.estado) });
            }

            lsbAutos.DisplayMember = "Display";

            var autitos = await subastaService.RecibirCarrosSubasta();

            lsbAutosSubasta.Items.Clear();

            foreach (var c in autitos)
            {
                lsbAutosSubasta.Items.Add(new { Display = (c.marca, c.modelo), Data = (c.placa, c.estado) });
            }

            lsbAutosSubasta.DisplayMember = "Display";
        }

        private void Subasta_Load(object sender, EventArgs e)
        {
            CargarListBoxAutosAsync();
            
        }

        private async void lsbAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbAutos.SelectedItem != null)
            {
                var seleccionado = lsbAutos.SelectedItem;
                var data = seleccionado.GetType().GetProperty("Data")?.GetValue(seleccionado);

                if (data is ValueTuple<string, string> datosTuple)
                {
                    txtPlaca.Text = datosTuple.Item1; // La placa
                }
            }

            
        }

        private async void btnAlquilar_Click(object sender, EventArgs e)
        {
            if (lsbAutosSubasta.SelectedItem != null)
            {
                var seleccionado = lsbAutosSubasta.SelectedItem.GetType().GetProperty("Data")?.GetValue(lsbAutosSubasta.SelectedItem);

                if (seleccionado is ValueTuple<string, string> TuplaDatos)
                {
                    await subastaService.ActualizarEstado(new SubastaRequest() { id_placa = TuplaDatos.Item1 }, "alquiler");

                    subastaService.EliminarDeSubasta(TuplaDatos.Item1);
                }
            }
            CargarListBoxAutosAsync();
        }

        private async void btnVender_Click(object sender, EventArgs e)
        {
            if (lsbAutosSubasta.SelectedItem != null)
            {
                CargarListBoxAutosAsync();
                // Obtener los datos seleccionados
                var seleccionado = lsbAutosSubasta.SelectedItem.GetType().GetProperty("Data")?.GetValue(lsbAutosSubasta.SelectedItem);

                if (seleccionado is ValueTuple<string, string> TuplaDatos)
                {
                    string placa = TuplaDatos.Item1;

                    // Actualizar estado
                    await subastaService.ActualizarEstado(new SubastaRequest() { id_placa = placa }, "venta");

                    // Eliminar de subasta
                    subastaService.EliminarDeSubasta(placa);

                    // Crear nueva venta
                    subastaService.NuevaVenta(placa);

                    // Actualizar los ListBox
                    await CargarListBoxAutosAsync();
                }
            }
        }


        private void ValidarFechas(object sender, EventArgs e)
        {
            if (dtpInicial.Value >= dtpFinal.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.", "Validación de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Corregir la inconsistencia si se detecta
                if (sender == dtpFinal)
                {
                    dtpFinal.Value = dtpInicial.Value.AddDays(1); // Ajusta hacia adelante un día
                }
                else if (sender == dtpInicial)
                {
                    try
                    {
                        dtpInicial.Value = dtpFinal.Value.AddDays(-1); // Ajusta hacia atrás un día
                    }
                    catch(ArgumentOutOfRangeException) { dtpFinal.Value = dtpInicial.Value.AddDays(1); }
                    
                }
            }
        }
    }
}
