using ENT;
using Microsoft.Data.SqlClient;
using System.Numerics;

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
            SqlConnection connection = new SqlConnection();
            List<Pedido> pedidos = new List<Pedido>();
            SqlCommand command = new SqlCommand();
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
                        pedido.PrecioTotal = (float)pt;
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
        /// Función que devuelve una lista de productos de la base de datos
        /// Pre: La base de datos tiene que estar encendida
        /// Post: Devuelve TODOS los registros de la tabla
        /// </summary>
        /// <returns></returns>
        public static List<Producto> getProductos()
        {
            SqlConnection connection = new SqlConnection();
            List<Producto> productos = new List<Producto>();
            SqlCommand command = new SqlCommand();
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
                        producto.IdProducto = (int)reader["id_producto"];
                        producto.Impuesto = (int)reader["impuesto"];
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

        public static List<Producto> getListaProductosPorIDProveedor(int idProveedor)
        {
            SqlConnection connection = new SqlConnection();
            List<Producto> productosProveedor = new List<Producto>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            Producto producto;
            connection.ConnectionString
            = ("server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idProveedor;
            try
            {
                connection.Open();
                command.CommandText = "EXEC "; // TIENES QUE PONER EL EXEC POR ID DE PROVEEDOR
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        producto = new();
                        producto.IdProducto = (int)reader["id_producto"];
                        producto.tipo = (Tipo)reader["id_tipoProducto"];
                        producto.Impuesto = (int)reader["impuesto"];
                        //producto. = (string)reader["nombre"];
                        productosProveedor.Add(producto);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return productosProveedor;
        }
        #region DetallesPedidos
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<DetallesPedido> GetDetallesPedidos()
        {
            SqlConnection connection = new SqlConnection();
            List<DetallesPedido> pedidos = new List<DetallesPedido>();
            SqlCommand command = new SqlCommand();
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
        #endregion
        #region Proveedores
        /// <summary>
        /// Función que recibe una lista de Proveedores
        /// </summary>
        /// <returns> List<Proveedor> proveedores </Proveedor></returns>
        public static List<Proveedor> getProveedores()
        {
            SqlConnection connection = new SqlConnection();
            List<Proveedor> proveedores = new List<Proveedor>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            Proveedor proveedor;
            connection.ConnectionString
            = ("server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Proveedor";
                command.Connection = connection;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        proveedor = new Proveedor();
                        proveedor.IdProveedor = (int)reader["id_proveedor"];
                        proveedor.Nombre = (string)reader["nombre"];
                        proveedor.Telefono = (Int64)reader["telefono"];
                        proveedor.Correo = (string)reader["correo"];
                        proveedores.Add(proveedor); // Añade las cosas a la lista sino no ve na GENIO
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return proveedores;

        }

        public static Proveedor getProveedorID(int idProveedor)
        {
            SqlConnection connection = new SqlConnection();
            Proveedor proveedor = new Proveedor();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            connection.ConnectionString
            = ("server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idProveedor;

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Proveedor WHERE id_proveedor = @id";
                command.Connection = connection;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read(); // Tengo que leer antes de poder guardar los datos ANORMAL
                    proveedor.IdProveedor = (int)reader["id_proveedor"];
                    proveedor.Nombre = (string)reader["nombre"];
                    proveedor.Telefono = (long)reader["telefono"];
                    proveedor.Correo = (string)reader["correo"];


                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return proveedor;
        }
        #endregion
    }
}
