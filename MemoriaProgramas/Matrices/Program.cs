using System;

namespace Matrices                  //Consola para probar clase MathIA.Matriz
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] m = new double[][] { new double[] { 1,4,5 },new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }, new double[] { 7, 8, 9 } };
            //double[][] inv = MathIA.Matriz.Inversa(m);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write("|\t"+m[i][j]+"\t|");
                Console.WriteLine();
            }

            double[][] T = MathIA.Matriz.Producto(m,10);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write("|\t" + T[i][j] + "\t|");
                Console.WriteLine();
            }
        }
    }
}