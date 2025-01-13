using Microsoft.Maui.Networking;

namespace AppMovilProyecto1.Services
{
    public class ConexionService
    {

        public static bool EstadoConexion() {

            var estado = Connectivity.Current.NetworkAccess;
            return estado == NetworkAccess.Internet;
        
        }


        //public void MonitorearEstado()
        //{
            //Connectivity.Current.ConnectivityChanged += (sender, args) =>
            //{
                // Notificar el cambio mediante un evento
                //bool conectado = args.NetworkAccess == NetworkAccess.Internet;
                //ConexionCambio?.Invoke(conectado);
            //};
        //}

        public static bool ConexionCambio(bool status)
        {
            return status;
        }



    }
}
