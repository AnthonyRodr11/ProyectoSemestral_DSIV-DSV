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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using Mysqlx;

namespace MotorsForm
{
    public partial class Registro : Form
    {

        CarroService carroService;
        Herramientas herra = new Herramientas();

        private string ruta;
        public Registro()
        {
            InitializeComponent();
            carroService = new CarroService();
        }


        private async void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (validarCampos() != true)
            {
                var auto = new CarroFlotaRequest()
                {
                    placa = txtPlaca.Text,
                    marca = txtMarca.Text,
                    modelo = txtModelo.Text,
                    color = txtColor.Text,
                    km = Convert.ToDouble(txtKm.Text),
                    transmision = cmbTransmision.Text,
                    tipo_gas = cmbCombustible.Text,
                    carroceria = cmbCarroceria.Text,
                    estado = cmbEstado.Text,
                    descripcion = txtDescripcion.Text,
                    foto = obtenerRuta()
                };

                var respuesta = await carroService.enviarEspecs(auto);

                if (respuesta.code == 200)
                {
                    MessageBox.Show("Se ingreso correctamente el Auto", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtColor.Clear();
                    txtDescripcion.Clear();
                    txtMarca.Clear();
                    txtModelo.Clear();
                    txtPlaca.Clear();
                    txtKm.Value = 0;
                    cmbCarroceria.SelectedIndex = -1;
                    cmbCombustible.SelectedIndex = -1;
                    cmbEstado.SelectedIndex = -1;
                    cmbTransmision.SelectedIndex = -1;
                    pcbImgGuardar.Image = null;
                    pcbImgGuardar.Image = Properties.Resources._5798294;
                }
                else
                {
                    MessageBox.Show("Hubo erro al ingresar el Auto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                

            }
            else
            {   
                MessageBox.Show("Debe Ingresar los datos del Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Metodo para validar que los campos esten llenos
        public bool validarCampos()
        {

            bool dañado = false;

            //validar TextBox
            if (String.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("Debe Ingresar la marca del Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return dañado = true;
            }

            if (String.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("Debe Ingresar el Modelo del Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dañado = true;
            }
            if (String.IsNullOrEmpty(txtPlaca.Text))
            {
                MessageBox.Show("Debe Ingresar la Placa del Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dañado = true;
            }
            if (String.IsNullOrEmpty(txtColor.Text))
            {
                MessageBox.Show("Debe Ingresar el Color del Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dañado = true;
            }
            if (String.IsNullOrEmpty(txtKm.Text))
            {
                MessageBox.Show("Debe Ingresar el Kilimetraje del Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dañado = true;
            }
            if (cmbTransmision.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar un tipo de transmision para el Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dañado = true;
            }
            if (cmbCombustible.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar un tipo de combustible para el Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dañado = true;
            }
            if (cmbCarroceria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar un tipo de Carroceria para el Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dañado = true;
            }
            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Debe Ingresar la descripcion del Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el estado del Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dañado = true;
            }
            //validamos que la ruta no este vacia o nula
            if (string.IsNullOrEmpty(ruta))
            {
                MessageBox.Show("Debe Seleccionar una imagen del Auto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dañado = true;

            }
            return dañado;

        }



        //Metodo para guardar la ruta
        public string obtenerRuta()
        {
            return ruta;
        }

        //metodo para asignar la ruta
        public void asignarRuta(string dirreccion)
        {
            ruta = dirreccion;
        }

        private void pcbImgGuardar_Click(object sender, EventArgs e)
        {
            ofdGuardarImg.InitialDirectory = @"C:\";
            ofdGuardarImg.Title = "Seleccionar imagen";

            if (ofdGuardarImg.ShowDialog() == DialogResult.OK)
            {
                // Ruta completa de la imagen seleccionada
                string rutaImagenOriginal = ofdGuardarImg.FileName;

                // Nombre del archivo de la imagen
                string nombreImagen = Path.GetFileName(rutaImagenOriginal);

                string rutaloca = "../../../MotorsValueWeb/Img";


                // Ruta absoluta para guardar la imagen en la carpeta Img del proyecto
                string directorioImg = Path.GetFullPath(rutaloca);
                string rutaDestino = Path.Combine(directorioImg, nombreImagen);

                try
                {
                    // Verificar si la carpeta Img existe, si no, crearla
                    if (!Directory.Exists(directorioImg))
                    {
                        Directory.CreateDirectory(directorioImg);
                    }

                    // Copiar la imagen al directorio destino
                    File.Copy(rutaImagenOriginal, rutaDestino, true);

                    // Mantener la ruta relativa para la base de datos
                    ruta = @"../Img/" + nombreImagen;
                    asignarRuta(ruta);

                    // Mostrar la imagen en el PictureBox
                    pcbImgGuardar.Image = Image.FromFile(rutaDestino);

                    MessageBox.Show("Imagen cargada y guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
