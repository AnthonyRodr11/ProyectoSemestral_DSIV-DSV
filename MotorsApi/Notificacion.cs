namespace MotorsApi
{
    public class Notificacion
    {
        //Metodo para notificar mensaje con advertencia
        public void notificarAdvertencia(string mensaje)
        {

            MessageBox.Show(mensaje, "Advertencia:", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        //notificar error 
        public void notificarError(string message)
        {

            MessageBox.Show(message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //Metodo para notificar accion realizada
        public void notificarAccion(string message)
        {

            MessageBox.Show(message, "Realizo:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
