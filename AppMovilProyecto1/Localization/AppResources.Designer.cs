﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppMovilProyecto1.Localization {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AppResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AppMovilProyecto1.Localization.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Conversor.
        /// </summary>
        internal static string Converter {
            get {
                return ResourceManager.GetString("Converter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Elementos favoritos.
        /// </summary>
        internal static string Favorite_elements {
            get {
                return ResourceManager.GetString("Favorite-elements", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Favoritos.
        /// </summary>
        internal static string Favorites {
            get {
                return ResourceManager.GetString("Favorites", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Inicio.
        /// </summary>
        internal static string Home {
            get {
                return ResourceManager.GetString("Home", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Buscar.
        /// </summary>
        internal static string Search {
            get {
                return ResourceManager.GetString("Search", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Buscar Divisa....
        /// </summary>
        internal static string SearchBarPlace {
            get {
                return ResourceManager.GetString("SearchBarPlace", resourceCulture);
            }
        }
    }
}
