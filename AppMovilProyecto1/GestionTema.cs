
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.Collections.ObjectModel;

namespace AppMovilProyecto1
{
    public static class GestionTema
    {
        // Guardar el estado del tema en Preferences
        public static void SaveThemePreference(bool isDarkTheme)
        {
            Preferences.Set("isDarkTheme", isDarkTheme);
        }

        // Leer el estado del tema desde Preferences
        public static bool GetThemePreference()
        {
            return Preferences.Get("isDarkTheme", false); // false es el valor predeterminado (tema claro)
        }

        // Aplicar el tema según la preferencia guardada
        public static void ApplyTheme()
        {
            bool isDarkTheme = GetThemePreference();

            // Obtener los diccionarios de recursos de la aplicación
            ICollection<ResourceDictionary> mergeDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergeDictionaries != null)
            {
                mergeDictionaries.Clear(); // Limpiar diccionarios de recursos existentes

                // Aplicar el tema según la preferencia guardada
                if (isDarkTheme)
                {
                    mergeDictionaries.Add(new TemaOscuro()); // Agregar Tema Oscuro
                }
                else
                {
                    mergeDictionaries.Add(new TemaClaro()); // Agregar Tema Claro
                }
            }
        }
    }
}
