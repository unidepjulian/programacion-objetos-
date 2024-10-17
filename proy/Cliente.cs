using proy.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy
{
    // Esta clase Cliente implementa la interfaz ICliente
    internal class Cliente : ICliente
    {
        // Propiedades que describen un cliente
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        // Cadena de conexión 
        private string connectionString = "Server=LAPTOP-HAM48O16\\PRACTICAS;Database=proyecto;User Id=sa;Password=12345;"; 

        // Método para agregar un nuevo cliente a la base de datos
        public void AgregarCliente(Cliente cliente)
        {
            SqlConnection connection = null; // Inicializamos la conexión a null

            try
            {
                // Creamos la conexión SQL
                connection = new SqlConnection(connectionString);

                // Consulta SQL para insertar un nuevo cliente en la tabla 'Clientes'
                string query = "INSERT INTO Clientes (Nombre, Telefono) VALUES (@Nombre, @Telefono)";
                SqlCommand command = new SqlCommand(query, connection);

                // Asignamos los parámetros 
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                // Abrimos la conexión.
                connection.Open();

                // Ejecuta el comando SQL para insertar el cliente
                command.ExecuteNonQuery();

                // Mensaje de confirmación de éxito
                Console.WriteLine("Cliente agregado con éxito.");
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL que ocurra durante la conexión
                Console.WriteLine($"Error al agregar el cliente: {ex.Message}");
            }
            finally
            {
               
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); // Cerramos la conexión de forma segura.
                }
            }
          
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>(); // Lista para almacenar los clientes.
            SqlConnection connection = null; 

            try
            {
                // Creamos la conexión SQL 
                connection = new SqlConnection(connectionString);

                string query = "SELECT * FROM Clientes"; // Consulta SQL para seleccionar todos los clientes
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open(); // Abrimos la conexión a la base de datos.

                SqlDataReader reader = command.ExecuteReader(); // Ejecutamos la consulta y obtenemos un lector para los resultados

                // Recorremos los resultados y creamos objetos 'Cliente' a partir de los datos
                while (reader.Read())
                {
                    // Agrega un nuevo cliente a la lista
                    clientes.Add(new Cliente
                    { // Asignamos y  tambien manejando posibles valores nulos.
                        IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? 0 : (int)reader["IdCliente"], 
                        Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? string.Empty : reader["Nombre"].ToString(),
                        Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? string.Empty : reader["Telefono"].ToString(), 
                    });
                }
            }
            catch (SqlException ex)
            {
                // Capturamos cualquier excepción SQL
                Console.WriteLine("Ocurrió un error al obtener los clientes: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción que no sea de SQL
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
            finally
            {
               
                // Cerramos la conexión si está abierta.
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); // Cerramos 
                }
            }

            return clientes; // Retornamos la lista de clientes
            
        }
    }
}




