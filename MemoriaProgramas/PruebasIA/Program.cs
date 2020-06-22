using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasIA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Tema: Cálculo de pi");
            Console.WriteLine("Fecha: 06 de febrero de 2020");
            Console.WriteLine("---------------------------------");
            double aux = 0;
            double error = 0;
            for (int i = 0; i < 100; i++)
            {
                aux = Math.Pow(-1, i) * 4 / (2 * i + 1) + aux;          //Método numérico para obtener pi
                error = 100000 * Math.Abs((Math.PI - aux) / Math.PI);   //Se multiplica el error
               Console.WriteLine("Pi=" + aux + " Error=" + error);
            }
        }
    }
}
