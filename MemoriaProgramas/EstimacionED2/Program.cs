using System;
using MathIA;
using System.IO;
using System.Collections.Generic;

namespace EstimacionED2                 //Programa en consola para pruebas de estiamción de ecuación de sistema subamortiguado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estimación ecuación diferencial segundo orden");
            string ruta_datos = "Sist2Orden.csv";
            StreamReader lector = new StreamReader(ruta_datos);
            var lineas = new List<string[]>();
            string[] Linea;
            while (!lector.EndOfStream)
            {
                Linea = lector.ReadLine().Split(',');
                lineas.Add(Linea);
            }


            double[][] t = Matriz.Crear(1, lineas.Count);
            double[][] y = Matriz.Crear(1, lineas.Count);
            for (int i = 0; i < lineas.Count; i++)
            {
                t[0][i] = Convert.ToDouble(lineas[i][0]);
                y[0][i] = Convert.ToDouble(lineas[i][1]);
                Console.WriteLine("\t" + t[0][i] + "\t" + y[0][i] + "\t");
            }
            Console.WriteLine("Derivadas");
            double[][] ypto = Matriz.Derivada1(t, y);
            double[][] y2pto = Matriz.Derivada2(t, y);
            double[][] u = Matriz.Escalon(t);

            for(int i= 0;i<y[0].Length-1;i++)
            {
                y[0][i] = y[0][i + 1];
            }

            double[][] psi = Matriz.Crear(3, y[0].Length);
            for (int i = 0; i < y[0].Length-2; i++)
            {
                psi[0][i] = y2pto[0][i];
                psi[1][i] = ypto[0][i];
                psi[2][i] = u[0][i];
                Console.WriteLine("|\t" + y[0][i] + "\t|\t" + psi[0][i] + "\t|\t" + psi[1][i] + "\t|\t" + psi[2][i] + "\t|");

            }

            double[][] theta = Matriz.EstimacionParametrica(y, psi);


            Console.WriteLine(Math.Round(theta[0][0], 5));
            Console.WriteLine(Math.Round(theta[1][0], 5));
            Console.WriteLine(Math.Round(theta[2][0], 5));

            double wn = Math.Sqrt(-theta[0][0]);
            double z = -theta[1][0] * wn / 2;
            double k = theta[2][0];

            double A = k;
            double B = k / Math.Sqrt(1 - z * z);
            double C = z * wn;
            double D = wn * Math.Sqrt(1 - z * z);
            double E = Math.Atan((Math.Sqrt(1 - z * z)) / z);


            double[][]estimacion = Matriz.Crear(1, t[0].Length);
            for (int i = 0; i < t[0].Length; i++)
            {
                estimacion[0][i] = A - B * Math.Exp(-C * t[0][i]) * Math.Sin(D * t[0][i] + E);
            }


            double[][] ECM = Matriz.ECM(estimacion, y);
            Console.WriteLine(ECM[0][0]/y[0].Length);
        }
    }
}
