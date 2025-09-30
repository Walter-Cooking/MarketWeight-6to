using System.Collections.Generic;
using MarketWeight.Core;

namespace MarketWeight_6to.mvc.ViewModel
{
    public class MonedaVM
    {
        public required string Nombre { get; set; }
        public required decimal Precio { get; set; }   
        public required decimal Cantidad { get; set; }   
    }
}
