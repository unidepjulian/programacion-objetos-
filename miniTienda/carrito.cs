using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniTienda
{
     class carrito
    {
        public List<productos> lista {  get; set; } = new List<productos>();

        public void AgregarProductos(productos producto1) 
        {
          lista.Add(producto1);
        }
       public void mostrarcarrito()
       {
            for (int p = 0; p < lista.Count; p++) 
            {
             Console.WriteLine($"Nombre -> '{lista[p].Nombre}',"
                 + $"Cantidad -> '{lista[p].Cantidad}',"
                 + $"Precio -> '${lista[p].Precio}',"
                 + $"Total -> ' ${lista[p].Cantidad * lista[p].Precio}'");
            }
        
        }
    }
}
