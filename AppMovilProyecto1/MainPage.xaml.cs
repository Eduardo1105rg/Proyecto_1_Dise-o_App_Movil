﻿using AppMovilProyecto1.GoogleAuth;
using AppMovilProyecto1.Services;
using Microsoft.Maui.Layouts;

namespace AppMovilProyecto1
{
    public partial class MainPage : ContentPage
    {
        private List<MenuDesplegableMain> menusAbiertos = new List<MenuDesplegableMain>();

        private AbsoluteLayout absoluteLayoutMain;

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

        private readonly GoogleAuthService _googleAuthService = new GoogleAuthService();

        public MainPage()
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


            bool llamar = RevisarEstado();
            if (llamar)
            {
                //InciarRenderizadoDeElementos();

            }
        }

        // Revisar el estado de la conexion
        private bool RevisarEstado()
        {
            bool llamar = ConexionService.EstadoConexion();
            if (llamar == false) {
                DisplayAlert("Error", "No estas conectado a internet", "OK");
                return false; 
            } else {
                DisplayAlert("Aviso", "Conectado a internet", "OK");
                return true; 
            }
        }

        // Funcion para ser llamada a traves de la interfaz para iniciar el proceso de busqueda.
        private async void IniciarBusqueda(object sender, EventArgs e)
        {
            await DisplayAlert("Error", "Iniciando busqueda.", "OK");
        }

        // Inciar el proceso de renderrizado de elementos en la pantalla.
        private async void InciarRenderizadoDeElementos()
        {

            string divisaSeleccionada = Application.Current.Resources["BaseCurrency"]?.ToString();

            // Consultar al API para el valor de la conversion.
            var DatosConsultadoDelAPI = ExchangeService.Import(divisaSeleccionada);

            if (DatosConsultadoDelAPI == null || DatosConsultadoDelAPI.conversion_rates == null)
            {
                await DisplayAlert("Informacion", "Actualmente no se han podido consultar los datos del api.", "OK");

            }


            FavoritosContenedorStackLayout.Children.Clear(); // Vaciar el contenedor de favoritos.

            foreach (var rate in DatosConsultadoDelAPI.conversion_rates.GetType().GetProperties())
            {

                string codigoDivisa = rate.Name;

                double valorConversion = (double)rate.GetValue(DatosConsultadoDelAPI.conversion_rates);

                RenderizarElementos(codigoDivisa, valorConversion, divisaSeleccionada);

            }
            
        }

        // Mostrar un elementos en la ventana.
        private void RenderizarElementos(string codigoDivisa, double valorConversion, string divisaActual)
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

                Text = $"{valorConversion}  {codigoDivisa}",
                Style = (Style)Application.Current.Resources["CodigoLabel"]

            });

            // Crear el Label para mostrar el valor.
            var valorLabel = new Label
            {
                Text = $"1 {divisaActual}",
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
            
            var menuDesplegable = new MenuDesplegableMain(codigoDivisa);
            menuDesplegable.OpcionSeleccionada += (sender, accion) =>
            {              
                if (accion == "Agregar")
                {
                    GuardarElementoEnRegistros(codigoDivisa);
                }
                //var absoluteLayout = (AbsoluteLayout)this.Content;
                //absoluteLayout.Children.Remove((View)sender);
                absoluteLayoutMain.Children.Remove((View)sender);
                menusAbiertos.Remove((MenuDesplegableMain)sender);
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

        // Cerrar todos los menus que esten abiertos.
        private void CerrarMenusDesplegables()
        {
           
            foreach (var menu in menusAbiertos)
            {
                //var absoluteLayout = (AbsoluteLayout)this.Content;
                //absoluteLayout.Children.Remove(menu);
                absoluteLayoutMain.Children.Remove(menu);
            }
            menusAbiertos.Clear();
            TouchOverlay.IsVisible = false;
        }
        
        // Reaccionar cuando se toca la ventana.
        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Acabamos de hacer un click.", "OK");
            CerrarMenusDesplegables(); // Cierra todos los menús abiertos
        }

        // Recargar el contenido de la ventana:
        public void RecargarContenido()
        {
            DisplayAlert("Aviso", "Recargando contenido", "OK");
            FavoritosContenedorStackLayout.Children.Clear(); // Vaciar el contenedor de favoritos.

            // Validamos si esta conectado a internet.
            bool llamar = RevisarEstado();
            if (llamar)
            {
                //InciarRenderizadoDeElementos();

            }
            //InciarRenderizadoDeElementos();
        }


        // Volver a lanzar la ventana:
        private async void ReelanzarVentana()
        {

            var paginaActual = this; // Optener la que esta
            await Navigation.PushAsync(new VentanaFavoritos()); // Crear la nueva.
            Navigation.RemovePage(paginaActual); // Elimianar la pagina anterior.
        }

        // Este metodo se activa cada vez que se cambia de ventana.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Aplicar el tema al cargar la MainPage
            GestionTema.ApplyTheme();

            RecargarContenido();
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


        private async void navegacionVentana(object sender, EventArgs e) // Con esos parametros, se le permite ser llamado desde la interfaz.
        {

            await Shell.Current.GoToAsync("//VentanaConversor");
        }


        //Para el inicio de sesion, metodo del video
        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            var loggedUser = await _googleAuthService.GetCurrentUserAsync();

            if (loggedUser == null)
            {
                loggedUser = await _googleAuthService.AuthenticateAsync();
            }

            await DisplayAlert("Login Message", "Welcome " + loggedUser.FullName, "Ok");
        }

        private async void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            await _googleAuthService?.LogoutAsync();

            await DisplayAlert("Login Message", "Goodbye", "Ok");
        }

    }
}
