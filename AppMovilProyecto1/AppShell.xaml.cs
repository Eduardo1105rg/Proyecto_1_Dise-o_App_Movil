using Android.Icu.Util;
using CommunityToolkit.Maui.Views;
namespace AppMovilProyecto1
{
    public partial class AppShell : Shell
    {
        private string _iconoTema;

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("secondpage", typeof(VentanaConversor)); // Para el registro de una ruta con parametros.
            Routing.RegisterRoute("favoritospage", typeof(VentanaFavoritos)); // Para el registro de una ruta con parametros.
            UpdateThemeIcon(); // Establecer el icono inicial
        }

        private async void SeleccionarDivisaBaseRediReccionador(object sender, EventArgs e)
        {
            var popup = new CurrencyPickerPopup();
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }

        public string ThemeIcon
        {
            get => _iconoTema;
            set
            {
                _iconoTema = value;
                OnPropertyChanged(nameof(iconoTema));
            }
        }
        public void UpdateThemeIcon()
        {
            ThemeIcon = GestionTema.ObtenerIcono(); // Establecer el icono según el tema actual
        }

    }
}
