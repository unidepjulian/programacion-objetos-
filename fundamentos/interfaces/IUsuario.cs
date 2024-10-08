using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos.interfaces
{
    // Definición de la interfaz para usuarios
    internal interface IUsuario
    {
        // Propiedades que deben implementar las clases
        string Nombre { get; set; }
        string Email { get; set; }

        // Métodos que deben implementar las clases
        void login();
        bool ActualizaPerfil(string nombre , string Email);
    }
}
