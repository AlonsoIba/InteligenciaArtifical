using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasIA05_03
{
    class Program
    {
        static void Main(string[] args)  //Tarea: Métodos de integración de MATLAB (rectángulo, trapecio, simpson)
                                         //Utilizar swith y enumerador

        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Integral");
            Console.WriteLine("Fecha: 5 de marzo de 2020");
            Console.WriteLine("---------------------------------");
           
            double a = 0;
            double b = 10;
            double[] x = MathIA.MatArr.Linspace(a, b, 0.001);
            double[] y = MathIA.Statistics.Normpdf(x, 5, 1);
            double simpson = MathIA.Integral.Simpson(a,b,y);
            double trapecio = MathIA.Integral.Trapz(a, b, y);
            double rectangulo = MathIA.Integral.Rectangulo(a, b, y);

            Console.WriteLine("La integral de " + a + " a " + b + " es: " + simpson +"(Simpson)");
            Console.WriteLine("La integral de " + a + " a " + b + " es: " + trapecio + "(Trapecio)");
            Console.WriteLine("La integral de " + a + " a " + b + " es: " + rectangulo + "(Rectángulo)");
            Console.Read();
        }
    }
}
