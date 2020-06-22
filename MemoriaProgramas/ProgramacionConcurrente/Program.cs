using System;
using System.Threading;

namespace ProgramacionConcurrente
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

            TimeSpan stop1;
            TimeSpan start1 = new TimeSpan(DateTime.Now.Ticks);

            calculo_pi();
            calculo_e();

            stop1 = new TimeSpan(DateTime.Now.Ticks);


            TimeSpan stop2;
            TimeSpan start2 = new TimeSpan(DateTime.Now.Ticks);
            Thread Hilo1 = new Thread(calculo_pi);
            Thread Hilo2 = new Thread(calculo_e);
            Hilo1.Start();
            Hilo2.Start();
            Hilo1.Join();
            Hilo2.Join();
            stop2 = new TimeSpan(DateTime.Now.Ticks);

            Console.WriteLine("El programa secuencial tardó " + stop1.Subtract(start1).TotalMilliseconds + " milisegundos");
            Console.WriteLine("El programa con hilos tardó " + stop2.Subtract(start2).TotalMilliseconds + " milisegundos");
            Console.ReadKey();
        }

        static void calculo_pi()
        {
            double pi = 0;
            long cont = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    for (int k = 0; k < 1000; k++)
                    {
                        pi = Math.Pow(-1, cont) * 4 / (2 * cont + 1) + pi;          //Método numérico para obtener pi 
                        cont++;
                    }
                }
            }
            Console.WriteLine("Pi=" + pi);
        }

        static void calculo_e()
        {
            double e = 0;
            double cont_e = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    for (int k = 0; k < 1000; k++)
                    {
                        e = Math.Pow((1.0 + 1.0 / cont_e), cont_e);          //Interés compuesto para estimar e 
                        cont_e++;
                    }
                }
            }
            Console.WriteLine("E=" + e);
        }
    }
}
