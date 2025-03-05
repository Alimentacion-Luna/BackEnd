namespace DTO
{
    public class Pedido
    {
        DateTime fechaPedido { get; set; }
        float precioTotal { get; set; }
        string estado { get; set; }
        Proveedor proveedor { get; set; }
        List<DetallesPedido> detalles { get; set; }

    }
}
