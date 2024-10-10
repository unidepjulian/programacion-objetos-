using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos.abstracta
{
    //clase rectangunlo 
    internal class rectangulo : figura
    {
        //propiedades que representa base y altura
        public int ba { get; set; }
        public int alt { get; set; }

        // Implementación del cálculo del área del círculo y del perimetro
        public override void CalculaArea()
        {
            Area = ba * alt; 
            
        }
        public override void CalculadorPerimetro()
        {
            Perimetro = (ba + alt) * 2;
            
        }
    }
}
