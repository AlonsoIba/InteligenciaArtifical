using System;
using System.IO;
using System.Collections.Generic;
namespace PruebasIA04_16
{
    class Program                           //Lectura de un archivo .csv
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Leer CSV");
            Console.WriteLine("Fecha: 16 de abril de 2020");
            Console.WriteLine("---------------------------------");

            string ruta = "DatosIA.csv";
            StreamReader lector = new StreamReader(ruta);
            var lineas = new List <string[]>();
            string[] Linea;
            while (!lector.EndOfStream)
            {
                Linea = lector.ReadLine().Split(',');
                lineas.Add(Linea);
            }
            double[,] datos = new double[lineas.Count, lineas[0].Length];
            for (int i = 0; i < lineas.Count; i++)
            {
                for (int j = 0; j < lineas[0].Length; j++)
                {
                    datos[i, j] = Convert.ToDouble(lineas[i][j]);
                 
                }
                Console.WriteLine("x1 = " + datos[i, 0] + "  x2 = " + datos[i, 1] + " y = " + datos[i, 2]);
            }

            
        }
    }
}
