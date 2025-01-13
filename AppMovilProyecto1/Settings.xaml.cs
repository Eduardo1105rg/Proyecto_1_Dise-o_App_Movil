namespace AppMovilProyecto1;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
        // Configurar el Switch según la preferencia guardada
        Sw_Tema.IsToggled = GestionTema.GetThemePreference();
    }

    private void OnSwitchToggled(object sender, ToggledEventArgs e)
    {

        // Guardar la preferencia del tema
        GestionTema.SaveThemePreference(Sw_Tema.IsToggled);

        // Cambiar el tema según el valor del Switch
        GestionTema.ApplyTheme();
    }
}