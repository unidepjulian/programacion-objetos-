using proy.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy
{
    // Esta clase Cita implementa la interfaz ICita y define cómo se gestionan las citas en la aplicación
    internal class Cita : ICita
    {
        // Propiedades que describen una cita
        public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }  
        public string Descripcion { get; set; }

        // Cadena de conexión a la base de datos
        private string connectionString = "Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;";


        // Método para agregar una nueva cita a la base de datos.
        public void AgregarCita(Cita cita)
        {
            // Usamos una conexión SQL para interactuar 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Query SQL para insertar una nueva cita en la tabla 'Citas'.
                    string query = "INSERT INTO Citas (IdCliente, FechaCita, HoraCita, Descripcion) VALUES (@IdCliente, @FechaCita, @HoraCita, @Descripcion)";

                    // Preparación del comando SQL, asignando los parámetros necesarios.
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdCliente", cita.IdCliente);
                    command.Parameters.AddWithValue("@FechaCita", cita.FechaCita);
                    command.Parameters.AddWithValue("@HoraCita", cita.HoraCita); 
                    command.Parameters.AddWithValue("@Descripcion", cita.Descripcion);

                    // Abrimos la conexión y ejecutamos la query.
                    connection.Open();
                    command.ExecuteNonQuery(); // Ejecuta el comando SQL.

                    // Mensaje de confirmación de éxito.
                    Console.WriteLine("Cita agregada con éxito.");
                }
                catch (SqlException ex) 
                {
                    // Mostramos un mensaje de error en caso de que ocurra una excepción.
                    Console.WriteLine($"Error al agregar la cita: {ex.Message}");
                }
                finally
                {
                    // El bloque finally siempre se ejecuta, cerrando la conexión si está abierta.
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close(); // Cerramos la conexión de forma segura.
                      
                    }
                }

            }
        }

        // Método para obtener una lista de citas 
        public List<Cita> ObtenerCitasPorCliente(int idCliente)
        {
            List<Cita> citas = new List<Cita>(); // Lista para almacenar las citas del cliente
            SqlConnection connection = null; // Inicializamos la conexión fuera del bloque try para usarla en finally

            try
            {
                // Creamos la conexión SQL con la cadena de conexión.
                connection = new SqlConnection(connectionString);

                // Query SQL para seleccionar todas las citas que correspondan al IdCliente 
                string query = "SELECT * FROM Citas WHERE IdCliente = @IdCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCliente", idCliente); // Asignamos el valor del parámetro

                // Abrimos la conexión.
                connection.Open();

                // Ejecutamos la query y leemos los datos obtenidos de la consulta
                SqlDataReader reader = command.ExecuteReader();

                // Recorremos los resultados y creamos objetos 'Cita' a partir de los datos.
                while (reader.Read())
                {
                    // Agrega una nueva cita a la lista.
                    citas.Add(new Cita
                    {

                        IdCita = (int)reader["IdCita"], // Asigna el ID de la cita.
                        IdCliente = (int)reader["IdCliente"], // Asigna el ID del cliente.
                        FechaCita = (DateTime)reader["FechaCita"], // Asigna la fecha de la cita.
                        HoraCita = (TimeSpan)reader["HoraCita"], // Asigna la hora de la cita.
                        Descripcion = reader["Descripcion"].ToString() // Asigna la descripción de la cita.
                    });
                }
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL que ocurra durante la conexión o la ejecución de la consulta.
                Console.WriteLine("Ocurrió un error al obtener las citas: " + ex.Message);
            }
            finally
            {
                // El bloque finally siempre se ejecuta, sin importar si ocurre una excepción o no.
                // Cerramos la conexión si está abierta.
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return citas; // Retornamos la lista de citas.
        }
    }
    
}
