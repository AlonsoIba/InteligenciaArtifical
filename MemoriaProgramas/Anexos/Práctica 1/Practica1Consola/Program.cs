using System;
using System.Diagnostics;
using System.Threading;

namespace Practica1Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch tiempo = new Stopwatch();
            Thread hilo = new Thread(Ciclos);

            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Práctica 1: Programación concurrente");
            Console.WriteLine("Fecha: 22 de marzo de 2020");
            Console.WriteLine("---------------------------------");

            tiempo.Start();
            hilo.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
            }
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write("y");
            //}
            hilo.Join();
            Thread.Sleep(3000);
            Console.WriteLine($"\n Tiempo: {tiempo.Elapsed.TotalMilliseconds} ms");
            Console.ReadKey();
        }

        static void Ciclos()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }
        }
    }
}
