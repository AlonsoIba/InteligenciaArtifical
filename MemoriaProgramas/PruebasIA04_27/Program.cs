using System;

namespace PruebasIA04_27
{
    class Program                       //Programa para HackeandoTec
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

            double[,] input = new double[2, 3] { { 1, 2,3 }, { 4,5,6 } };
            for(int i=0;i<input.GetLength(0);i++)
            {
                for(int j=0;j<input.GetLength(1);j++)
                {
                    Console.Write("|" + input[i, j] + "|");
                }
                Console.WriteLine("");
            }



            Console.WriteLine(input.GetLength(0));      //Filas
            Console.WriteLine(input.GetLength(1));      //Columnas            
            
            double[] fila = new double[input.GetLength(1)];
            double[] columna = new double[input.GetLength(0)];

            int n_fila = 0;
            int n_columna = 2;
            Console.WriteLine("GetRow");
            fila = MathIA.RNA.GetRow(input, n_fila);
            for(int i=0;i<input.GetLength(1);i++)
            {
                Console.Write("|"+fila[i]+"|");
            }
            Console.WriteLine("\nGetCol");
            columna = MathIA.RNA.GetCol(input, n_columna);
            for (int i = 0; i < input.GetLength(0); i++)
            {
                Console.WriteLine("|" + columna[i] + "|");
            }

            Console.WriteLine(MathIA.RNA.Hardlim(0));

            Console.WriteLine("\nTranspuesta\n");
            double[,] output = MathIA.RNA.Transpose(input);
            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    Console.Write("|" + output[i, j] + "|");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("7 segmentos");

            double[,] P = new double[10, 7] { { 1, 1, 1, 1, 1, 1, 0 },
                                    { 0, 1, 1, 0, 0, 0, 0 },
                                    { 1, 1, 0, 1, 1, 0, 1 },
                                    { 1, 1, 1, 1, 0, 0, 1 },
                                    { 0, 1, 1, 0, 0, 1, 1 },
                                    { 1, 0, 1, 1, 0, 1, 1 },
                                    { 1, 0, 1, 1, 1, 1, 1 },
                                    { 1, 1, 1, 0, 0, 0, 0 },
                                    { 1, 1, 1, 1, 1, 1, 1 },
                                    { 1, 1, 1, 1, 0, 1, 1 }};
            double[,] Pt = MathIA.RNA.Transpose(P);
            int[] ta = new int[10] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
            int[] tb = new int[10] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 };
            int[] tc = new int[10] { 0, 0, 1, 1, 0, 1, 0, 1, 0, 0 };
            double[] W = new double[7];
            double[] E = new double[10];
            double b;
            int[] t;
            int epocas = 7;
            Random aleatorio;

            Console.WriteLine("Números pares");
            t = tc;
            aleatorio = new Random();
            for (int i = 0; i < W.Length; i++)
            {
                W[i] = 0;// 2 * aleatorio.NextDouble() - 1;
            }
            b = 0;// 2 * aleatorio.NextDouble() - 1;

            for (int k = 0; k < epocas; k++)
            {
                for (int i = 0; i < t.Length; i++)
                {
                    E[i] = t[i] - MathIA.RNA.Hardlim(MathIA.Arithmetic.Dot(W, MathIA.RNA.GetCol(Pt, i))+b);
                    W = MathIA.Arithmetic.Sum(W, MathIA.Arithmetic.Prod(E[i], MathIA.RNA.GetCol(Pt, i)));
                    b = b + E[i];
                }
                
            }

            Console.WriteLine("Matriz W");
            for (int i = 0; i < W.Length; i++)
            {
                Console.WriteLine("|" + W[i] + "|");
            }

            Console.WriteLine(b);

            Console.WriteLine("Error");
            for (int i = 0; i < E.Length; i++)
            {
                Console.WriteLine("|" + E[i] + "|");
            }
        }
    }
}
