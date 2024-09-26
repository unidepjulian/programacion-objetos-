 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    class catalogo
    {
        private static List<articulo> inventario { get; set; } 
        private static void llenarcatalogo()
        {
            inventario = new List<articulo>
            {
                new articulo { Nombre = "jabon", Precio = 18.9f, ID = 1 },
                new articulo { Nombre = "mayonesa", Precio = 45.10f, ID = 2 },
                new articulo { Nombre = "tomate", Precio = 49.00f, ID = 3 },
                new articulo { Nombre = "carne", Precio = 98.00f, ID = 4 },
                new articulo { Nombre = "huevos", Precio = 80.90f, ID = 5 },

            };
        }
        public static void MostrarCatalogo() 
        {
            llenarcatalogo();
            foreach (articulo art in inventario) 
            {
            Console.WriteLine($"{art.ID} - {art.Nombre} - {art.Precio}");
            
            }
         
        }
        public static articulo BuscarArticuloPorID(int artID)
        {
          return inventario.Find(articulo => articulo.ID.Equals(artID));
        }    

}
    }
