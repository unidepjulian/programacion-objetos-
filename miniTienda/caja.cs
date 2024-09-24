using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniTienda
{
    class caja
    {
        //mostrar la lista de productos y el total del carrito

        public void Cobrar(carrito CARRITO)
        {
            decimal total = 0;

            // Calcular el total de todos los productos en el carrito
            foreach (var Producto in CARRITO.lista)
            {
                total += Producto.Cantidad * Producto.Precio;
            }

            // Mostrar el total
            Console.WriteLine($"Total a pagar: ${total}");


        }


    }
}
