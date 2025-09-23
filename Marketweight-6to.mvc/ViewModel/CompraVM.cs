using System.Collections.Generic;
using MarketWeight.Core;

namespace MarketWeight_6to.mvc.ViewModel
{
    public class CompraVM
    {
        public uint idUsuario { get; set; }
        public uint idMoneda { get; set; }
        public decimal Cantidad { get; set; }

        public List<Moneda> Monedas { get; set; } = new();
    }
}
