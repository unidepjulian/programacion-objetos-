using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniTienda
{
    internal class Program
    {
        static void Main(string[] args)
        {

            carrito CARRITO = new carrito();
            string continuar = "si";
            while (continuar.ToLower() == "si")
            {

                string nombre = "";
                int cantidad = 0;
                decimal precio = 0;
                Console.WriteLine("ingresa nombre del producto");
                nombre = Console.ReadLine();
                Console.WriteLine("ingresa cantidad");
                cantidad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ingresa precio");
                precio = Convert.ToDecimal(Console.ReadLine());

                productos prod = new productos();
                prod.Nombre = nombre;
                prod.Cantidad = cantidad;
                prod.Precio = precio;
                CARRITO.AgregarProductos(prod);

                Console.WriteLine("¿Deseas agregar otro producto? (si/no):");
                continuar = Console.ReadLine();
            }
            caja CAJA = new caja();
            CAJA.Cobrar(CARRITO);
            CARRITO.mostrarcarrito();


            Console.ReadLine();
            

        }
    }
}
