﻿using Microsoft.Maui.Controls;
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
                BackgroundColor = Colors.White, // Color de fondo blanco
                Padding = new Thickness(5), // Relleno de 5 unidades en todos los bordes
                Children =
                {
                    new Button
                    {
                        Text = Localization.AppResources.Delete, // Texto del botón
                        Command = new Command(() => ReaccionarOpcionSeleccionada("Eliminar", codigoDivisa)), // Comando de la acción al presionar
                        BackgroundColor = Colors.Green, // Color de fondo del botón
                        TextColor = Colors.White, // Color del texto del botón
                        FontSize = 20, // Tamaño de fuente
                        CornerRadius = 8, // Esquinas redondeadas
                        Margin = new Thickness(4), // Márgenes de 4 unidades
                        Padding = new Thickness(0), // Sin relleno
                        VerticalOptions = LayoutOptions.Center, // Alineación vertical al centro
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
