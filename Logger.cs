using calificacion.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calificacion
{
    class Logger
    {
        static string constrg = "Data Source=LAPTOP-HAM48O16\\PRACTICAS; Initial Catalog = calificacion; User ID = sa; Password = 12345; TrustServerCertificate = True";
        public static void Log(string mensaje,string metodo,string clase)
        {
            SqlConnection conn = new SqlConnection(constrg);
            SqlCommand comm = new SqlCommand("INSERT INTO LogError (mensaje,metodo,clase,fecha)VALUES(@mensaje,@metodo,@clase,@fecha) ", conn);
            comm.Parameters.AddWithValue("@mensaje", mensaje);
            comm.Parameters.AddWithValue("@metodo", metodo);
            comm.Parameters.AddWithValue("@clase", clase);
            comm.Parameters.AddWithValue("@fecha", DateTime.Now);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
               
            }

            finally
            {
                conn.Close();
            }
        }
    }
}
