using System;
using System.Threading;

namespace EstimacionPendiente              //Programa para estimar una pendiente
{
    class Program
    {
        public static double m;
        public static double max;
        public static double min;
        public static double error;
        public static double signo;
        public static int i;
        public static double[] x;
        public static double[] y;
        public static double mt;
        public static Random rand;

        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Estimación de pendiente entre dos puntos");
            Console.WriteLine("Fecha: 12 de marzo de 2020");
            Console.WriteLine("---------------------------------");

            x = new double[2] { 1, 2 };                 //Absisas
            y = new double[2] { 1, 2 };                 //Ordenadas
            mt = (y[0] - y[1]) / (x[0] - x[1]);         //Pendiente real
            m =0;                   
            max = 100;                                  //Limite superior
            min = -100;                                 //Limite inferior
            error=1;
            i = 0;
            rand = new Random();

            Pendiente();
            Console.WriteLine("En " + i + " intentos");
            Console.ReadKey();
        }
        static void Pendiente()
        {
            while (error > 0)
            {
                m = rand.NextDouble() * (max - min) + min;  //Valor aleaotrio
                signo = (m - mt) / mt;                     //Signo del error
                error = Math.Abs(signo);                    //Valor absoluto del error
                Console.WriteLine("Una pendiente de " + m + " tiene un error de " + error);
                if (mt > 0)                                 //Se cambian los limites inferior y superior para ir acotando
                {
                    if (signo < 0)
                    {
                        min = m;
                    }
                    else if (signo > 0)
                    {
                        max = m;
                    }
                }
                else if (mt < 0)
                {
                    if (signo < 0)
                    {
                        max = m;
                    }
                    else if (signo > 0)
                    {
                        min = m;
                    }
                }
                i++;
            }
        }
    }
}
