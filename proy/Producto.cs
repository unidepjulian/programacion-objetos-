using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy
{
    // Esta clase representa un producto
    internal class Producto
    {
        // Propiedades
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        //conexion a la base datos
        private string connectionString = "Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;"; 

        public void AgregarProducto()
        {
            SqlConnection connection = null; // Inicializamos la conexión a null

            try
            {
                // Creamos la conexión SQL
                connection = new SqlConnection(connectionString);
                string query = "INSERT INTO Productos (NombreProducto, Precio) VALUES (@NombreProducto, @Precio)";
                SqlCommand command = new SqlCommand(query, connection);

                // Asignamos los parámetros necesarios a la consulta SQL
                command.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                command.Parameters.AddWithValue("@Precio", Precio);

                // Abrimos 
                connection.Open();

                // Ejecutamos el comando SQL para insertar el producto
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL
                Console.WriteLine($"Error al agregar el producto: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción que no sea de SQL
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
            finally
            {
                // Cerramos 
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); 
                }
            }
        }

        public static List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();
            SqlConnection connection = null; // Inicializamos la conexión como null

            try
            {
                // Creamos la conexión SQL
                connection = new SqlConnection("Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;");

                // Consulta SQL para seleccionar todos los productos
                string query = "SELECT * FROM Productos";
                SqlCommand command = new SqlCommand(query, connection);

                // Abrimos 
                connection.Open();

                // Ejecutamos la consulta y obtenemos un lector de datos
                SqlDataReader reader = command.ExecuteReader();

                // Recorremos los resultados y creamos objetos 'Producto'
                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        // Asignamos los valores leídos desde la base de datos a las propiedades del producto
                        IdProducto = (int)reader["IdProducto"],
                        NombreProducto = (string)reader["NombreProducto"],
                        Precio = (decimal)reader["Precio"]
                    };

                    // Agregamos el producto a la lista
                    productos.Add(producto);
                }
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL
                Console.WriteLine("Ocurrió un error al obtener los productos: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Capturamos cualquier otra excepción que no sea de SQL
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                // Cerramos 
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); 
                }
            }

            // Retornamos 
            return productos;
        }
    }
}
