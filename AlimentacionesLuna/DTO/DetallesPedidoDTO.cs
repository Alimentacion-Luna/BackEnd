﻿
namespace DTO
{
    public class DetallesPedidoDTO
    {
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public float precioUnitario { get; set; }
        public float precioCantidad { get; set; }
        public int descuento { get; set; }
        public int impuesto { get; set; }
    }
}
