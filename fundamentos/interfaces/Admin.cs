using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos.interfaces
{
    internal class Admin : IUsuario
    {
        // Implementación de las propiedades de la interfaz
        public string Nombre { get ; set ; }
        public string Email { get ; set ; }
        public int Nivel { get ; set ; }


        // Implementación del método para actualizar perfil
        public bool ActualizaPerfil(string nombre, string Email)
        {
            return true;

        }

        public void login()
        {
            //SQL CONEXXION
            Console.WriteLine("usuario logeado");
        }
    }
}
