namespace AppMovilProyecto1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Regitre el recurso global.
            Resources.Add("BaseCurrency", "USD");
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}