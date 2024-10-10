using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos.abstracta
{//clase circulo
    internal class circulo : figura
    {
        // Propiedad que representa el radio del círculo
        public int radio { get; set; }


        // Implementación del cálculo del área del círculo y del perimetro
        public override void CalculaArea()
        {
                   //(π * radio ^ 2).
            Area = Math.PI * Math.Pow(radio, 2);

        }

        public override void CalculadorPerimetro()
        {              //(2 * π * radio).
            Perimetro = 2 * Math.PI * radio;
        }
    }
}
