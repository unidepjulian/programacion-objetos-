using proy.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy
{
    // Esta clase representa un servicio ofrecido en la peluquería, implementando la interfaz IServicio

    internal class Servicio : IServicio
    {
        //propiedades
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public decimal Precio { get; set; }
        //conexion a base de datos 
        private string connectionString = "Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;";

        public void AgregarServicio(Servicio servicio)
        {
            SqlConnection connection = null; // Inicializamos null

            try
            {
                // Creamos la conexión SQL
                connection = new SqlConnection(connectionString);

                // Consulta SQL para insertar un nuevo servicio
                string query = "INSERT INTO Servicios (NombreServicio, Precio) VALUES (@NombreServicio, @Precio)";
                SqlCommand command = new SqlCommand(query, connection);

                // Asignamos los parámetros
                command.Parameters.AddWithValue("@NombreServicio", servicio.NombreServicio);
                command.Parameters.AddWithValue("@Precio", servicio.Precio);

                // Abrimos la conexión
                connection.Open();


                command.ExecuteNonQuery();
                Console.WriteLine("Servicio agregado con éxito.");
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL
                Console.WriteLine($"Error al agregar el servicio: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Capturamos cualquier otra excepción que no sea de SQL
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

        public List<Servicio> ObtenerServicios()
        {
            List<Servicio> servicios = new List<Servicio>(); // Lista para almacenar los servicios
            SqlConnection connection = null; // null

            try
            {
                
                connection = new SqlConnection(connectionString);
                string query = "SELECT * FROM Servicios";
                SqlCommand command = new SqlCommand(query, connection);

                // Abrimos la conexión
                connection.Open();

                // Ejecutamos la consulta y obtenemos un lector de datos
                SqlDataReader reader = command.ExecuteReader();

                // Recorremos los resultados y creamos objetos 'Servicio' a partir de los datos
                while (reader.Read())
                {
                    // Agregamos el servicio a la lista con los valores leídos desde la base de datos
                    servicios.Add(new Servicio
                    { //asignamos
                        IdServicio = (int)reader["IdServicio"],       
                        NombreServicio = reader["NombreServicio"].ToString(), 
                        Precio = (decimal)reader["Precio"]             
                    });
                }
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL y mostramos el mensaje
                Console.WriteLine("Ocurrió un error al obtener los servicios: " + ex.Message);
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

            // Retornamos la lista de servicios obtenidos
            return servicios;
        }
    }
    
}
