namespace MarketWeight_6toaeaeeaeaeeaea.ViewModel
{
    public class CompraViewModel
    {
        public int UsuarioId { get; set; }
        public int MonedaId { get; set; }
        public decimal Cantidad { get; set; }
        public List<Moneda> MonedasDisponibles { get; set; } = new();
        
    }

}
