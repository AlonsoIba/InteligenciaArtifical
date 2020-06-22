using System;
using System.Diagnostics;

namespace Practica_1__Consola_
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

            Console.WriteLine("Práctica 1: Programación Concurrente");
            Console.WriteLine("Fecha: 24 de marzo de 2020");
            Console.WriteLine("---------------------------------");

            Stopwatch Tiempo = new Stopwatch();

            Tiempo.Start();
            Console.WriteLine("Tiempo: "+Tiempo.Elapsed.TotalMilliseconds+" ms");

            Console.ReadKey();
        }
    }
}
