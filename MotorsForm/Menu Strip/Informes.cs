using MotorsForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorsForm.Menu_Strip
{
    public partial class Informes : Form
    {

        private InformesService archivos = new InformesService();
        private NotifyIcon notificacion;

        public Informes()
        {
            InitializeComponent();

            // Inicializa el NotifyIcon
            notificacion = new NotifyIcon
            {
                Icon = SystemIcons.Information, 
                Visible = true // Haz que sea visible en la bandeja del sistema
            };
        }

        private async void btnFlota_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Informacion de la Flota  de Autos", "Contenido a Generar:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Se abre el SaveFileDialog
                SaveFileDialog guardar = new SaveFileDialog();
                //solo archivos .txt
                guardar.Filter = "csv|*.csv";
                guardar.Title = "Guardando Informe de FLota";
                guardar.ShowDialog();


                //validamos que la ruta no sea nula o vacia
                if (guardar.FileName != "" || guardar.FileName != null)
                {
                    string[] datos = await archivos.obtenerFlotaInfo();

                    //escribimos el archivo

                    using (StreamWriter saveArchivo = new StreamWriter(guardar.FileName, false, Encoding.UTF8))
                    {

                        saveArchivo.WriteLine("Placa;Marca;Modelo;Color;KM;Transmision;Tipo Gas;Carroceria");

                        foreach (var linea in datos)
                        {
                            saveArchivo.WriteLine(linea);
                        }
                    }

                    notificacion.ShowBalloonTip(1000, "Archivo Guardado", "El informe de la flota se guardó correctamente.", ToolTipIcon.Info);
                }
                else
                {

                    MessageBox.Show("Ruta vacia o nula, Seleccione una ruta valida", "Guardar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {

                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btnVentas_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Informacion de Ventas de Autos", "Contenido a Generar:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Se abre el SaveFileDialog
                SaveFileDialog guardar = new SaveFileDialog();
                //solo archivos .txt
                guardar.Filter = "csv|*.csv";
                guardar.Title = "Guardando Informe de Ventas";
                guardar.ShowDialog();


                //validamos que la ruta no sea nula o vacia
                if (guardar.FileName != "" || guardar.FileName != null)
                {
                    string[] datos = await archivos.obtenerVentaInfo();

                    //escribimos el archivo

                    using (StreamWriter saveArchivo = new StreamWriter(guardar.FileName, false, Encoding.UTF8))
                    {

                        saveArchivo.WriteLine("Codigo Venta;Nombre;F.Compra;Placa;Total");

                        foreach (var linea in datos)
                        {
                            saveArchivo.WriteLine(linea);
                        }
                    }

                    notificacion.ShowBalloonTip(1000, "Archivo Guardado", "El informe de Venta se guardó correctamente.", ToolTipIcon.Info);
                }
                else
                {

                    MessageBox.Show("Ruta vacia o nula, Seleccione una ruta valida", "Guardar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAlquiler_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Informacion de Alquiler de Autos", "Contenido a Generar:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Se abre el SaveFileDialog
                SaveFileDialog guardar = new SaveFileDialog();
                //solo archivos .txt
                guardar.Filter = "csv|*.csv";
                guardar.Title = "Guardando Informe de Alquiler";
                guardar.ShowDialog();


                //validamos que la ruta no sea nula o vacia
                if (guardar.FileName != "" || guardar.FileName != null)
                {
                    string[] datos = await archivos.obtenerAlquilerInfo();

                    //escribimos el archivo

                    using (StreamWriter saveArchivo = new StreamWriter(guardar.FileName, false, Encoding.UTF8))
                    {

                        saveArchivo.WriteLine("CodigoAlquiler;Placa;ID Usuario;TipoTarifa;F.Retiro;F.Entrega;Total");

                        foreach (var linea in datos)
                        {
                            saveArchivo.WriteLine(linea);
                        }
                    }

                    notificacion.ShowBalloonTip(1000, "Archivo Guardado", "El informe de Alquiler se guardó correctamente.", ToolTipIcon.Info);
                }
                else
                {

                    MessageBox.Show("Ruta vacia o nula, Seleccione una ruta valida", "Guardar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSubasta_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Informacion de Subasta de Autos", "Contenido a Generar:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Se abre el SaveFileDialog
                SaveFileDialog guardar = new SaveFileDialog();
                //solo archivos .txt
                guardar.Filter = "csv|*.csv";
                guardar.Title = "Guardando Informe de Subastas";
                guardar.ShowDialog();


                //validamos que la ruta no sea nula o vacia
                if (guardar.FileName != "" || guardar.FileName != null)
                {
                    string[] datos = await archivos.obtenerSubastaInfo();

                    //escribimos el archivo

                    using (StreamWriter saveArchivo = new StreamWriter(guardar.FileName, false, Encoding.UTF8))
                    {

                        saveArchivo.WriteLine("CodigoSubasta;ValorInicial;Placa;ValorPuja;IdUsuario;Nombre;Apellido;estado;T.Inicial;T.Final");

                        foreach (var linea in datos)
                        {
                            saveArchivo.WriteLine(linea);
                        }
                    }

                    notificacion.ShowBalloonTip(1000, "Archivo Guardado", "El informe de Subasta se guardó correctamente.", ToolTipIcon.Info);
                }
                else
                {

                    MessageBox.Show("Ruta vacia o nula, Seleccione una ruta valida", "Guardar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSolicitudes_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Informacion de Solicitud", "Contenido a Generar:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Se abre el SaveFileDialog
                SaveFileDialog guardar = new SaveFileDialog();
                //solo archivos .txt
                guardar.Filter = "csv|*.csv";
                guardar.Title = "Guardando Informe de Solicitudes";
                guardar.ShowDialog();


                //validamos que la ruta no sea nula o vacia
                if (guardar.FileName != "" || guardar.FileName != null)
                {
                    string[] datos = await archivos.obtenerSolicitudesInfo();

                    //escribimos el archivo

                    using (StreamWriter saveArchivo = new StreamWriter(guardar.FileName, false, Encoding.UTF8))
                    {

                        saveArchivo.WriteLine("CodigoSolicitud;Nombre;Estado;F.Solicitud;Monto");

                        foreach (var linea in datos)
                        {
                            saveArchivo.WriteLine(linea);
                        }
                    }

                    notificacion.ShowBalloonTip(1000, "Archivo Guardado", "El informe de Solicitud se guardó correctamente.", ToolTipIcon.Info);
                }
                else
                {

                    MessageBox.Show("Ruta vacia o nula, Seleccione una ruta valida", "Guardar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
