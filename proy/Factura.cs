using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy
{
    // Esta clase representa una factura
    internal class Factura
    {
        // Propiedades que describen una factura.
        public int IdFactura { get; set; }
        public int IdCita { get; set; }
        public decimal Total { get; set; }
        // Cadena de conexión
        private string connectionString = "Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;";

        // Método para agregar una nueva factura a la base de datos
        public void AgregarFactura()
        {
            SqlConnection connection = null; // Inicializamos la conexión a null

            try
            {
                // Creamos la conexión SQL
                connection = new SqlConnection(connectionString);
                string query = "INSERT INTO Facturas (IdCita, Total) VALUES (@IdCita, @Total)";
                SqlCommand command = new SqlCommand(query, connection);

                // Asignamos los parámetros necesarios
                command.Parameters.AddWithValue("@IdCita", IdCita);
                command.Parameters.AddWithValue("@Total", Total);

                // Abrimos la conexión
                connection.Open();

                // Ejecuta el comando SQL para insertar la factura
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL
                Console.WriteLine($"Error al agregar la factura: {ex.Message}");
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
                    connection.Close(); // Cerramos la conexión de forma segura
                }
            }
       
        }

        public static List<Factura> ObtenerFacturas()
        {
            List<Factura> facturas = new List<Factura>(); // Lista para almacenar las facturas
            SqlConnection connection = null; // Inicializa null.

            try
            {
                // Creamos la conexión SQL.
                connection = new SqlConnection("Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;");
                string query = "SELECT * FROM Facturas"; // Consulta SQL para seleccionar todas las facturas
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open(); // Abrimos 
                SqlDataReader reader = command.ExecuteReader(); // Ejecutamos la consulta y obtenemos un lector de datos

                // Recorremos los resultados y creamos objetos 'Factura' a partir de los datos
                while (reader.Read())
                {
                    Factura factura = new Factura
                    {
                        // Asignamos los valores leídos desde la base de datos a las propiedades de la factura
                        IdFactura = (int)reader["IdFactura"],
                        IdCita = (int)reader["IdCita"],
                        Total = (decimal)reader["Total"]
                    };
                    facturas.Add(factura); // Agregamos la factura a la lista
                }
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL 
                Console.WriteLine("Ocurrió un error al obtener las facturas: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción que no sea de SQL
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

            return facturas; // Retornamos la lista de facturas obtenidas
        }
       
    }
    
}

