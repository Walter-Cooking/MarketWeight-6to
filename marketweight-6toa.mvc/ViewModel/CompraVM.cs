using System.Collections.Generic;
using MarketWeight.Core;

namespace MarketWeight_6to.mvc.ViewModel
{
    public class CompraVM
    {
        public uint UsuarioId { get; set; }
        public uint MonedaId { get; set; }
        public decimal Cantidad { get; set; }

        public List<Moneda> Monedas { get; set; } = new();
    }
}
