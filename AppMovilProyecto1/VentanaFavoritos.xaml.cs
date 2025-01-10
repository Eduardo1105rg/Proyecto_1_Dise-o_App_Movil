using System.Formats.Asn1;
using AppMovilProyecto1.Models;
using AppMovilProyecto1.Services;


namespace AppMovilProyecto1;

public partial class VentanaFavoritos : ContentPage
{
	public VentanaFavoritos()
	{
		InitializeComponent();
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

        foreach (var favorito in elementosRegistrado) { 

            string codigoDivisa = favorito.CodigoDivisa;

            Dictionary<string, double> valoresConversion = favorito.ValoresConversion;

            RenderizarElementos(codigoDivisa);

            //Console.WriteLine($"Divisa: {favorito.CodigoDivisa}, Valores: {favorito.ValoresConversion}"); 

        }


    }

    // Mostrar un elementos en la ventana.
    private void RenderizarElementos(string codigoDivisa) {
    
    }



    // Funcion para ser llamada a travez de la interfaz para guardar un elemento en favoritos.
    private async void GuardarElementoEnRegistros(object sender,EventArgs e)
	{
        string divisaSeleccionada = "CRC";
        // Validamos que el archivo no este ya creado.
        var validarExistencia = await FavoritosService.LeerArchivoFavorito(divisaSeleccionada);

        if (validarExistencia == null)
        {
            await DisplayAlert("Error", "Esta divisa ya fue guardada en favoritos.", "OK");
            return;
        }

        // Acomodamos los datos de la divisa.
        var elementoAcomodado = FavoritosService.AcomodarValoresParaGuardar(divisaSeleccionada);

        if (elementoAcomodado == null) {
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