using AppMovilProyecto1.GoogleAuth;

namespace AppMovilProyecto1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly IGoogleAuthService _googleAuthService = new GoogleAuthService(); //probar lo del inicio de sesion

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void navegacionVentana(object sender, EventArgs e) // Con esos parametros, se le permite ser llamado desde la interfaz.
        {

            await Shell.Current.GoToAsync("//VentanaConversor");
        }

        
        //Para el inicio de sesion
        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            var loggedUser = await _googleAuthService.GetCurrentUserAsync();

            if (loggedUser == null)
            {
                loggedUser = await _googleAuthService.AuthenticateAsync();
            }

            await Application.Current.MainPage.DisplayAlert("Login Message", "Welcome " + loggedUser.FullName, "Ok");
        }

        private async void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            await _googleAuthService?.LogoutAsync();

            await Application.Current.MainPage.DisplayAlert("Login Message", "Goodbye", "Ok");
        }
    }

}
