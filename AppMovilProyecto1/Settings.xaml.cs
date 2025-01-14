namespace AppMovilProyecto1;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
        // Configurar el Switch seg�n la preferencia guardada
        Sw_Tema.IsToggled = GestionTema.GetThemePreference();
    }

    private void OnSwitchToggled(object sender, ToggledEventArgs e)
    {

        // Guardar la preferencia del tema
        GestionTema.SaveThemePreference(Sw_Tema.IsToggled);

        // Cambiar el tema seg�n el valor del Switch
        GestionTema.ApplyTheme();

        // Actualizar el icono en AppShell
        var appShell = Application.Current.MainPage as AppShell;
        appShell?.UpdateThemeIcon(); // Llama al método para actualizar el icono
    }
}