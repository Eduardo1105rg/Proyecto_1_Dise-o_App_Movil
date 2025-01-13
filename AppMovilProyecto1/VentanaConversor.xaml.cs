namespace AppMovilProyecto1;

using AppMovilProyecto1.Services;

public partial class VentanaConversor : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Aplicar el tema al cargar la MainPage
        GestionTema.ApplyTheme();
    }

    public string[] datosDivisasPicker = new string[] {
        "United Arab Emirates", "Afghanistan", "Albania", "Armenia", "Netherlands Antilles", "Angola",
        "Argentina", "Australia", "Aruba", "Azerbaijan", "Bosnia and Herzegovina", "Barbados",
        "Bangladesh", "Bulgaria", "Bahrain", "Burundi", "Bermuda", "Brunei", "Bolivia", "Brazil",
        "Bahamas", "Bhutan", "Botswana", "Belarus", "Belize", "Canada", "Congo (Kinshasa)", "Switzerland",
        "Chile", "China", "Colombia", "Costa Rica", "Cuba", "Cape Verde", "Czech Republic", "Djibouti",
        "Denmark", "Dominican Republic", "Algeria", "Egypt", "Eritrea", "Ethiopia", "Eurozone", "Fiji",
        "Falkland Islands", "Faroe Islands", "United Kingdom", "Georgia", "Guernsey", "Ghana", "Gibraltar",
        "Gambia", "Guinea", "Guatemala", "Guyana", "Hong Kong", "Honduras", "Croatia", "Haiti", "Hungary",
        "Indonesia", "Israel", "Isle of Man", "India", "Iraq", "Iran", "Iceland", "Jersey", "Jamaica",
        "Jordan", "Japan", "Kenya", "Kyrgyzstan", "Cambodia", "Kiribati", "Comoros", "South Korea", "Kuwait",
        "Cayman Islands", "Kazakhstan", "Laos", "Lebanon", "Sri Lanka", "Liberia", "Lesotho", "Libya",
        "Morocco", "Moldova", "Madagascar", "North Macedonia", "Myanmar", "Mongolia", "Macau",
        "Mauritania", "Mauritius", "Maldives", "Malawi", "Mexico", "Malaysia", "Mozambique",
        "Namibia", "Nigeria", "Nicaragua", "Norway", "Nepal", "New Zealand", "Oman", "Panama",
        "Peru", "Papua New Guinea", "Philippines", "Pakistan", "Poland", "Paraguay", "Qatar",
        "Romania", "Serbia", "Russia", "Rwanda", "Saudi Arabia", "Solomon Islands", "Seychelles",
        "Sudan", "Sweden", "Singapore", "Saint Helena", "Sierra Leone", "Somalia", "Suriname",
        "South Sudan", "São Tomé and Príncipe", "Syria", "Eswatini", "Thailand", "Tajikistan",
        "Turkmenistan", "Tunisia", "Tonga", "Turkey", "Trinidad and Tobago", "Tuvalu",
        "Taiwan", "Tanzania", "Ukraine", "Uganda", "United States", "Uruguay", "Uzbekistan",
        "Venezuela", "Vietnam", "Vanuatu", "Samoa", "Central African CFA", "Eastern Caribbean",
        "Special Drawing Rights", "West African CFA", "CFP Franc", "Yemen", "South Africa",
        "Zambia", "Zimbabwe"
    };

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


    public Dictionary<string, Dictionary<string, double>> DatosFavoritosCargados;

    public VentanaConversor()
    {
        InitializeComponent();
        AsignarValoresPickerDefault();
        DatosFavoritosCargados = new Dictionary<string, Dictionary<string, double>>();
        AccederInfoDivisasPorCodigo = AccederInfoDivisas.ToDictionary(item => item.Value, item => item.Key);
    }

    // Asignar los valores por defecto al picker.
    private void AsignarValoresPickerDefault()
    {
        DivisaOrigenPicker.ItemsSource = datosDivisasPicker;//new string[] { "USD", "EUR", "CRC" }; // Añadir más divisas según sea necesario
        DivisaDestinoPicker.ItemsSource = datosDivisasPicker;//new string[] { "USD", "EUR", "CRC" };
    }

    // Asignar los valores al picker despues de cambiar a favoritos.
    private void AsignarValoresPickerDefaultActualizacion(object sender, EventArgs e)
    {
        DivisaOrigenPicker.ItemsSource = null;
        DivisaOrigenPicker.SelectedIndex = -1;

        DivisaOrigenPicker.ItemsSource = datosDivisasPicker;//new string[] { "USD", "EUR", "CRC" }; // Añadir más divisas según sea necesario
        DivisaDestinoPicker.ItemsSource = datosDivisasPicker;

        ModificarBtn.Clicked -= AsignarValoresPickerDefaultActualizacion;
        ModificarBtn.Clicked += AsignarValoresPickerFavoritos;
        ModificarBtn.Text = "Elementos favoritos";

        // Modifcar los datos del boton que inicia el proceso de conversion.
        ConvertirBtn.Clicked -= RealizarConvercionFavoritos;
        ConvertirBtn.Clicked += RealizarConvercion;

    }

    // 
    private async void AsignarValoresPickerFavoritos(object sender, EventArgs e)
    {
        DatosFavoritosCargados = new Dictionary<string, Dictionary<string, double>>();
        var elementosRegistrado = await FavoritosService.LeerTodoLosArchivosExistentesLista();

        if (elementosRegistrado.Count() == 0)
        {
            await DisplayAlert("Informacion", "Actualmente no hay elementos guardados en favoritos.", "OK");
            return;
        }

        // Vaciar los datos del picker.
        DivisaOrigenPicker.ItemsSource = null;
        DivisaOrigenPicker.SelectedIndex = -1;


        List<string> divisaRegistradasEnFavoritos = new List<string>();
        Dictionary<string, Dictionary<string, double>> valoresConversionDvisas = new Dictionary<string, Dictionary<string, double>>();
        foreach (var favorito in elementosRegistrado)
        {

            string codigoDivisa = favorito.CodigoDivisa;

            divisaRegistradasEnFavoritos.Add(AccederInfoDivisasPorCodigo[codigoDivisa]);

            Dictionary<string, double> valoresConversion = favorito.ValoresConversion;
            DatosFavoritosCargados.Add(codigoDivisa, valoresConversion);
        }

        //DatosFavoritosCargados.Add(valoresConversionDvisas);

        string[] listaDeDivisasRegistradas = divisaRegistradasEnFavoritos.ToArray();


        if (listaDeDivisasRegistradas.Any())
        {
            DivisaOrigenPicker.ItemsSource = listaDeDivisasRegistradas;
        }
        else
        {
            await DisplayAlert("Error", "No se encontraron divisas registradas en favoritos.", "OK");
            return;
        }



        //DivisaOrigenPicker.ItemsSource = listaDeDivisasRegistradas;

        //DivisaDestinoPicker.ItemsSource = datosDivisasPicker;


        // Modificar los datos del boton que actualiza los valores del picker.
        ModificarBtn.Clicked -= AsignarValoresPickerFavoritos;
        ModificarBtn.Clicked += AsignarValoresPickerDefaultActualizacion;
        ModificarBtn.Text = "Elementos default";

        // Modifcar los datos del boton que inicia el proceso de conversion.
        ConvertirBtn.Clicked -= RealizarConvercion;
        ConvertirBtn.Clicked += RealizarConvercionFavoritos;


        //AccederInfoDivisasPorCodigo = AccederInfoDivisas.ToDictionary(item => item.Value, item => item.Key);

    }


    private async void RealizarConvercion(object sender, EventArgs e)
    {
        // Limpiar el lugar en donde se muestran los datos.

        // Validar que si se selecciono un elemento.
        if (DivisaOrigenPicker.SelectedItem == null || DivisaDestinoPicker == null)
        {
            await DisplayAlert("Error", "Debes de seleccionar una divisa origen y destino.", "OK");
            return;
        }


        string paisSeleccionadoOrigen = DivisaOrigenPicker.SelectedItem.ToString(); // Obtener la divisa origen. -> Corregir para el caso de que no se tenga un valor elegido.

        string paisSeleccionadoDestino = DivisaDestinoPicker.SelectedItem.ToString(); // Obtener la divisa destino.


        // Validar que el monto no este vacio.
        if (string.IsNullOrWhiteSpace(MontoEntry.Text))
        {
            await DisplayAlert("Error", "Debes de ingresar un monto a convertir.", "OK");
            return;
        }

        double montoIngresado; // Obtener el monto ingresado.  = double.Parse(MontoEntry.Text)

        // Validar que sea un numero.
        if (!double.TryParse(MontoEntry.Text, out montoIngresado))
        {
            await DisplayAlert("Error", "El monto ingresado debe de ser un valor numerico entero.", "OK");
            return;

        }

        // Validar que no sea menor que 0.
        if (montoIngresado < 0)
        {
            await DisplayAlert("Error", "El monto ingresado debe de ser un valor numerico entero positivo.", "OK");
            return;
        }

        ResultadoLabel.Text = "";

        string divisaOrigen = AccederInfoDivisas[paisSeleccionadoOrigen]; // Acceder a su respectivo codigo de divisa.

        string divisaDestino = AccederInfoDivisas[paisSeleccionadoDestino];


        double? datosConvercion = ExchangeService.optencion_tipo_de_cambio_conversion(divisaOrigen, divisaDestino);

        //decimal montoConvertido = montoIngresado * (decimal)datosConvercion.Value;
        //var montoIngresado = MontoEntry.GetValue;

        decimal montoConvertido = 0;
        if (datosConvercion.HasValue)
        {

            montoConvertido = (decimal)montoIngresado * (decimal)datosConvercion.Value;
        }

        ResultadoLabel.Text = $"{montoConvertido}";

        //var datosConvercion = ExchangeService.Import();

        //DisplayAlert("Error", "No se pudo realizar la conversión.", "OK");
    }
    // Otro metodo para acceder a los datos del diccionario "AccederInfoDivisas"
    // AccederInfoDivisas.TryGetValue(pais, out string codigoDivisa)
    // Pais es la clase de acceso al elementos, codigo divisa es lo que se devuelve.



    private async void RealizarConvercionFavoritos(object sender, EventArgs e)
    {
        // Limpiar el lugar en donde se muestran los datos.

        // Validar que si se selecciono un elemento.
        if (DivisaOrigenPicker.SelectedItem == null || DivisaDestinoPicker == null)
        {
            await DisplayAlert("Error", "Debes de seleccionar una divisa origen y destino.", "OK");
            return;
        }


        string paisSeleccionadoOrigen = DivisaOrigenPicker.SelectedItem.ToString(); // Obtener la divisa origen. -> Corregir para el caso de que no se tenga un valor elegido.

        string paisSeleccionadoDestino = DivisaDestinoPicker.SelectedItem.ToString(); // Obtener la divisa destino.


        // Validar que el monto no este vacio.
        if (string.IsNullOrWhiteSpace(MontoEntry.Text))
        {
            await DisplayAlert("Error", "Debes de ingresar un monto a convertir.", "OK");
            return;
        }

        double montoIngresado; // Obtener el monto ingresado.  = double.Parse(MontoEntry.Text)

        // Validar que sea un numero.
        if (!double.TryParse(MontoEntry.Text, out montoIngresado))
        {
            await DisplayAlert("Error", "El monto ingresado debe de ser un valor numerico entero.", "OK");
            return;

        }

        // Validar que no sea menor que 0.
        if (montoIngresado < 0)
        {
            await DisplayAlert("Error", "El monto ingresado debe de ser un valor numerico entero positivo.", "OK");
            return;
        }

        ResultadoLabel.Text = "";

        string divisaOrigen = AccederInfoDivisas[paisSeleccionadoOrigen]; // Acceder a su respectivo codigo de divisa.

        string divisaDestino = AccederInfoDivisas[paisSeleccionadoDestino];


        Dictionary<string, double> diccionarioValoresDeconversion = DatosFavoritosCargados[divisaOrigen];


        double? datosConvercion = diccionarioValoresDeconversion[divisaDestino];

        //decimal montoConvertido = montoIngresado * (decimal)datosConvercion.Value;
        //var montoIngresado = MontoEntry.GetValue;

        decimal montoConvertido = 0;
        if (datosConvercion.HasValue)
        {

            montoConvertido = (decimal)montoIngresado * (decimal)datosConvercion.Value;
        }

        ResultadoLabel.Text = $"{montoConvertido}";

        //var datosConvercion = ExchangeService.Import();

        //DisplayAlert("Error", "No se pudo realizar la conversión.", "OK");
    }


    private async void VolversAtras(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }



}