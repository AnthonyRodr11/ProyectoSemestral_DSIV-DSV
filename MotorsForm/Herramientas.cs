using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
