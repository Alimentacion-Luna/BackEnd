using DTO;
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
        public static List<PedidoDTO> getPedidos()
        {
            SqlConnection connection = new SqlConnection();
            List<PedidoDTO> pedidos = new();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            PedidoDTO pedido;
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
                        pedido = new();
                        pedido.IdPedido = (int)reader["id_pedido"];
                        pedido.fechaPedido = (DateTime)reader["fecha_pedido"];
                        pedido.detalles = getDetallesPedidos(pedido.IdPedido);
                        decimal pT = (decimal)reader["precio_total"];
                        pedido.precioTotal = (float)pT;
                        pedido.estado = (string)reader["estado"];
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return pedidos;
        }

        public static PedidoDTO getPedidoPorID(int idPedido)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            PedidoDTO pedido = null;
            connection.ConnectionString
            = ("server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idPedido;

            try
            {
                connection.Open();
                command.CommandText = "EXEC PedidosConNombreProv_IdPedido @id";
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    pedido = new();
                    int IdProveedor = (int)reader["id_proveedor"];
                    string NombreProveedor = (string)reader["nombre_proveedor"];
                    Proveedor p = new();
                    p.IdProveedor = IdProveedor;
                    p.Nombre = NombreProveedor;
                    pedido.fechaPedido = (DateTime)reader["fecha_pedido"];
                    pedido.proveedor = p;
                    decimal pT = (decimal)reader["precio_total"];
                    pedido.precioTotal = (float)pT;
                    pedido.estado = (string)reader["estado"];

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return pedido;

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
                command.CommandText = "EXECUTE ProductoConTipo";
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        producto = new Producto();
                        producto.IdProducto = (int)reader["id_producto"];
                        producto.Impuesto = (int)reader["impuesto"];
                        Tipo t = new Tipo();
                        t.Id = (int)reader["id_tipoProducto"];
                        t.Nombre = (string)reader["nombre_tipoProducto"];
                        producto.tipo = t;
                        producto.NombreProd = (string)reader["nombre_producto"];
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProveedor"></param>
        /// <returns></returns>
        public static List<ProductoDTO> getListaProductosPorIDProveedor(int idProveedor)
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
                command.CommandText = "EXEC ProductosPorIDProveedor @id_prov = @id"; // TIENES QUE PONER EL EXEC POR ID DE PROVEEDOR
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        producto = new Producto();
                        producto.IdProducto = (int)reader["id_producto"];
                        producto.Impuesto = (int)reader["impuesto"];
                        Tipo t = new Tipo();
                        t.Id = (int)reader["id_tipoProducto"];
                        t.Nombre = (string)reader["nombre_tipoProducto"];
                        producto.tipo = t;
                        producto.NombreProd = (string)reader["nombre_producto"];
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
        public static List<DetallesPedidoDTO> getDetallesPedidos(int idPedido)
        {
            SqlConnection connection = new SqlConnection();
            List<DetallesPedidoDTO> pedidos = new List<DetallesPedidoDTO>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            DetallesPedidoDTO pedido;
            connection.ConnectionString
            = ("server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idPedido;

            try
            {
                connection.Open();
                command.CommandText = "EXEC DetallesCompletos_IdPedido @id";
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pedido = new();
                        pedido.nombreProducto = (string)reader["nombre_producto"];
                        pedido.cantidad = (int)reader["cantidad"];
                        decimal pC = (decimal)reader["precio_cantidad"];
                        pedido.precioCantidad = (float)pC;
                        decimal pU = (decimal)reader["precio_unitario"];
                        pedido.precioUnitario = (float)pU;
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
                        proveedor.Telefono = (long)reader["telefono"];
                        proveedor.Correo = (string)reader["correo"];
                        proveedores.Add(proveedor);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return proveedores;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProveedor"></param>
        /// <returns></returns>
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
        public static List<Tipo> getTipos()
        {
            SqlConnection connection = new SqlConnection();
            List<Tipo> tipos = new List<Tipo>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            connection.ConnectionString
            = ("server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");

            connection.Open();
            command.CommandText = "SELECT * FROM Tipos";
            command.Connection = connection;
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Tipo tipo = new Tipo();
                    reader.Read();
                    tipo.Id = (int)reader["id_tipoProducto"];
                    tipo.Nombre = (string)reader["nombre_tipoProducto"];
                    tipos.Add(tipo);
                }


            }

            return tipos;
        }



    }
}
