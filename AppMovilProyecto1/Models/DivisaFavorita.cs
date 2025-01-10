using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMovilProyecto1.Models
{
    class DivisaFavorita
    {
        public string CodigoDivisa { get; set; }
        
        public Dictionary<string, double> ValoresConversion { get; set; }
    }
}
