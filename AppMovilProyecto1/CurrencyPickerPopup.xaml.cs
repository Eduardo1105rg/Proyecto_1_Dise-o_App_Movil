using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;

namespace AppMovilProyecto1
{
    public partial class CurrencyPickerPopup : Popup
    {
        public CurrencyPickerPopup()
        {
            InitializeComponent();

            CurrencyPicker.ItemsSource = new string[] { "USD", "EUR", "CRC", "JPY" };


        }

        // Esto se llama cuando se selecciona una opcion en el piker.
        private void CambiarOpcionSeleccionada(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            string selectedCurrency = (string)picker.SelectedItem;
            
            // Algo global en lo que se guarda.
            App.Current.Resources["BaseCurrency"] = selectedCurrency;

            

            // Cerrar el popup
            Close();

            // Recargar la ventana actual 
            RecargarContenidoDePaginaActual();
        }

        // Se recarga el conenido de la pagina actual.
        private void RecargarContenidoDePaginaActual()
        {
            // Obtiene la pagina actual
            var currentPage = Shell.Current.CurrentPage;

            // LLamar al metodo de la ventana correspondiente
            //if (currentPage is VentanaFavoritos ventanaFavoritos)
            //{
                //ventanaFavoritos.RecargarContenido();
            //}
          
            if (currentPage is MainPage mainPage)
            {
                mainPage.RecargarContenido();
            }

        }
    }
}

