using Azure;
using calificacion.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calificacion
{
    class central
    {
        //sql server 
        static string constrg = "Data Source=LAPTOP-HAM48O16\\PRACTICAS; Initial Catalog = calificacion; User ID = sa; Password = 12345; TrustServerCertificate = True";
        //*********

        public static response RegistrarAlumnos(AlumnO alumno) 
        {
            response Response = new response();
            SqlConnection conn = new SqlConnection (constrg);
            SqlCommand comm = new SqlCommand("INSERT INTO alumnos (nombre,apellido,matricula)VALUES(@Nombre,@Apellidos,@Matricula) ", conn);
            comm.Parameters.AddWithValue("@Nombre", alumno.Nombres);
            comm.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
            comm.Parameters.AddWithValue("@Matricula", alumno.Matricula);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                Response.Codigo = 1;
                Response.Mensaje = "alumnos registrado correcto ";
            }
            catch (Exception ex)
            {
                Response.Codigo = 2 ;
                Response.Mensaje = "ocurrio un error, el alumno no registro";
                Logger.Log(ex.Message, "registraralumno", "Central");
            }
        
            finally
            {
                conn.Close();
            }
            return Response;

        }



        public static DataTable CargarAlumno()
        {
            DataTable dtalumnos = new DataTable();
            SqlConnection conn = new SqlConnection(constrg);
            SqlCommand comm = new SqlCommand("select* from alumnos", conn);
            
            try
            {
                conn.Open();
                SqlDataAdapter  da= new SqlDataAdapter(comm);
                da.Fill(dtalumnos);
            }
            catch (Exception ex)
            {
               
                Logger.Log(ex.Message, "cargarAlumnos", "Central");
            }

            finally
            {
                conn.Close();
            }

            //codigo para obterner la lista de alumnos 
            return dtalumnos;

        }

        public static void RegitrarMAteria(MaTeria MATERIA)
        { 
        
        }
        public static DataTable CargarMateria()
        {
            DataTable dtMateria = new DataTable();

            //codigo para obtener la lista de alumnos 
            return dtMateria;

        }
    }
}
