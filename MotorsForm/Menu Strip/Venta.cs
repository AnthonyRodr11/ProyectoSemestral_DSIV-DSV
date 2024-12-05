using MotorsForm.Models;
using MotorsForm.Resource;
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

namespace MotorsForm.Menu_Strip
{
    public partial class Venta : Form
    {
        VentaService ventaService = new VentaService();
        Herramientas herra = new Herramientas();
        public Venta()
        {
            InitializeComponent();
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            herra.ValidarNumeric(txtPrecio, null);
        }

        private async void btnVender_Click(object sender, EventArgs e)
        {
            var ventita = new Ventas()
            {
                total = Convert.ToDouble(txtPrecio.Value),
                id_vehiculo = lblMatricula.Text,
            };

            if ((lblMatricula.Text != null && lblMatricula.Text != "") && (!(txtPrecio.Value <= 0)&& txtPrecio.Value != null))
            {
                if (lsbVender.SelectedItem != null)
                {
                    var seleccionado = lsbVender.SelectedItem.GetType().GetProperty("Data")?.GetValue(lsbVender.SelectedItem);

                    if (seleccionado is ValueTuple<string, string> datosTuple)
                    {
                        if (datosTuple.Item2.Equals("subasta"))
                        {
                            ventaService.EliminarDeSubasta(datosTuple.Item1);
                        }

                        var respuesta = await ventaService.EnviarNuevaVenta(ventita);
                        if (respuesta.code == 200)
                        {
                            await ventaService.ActualizarEstado(new SubastaRequest() { id_placa = datosTuple.Item1 }, "venta");
                            MessageBox.Show("Carro Agregado a Venta con éxito", "Que bien!");
                        }
                    }
                }
                CargarListBox();
            }
            else
            {
                MessageBox.Show("Llene todos los campos", "Error en Cayo Perico");
            }
        }

        private async void btnSubastar_Click(object sender, EventArgs e)
        {
            if (lsbVenta.SelectedItem != null)
            {
                var seleccionado = lsbVenta.SelectedItem.GetType().GetProperty("Data")?.GetValue(lsbVenta.SelectedItem);

                if (seleccionado is ValueTuple<string, string> TuplaDatos)
                {
                    

                    if (txtPrecioSubasta.Value > 0)
                    {
                        await ventaService.EnviarNuevaSubasta(new SubastaRequest() { id_placa = TuplaDatos.Item1, valor_inicial = Convert.ToDouble(txtPrecioSubasta.Value) });

                        await ventaService.ActualizarEstado(new SubastaRequest() { id_placa = TuplaDatos.Item1 }, "subasta");

                        ventaService.EliminarDeVentas(TuplaDatos.Item1);

                        CargarListBox();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un valor inicial para la subasta","NonoNO");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un auto para continuar", "Despierta, estás en una simulación");
            }
        }

        private async void btnAlquilar_Click(object sender, EventArgs e)
        {
            if (lsbVenta.SelectedItem != null)
            {
                var seleccionado = lsbVenta.SelectedItem.GetType().GetProperty("Data")?.GetValue(lsbVenta.SelectedItem);

                if (seleccionado is ValueTuple<string, string> TuplaDatos)
                {
                    await ventaService.ActualizarEstado(new SubastaRequest() { id_placa = TuplaDatos.Item1 }, "alquiler");

                    ventaService.EliminarDeVentas(TuplaDatos.Item1);
                    CargarListBox();
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un auto para continuar", "Despierta, estás en una simulación");
            }

        }

        public async Task CargarListBox()
        {
            // Obtener los datos asincrónicamente
            var carritos = await ventaService.RecibirCarros();

            lsbVender.Items.Clear();

            foreach (var c in carritos)
            {
                lsbVender.Items.Add(new { Display = (c.marca, c.modelo), Data = (c.placa, c.estado) });
            }

            lsbVender.DisplayMember = "Display";

            var autitos = await ventaService.RecibirCarrosVenta();

            lsbVenta.Items.Clear();

            foreach (var c in autitos)
            {
                lsbVenta.Items.Add(new { Display = (c.marca, c.modelo), Data = (c.placa, c.estado) });
            }

            lsbVenta.DisplayMember = "Display";

            lblValor.Visible = false;
            txtPrecioSubasta.Visible = false;
            txtPrecio.Value = 0;
            txtPrecioSubasta.ResetText();
            lblMatricula.ResetText();
            lblValor.ResetText();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            CargarListBox();
        }

        private void lsbVender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbVender.SelectedItem != null)
            {
                var seleccionado = lsbVender.SelectedItem;
                var data = seleccionado.GetType().GetProperty("Data")?.GetValue(seleccionado);

                if (data is ValueTuple<string, string> datosTuple)
                {
                    lblMatricula.Text = datosTuple.Item1; // La placa
                }
            }
        }

        private void btnSubastar_MouseEnter(object sender, EventArgs e)
        {
            txtPrecioSubasta.Visible = true;
            lblValor.Visible = true;
        }
    }
}
