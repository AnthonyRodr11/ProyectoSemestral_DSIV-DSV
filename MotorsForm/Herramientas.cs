using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MotorsForm.Resource
{
    public class Herramientas
    {
        //Herramientas...
        //Objeto para mandar un error bien XD
        ErrorProvider errorXD = new ErrorProvider();

        public static bool continuar {  get; set; }

        public static Login LojinForm;

        public static void SetLoginForm(Login form)
        {
            LojinForm = form;
        }
        public static void MostrarLogin()
        {
            if (LojinForm != null)
            {
                LojinForm.Show(); // Mostrar el formulario si existe
            }
        }

        //Herramientas de Validación
        public static bool ValidarFormatoCorreo(string correo)
        {
            try
            {
                var direccionCorreo = new System.Net.Mail.MailAddress(correo);
                //Revisa si termina en .com o en .pa (Para el correo institucional)
                return direccionCorreo.Address == correo && (correo.EndsWith(".com")||correo.EndsWith(".pa"));
            }
            catch
            {
                return false; // El correo no es válido.
            }
        }

        public void ValidarTxtMail(TextBox control)
        {

            if (control.TextLength != 0)
            {
                if (!ValidarFormatoCorreo(control.Text))
                {
                    MensajeError(control, "Correo Incorrecto", false);
                    continuar = false;
                }
                else
                {
                    MensajeError(control, null, true);
                    continuar=true;
                }
            }
            else
            {
                MensajeError(control, "No puede dejar este campo vacío", false);
                continuar = false;
            }
        }


        public void ValidarComboBox(ComboBox control)
        {
            if (control.SelectedIndex <= 0)
            {
                MensajeError(control, "Debe seleccionar una opción", false);
                continuar = false;
            }
            else
            {
                MensajeError(control, null, true);
                continuar = true;
            }
        }

        public void ValidarTextBox(TextBox control)
        {
            if (control.TextLength != 0)
            {
                MensajeError(control, null, true);
                continuar = true;
            }
            else
            {
                MensajeError(control, "No puede dejar este campo vacío", false);
                continuar = false;
            }
        }

        public void ValidarNumeric(NumericUpDown control, string cadena)
        {
            if (control.Value > 0)
            {
                MensajeError(control, null, true);
                continuar = true;
            }
            else
            {
                MensajeError(control, cadena , false);
                continuar = false;
            }
        }

        public void ValidarMasked(MaskedTextBox control)
        {
            if (control.MaskCompleted)
            {
                MensajeError(control, null, true);
                continuar = true;
            }
            else
            {
                MensajeError(control, "Debe llenar el campo", false);
                continuar = false;
            }
        }

        

        //Método para encontrar dónde inicia una cadena 
        //Se usa actualmente en los Masked Box
        public void InicioDeCadena(MaskedTextBox mascara)
        {
            var originalFormat = mascara.TextMaskFormat;

            // Excluye los caracteres de máscara al evaluar el texto
            mascara.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            // Obtiene el texto actual sin caracteres de máscara
            string userText = mascara.Text;

            // Restaura el formato original
            mascara.TextMaskFormat = originalFormat;

            // Si no hay texto ingresado, coloca el cursor al inicio
            if (string.IsNullOrEmpty(userText))
            {
                mascara.SelectionStart = 0;
            }
            else if (userText.Length > 3)
            {
                // Encuentra la posición del primer carácter vacío
                mascara.SelectionStart = userText.Length + 1;
            }
            else
            {
                mascara.SelectionStart = userText.Length;
            }
            
        }

        //Herramientas de mensajes
        //Crear mensaje de Error
        public void MensajeError(Control control, string cadena, bool valida)
        {
            if (!valida)
            {
                errorXD.SetError(control, cadena);
            }
            else
            {
                errorXD.Clear();
            }
        }


        public string ConseguirRutaAbsoluta(string relativa)
        {

            relativa =  "../../../MotorsValueWeb"+relativa;

            return relativa;
        }

        public string ParaCambiarLaRuta(string foto)
        {
            if (foto != null)
            {
                string[] strings = foto.Split(new string[] { ".." }, StringSplitOptions.RemoveEmptyEntries);

                return ConseguirRutaAbsoluta(strings[0]);
            }
            return null;
        }

    }
}
