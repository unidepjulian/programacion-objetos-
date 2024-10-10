<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos
{
    internal class Program
    {
        // Clase principal donde se ejecuta el programa
        static void Main(string[] args)
        {
            // Se crea una instancia de la clase 'persona2'
            persona2 Persona2 = new persona2("juan","juan@correo",1);
            Console.ReadLine();

            // Se actualizan los atributos de la persona
            Persona2.Nombre = "juan luis";
            Persona2.Email = "juan@correo.com";

            // Llamada a los métodos para imprimir los atributos
            Persona2.imprimeNombre();
            Persona2.imprimeEmail();

            // Actualiza la fecha de creación con la fecha actual
            Persona2.cambiarFecha(DateTime.Now);
            Persona2.imprimeFecha();
            Console.ReadLine();
        }
    }
}
=======
﻿using fundamentos.abstracta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentos
{
    internal class Program
    {
        // Clase principal donde se ejecuta el programa
        static void Main(string[] args)
        {
            /* // Se crea una instancia de la clase 'persona2'
             persona2 Persona2 = new persona2("juan","juan@correo",1);
             Console.ReadLine();

             // Se actualizan los atributos de la persona
             Persona2.Nombre = "juan luis";
             Persona2.Email = "juan@correo.com";

             // Llamada a los métodos para imprimir los atributos
             Persona2.imprimeNombre();
             Persona2.imprimeEmail();

             // Actualiza la fecha de creación con la fecha actual
             Persona2.cambiarFecha(DateTime.Now);
             Persona2.imprimeFecha();
             Console.ReadLine();*/

            Console.WriteLine(" -*****************cuadrado************-");
            cuadrado CUADRADO = new cuadrado()
            {
                MedidaLado = 5,
                UnidadMedida = "metros "
            };

            CUADRADO.CalculaArea();
            CUADRADO.CalculadorPerimetro();
            CUADRADO.MuestraArea();
            CUADRADO.MuestraPerimetro();

            //*******************************************
            Console.WriteLine("\n -***************triangulo**********-");

            triangulo TRIANGULO = new triangulo()
            {
                L1 = 5,
                l2 = 6,
                L3 = 7,
                basen=6,
                altura = 8,
                UnidadMedida = "metros "
            };

            TRIANGULO.CalculaArea();
            TRIANGULO.CalculadorPerimetro();
            TRIANGULO.MuestraArea();
            TRIANGULO.MuestraPerimetro();
            //*************************************

            Console.WriteLine("\n -**************circulo***************-");
            circulo CIRCULO = new circulo()
            {
               radio = 5,
                UnidadMedida = "metros "
            };

            CIRCULO.CalculaArea();
            CIRCULO.CalculadorPerimetro();
            CIRCULO.MuestraArea();
            CIRCULO.MuestraPerimetro();
            //**************************************

            Console.WriteLine("\n -***************renctagulo**************-");
            rectangulo RECTANGULO = new rectangulo()
            {
                ba = 5,
                alt =8,
                UnidadMedida = "metros "
            };

            RECTANGULO.CalculaArea();
            RECTANGULO.CalculadorPerimetro();
            RECTANGULO.MuestraArea();
            RECTANGULO.MuestraPerimetro();

            Console.WriteLine("\n -*****************poligono************-");
            poligono POLIGONO = new poligono()
            {
                nlados= 5,
                longi= 6,
                apotema = 4.1,
                UnidadMedida = "metros "
            };

            POLIGONO.CalculaArea();
            POLIGONO.CalculadorPerimetro();
            POLIGONO.MuestraArea();
            POLIGONO.MuestraPerimetro();


            Console.ReadLine();







        }
    }
}
>>>>>>> 03798b3 (figuras)
