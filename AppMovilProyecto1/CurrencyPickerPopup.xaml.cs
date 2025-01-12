using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;

namespace AppMovilProyecto1
{
    public partial class CurrencyPickerPopup : Popup
    {
        public CurrencyPickerPopup()
        {
            InitializeComponent();
        }

        private void OnCurrencyPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            string selectedCurrency = (string)picker.SelectedItem;
            // Guarda la divisa seleccionada en una propiedad global o en App.xaml.cs
            App.Current.Resources["BaseCurrency"] = selectedCurrency;

            

            // Cerrar el popup
            Close();

            // Recargar la ventana actual o tomar otras acciones
            ReloadCurrentPage();
        }

        private void ReloadCurrentPage()
        {
            // Obtén la página actual
            var currentPage = Shell.Current.CurrentPage;

            if (currentPage is VentanaFavoritos ventanaFavoritos)
            {
                ventanaFavoritos.RecargarContenido();
            }
          
            else if (currentPage is MainPage mainPage)
            {
                mainPage.RecargarContenido();
            }

        }
    }
}

