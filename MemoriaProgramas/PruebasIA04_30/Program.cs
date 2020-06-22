using System;
using System.Globalization;

namespace PruebasIA04_30
{
    class Program                                   //Evaluar clase RNA para HacekandoTec
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: 7 segmentos");
            Console.WriteLine("Fecha: 27 de abril de 2020");
            Console.WriteLine("---------------------------------");

            double[,] P = new double[2, 9] { { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, { 7, 8, 7, 1, 2, 1, 7, 8, 7 } };
            double[,] T = new double[2, 9] { { 0, 0, 0, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 0, 0, 0 } };
            double[,] W = new double[2, 2];
            double[] b=new double [2];
            double[,] E = new double[2, 9];
            int epocas = 500;
            Random aleatorio= new Random();
            for (int i = 0; i < W.GetLength(0); i++)
            {
                for (int j = 0; j < W.GetLength(1); j++)
                {
                    W[i, j] = 0;// 2 * aleatorio.NextDouble() - 1;
                }
            }

            for (int i = 0; i < E.GetLength(0); i++)
            {
                for (int j = 0; j < E.GetLength(1); j++)
                {
                    E[i, j] = 0;// 2 * aleatorio.NextDouble() - 1;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                b[i] = 0;// 2 * aleatorio.NextDouble() - 1;
            }

            for (int k = 0; k < epocas; k++)
            {
                for (int i = 0; i < P.GetLength(1); i++)
                {
                    for (int j = 0; j < P.GetLength(0); j++)
                    {
                        E[j, i] = T[j, i] - MathIA.RNA.Hardlim(MathIA.Arithmetic.Dot(MathIA.RNA.GetRow(W, j), MathIA.RNA.GetCol(P, i)) + b[j]);
                        W = MathIA.Arithmetic.Sum(W, MathIA.Arithmetic.Prod(MathIA.RNA.GetCol(E, i), MathIA.RNA.GetCol(P, i)));
                        b[j]= b[j] + E[j,i];
                    }
                }
            }


            Console.WriteLine("Matriz W\n");
            for (int i = 0; i < W.GetLength(0); i++)
            {
                for (int j = 0; j < W.GetLength(1); j++)
                {
                    Console.Write("|" + W[i, j] + "|");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Vector b");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                Console.WriteLine("|" + b[i] + "|");
            }

            Console.WriteLine("Matriz E\n");
            for (int i = 0; i < E.GetLength(0); i++)
            {
                for (int j = 0; j < E.GetLength(1); j++)
                {
                    Console.Write("|"+E[i, j]+"|");
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
