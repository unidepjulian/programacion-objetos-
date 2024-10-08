using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos
{
    internal class Program
    {
        // Clase principal donde se ejecuta el programa
        static void Main(string[] args)
        {
            // Se crea una instancia de la clase 'persona2'
            persona2 Persona2 = new persona2("juan","juan@correo",1);
            Console.ReadLine();

            // Se actualizan los atributos de la persona
            Persona2.Nombre = "juan luis";
            Persona2.Email = "juan@correo.com";

            // Llamada a los métodos para imprimir los atributos
            Persona2.imprimeNombre();
            Persona2.imprimeEmail();

            // Actualiza la fecha de creación con la fecha actual
            Persona2.cambiarFecha(DateTime.Now);
            Persona2.imprimeFecha();
            Console.ReadLine();
        }
    }
}
