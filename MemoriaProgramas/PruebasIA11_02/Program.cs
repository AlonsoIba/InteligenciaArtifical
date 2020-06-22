using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasIA
{
    class Program                                       //Operaciones aritmeticas
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Promedio");
            Console.WriteLine("Fecha: 11 de febrero de 2020");
            Console.WriteLine("---------------------------------");


            double[] a = new double[5] { 1, 2, 3, 4, 5 };
            double s = MathIA.Arithmetic.Sum(a);
            double[] b = new double[5];
            b = MathIA.Arithmetic.Sum(5, a);
            Console.WriteLine("Suma de valores en un vector");
            Console.WriteLine(s);
            Console.WriteLine("Suma de un escalar a un vector");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("[" + a[i] + "] ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Suma de dos arreglos");
            double[,] c = new double[2, 2] { { 1, 2 }, { 3, 4 } };
            double[,] d = new double[2, 2];
            d = MathIA.Arithmetic.Sum(c, c);
            for (int j = 0; j < d.GetLength(1); j++)
            {
                for (int i = 0; i < d.GetLength(0); i++)
                {
                    Console.Write("[" + d[i, j] + "] ");
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine("Raíz de un número");
            double r = MathIA.ExpLog.Sqrt(1524);
            Console.WriteLine("La raíz de 1524 es " + r);

            Console.WriteLine("Cuadrado de un número");
            double p = MathIA.Arithmetic.Power(1524,2);
            Console.WriteLine("El cuadrado de 1524 es " + p);

            Console.WriteLine("Inverso cuadrado de un número");
            double q = MathIA.Arithmetic.Power(1524, -2);
            Console.WriteLine("El inverso cuadrado de 1524 es " + q);
            Console.ReadKey();
        }
    }
}
