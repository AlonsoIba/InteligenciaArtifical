using MathIA;
using System;

namespace EstimacionParametrica                 //Algoritmo de estimación paramétrica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estimación paramétrica");

            double[][] t = Matriz.Vector(1, 10, 1);
            double[][] y = Matriz.Crear(1, 10);
            for (int i = 0; i < y[0].Length; i++)
            {
                y[0][i] = 10*Math.Sin(t[0][i])-5*Math.Exp(t[0][i])+13*Math.Sqrt(t[0][i]);
            }
            double[][] psi = Matriz.Crear(3, y[0].Length);
            for (int i = 0; i < y[0].Length; i++)
            {
                psi[0][i] = Math.Sin(t[0][i]);
                psi[1][i] = Math.Exp(t[0][i]);
                psi[2][i] = Math.Sqrt(t[0][i]);
            }

            double[][] theta = Matriz.EstimacionParametrica(y, psi); //Una vez probado, se agrego a la clase MathIA


            Console.WriteLine(Math.Round(theta[0][0], 5));
            Console.WriteLine(Math.Round(theta[1][0], 5));
            Console.WriteLine(Math.Round(theta[2][0], 5));

        }
    }
}
