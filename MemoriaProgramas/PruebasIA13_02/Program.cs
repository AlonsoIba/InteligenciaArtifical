using System;

namespace PruebasIA13_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Promedio, desviación estándar y varianza");
            Console.WriteLine("Fecha: 13 de febrero de 2020");
            Console.WriteLine("---------------------------------");

            double[] arr = new double[] { 1, 2 , 3 , 4 , 5 };
            double prom = MathIA.Statistics.Mean(arr);
            double var = MathIA.Statistics.Varm(arr);
            double desv = MathIA.Statistics.Stdm(arr);
            Console.WriteLine("Tenemos los siguientes datos: ");
            for (int i = 0; i < arr.Length; i++)                        //Imprimir valores de un arreglo
            {
                Console.Write("[" + arr[i] + "]");
            }
            Console.WriteLine(" ");
            Console.WriteLine("El promedio es " + prom);
            Console.WriteLine("La varianza es " + var);
            Console.WriteLine("La desviación estándar es " + desv);
            Console.ReadKey();

        }
    }
}
