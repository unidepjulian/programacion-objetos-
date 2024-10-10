using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos.abstracta
{//clase poligono
    internal class poligono : figura
    {
        //// Propiedad que representa 
        ///el número de lados del polígono, la longitud y el apotema 
        public int nlados { get; set; }
        public double longi { get; set; }
        public Double apotema { get; set; }

        // Implementación del cálculo del área del círculo y del perimetro
        public override void CalculaArea()
        {
            // Llama al método para calcular el perímetro antes de calcular el área.
            CalculadorPerimetro();

            Area = (apotema* Perimetro) /2 ;

        }
        public override void CalculadorPerimetro()
        {
            Perimetro = nlados * longi;

        }
    }
}
