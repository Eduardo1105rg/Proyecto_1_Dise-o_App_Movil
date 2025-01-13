using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace AppMovilProyecto1
{
    public class MenuDesplegable : ContentView
    {

        public event EventHandler<string> OpcionSeleccionada;

        public MenuDesplegable(string codigoDivisa)
        {
            var stackLayoutOpciones = new StackLayout
            {

                BackgroundColor = Colors.White,
                Padding = 5,
                Children =
                {
                    new Button
                    {
                        Text = Localization.AppResources.Delete,
                        Command = new Command(() => ReaccionarOpcionSeleccionada("Eliminar", codigoDivisa)),
                        Style = (Style)Application.Current.Resources["OpcionesBtnStyle"]
                    },

                }

            };

            Content = new Border
            {
                Content = stackLayoutOpciones,
                StrokeShape = new RoundRectangle { CornerRadius = 10 },
                Stroke = Colors.Gray,
                BackgroundColor = Colors.White,
                Padding = 5,
                Margin = new Thickness(10),
            };


        }

        // Reaccionar a la accion..
        private void ReaccionarOpcionSeleccionada(string accion, string codigoDivisa)
        {
            OpcionSeleccionada?.Invoke(this, accion);
        }
    }
}
