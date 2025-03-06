using ENT;

namespace DTO
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public DateTime fechaPedido { get; set; }
        public float precioTotal { get; set; }
        public string estado { get; set; }
        public Proveedor proveedor { get; set; }
        public List<DetallesPedidoDTO> detalles { get; set; }

    }
}
