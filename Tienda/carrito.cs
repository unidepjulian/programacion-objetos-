using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    class carrito
    {
        public List<articulo> Lista { get; set; } = new List<articulo>();


        public void AgregarArticulo(articulo articulo)
        {
            Lista.Add(articulo);
        }

        public void MostrarArticulosEnCarrito()
        {
            if (Lista.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                foreach (var articulo in Lista)
                {
                    Console.WriteLine($"ID: {articulo.ID}, Nombre: {articulo.Nombre}, Precio: {articulo.Precio}");
                }
            }
        }
    }
}
    
