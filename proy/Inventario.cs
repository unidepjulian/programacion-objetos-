using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy
{ // Esta clase representa el inventario de productos en la peluquería
    internal class Inventario
    {  // Cadena de conexión a la base de datos
        private string connectionString = "Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;";

        // Método para agregar un producto al inventario
        public void AgregarProducto(int idProducto, int cantidad)
        {
            // Se utiliza la declaración 'using' para asegurar que la conexión se cierre automáticamente
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta SQL para insertar un nuevo registro en la tabla Inventario
                string query = "INSERT INTO Inventario (IdProducto, Cantidad) VALUES (@IdProducto, @Cantidad)";
                SqlCommand command = new SqlCommand(query, connection);
                // Asignamos los parámetros
                command.Parameters.AddWithValue("@IdProducto", idProducto);
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                // Abrimos la conexión 
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para obtener la lista del inventario, que incluye productos y sus cantidades
        public List<(Producto, int)> ObtenerInventario()
        {
            // Lista para almacenar los productos y sus cantidades
            List<(Producto, int)> inventario = new List<(Producto, int)>();
            using (SqlConnection connection = new SqlConnection("Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;")) // Reemplaza con tu cadena de conexión
            {
                string query = "SELECT p.*, i.Cantidad FROM Productos p JOIN Inventario i ON p.IdProducto = i.IdProducto";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        IdProducto = (int)reader["IdProducto"],
                        NombreProducto = (string)reader["NombreProducto"],
                        Precio = (decimal)reader["Precio"]
                    };
                    int cantidad = (int)reader["Cantidad"];
                    inventario.Add((producto, cantidad));
                }
            }
            return inventario;
        }
    }
}
