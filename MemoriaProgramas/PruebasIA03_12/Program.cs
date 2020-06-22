using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasIA03_12
{
    class Program                                       //Método de tregresión lineal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Regresión lineal");
            Console.WriteLine("Fecha: 12 de marzo de 2020");
            Console.WriteLine("---------------------------------");
            double[] y = new double [5] { -0.046,-0.0257,0,0.02,0.03};
            double[] x = new double[5] {-10.49931104,-6.074180675,0,2.905290751,4.709183765};
            double[] regression = MathIA.Statistics.Regression(x, y);
            Console.WriteLine("La pendiente es " + regression[0]);
            Console.WriteLine("La ordenada al origen es " + regression[1]);
            double[] y_real = new double[y.Length];
            for (int i = 0; i < x.Length; i++)
            {
                y_real[i] = regression[0] * x[i] + regression[1];                             //Los valores reales calculados
            }
            double[] error = MathIA.Statistics.ECM(y,y_real);
            Console.WriteLine("El error cuadrático medio es de "+error[0]);

            //Práctica de dinámica de maquinaria
            double m = 3239.5;
            double g = 978;
            double Iz = m * g / regression[0];
            Console.WriteLine("Iz = " + Iz);
            Console.ReadKey();

            //Añadir r^2, pearson y errores y hacer un programa de barrido con m en random, el error te indica hacia donde tiende el valor
            //b en 0
        }
    }
}
