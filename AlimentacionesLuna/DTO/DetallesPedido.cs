using ENT;

namespace DTO
{
    public class DetallesPedido
    {
        public string nombreProducto { get; set; }
        int cantidad { get; set; }
        float precioUnitario { get; set; }
        float precioCantidad { get; set; }
        int descuento { get; set; }
        int impuesto { get; set; }
    }
}
