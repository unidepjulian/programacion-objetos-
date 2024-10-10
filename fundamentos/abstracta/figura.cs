using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos.abstracta
{
    // Clase abstracta
    internal abstract class figura
    {
        //para almacenar el área y el perímetro 
        protected Double Area {  get; set; }
        protected double Perimetro { get; set; }
        public string UnidadMedida { get; set; }// Propiedad para especificar la unidad de medida (ejem. metros).
       
        // Método abstracto que debe ser implementado por las subclases para calcular el area y perimetro.
        public abstract void CalculaArea();      
        public abstract void CalculadorPerimetro();

        // Método que muestra el área de la figura en la consola.
        public void  MuestraArea() 
        {
            Console.WriteLine($"el area es {Area} {UnidadMedida}"); 
        }
        public void MuestraPerimetro()
        {
            Console.WriteLine($"el perimetro es {Perimetro} {UnidadMedida} ");
        }
    }
}
