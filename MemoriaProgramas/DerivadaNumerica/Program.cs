using System;
using MathIA;

namespace DerivadaNumerica              //La derivada numerica se utilizo en el programa para estimar la ecuacion
{                                       //de un sistema subamortiguado
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Derivada numérica");
            double[][] t = Matriz.Vector(1, 10, 1);
            double[][] y = Matriz.Crear(1, 10);
            for (int i = 0; i < y[0].Length; i++)
            {
                y[0][i] = i * i;
            }
            double[][] ypto = Matriz.Derivada1(t, y);

            double[][] y2pto = Matriz.Derivada2(t,y);
            Console.WriteLine("|\ty\t|\typ\t|\typp\t|");
            for (int i = 0; i < y[0].Length - 2; i++)
            {
                Console.WriteLine("|\t"+y[0][i+1]+"\t|\t"+ypto[0][i] + "\t|\t" +y2pto[0][i] + "\t|");
            }
            Console.WriteLine("Entrada escalón");
            double[][] escalon = Matriz.Escalon(t);
            for (int i = 0; i < y[0].Length - 2; i++)
            {
                Console.WriteLine("|\t" + escalon[0][i]+ "\t|");
            }
            Console.WriteLine("Cortar vector");
            double[][] cortar = Matriz.Cortar(y, 2, 5);
            for (int i = 0; i < cortar[0].Length; i++)
            {
                Console.WriteLine("|\t" + cortar[0][i] + "\t|");
            }
        }
    }
}
