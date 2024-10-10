using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos.abstracta
{
    // Clase de un triángulo
    internal class triangulo : figura
    {
       // Propiedades que representan los lados del triángulo, la base y la altura.
        public int L1 { get; set; }
        public int l2 { get; set; }
        public int L3 { get; set; }
        public int basen {  get; set; }
        public int altura { get; set; }

        // Implementación del cálculo del área del triángulo y perimetro
        public override void CalculaArea()
        {
            Area = (basen * altura) / 2;
            

        }
        public override void CalculadorPerimetro()
        {
            Perimetro = L1 + l2 + L3 ;
           
        }
    }
}
