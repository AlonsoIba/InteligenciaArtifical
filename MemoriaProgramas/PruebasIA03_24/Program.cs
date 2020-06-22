using System;

namespace PruebasIA03_24
{
    class Program                                       //Estimación de pendiente empezando por un número aleatorio y acotando mediante el error
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Promedio");
            Console.WriteLine("Fecha: 24 de marzo de 2020");
            Console.WriteLine("---------------------------------");


            double[] x = new double[5] { 1, 2, 3, 4, 5, };
            double[] y = new double[5] { 1, 2, 3, 4, 5, };


            double[] Reg = new double[2];
            Reg=MathIA.Statistics.Regression(x,y);
            double mt = Reg[0];

            Console.WriteLine("La ecuación de la recta es: y = " + mt + "x+" + Reg[1]);

            double m;
            double max = 10;
            double min = -10;
            Random rand = new Random();
            bool error = true;
            int contador = 0;

            while(error)
            {
                m = rand.NextDouble() * (max - min) + min;
                double[] y_real = new double[y.Length];

                for (int i = 0; i < x.Length; i++)
                {
                    y_real[i] = m * x[i];
                }

                double[] ECM = MathIA.Statistics.ECM(y, y_real);
                Console.WriteLine("El error cuadrático medio es " + ECM[0]);
                Console.WriteLine("La pendiente es " + m);
                if(ECM[1]>0)
                {
                    min = m;
                }
                else if(ECM[1]<0)
                {
                    max = m;
                }

                Console.WriteLine("Máximo = " + max + ", Mínimo = " + min);
                if(ECM[0]==0)
                {
                    error = false;
                }
                contador++;
            }
            Console.WriteLine("En " + contador + " intentos");
            Console.ReadKey();
        }
    }
}
