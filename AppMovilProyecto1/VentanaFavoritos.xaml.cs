using System.Formats.Asn1;
using System.Linq;
using AppMovilProyecto1.Models;
using AppMovilProyecto1.Services;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace AppMovilProyecto1;

public partial class VentanaFavoritos : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Aplicar el tema al cargar la MainPage
        GestionTema.ApplyTheme();
        RecargarContenido();
    }
    
    // Registrar los menus abiertos.
    private List<MenuDesplegable> menusAbiertos = new List<MenuDesplegable>();

    // El layout principal del sistema.
    private AbsoluteLayout absoluteLayoutMain;

    //Info de la divisa por nombre de pais.
    public Dictionary<String, String> AccederInfoDivisas = new Dictionary<string, string> {
        { "United Arab Emirates", "AED" }, { "Afghanistan", "AFN" }, { "Albania", "ALL" },
        { "Armenia", "AMD" }, { "Netherlands Antilles", "ANG" }, { "Angola", "AOA" },
        { "Argentina", "ARS" }, { "Australia", "AUD" }, { "Aruba", "AWG" },
        { "Azerbaijan", "AZN" }, { "Bosnia and Herzegovina", "BAM" }, { "Barbados", "BBD" },
        { "Bangladesh", "BDT" }, { "Bulgaria", "BGN" }, { "Bahrain", "BHD" },
        { "Burundi", "BIF" }, { "Bermuda", "BMD" }, { "Brunei", "BND" },
        { "Bolivia", "BOB" }, { "Brazil", "BRL" }, { "Bahamas", "BSD" },
        { "Bhutan", "BTN" }, { "Botswana", "BWP" }, { "Belarus", "BYN" },
        { "Belize", "BZD" }, { "Canada", "CAD" }, { "Congo (Kinshasa)", "CDF" },
        { "Switzerland", "CHF" }, { "Chile", "CLP" }, { "China", "CNY" },
        { "Colombia", "COP" }, { "Costa Rica", "CRC" }, { "Cuba", "CUP" },
        { "Cape Verde", "CVE" }, { "Czech Republic", "CZK" }, { "Djibouti", "DJF" },
        { "Denmark", "DKK" }, { "Dominican Republic", "DOP" }, { "Algeria", "DZD" },
        { "Egypt", "EGP" }, { "Eritrea", "ERN" }, { "Ethiopia", "ETB" },
        { "Eurozone", "EUR" }, { "Fiji", "FJD" }, { "Falkland Islands", "FKP" },
        { "Faroe Islands", "FOK" }, { "United Kingdom", "GBP" }, { "Georgia", "GEL" },
        { "Guernsey", "GGP" }, { "Ghana", "GHS" }, { "Gibraltar", "GIP" },
        { "Gambia", "GMD" }, { "Guinea", "GNF" }, { "Guatemala", "GTQ" },
        { "Guyana", "GYD" }, { "Hong Kong", "HKD" }, { "Honduras", "HNL" },
        { "Croatia", "HRK" }, { "Haiti", "HTG" }, { "Hungary", "HUF" },
        { "Indonesia", "IDR" }, { "Israel", "ILS" }, { "Isle of Man", "IMP" },
        { "India", "INR" }, { "Iraq", "IQD" }, { "Iran", "IRR" },
        { "Iceland", "ISK" }, { "Jersey", "JEP" }, { "Jamaica", "JMD" },
        { "Jordan", "JOD" }, { "Japan", "JPY" }, { "Kenya", "KES" },
        { "Kyrgyzstan", "KGS" }, { "Cambodia", "KHR" }, { "Kiribati", "KID" },
        { "Comoros", "KMF" }, { "South Korea", "KRW" }, { "Kuwait", "KWD" },
        { "Cayman Islands", "KYD" }, { "Kazakhstan", "KZT" }, { "Laos", "LAK" },
        { "Lebanon", "LBP" }, { "Sri Lanka", "LKR" }, { "Liberia", "LRD" },
        { "Lesotho", "LSL" }, { "Libya", "LYD" }, { "Morocco", "MAD" },
        { "Moldova", "MDL" }, { "Madagascar", "MGA" }, { "North Macedonia", "MKD" },
        { "Myanmar", "MMK" }, { "Mongolia", "MNT" }, { "Macau", "MOP" },
        { "Mauritania", "MRU" }, { "Mauritius", "MUR" }, { "Maldives", "MVR" },
        { "Malawi", "MWK" }, { "Mexico", "MXN" }, { "Malaysia", "MYR" },
        { "Mozambique", "MZN" }, { "Namibia", "NAD" }, { "Nigeria", "NGN" },
        { "Nicaragua", "NIO" }, { "Norway", "NOK" }, { "Nepal", "NPR" },
        { "New Zealand", "NZD" }, { "Oman", "OMR" }, { "Panama", "PAB" },
        { "Peru", "PEN" }, { "Papua New Guinea", "PGK" }, { "Philippines", "PHP" },
        { "Pakistan", "PKR" }, { "Poland", "PLN" }, { "Paraguay", "PYG" },
        { "Qatar", "QAR" }, { "Romania", "RON" }, { "Serbia", "RSD" },
        { "Russia", "RUB" }, { "Rwanda", "RWF" }, { "Saudi Arabia", "SAR" },
        { "Solomon Islands", "SBD" }, { "Seychelles", "SCR" }, { "Sudan", "SDG" },
        { "Sweden", "SEK" }, { "Singapore", "SGD" }, { "Saint Helena", "SHP" },
        { "Sierra Leone", "SLE" }, { "Somalia", "SOS" }, { "Suriname", "SRD" },
        { "South Sudan", "SSP" }, { "São Tomé and Príncipe", "STN" }, { "Syria", "SYP" },
        { "Eswatini", "SZL" }, { "Thailand", "THB" }, { "Tajikistan", "TJS" },
        { "Turkmenistan", "TMT" }, { "Tunisia", "TND" }, { "Tonga", "TOP" },
        { "Turkey", "TRY" }, { "Trinidad and Tobago", "TTD" }, { "Tuvalu", "TVD" },
        { "Taiwan", "TWD" }, { "Tanzania", "TZS" }, { "Ukraine", "UAH" },
        { "Uganda", "UGX" }, { "United States", "USD" }, { "Uruguay", "UYU" },
        { "Uzbekistan", "UZS" }, { "Venezuela", "VES" }, { "Vietnam", "VND" },
        { "Vanuatu", "VUV" }, { "Samoa", "WST" }, { "Central African CFA", "XAF" },
        { "Eastern Caribbean", "XCD" }, { "Special Drawing Rights", "XDR" },
        { "West African CFA", "XOF" }, { "CFP Franc", "XPF" }, { "Yemen", "YER" },
        { "South Africa", "ZAR" }, { "Zambia", "ZMW" }, { "Zimbabwe", "ZWL" }
    };

    // Info de la divisas por codigo.
    public Dictionary<String, String> AccederInfoDivisasPorCodigo = new Dictionary<string, string>();

    // Guardar los codigos de las divisas guardados
    //public Dictionary<String, String> DivisasRecuperadas = new Dictionary<string, string>();

    public List<string> DivisasRecuperadas = new List<string>();

    public VentanaFavoritos()
    {
        InitializeComponent();
        AccederInfoDivisasPorCodigo = AccederInfoDivisas.ToDictionary(item => item.Value, item => item.Key);

        var grid = this.Content as Grid;
        if (grid != null)
        {
            absoluteLayoutMain = grid.Children.OfType<AbsoluteLayout>().FirstOrDefault();
        }

        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += (s, e) =>
        {
            // Handle the tap
            CerrarMenusDesplegables();
        };

        absoluteLayoutMain.GestureRecognizers.Add(tapGestureRecognizer);

        // Configurar el TouchOverlay para cerrar menús
        if (TouchOverlay != null)
        {
            TouchOverlay.IsVisible = false; // Asegurarse de que está oculto al inicio
        }


        InciarRenderizadoDeElementos();

    }

    // Revisar el estado de la conexion
    private bool RevisarEstado()
    {
        bool llamar = ConexionService.EstadoConexion();
        if (llamar == false)
        {
            DisplayAlert("Error", "No estas conectado a internet", "OK");
            return false;
        }
        else
        {
            DisplayAlert("Aviso", "Conectado a internet", "OK");
            return true;
        }
    }

    // Funcion para ser llamada a traves de la interfaz para iniciar el proceso de busqueda.
    private void IniciarBusqueda(object sender, TextChangedEventArgs e)
    {
        
        var textoBusqueda = e.NewTextValue.ToLower(); //BusquedaSearchBar.Text.ToLower();
        FavoritosContenedorStackLayout.Children.Clear();
        foreach (var elemento in DivisasRecuperadas)
        {
            string codigoDivisa = elemento;
            string nombrePais = AccederInfoDivisasPorCodigo[elemento];
            if (string.IsNullOrEmpty(textoBusqueda) || codigoDivisa.ToLower().Contains(textoBusqueda) || nombrePais.ToLower().Contains(textoBusqueda))
            {
                RenderizarElementos(codigoDivisa);
            }
        }



    }

    // Inciar el proceso de renderrizado de elementos en la pantalla.
    private async void InciarRenderizadoDeElementos()
    {

        var elementosRegistrado = await FavoritosService.LeerTodoLosArchivosExistentesLista();

        if (elementosRegistrado.Count() == 0)
        {
            await DisplayAlert("Informacion", "Actualmente no hay elementos guardados en favoritos.", "OK");
            return;
        }

        // Consultar al API para el valor de la conversion.
        //var DatosConsultadoDelAPI = ExchangeService.Import("USD");



        FavoritosContenedorStackLayout.Children.Clear(); // Vaciar el contenedor de favoritos.
        DivisasRecuperadas.Clear();
        foreach (var favorito in elementosRegistrado)
        {

            string codigoDivisa = favorito.CodigoDivisa;

            DivisasRecuperadas.Add(codigoDivisa);

            Dictionary<string, double> valoresConversion = favorito.ValoresConversion;

            RenderizarElementos(codigoDivisa);

            //Console.WriteLine($"Divisa: {favorito.CodigoDivisa}, Valores: {favorito.ValoresConversion}"); 

        }


    }

    // Mostrar un elementos en la ventana.
    private void RenderizarElementos(string codigoDivisa)
    {

        //FavoritosContenedorStackLayout.Children.Clear();


        // >>> Crear los elementos----------------------- Style = (Style)Application.Current.Resources[""]
        // Crear Recuadro verde.
        var recuadroVerde = new Border
        {
            BackgroundColor = Application.Current.Resources.TryGetValue("InternContainer", out var bgColor)
                    ? (Color)bgColor : Colors.Transparent,
            Stroke = Brush.Transparent,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(20) },
            Margin = new Thickness(10, 5, 10, 5)
        };

        // Crear recuadro blanco.
        var recuadroBlanco = new Border
        {
            Style = Application.Current.Resources.TryGetValue("RecuadroInterno", out var styleInterno)
                    ? styleInterno as Style
                    : null,
            BackgroundColor = Application.Current.Resources.TryGetValue("PageBackgroundColor", out var bgColor2)
                    ? (Color)bgColor2
                    : Colors.White,
            Stroke = new SolidColorBrush(Application.Current.Resources.TryGetValue("Border", out var borderColor)
                    ? (Color)borderColor
                    : Colors.Black),
            StrokeThickness = 2,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(20) },
            Padding = new Thickness(1),
            Margin = new Thickness(5, 5, 0, 0),
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        // Crear el StackLayou horizontal que organiza los elementos en horizontal.
        var stackLayoutHorizontal = new StackLayout
        {
            Style = Application.Current.Resources.TryGetValue("StackLayouHorizontal", out var styleHorizontal)
                    ? styleHorizontal as Style
                    : null,
            Orientation = StackOrientation.Horizontal
        };


        // Crear StackLayout para el pais y codigo de la divisa.
        var stacktLayoutLabelsInfo = new StackLayout();

        // Agregar el label con el nombre del pais.
        stacktLayoutLabelsInfo.Add(new Label
        {
            Text = AccederInfoDivisasPorCodigo[codigoDivisa],
            Style = Application.Current.Resources.TryGetValue("PaisLabel", out var paisStyle)
                    ? paisStyle as Style
                    : null,
            TextColor = Application.Current.Resources.TryGetValue("PrimaryTextColor", out var textColor)
                    ? (Color)textColor
                    : Colors.Black,
            Margin = new Thickness(10, 5, 0, 0)
        });

        // Agregar el Label del codigo de la divisa.
        stacktLayoutLabelsInfo.Add(new Label
        {
            Text = codigoDivisa,
            Style = Application.Current.Resources.TryGetValue("CodigoLabel", out var codigoStyle)
                    ? codigoStyle as Style
                    : null,
            TextColor = Application.Current.Resources.TryGetValue("PrimaryTextColor", out var textColor2)
                    ? (Color)textColor2
                    : Colors.Black,
            Margin = new Thickness(10, 5, 0, 5)
        });

        // Crear el Label para mostrar el valor.
        var valorLabel = new Label
        {
            Text = "",
            Style = Application.Current.Resources.TryGetValue("ValorLabel", out var valorStyle)
                    ? valorStyle as Style
                    : null,
            TextColor = Application.Current.Resources.TryGetValue("PrimaryTextColor", out var textColor3)
                    ? (Color)textColor3
                    : Colors.Black,
            Margin = new Thickness(10, 5, 0, 5),
            VerticalOptions = LayoutOptions.EndAndExpand, // Ajusta según sea necesario
            HorizontalOptions = LayoutOptions.EndAndExpand // Ajusta según sea necesario
        };

        // Crear El StackLayout Vertical para colocar el boton.
        var stackLayoutVerticalBtn = new StackLayout
        {
            HorizontalOptions = LayoutOptions.Center, // Centrado horizontalmente
            VerticalOptions = LayoutOptions.Center // Centrado verticalmente
        };

        // Crear el boton de opciones:
        var opcionesBtn = new Button
        {
            Text = "O", // Texto del botón
            Margin = new Thickness(0), // Según el estilo, el margen es 0
            BackgroundColor = Colors.Transparent, // Fondo transparente
            TextColor = (Color)Application.Current.Resources["PrimaryTextColor"], // Color dinámico para el texto
            FontSize = 30, // Tamaño de fuente
            Padding = new Thickness(0), // Sin relleno adicional
            VerticalOptions = LayoutOptions.Center // Alineación vertical centrada
        };
        opcionesBtn.Clicked += (sender, args) => MostrarMenuDesplegable(codigoDivisa, opcionesBtn); // Añadir al boton la funcion de desplegar ventana.

        stackLayoutVerticalBtn.Children.Add(opcionesBtn);// Añadir al StackLayout el botn


        // Agregar los StackLayou principal los stackLayout secundarios.
        stackLayoutHorizontal.Children.Add(stacktLayoutLabelsInfo);
        stackLayoutHorizontal.Children.Add(valorLabel);
        stackLayoutHorizontal.Children.Add(stackLayoutVerticalBtn);


        // Agregar el StackLayout horizontal al recuadro blanco.
        recuadroBlanco.Content = stackLayoutHorizontal;

        // Agregar el recuadro blanco al recuadro verde.
        recuadroVerde.Content = recuadroBlanco;

        // Agregar al recuadro verde al contenedor principal de elementos favoritos.
        FavoritosContenedorStackLayout.Children.Add(recuadroVerde);

    }

    // Mostrar el menu de opciones en la ventana.
    private async void MostrarMenuDesplegable(string codigoDivisa, View anchor)
    {
        // Cerrar otros menús abiertos
        CerrarMenusDesplegables();
       

        var menuDesplegable = new MenuDesplegable(codigoDivisa);
        menuDesplegable.OpcionSeleccionada += (sender, accion) =>
        {
            if (accion == "Eliminar")
            {
                EliminarElementoFavorito(codigoDivisa);
            }
            else if (accion == "Cerrar")
            {
                CerrarMenusDesplegables();
            }

            //var absoluteLayout = (AbsoluteLayout)this.Content;
            //absoluteLayout.Children.Remove((View)sender);
            absoluteLayoutMain.Children.Remove((View)sender);
            menusAbiertos.Remove((MenuDesplegable)sender);
            TouchOverlay.IsVisible = false;
        };

        //var absoluteLayoutMain = (AbsoluteLayout)this.Content;
        //absoluteLayoutMain.Children.Add(menuDesplegable);
        absoluteLayoutMain.Children.Add(menuDesplegable);
        TouchOverlay.IsVisible = true;

        await Task.Yield(); // Esperar un ciclo de renderizado

        // Obtener las dimensiones del menú desplegable
        menuDesplegable.Measure(absoluteLayoutMain.Width, absoluteLayoutMain.Height);
        var menuWidth = menuDesplegable.DesiredSize.Width;
        var menuHeight = menuDesplegable.DesiredSize.Height;

        // Posicionar el menú desplegable justo debajo del botón de opciones
        var anchorLocation = anchor.GetRelativePosition(this);
        double menuX = anchorLocation.X;
        double menuY = anchorLocation.Y + anchor.Height;

        double screenWidth = this.Width;
        double screenHeight = this.Height;

        // Ajustar la posición si el menú se sale de los márgenes de la pantalla
        if (menuX + menuWidth > screenWidth)
        {
            menuX = screenWidth - menuWidth;
        }
        if (menuY + menuHeight > screenHeight)
        {
            menuY = screenHeight - menuHeight;
        }
        if (menuX < 0)
        {
            menuX = 0;
        }
        if (menuY < 0)
        {
            menuY = 0;
        }

        AbsoluteLayout.SetLayoutBounds(menuDesplegable, new Rect(menuX, menuY, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        AbsoluteLayout.SetLayoutFlags(menuDesplegable, AbsoluteLayoutFlags.None);

        // Asegurar que el menú desplegable esté en el contenedor principal de AbsoluteLayout
        menusAbiertos.Add(menuDesplegable);
    }


    private async void MostrarMenuDesplegablePopup(string codigoDivisa, View anchor)
    {
        var popup = new MenuDesplegablePopup1(codigoDivisa, AccionSeleccionada); 
        await this.ShowPopupAsync(popup);
    }

    private void AccionSeleccionada(string codigoDivisa, string accion)
    {
        if (accion == "Agregar") { 
            GuardarElementoEnRegistros(codigoDivisa); 
        } 
        else if (accion == "Eliminar") { 
            EliminarElementoFavorito(codigoDivisa); 
        }
    }

    // Cerrar todos los menus que esten abiertos.
    private void CerrarMenusDesplegables()
    {
        
        foreach (var menu in menusAbiertos)
        {

            absoluteLayoutMain.Children.Remove(menu);
        }
        menusAbiertos.Clear();
        TouchOverlay.IsVisible = false;
    }
    private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
    {
        DisplayAlert("Error", "Acabamos de hacer un click.", "OK");
        CerrarMenusDesplegables(); // Cierra todos los menús abiertos
    }


    // Recargar el contenido de la ventana:
    public void RecargarContenido()
    {
        CerrarMenusDesplegables();
        FavoritosContenedorStackLayout.Children.Clear(); // Vaciar el contenedor de favoritos.
        InciarRenderizadoDeElementos();
    }


    // Volver a lanzar la ventana:
    private async void ReelanzarVentana()
    {

        var paginaActual = this; // Optener la que esta
        await Navigation.PushAsync(new VentanaFavoritos()); // Crear la nueva.
        Navigation.RemovePage(paginaActual); // Elimianar la pagina anterior.
    }


    // Actualizar todas las divisas registradas:
    private async void ActualizarDivisas(object sender, EventArgs e)
    {
        bool llamar = RevisarEstado();
        if (!llamar)
        {
            return;

        }
        var elementosRegistrado = await FavoritosService.LeerTodoLosArchivosExistentesLista();

        if (elementosRegistrado.Count() == 0)
        {
            await DisplayAlert("Error", "No hay divisas guardadas en favoritos.", "OK");
            return;
        }

        // Consultar al API para el valor de la conversion.
        
        foreach (var favorito in elementosRegistrado)
        {

            string codigoDivisa = favorito.CodigoDivisa;

            ActualizarElementoEnRegistros(codigoDivisa);

        }
        await DisplayAlert("Informacion", "Valores de las divisas guardadas en favoritos actualizadas con exito.", "OK");
    }


    // Funcion para ser llamada a travez de la interfaz para guardar un elemento en favoritos.
    private async void GuardarElementoEnRegistros(string divisaSeleccionada)
    {
        //string divisaSeleccionada = "CRC";
        // Validamos que el archivo no este ya creado.
        var validarExistencia = await FavoritosService.LeerArchivoFavorito(divisaSeleccionada);

        if (validarExistencia != null)
        {
            await DisplayAlert("Error", "Esta divisa ya fue guardada en favoritos.", "OK");
            return;
        }

        // Acomodamos los datos de la divisa.
        var elementoAcomodado = FavoritosService.AcomodarValoresParaGuardar(divisaSeleccionada);

        if (elementoAcomodado == null)
        {
            await DisplayAlert("Error", "No ha sido posible acomodar los datos de la divisa.", "OK");
            return;
        }

        // Guardamos la divisa.
        await FavoritosService.GuardarNuevoFavorito(elementoAcomodado);


        //var llamar = await FavoritosService.LeerTodoLosArchivosExistentes();

        //foreach (var favorito in llamar) { 
        //Console.WriteLine($"Divisa: {favorito.CodigoDivisa}, Valores: {favorito.ValoresConversion}"); 
        //}

        await DisplayAlert("Exito", "La divisa seleccionada ha sido guardada en favoritos exitosamente.", "OK");

    }


    private async void ActualizarElementoEnRegistros(string divisaSeleccionada)
    {
       

        // Acomodamos los datos de la divisa.
        var elementoAcomodado = FavoritosService.AcomodarValoresParaGuardar(divisaSeleccionada);

        if (elementoAcomodado == null)
        {
            await DisplayAlert("Error", "No ha sido posible acomodar los datos de la divisa.", "OK");
            return;
        }

        // Guardamos la divisa.
        await FavoritosService.GuardarNuevoFavorito(elementoAcomodado);

    }


    // Funcion para eliminar un elemento del registro de favoritos...
    private async void EliminarElementoFavorito(string codigoDivisa)
    {
        FavoritosService.EliminarArchivo(codigoDivisa);
        
        bool respuesta = await DisplayAlert("Confermar eliminacion", $"¿Estás seguro de que deseas eliminar {codigoDivisa}?", "Sí", "No");

        if (!respuesta)
        {
            await DisplayAlert("Informacion", "Accion cancelada.", "OK");
            return;
        }

        await DisplayAlert("Informacion", $"Divisa {codigoDivisa} eliminada de favoritos.", "OK");

        FavoritosContenedorStackLayout.Children.Clear(); // Vaciar el contenedor de favoritos.
        RecargarContenido();
    }

}
