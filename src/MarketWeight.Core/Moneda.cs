
namespace MarketWeight.Core
{
    public class Moneda
    {
        public required decimal Precio { get; set; }
        public required uint idMoneda { get; set; }
        public required decimal Cantidad { get; set; }
        public required string Nombre { get; set; }
    }
}

