using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorsForm.Resource
{
    public class Herramientas
    {
        //Herramientas...

        //Herramientas de Validación
        public static bool ValidarCorreo(string correo)
        {
            try
            {
                var direccionCorreo = new System.Net.Mail.MailAddress(correo);
                return direccionCorreo.Address == correo;
            }
            catch
            {
                return false;
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

    }
}
