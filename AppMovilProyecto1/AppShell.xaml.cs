namespace AppMovilProyecto1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("secondpage", typeof(VentanaConversor)); // Para el registro de una ruta con parametros.
            Routing.RegisterRoute("favoritospage", typeof(VentanaFavoritos)); // Para el registro de una ruta con parametros.
        }
    }
}
