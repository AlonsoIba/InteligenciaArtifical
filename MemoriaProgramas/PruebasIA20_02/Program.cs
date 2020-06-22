using System;

namespace PruebasIA25_02
{
    class Program                                               //Generación de una distribución normal para un arreglo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Función de distribución de probabilidad");
            Console.WriteLine("Fecha: 25 de febrero de 2020");
            Console.WriteLine("---------------------------------");


            double[]arr = new double[50] { 1.95, 1.95, 1.93, 1.96, 1.95, 1.93, 1.96, 1.92, 1.92, 1.93, 1.93, 1.93, 1.95, 1.93, 1.94, 1.96, 1.93, 1.95, 1.95, 1.95, 1.96, 1.96, 1.95, 1.93, 1.96, 1.93, 1.96, 1.92, 1.92, 1.93, 1.93, 1.93, 1.95, 1.93, 1.93, 1.95, 1.93, 1.94, 1.96, 1.93, 1.95, 1.93, 1.94, 1.96, 1.95, 1.95, 1.95, 1.93, 1.94, 1.96 };
            MathIA.ObjStac integrados = new MathIA.ObjStac(arr);        //Clase objeto estadístico
            double min = integrados.Min;
            double max = integrados.Max;
            double[] x = integrados.x;                                  //Linspace
            double[] y = integrados.y;                                  //Normpdf del linspace
            Console.WriteLine("Tenemos los siguientes datos: ");
            for (int i = 0; i < x.Length; i++)                        //Imprimir valores de un arreglo
            {
                Console.WriteLine("[" + x[i] + "]");
            }
            Console.WriteLine("Hay " + x.Length + " elementos en el arreglo");
            Console.WriteLine("Distribución normal");
            for (int i = 0; i < x.Length; i++)                        //Imprimir valores de un arreglo
            {
                Console.WriteLine("[" + y[i] + "]");
            }
            Console.ReadKey();
             //Derivada disctreta

        }
    }
}
