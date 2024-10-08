using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos
{
    //heredar de persona de persona 2 

    internal class persona2:persona
    {

        // Constructor que inicializa los atributos heredados 
        public persona2(string nombre,string email , int id ) 
        {
            Nombre = nombre;
            Email = email;
            ID = id;
            // Imprime los valores inicializados
            imprimeID();
            imprimeNombre();
            imprimeEmail();
            imprimeFecha();
        }

        // Método adicional para imprimir el email
        public void imprimeEmail()
        {
            Console.WriteLine(Email);
        }

    }
}
