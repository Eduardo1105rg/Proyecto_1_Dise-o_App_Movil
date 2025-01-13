using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using System.Windows.Input;

namespace AppMovilProyecto1
{
    public partial class MenuDesplegablePopup1 : Popup
    {
        public ICommand AgregarCommand { get; }
        public ICommand EliminarCommand { get; }

        public MenuDesplegablePopup1(string codigoDivisa, Action<string, string> accionSeleccionada)
        {
            InitializeComponent();
            AgregarCommand = new Command(() => accionSeleccionada?.Invoke(codigoDivisa, "Agregar"));
            EliminarCommand = new Command(() => accionSeleccionada?.Invoke(codigoDivisa, "Eliminar"));

            BindingContext = this;
        }
    }
}
