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

        /*
         * Incompleto, hablar sobre un posible procedimiento para el tipo de producto
         */
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
                command.CommandText = "SELECT * FROM Pedidos";
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
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return productos;
        }
    }
}
