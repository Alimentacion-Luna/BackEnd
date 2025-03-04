namespace ENT
{
    public class DetallesPedido
    {
        public int IdPedido { get; set; }
        public int IdProdcuto { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float PrecioCantidad { get; set; }
        public int Descuento { get; set; }
        public int Impuesto { get; set; }
        public string NombreProv { get; set; }
        public string NombreProd { get; set; }
    }
}
