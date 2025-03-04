using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class Manejadora
    {
        /// <summary>
        /// Función que devuelve una lista de pedidos de la base de datos
        /// Pre: La base de datos tiene que estar encendida
        /// Post: Devuelve TODOS los registros de la tabla
        /// </summary>
        /// <returns>Listado de pedidos</returns>
        public static List<Pedido> getPedidos()
        {
            SqlConnection connection = new();
            List<Pedido> pedidos = new();
            SqlCommand command = new();
            SqlDataReader reader;
            Pedido pedido;
            connection.ConnectionString
            = ("server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Pedidos";
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        pedido = new Pedido();
                        pedido.IdPedido = (int)reader["id_pedido"];
                        pedido.IdProveedor = (int)reader["id_proveedor"];
                        pedido.FechaPedido = (DateTime)reader["fecha_pedido"];
                        decimal pt = (decimal)reader["precio_total"];
                        pedido.PrecioTotal = (float) pt;
                        pedido.Estado = (string)reader["estado"];
                        pedidos.Add(pedido);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return pedidos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Producto> getProductos()
        {
            SqlConnection connection = new();
            List<Producto> productos = new();
            SqlCommand command = new();
            SqlDataReader reader;
            Producto producto;
            connection.ConnectionString
            = ("server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Productos";
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        producto = new Producto();
                        producto.IdProducto = (int) reader["id_producto"];
                        producto.Nombre = (string)reader["nombre"];
                        producto.Impuesto = (int)reader["impuesto"];
                        producto.Tipo = (int)reader["id_tipoProducto"];
                        productos.Add(producto);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return productos;
        }

        public static List<DetallesPedido> GetDetallesPedidos()
        {
            SqlConnection connection = new();
            List<DetallesPedido> pedidos = new();
            SqlCommand command = new();
            SqlDataReader reader;
            DetallesPedido pedido;
            connection.ConnectionString
            = ("server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Detalles_Pedido";
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pedido = new();
                        pedido.IdPedido = (int)reader["id_pedido"];
                        pedido.IdProdcuto = (int)reader["id_producto"];
                        pedido.Cantidad = (int)reader["cantidad"];
                        decimal pU = (decimal)reader["precio_unitario"];
                        pedido.PrecioUnitario = (float)pU;
                        decimal pC = (decimal)reader["precio_cantidad"];
                        pedido.PrecioCantidad = (float)pC;
                        pedido.Descuento = (int)reader["descuento_detallesPedido"];
                        pedido.Impuesto = (int)reader["impuesto_detallesPedido"];
                    }
                }
            }
            catch (SqlException ex) 
            {
                throw ex;
            }

            return pedidos;
        }
    }
}
