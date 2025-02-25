namespace ENT
{
    public class Pedido
    {
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaPedido { get; set; }
        public float PrecioTotal { get; set; }
        public string Estado { get; set; }
    }
}
