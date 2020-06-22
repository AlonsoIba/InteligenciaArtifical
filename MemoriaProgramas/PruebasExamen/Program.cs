using System;
using System.IO;
using System.Collections.Generic;

namespace PruebasExamen
{
    class Program                       //Programa de consola para pruebas del examen
    {
        static void Main(string[] args)
        {
           
            string ruta_datos = "MuestrasExamen.csv";
            StreamReader lector = new StreamReader(ruta_datos);
            var lineas = new List<string[]>();
            string[] Linea;
            while (!lector.EndOfStream)
            {
                Linea = lector.ReadLine().Split(',');
                lineas.Add(Linea);
            }
            Console.WriteLine("Mujeres saludables");
            double[][] MS = new double[147][];
            for (int i = 0; i < 147; i++)
            {
                MS[i] = new double[9];
                MS[i][0] = Convert.ToDouble(lineas[i][0]);
                MS[i][1] = Convert.ToDouble(lineas[i][1]);
                MS[i][2] = Convert.ToDouble(lineas[i][2]);
                MS[i][3] = Convert.ToDouble(lineas[i][3]);
                MS[i][4] = Convert.ToDouble(lineas[i][4]);
                MS[i][5] = Convert.ToDouble(lineas[i][5]);
                MS[i][6] = Convert.ToDouble(lineas[i][6]);
                MS[i][7] = Convert.ToDouble(lineas[i][7]);
                MS[i][8] = Convert.ToDouble(lineas[i][8]);
                Console.WriteLine("|\t" + MS[i][0] + "|\t" + MS[i][1] + "|\t" + MS[i][2] + "|\t" + MS[i][3] +
                    "|\t" + MS[i][4] + "|\t" + MS[i][5] + "|\t" + MS[i][6] + "|\t" + MS[i][7] + "|\t" + MS[i][8] + "|\t");
            }
            Console.WriteLine("Mujeres  no saludables");
            double[][] MNS = new double[67][];
            for (int i = 147; i < 147 + 67; i++)
            {
                MNS[i - 147] = new double[9];
                MNS[i - 147][0] = Convert.ToDouble(lineas[i][0]);
                MNS[i - 147][1] = Convert.ToDouble(lineas[i][1]);
                MNS[i - 147][2] = Convert.ToDouble(lineas[i][2]);
                MNS[i - 147][3] = Convert.ToDouble(lineas[i][3]);
                MNS[i - 147][4] = Convert.ToDouble(lineas[i][4]);
                MNS[i - 147][5] = Convert.ToDouble(lineas[i][5]);
                MNS[i - 147][6] = Convert.ToDouble(lineas[i][6]);
                MNS[i - 147][7] = Convert.ToDouble(lineas[i][7]);
                MNS[i - 147][8] = Convert.ToDouble(lineas[i][8]);
                Console.WriteLine("|\t" + MNS[i-147][0] + "|\t" + MNS[i-147][1] + "|\t" + MNS[i-147][2] + "|\t" + MNS[i-147][3] +
                    "|\t" + MNS[i-147][4] + "|\t" + MNS[i-147][5] + "|\t" + MNS[i-147][6] + "|\t" + MNS[i-147][7] + "|\t" + MNS[i-147][8] + "|\t");
            }

            Console.WriteLine("Hombres saludables");
            double[][] HS = new double[65][];
            for (int i = 147 + 67; i < 147 + 67 + 65; i++)
            {
                HS[i - 214] = new double[9];
                HS[i - 214][0] = Convert.ToDouble(lineas[i][0]);
                HS[i - 214][1] = Convert.ToDouble(lineas[i][1]);
                HS[i - 214][2] = Convert.ToDouble(lineas[i][2]);
                HS[i - 214][3] = Convert.ToDouble(lineas[i][3]);
                HS[i - 214][4] = Convert.ToDouble(lineas[i][4]);
                HS[i - 214][5] = Convert.ToDouble(lineas[i][5]);
                HS[i - 214][6] = Convert.ToDouble(lineas[i][6]);
                HS[i - 214][7] = Convert.ToDouble(lineas[i][7]);
                HS[i - 214][8] = Convert.ToDouble(lineas[i][8]);
                Console.WriteLine("|\t" + HS[i-214][0] + "|\t" + HS[i-214][1] + "|\t" + HS[i-214][2] + "|\t" + HS[i-214][3] +
                    "|\t" + HS[i-214][4] + "|\t" + HS[i-214][5] + "|\t" + HS[i-214][6] + "|\t" + HS[i-214][7] + "|\t" + HS[i-214][8] + "|\t");
            }

            Console.WriteLine("Hombres no saludables");
            double[][] HNS = new double[67][];
            for (int i = 279; i < 147 + 67 + 65 + 67; i++)
            {
                HNS[i - 279] = new double[9];
                HNS[i - 279][0] = Convert.ToDouble(lineas[i][0]);
                HNS[i - 279][1] = Convert.ToDouble(lineas[i][1]);
                HNS[i - 279][2] = Convert.ToDouble(lineas[i][2]);
                HNS[i - 279][3] = Convert.ToDouble(lineas[i][3]);
                HNS[i - 279][4] = Convert.ToDouble(lineas[i][4]);
                HNS[i - 279][5] = Convert.ToDouble(lineas[i][5]);
                HNS[i - 279][6] = Convert.ToDouble(lineas[i][6]);
                HNS[i - 279][7] = Convert.ToDouble(lineas[i][7]);
                HNS[i - 279][8] = Convert.ToDouble(lineas[i][8]);
                Console.WriteLine("|\t" + HNS[i-279][0] + "|\t" + HNS[i-279][1] + "|\t" + HNS[i-279][2] + "|\t" + HNS[i-279][3] +
                    "|\t" + HNS[i-279][4] + "|\t" + HNS[i-279][5] + "|\t" + HNS[i-279][6] + "|\t" + HNS[i-279][7] + "|\t" + HNS[i-279][8] + "|\t");
            }
            Console.ReadKey();

        }
    }
}
