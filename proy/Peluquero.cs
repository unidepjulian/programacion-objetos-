using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy
{
    // Esta clase representa a un peluquero 
    internal class Peluquero
    {
        // Propiedades que describen un peluquero
        public int IdPeluquero { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        // Cadena de conexión 
        private string connectionString = "Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;"; // Reemplaza con tu cadena de conexión
       
        // Método para agregar un nuevo peluquero a la base de datos
        public void AgregarPeluquero()
        {
            SqlConnection connection = null; // Inicializamos la conexión a null

            try
            {
                // Creamos la conexión SQL
                connection = new SqlConnection(connectionString);
                string query = "INSERT INTO Peluqueros (Nombre, Especialidad) VALUES (@Nombre, @Especialidad)";
                SqlCommand command = new SqlCommand(query, connection);

                // Asignamos los parámetros a la consulta SQL
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Especialidad", Especialidad);

                // Abrimos la conexión
                connection.Open();

                // Ejecutamos el comando SQL para insertar el peluquero
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL
                Console.WriteLine($"Error al agregar el peluquero: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción que no sea de SQL
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
            finally
            {
                // Cerramos la conexión si está abierta
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); // Cerramos la conexión de forma segura
                }
            }
            
        }

        public static List<Peluquero> ObtenerPeluqueros()
        {
            // Lista para almacenar los peluqueros obtenidos de la base de datos
            List<Peluquero> peluqueros = new List<Peluquero>();

            // Inicializamos null
            SqlConnection connection = null;

            try
            {
                // Creamos la conexión SQL
                connection = new SqlConnection("Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;");
                string query = "SELECT * FROM Peluqueros";
                SqlCommand command = new SqlCommand(query, connection);

                // Abrimos 
                connection.Open();

                // Ejecutamos la consulta y obtenemos un lector de datos
                SqlDataReader reader = command.ExecuteReader();

                // Recorremos los resultados y creamos objetos 'Peluquero' a partir de los datos
                while (reader.Read())
                {
                    Peluquero peluquero = new Peluquero
                    {
                        // Asignamos los valores leídos desde la base de datos a las propiedades del peluquero
                        IdPeluquero = (int)reader["IdPeluquero"], 
                        Nombre = (string)reader["Nombre"],
                        Especialidad = (string)reader["Especialidad"] 
                    };
                    // Agregamos el peluquero a la lista
                    peluqueros.Add(peluquero);
                }
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL 
                Console.WriteLine("Ocurrió un error al obtener los peluqueros: " + ex.Message);
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

            // Retornamos la lista de peluqueros obtenidos
            return peluqueros;
        }
    }
}
