using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace POOsemana1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;

            // Menú
            Console.WriteLine("****************");
            Console.WriteLine("      Menú      ");
            Console.WriteLine("****************");
            Console.WriteLine("1. comparar tres números menor a mayor");
            Console.WriteLine("2. Verificar si un número es primo");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                CompararNumeros();
            }
            else if (opcion == 2)
            {
                VerificarPrimo();
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }

            Console.ReadKey(); // Espera una tecla antes de cerrar el programa
        }

        static void CompararNumeros()
        {
            int n1 = 0;
            int n2 = 0;
            int n3 = 0;
            Console.WriteLine("Dame el primer número: ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame el segundo número: ");
            n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame el tercer número: ");
            n3 = Convert.ToInt32(Console.ReadLine());

            // Inicializar las variables para el menor y el mayor
            int menor = n1;
            int mayor = n1;

            // Comparaciones para determinar el menor
            if (n2 < menor)
            {
                menor = n2;
            }
            if (n3 < menor)
            {
                menor = n3;
            }

            // Comparaciones para determinar el mayor
            if (n2 > mayor)
            {
                mayor = n2;
            }
            if (n3 > mayor)
            {
                mayor = n3;
            }

            // Mostrar el menor y el mayor
            Console.WriteLine("El número menor es: " + menor);
            Console.WriteLine("El número mayor es: " + mayor);
        }

        static void VerificarPrimo()
        {
            int n = 0;
            Console.WriteLine("Ingrese un número: ");
            n = Convert.ToInt32(Console.ReadLine());

            // Si el número es menor o igual a 1, no es primo
            if (n <= 1)
            {
                Console.WriteLine(n + " no es primo.");
                return;
            }

            // Desde el 2 hasta uno menos que 'n'
            //ejemplo 7 se le resta uno entonces quedaria 2,3,4,5,6
            //ejemplo 13 se le resta uno entonces quedaria 2,3,4,5,6,7,8,9,10,11,12
            for (int i = 2; i < n; i++)
            {
                // Si 'n' es divisible por 'i', no es primo
                /*ejemplo  con el 7 
                 *            (n) (i)
                   i = 2:
                   Comprobamos 7 % 2. El residuo es 1 (no es divisible).

                   i = 3:
                   Comprobamos 7 % 3. El residuo es 1 (no es divisible).

                   i = 4:
                   Comprobamos 7 % 4. El residuo es 3 (no es divisible).

                   i = 5:
                   Comprobamos 7 % 5. El residuo es 2 (no es divisible).

                   i = 6:
                   Comprobamos 7 % 6. El residuo es 1 (no es divisible).
                 */
                if (n % i == 0)
                {
                    Console.WriteLine(n + " no es primo.");
                    return; // No es necesario seguir comprobando
                }
            }

            // Si no se encontró ningún divisor, el número es primo
            Console.WriteLine(n + " es primo.");
        }

    }
    }




    

    