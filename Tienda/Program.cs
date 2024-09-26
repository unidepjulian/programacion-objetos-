using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            carrito CArrito = new carrito();  // Crear instancia del carrito
            while (true)
            {
                
                Console.WriteLine("selecciona el articulo");
                Console.WriteLine("selecciona 0 para finalizar");
                catalogo.MostrarCatalogo();
                int artID = Convert.ToInt32(Console.ReadLine());
                if (artID == 0)
                {
                    break;
                }
                articulo articuloseleccionado = catalogo.BuscarArticuloPorID(artID);
                if (articuloseleccionado != null)
                {
                    CArrito.AgregarArticulo(articuloseleccionado);
                    Console.WriteLine($"Articulo '{articuloseleccionado.Nombre}' agregado al carrito.");
                }
                Console.WriteLine();

            }
        }
    }
}
