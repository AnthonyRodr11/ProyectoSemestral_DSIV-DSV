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

namespace MotorsForm
{
    public partial class Flota : Form
    {
        FlotaServices flotaServices;
        public Flota()
        {
            InitializeComponent();
            flotaServices = new FlotaServices();
            CargarFlota();
        }

        public async void CargarFlota()
        {
            try
            {
                var autos = await flotaServices.ObternerTodaLaFlota();

                // Configurar el ListView
                lsvCarros.View = View.Details;
                lsvCarros.Items.Clear();

                // Configurar el ImageList si no está inicializado
                if (lsvCarros.SmallImageList == null)
                {
                    lsvCarros.SmallImageList = new ImageList
                    {
                        ImageSize = new Size(100, 100),
                        ColorDepth = ColorDepth.Depth32Bit
                    };
                }

                // Agregar los datos
                foreach (var auto in autos)
                {
                    // Crear el ListViewItem vacío
                    var item = new ListViewItem();

                    // Agregar imagen (en la primera columna, "Foto")
                    if (!string.IsNullOrEmpty(auto.foto) && System.IO.File.Exists(auto.foto))
                    {
                        // Generar una clave única para la imagen
                        var imageKey = auto.foto;
                        if (!lsvCarros.SmallImageList.Images.ContainsKey(imageKey))
                        {
                            lsvCarros.SmallImageList.Images.Add(imageKey, Image.FromFile(auto.foto));
                        }
                        item.ImageKey = imageKey; // Esto asigna la imagen a la columna "Foto"
                    }
                    else
                    {
                        // Si no hay imagen, agregar una imagen predeterminada
                        var defaultImageKey = "default";
                        if (!lsvCarros.SmallImageList.Images.ContainsKey(defaultImageKey))
                        {
                            lsvCarros.SmallImageList.Images.Add(defaultImageKey, Properties.Resources.defaultCar); // Imagen predeterminada
                        }
                        item.ImageKey = defaultImageKey;
                    }

                    // Agregar la marca (columna "Marca") como primer subelemento
                    item.SubItems.Add(auto.marca);

                    // Agregar los demás subelementos (resto de las columnas)
                    item.SubItems.Add(auto.modelo);
                    item.SubItems.Add(auto.carroceria);
                    item.SubItems.Add(auto.km.ToString());
                    item.SubItems.Add(auto.color);
                    item.SubItems.Add(auto.descripcion);
                    item.SubItems.Add(auto.placa);
                    item.SubItems.Add(auto.estado);

                    // Agregar el item al ListView
                    lsvCarros.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la flota: {ex.Message}");
            }
        }


    }
}
