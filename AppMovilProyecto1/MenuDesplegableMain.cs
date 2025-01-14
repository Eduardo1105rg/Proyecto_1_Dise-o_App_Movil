using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace AppMovilProyecto1
{
    public class MenuDesplegableMain : ContentView
    {

        public event EventHandler<string> OpcionSeleccionada;

        public MenuDesplegableMain(string codigoDivisa)
        {
            var stackLayoutOpciones = new StackLayout
            {
                BackgroundColor = Colors.White, // Fondo blanco para el StackLayout
                Padding = new Thickness(5), // Relleno interno de 5 en todos los lados
                Children =
                {

                    // Imagen para cerrar la ventana. 
                    new ImageButton {
                        
                        Source ="x.png",
                        HeightRequest = 50,
                        WidthRequest = 50,
                        BackgroundColor = Colors.Transparent,
                        Margin = new Thickness(4), // Márgenes alrededor del botón
                        Command = new Command(() =>  ReaccionarOpcionSeleccionada("Cerrar", codigoDivisa))
                    
                    },

                    new Button
                    {
                        Text = Localization.AppResources.Add, // Texto del botón
                        Command = new Command(() => ReaccionarOpcionSeleccionada("Agregar", codigoDivisa)), // Comando asociado al botón
                        BackgroundColor = Colors.Green, // Fondo verde para el botón
                        TextColor = Colors.White, // Texto blanco
                        FontSize = 20, // Tamaño de fuente
                        CornerRadius = 8, // Bordes redondeados
                        Margin = new Thickness(4), // Márgenes alrededor del botón
                    }
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
