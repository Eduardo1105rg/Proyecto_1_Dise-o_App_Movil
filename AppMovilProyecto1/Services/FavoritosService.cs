using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AppMovilProyecto1.Models;


namespace AppMovilProyecto1.Services
{
    class FavoritosService
    {

        public static string rutaArchivosFavoritos = Path.Combine(FileSystem.AppDataDirectory, "Favoritos"); //Ruta del direcctorio de archivo, esta ruta es la mas recomendada para guardar archivos de forma local.

        // Verificamos si existe el directorio, si no existe lo creamos...FavoritosService()
        public static void GenerarRutas()
        {
            if (!Directory.Exists(rutaArchivosFavoritos))
            {
                Directory.CreateDirectory(rutaArchivosFavoritos);
            }
        }

        // Guardamos un elemento favorito en forma .json
        public static async Task GuardarNuevoFavorito(DivisaFavorita divisaFavorita)
        {
            try
            {
                GenerarRutas();
                string rutaArchivo = Path.Combine(rutaArchivosFavoritos, $"{divisaFavorita.CodigoDivisa}.json");
                string archivo = JsonSerializer.Serialize(divisaFavorita);

                await File.WriteAllTextAsync(rutaArchivo, archivo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        // Recuperemos un elemento favorito por su nombre de archivo
        public static async Task<DivisaFavorita> LeerArchivoFavorito(string codigoDivisa)
        {
            try
            {
                GenerarRutas();
                string rutaArchivo = Path.Combine(rutaArchivosFavoritos, $"{codigoDivisa}.json");

                if (File.Exists(rutaArchivo))
                {
                    string archivo = await File.ReadAllTextAsync(rutaArchivo);
                    return JsonSerializer.Deserialize<DivisaFavorita>(archivo);

                }
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Recuperamos todos los elementos favoritos guardados y los devolvemos como un diccionario
        public static async Task<Dictionary<string, DivisaFavorita>> LeerTodoLosArchivosExistentesDiccionario()
        {
            try
            {
                GenerarRutas();
                var archivos = Directory.GetFiles(rutaArchivosFavoritos, "*.json");

                // Validamos si hay archivos

                if (archivos.Length == 0)
                {

                    return new Dictionary<string, DivisaFavorita>();
                }

                Dictionary<string, DivisaFavorita> diccionarioDeElementos = new Dictionary<string, DivisaFavorita>();

                foreach (var rutaArchivo in Directory.GetFiles(rutaArchivosFavoritos, "*.json"))
                {
                    string archivo = await File.ReadAllTextAsync(rutaArchivo);
                    var favorito = JsonSerializer.Deserialize<DivisaFavorita>(archivo);
                    if (favorito != null)
                    {
                        diccionarioDeElementos.Add(favorito.CodigoDivisa, favorito);
                    }
                }
                return diccionarioDeElementos;
            }
            catch (Exception ex)
            {

                return new Dictionary<string, DivisaFavorita>();

            }
        }

        // Recuperamos todos los elementos favoritos guardados y los devolvemos como una lista.
        public static async Task<List<DivisaFavorita>> LeerTodoLosArchivosExistentesLista()
        {
            try
            {
                GenerarRutas();
                var archivos = Directory.GetFiles(rutaArchivosFavoritos, "*.json");

                // Validamos si hay archivos

                if (archivos.Length == 0)
                {
                    return new List<DivisaFavorita>();

                }

                var elementosGuardados = new List<DivisaFavorita>();

                foreach (var rutaArchivo in Directory.GetFiles(rutaArchivosFavoritos, "*.json"))
                {
                    string archivo = await File.ReadAllTextAsync(rutaArchivo);
                    var favorito = JsonSerializer.Deserialize<DivisaFavorita>(archivo);
                    if (favorito != null)
                    {

                        elementosGuardados.Add(favorito);
                    }
                }
                return elementosGuardados;
            }
            catch (Exception ex)
            {
                return new List<DivisaFavorita>();
            }
        }

        // Eliminar un archivo del registro de favoritos.
        public static void EliminarArchivo(string codigoDivisa)
        {

            try
            {

                GenerarRutas();

                string rutaArchivo = Path.Combine(rutaArchivosFavoritos, $"{codigoDivisa}.json");

                if (File.Exists(rutaArchivo))
                {
                    File.Delete(rutaArchivo);
                }

            }
            catch (Exception e)
            {


            }
        }


        // Se acomodan los valores en un objeto tipo DivisaFavorita, para poderla guardar.
        public static DivisaFavorita AcomodarValoresParaGuardar(string codigoDivisa)
        {
            var datos = ExchangeService.Import(codigoDivisa);
            if (datos != null)
            {
                try
                {
                    Dictionary<string, double> tazasConversion = new Dictionary<string, double>();
                    var valores = datos.conversion_rates.GetType().GetProperties();

                    foreach (var element in valores)
                    {
                        string nombreDivisa = element.Name;
                        double valor = (double)element.GetValue(datos.conversion_rates);
                        tazasConversion.Add(nombreDivisa, valor);
                    }

                    var objetoAcomodado = new DivisaFavorita
                    {

                        CodigoDivisa = codigoDivisa,
                        ValoresConversion = tazasConversion
                    };

                    return objetoAcomodado;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
            return null;
        }

        // Se valida que se tenga guardado ese elemento.

    }
}
