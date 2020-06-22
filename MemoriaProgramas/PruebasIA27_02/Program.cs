using System;

namespace PruebasIA27_02
{
    class Program
    {
        static void Main(string[] args) //Tarea: maximo y minimo a partir de mu y sigma, añadir todos los métodos estadisticos a ObjStac
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: ObjStac");
            Console.WriteLine("Fecha: 27 de febrero de 2020");
            Console.WriteLine("---------------------------------");

            double[] datos=new double[50] { 1.95, 1.95, 1.93, 1.96, 1.95, 1.93, 1.96, 1.92, 1.92, 1.93, 1.93, 1.93, 1.95, 1.93, 1.94, 1.96, 1.93, 1.95, 1.95, 1.95, 1.96, 1.96, 1.95, 1.93, 1.96, 1.93, 1.96, 1.92, 1.92, 1.93, 1.93, 1.93, 1.95, 1.93, 1.93, 1.95, 1.93, 1.94, 1.96, 1.93, 1.95, 1.93, 1.94, 1.96, 1.95, 1.95, 1.95, 1.93, 1.94, 1.96 };
            MathIA.ObjStac datosStac = new MathIA.ObjStac(datos);

            
            Console.WriteLine("Tenemos los siguientes datos: ");
            for (int i = 0; i < datosStac.Cantidad; i++)                        //Imprimir valores de un arreglo
            {
                Console.Write("[" + datosStac.Datos[i] + "]");
            }

            Console.WriteLine("");
            double media = datosStac.Mean;
            double desv =datosStac.Std;
            double var = datosStac.Var;
            double min = datosStac.Min;
            double max = datosStac.Max;
            double[] x = datosStac.x;
            double[] y = datosStac.y;


            Console.WriteLine("La media es: " + media + ", la desviación estándar es: " + desv + ", la varianza es: " + var);
            Console.WriteLine("El mínimo es: " + min + " y el máximo es: " + max);
            for (int i = 0; i < x.Length; i++)                        //Imprimir valores de un arreglo
            {
                Console.Write("[" + x[i] + "]");
            }
            Console.WriteLine("");
            for (int i = 0; i < y.Length; i++)                        //Imprimir valores de un arreglo
            {
                Console.Write("[" + y[i] + "]");
            }
            Console.WriteLine("");
            Console.ReadKey();

        }
    }

    
}



//x=linspace(min,max,0.1),y=normpdf(x,mu,sigma),min(mu,sigma),max(mu,sigma)
//x y para obtener gráfica y poder acceder a los valores, medir un objeto