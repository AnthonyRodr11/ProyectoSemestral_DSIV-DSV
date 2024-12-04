using Microsoft.Win32;
using MotorsForm.Models;
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
    public partial class Solicitudes_Primero : Form
    {
        private SolicitudService solicitudService;

        public Solicitudes_Primero()
        {
            InitializeComponent();
            //inicializamos el obejeto
            solicitudService = new SolicitudService();
        }

        //Metodo para mostrar la lista de solicitudes al abrir la ventana
        private void Solicitudes_Primero_Load(object sender, EventArgs e)
        {
            this.cargarLista();
        }

        // Método para cargar la lista de solicitantes en el ListBox
        public async Task cargarLista()
        {
            try
            {
                List<Solicitud> solicitudes = await solicitudService.obtenerSolicitudes();

                lbsSolicitudes.Items.Clear(); //  limpiar antes de cargar

                foreach (var solicitud in solicitudes)
                {
                    // Modifica esto según lo que quieras mostrar en el ListBox
                    lbsSolicitudes.Items.Add($"{solicitud.id_solicitud} - {solicitud.nombre} {solicitud.apellido} - {solicitud.estado} - {solicitud.f_solicitud} - {solicitud.monto}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (lbsSolicitudes.SelectedItem != null) // Validar que se seleccionó un elemento
            {
                try
                {
                    string seleccion = lbsSolicitudes.SelectedItem.ToString();
                    string[] partes = seleccion.Split('-');
                    int id_solicitud = int.Parse(partes[0].Trim());

                    SolicitudesDetalles detalleSolicitud = new SolicitudesDetalles(id_solicitud);
                    detalleSolicitud.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una solicitud de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
