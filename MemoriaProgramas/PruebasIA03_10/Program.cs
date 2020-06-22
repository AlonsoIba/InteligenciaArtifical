using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasIA03_10
{
    class Program                                       //Calcula el likelyhood de un valor leido en consola con las muestras datos1 y datos2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Likelyhood");
            Console.WriteLine("Fecha: 10 de marzo de 2020");
            Console.WriteLine("---------------------------------");

            double[] datos1 = new double[10] { 21.6041417819113 ,  21.6023050561582 ,   21.4022908599618  ,  21.4230011088514  ,  21.7296563376506  ,  21.4125424905737  ,  21.1727240804802  ,  21.7539253613091  ,  21.5743350410939  ,  21.5421654145804};
            double[] datos2 = new double[10] { 7.5937413484042 ,   7.2715133248539, 7.88973667733885 ,   7.63501715160858   , 7.92281083079749 ,   7.07823819303125  ,  7.30170244072419  ,  7.36914344405238  ,  7.19820093532508  ,  7.82526872638479};
            MathIA.ObjStac muestra1 = new MathIA.ObjStac(datos1);
            MathIA.ObjStac muestra2 = new MathIA.ObjStac(datos2);
            double valor = Convert.ToDouble(Console.ReadLine()); 
            double like1 = MathIA.Statistics.Likelyhood(valor, muestra1);
            double like2 = MathIA.Statistics.Likelyhood(valor, muestra2);
            Console.WriteLine(like1);
            Console.WriteLine(like2);
            if(like1>like2)
            {
                Console.WriteLine("El dato pertenece a la muestra 1");
            }
            else
            {
                Console.WriteLine("El dato pertenece a la muestra 2");
            }
            Console.ReadKey();


        }
    }
}
