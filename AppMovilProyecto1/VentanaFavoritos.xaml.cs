using System.Formats.Asn1;
using AppMovilProyecto1.Models;
using AppMovilProyecto1.Services;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Layouts;

namespace AppMovilProyecto1;

public partial class VentanaFavoritos : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Aplicar el tema al cargar la MainPage
        GestionTema.ApplyTheme();
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

    // Funcion para ser llamada a traves de la interfaz para iniciar el proceso de busqueda.
    private async void IniciarBusqueda(object sender, EventArgs e)
    {
        await DisplayAlert("Error", "Iniciando busqueda.", "OK");
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

        foreach (var favorito in elementosRegistrado)
        {

            string codigoDivisa = favorito.CodigoDivisa;

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
            Style = (Style)Application.Current.Resources["RecuadroElemento"]
        };

        // Crear recuadro blanco.
        var recuadroBlanco = new Border
        {
            Style = (Style)Application.Current.Resources["RecuadroInterno"]
        };

        // Crear el StackLayou horizontal que organiza los elementos en horizontal.
        var stackLayoutHorizontal = new StackLayout
        {
            Style = (Style)Application.Current.Resources["StackLayouHorizontal"]
        };

        // Crear StackLayout para el pais y codigo de la divisa.
        var stacktLayoutLabelsInfo = new StackLayout();

        // Agregar el label con el nombre del pais.
        stacktLayoutLabelsInfo.Add(new Label
        {

            Text = AccederInfoDivisasPorCodigo[codigoDivisa],
            Style = (Style)Application.Current.Resources["PaisLabel"]

        });

        // Agregar el Label del codigo de la divisa.
        stacktLayoutLabelsInfo.Add(new Label
        {

            Text = codigoDivisa,
            Style = (Style)Application.Current.Resources["CodigoLabel"]

        });

        // Crear el Label para mostrar el valor.
        var valorLabel = new Label
        {
            Text = "",
            Style = (Style)Application.Current.Resources["ValorLabel"]
        };

        // Crear El StackLayout Vertical para colocar el boton.
        var stackLayoutVerticalBtn = new StackLayout
        {
            Style = (Style)Application.Current.Resources["StackLayouVerticalEspecial"]
        };

        // Crear el boton de opciones:
        var opcionesBtn = new Button
        {

            Text = "O", //
            Style = (Style)Application.Current.Resources["OpcionesBtn"]

        };
        opcionesBtn.Clicked += (sender, args) => MostrarMenuDesplegablePopup(codigoDivisa, opcionesBtn); // Añadir al boton la funcion de desplegar ventana.

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
        DisplayAlert("Error", "Cerrando los menus abiertos.", "OK");
        foreach (var menu in menusAbiertos)
        {
            //var absoluteLayout = (AbsoluteLayout)this.Content;
            //absoluteLayout.Children.Remove(menu);
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
        DisplayAlert("Error", "Recargando contenido", "OK");
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
        //RecargarContenido();
        
        DisplayAlert("Exito", $"Eliminar {codigoDivisa}", "OK");

        FavoritosContenedorStackLayout.Children.Clear(); // Vaciar el contenedor de favoritos.
        RecargarContenido();
    }

}