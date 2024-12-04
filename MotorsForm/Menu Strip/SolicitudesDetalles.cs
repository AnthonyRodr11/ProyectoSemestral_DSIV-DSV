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
    public partial class SolicitudesDetalles : Form
    {
        Herramientas herra = new Herramientas();

        SolicitudService solici = new SolicitudService();

        public int solicitoId;
        public SolicitudesDetalles(int id_solicitud)
        {
            InitializeComponent();

            _ = cargarDetalles(id_solicitud); // Cargar los detalles de forma asíncrona


            // Configuración de botones y borde del formulario
            this.FormBorderStyle = FormBorderStyle.Sizable; // Habilita borde con capacidad de cambiar tamaño
            this.ControlBox = true;                        // Habilita los botones de control (cerrar, minimizar, maximizar)
            this.MinimizeBox = true;                       // Habilita el botón minimizar
            this.MaximizeBox = true;                       // Habilita el botón maximizar
            this.StartPosition = FormStartPosition.CenterScreen; // Opcional: Centrar la ventana al abrir

            solicitoId = id_solicitud;
        }

        //metodo para cargar el monto, nombre y descripcion
        public async Task cargarDetalles(int solicitud)
        {
            lblNombre.Text = await solici.obtenerNombre(solicitud);

            // Obtener el monto como double y formatearlo como moneda
            double monto = await solici.obtenerMonto(solicitud);
            lblMonto.Text = monto.ToString();

            lblDescripcion.Text = await solici.obtenerDescripcion(solicitud);
        }


        //Boton para aceptar solicitud
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {   
                
                int result = await solici.aceptar(solicitoId);

                if (result == 1)
                {
                    MessageBox.Show("La solicitud ha sido aceptada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al aceptar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //boton para rechazar solicitud
        private async void btnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                int result = await solici.rechazar(solicitoId);

                if (result == 1)
                {
                    MessageBox.Show("La solicitud ha sido rechazada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al rechazar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
