using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos.abstracta
{
    // Clase de cuadrado
    internal class cuadrado:figura
    {
        // Propiedad que define la medida del lado del cuadrado.
        public int MedidaLado { get; set; }

        // Implementación del cálculo del area
        public override void CalculaArea()
        { 
         Area= MedidaLado * MedidaLado;
        }

        // Implementación del cálculo del perimetro
        public override void CalculadorPerimetro() 
        {
            Perimetro = MedidaLado * 4;
        }
    }
}
