using System.Formats.Asn1;
using AppMovilProyecto1.Models;
using AppMovilProyecto1.Services;


namespace AppMovilProyecto1;

public partial class VentanaFavoritos : ContentPage
{


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

    public Dictionary<String, String> AccederInfoDivisasPorCodigo = new Dictionary<string, string>();




    public VentanaFavoritos()
    {
        InitializeComponent();
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

            Text = "CostaRica",//AccederInfoDivisasPorCodigo[codigoDivisa],
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
            Text = "1 USD",
            Style = (Style)Application.Current.Resources["ValorLabel"]
        };

        // Crear El StackLayout Vertical para colocar el boton.
        var stackLayoutVerticalBtn = new StackLayout
        {
            Style = (Style)Application.Current.Resources["StackLayouVerticalEspecial"]
        };

        // Añadir al StackLayout del boton el boton.
        stackLayoutVerticalBtn.Add(new Button
        {
            Text = "E", //
            Style = (Style)Application.Current.Resources["OpcionesBtn"]
        });


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



    // Funcion para ser llamada a travez de la interfaz para guardar un elemento en favoritos.
    private async void GuardarElementoEnRegistros(object sender, EventArgs e)
    {
        string divisaSeleccionada = "CRC";
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


}