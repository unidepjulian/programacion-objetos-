using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos
{
    internal class persona
    {

        // Propiedad protegida, visible solo en esta clase y clases derivadas
        protected int ID { get; set; }

        // Propiedades públicas accesibles para cualquier instancia
        public string Nombre { get; set; }
        public string Email { get; set; }

        // Propiedad privada que solo puede ser modificada desde esta clase
        private DateTime creado {  get; set; }
        

        //metodos
        public void imprimeNombre() 
        {
         Console.WriteLine(Nombre);
        }
        public void imprimeID()
        {
            Console.WriteLine(ID);
        }
        public void imprimeFecha()
        {
            Console.WriteLine(creado);

        }
        public void cambiarFecha(DateTime nuevafecha) 
        {
            creado = nuevafecha;  

        }
    }
}
