using System;

namespace MovimientoOsc                                 //Movimiento oscilatorio por gradiente descendiente
{                                                       //Consiste en ir variando las variables en la función
    class Program                                       //(x-1,y+1) (x,y+1) (x+1,y+1)
    {                                                   //(x-1,y)   (x,y)   (x+,y)
        static void Main(string[] args)                 //(x-1.y-1) (x,y-1) (x-1,y-1)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Obtención de pendiente y ordenada al origen mediante IA");
            Console.WriteLine("Fecha: 26 de marzo de 2020");
            Console.WriteLine("---------------------------------");


            double[] x = new double[6] {  0, 1,2,3, 4,5 };
            double[] y = new double[6] { 0.1309325039, 1.152254017, 1.126559309, 0.8546077958, 1.080655028, 0.9767980784 };
            double w = 0;
            double max_w = 10;
            double min_w = 0;
            double paso_w = 0.1;
            double z_central;
            double z = 0;
            double max_z;
            double min_z;
            double paso_z = 0.001;
            double[] y_estimada = new double[y.Length];
            double[] error_w = new double[3];
            double[] error_z = new double[3];
            double tolerancia = 0.00000001;

            Random aleatorio = new Random();
            bool calcular_z = true;
            bool calcular_w = true;
            
            while (calcular_w)
            {
                w = aleatorio.NextDouble() * (max_w - min_w) + min_w;
                calcular_z = true;
                max_z = 1;
                min_z = 0;
                while (calcular_z)
                {
                    z = aleatorio.NextDouble() * (max_z - min_z) + min_z;
                    
                    for (int k = 0; k < y_estimada.Length; k++)
                    {   //z,w+paso_w
                        y_estimada[k] = 1-(1/(Math.Sqrt(1-Math.Pow(z,2))))*Math.Exp(-z*(w+paso_w)*x[k])*Math.Sin((w+paso_w)* (Math.Sqrt(1 - Math.Pow(z, 2)))*x[k]+1);
                    }
                    error_z[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {   //z+paso_z,w+paso_w
                        y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z+paso_z), 2)))) * Math.Exp(-((z + paso_z)) * (w + paso_w) * x[k]) * Math.Sin((w + paso_w) * (Math.Sqrt(1 - Math.Pow((z + paso_z), 2))) * x[k] + 1);
                    }
                    error_z[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {   //z-paso_z,w+paso_w
                        y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z - paso_z), 2)))) * Math.Exp(-((z - paso_z)) * (w + paso_w) * x[k]) * Math.Sin((w + paso_w) * (Math.Sqrt(1 - Math.Pow((z - paso_z), 2))) * x[k] + 1);
                    }
                    error_z[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    if ((error_z[2] >= (1 - tolerancia) * error_z[0]) && (error_z[2] <= (1 + tolerancia) * error_z[0]))
                    {   //Determinar hacia donde va el error en z
                        calcular_z = false;
                        error_w[2] = error_z[1];
                    }
                    else
                    {
                        if (error_z[2] < error_z[0])
                        {
                            min_z = z;
                        }
                        else
                        {
                            max_z = z;
                        }
                    }
                }

                calcular_z = true;
                max_z = 1;
                min_z = 0;
                while (calcular_z)
                {   
                    z = aleatorio.NextDouble() * (max_z - min_z) + min_z;
                    for (int k = 0; k < y_estimada.Length; k++)
                    {//z,w-paso_w
                        y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow(z, 2)))) * Math.Exp(-z * (w - paso_w) * x[k]) * Math.Sin((w - paso_w) * (Math.Sqrt(1 - Math.Pow(z, 2))) * x[k] + 1);
                    }
                    error_z[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {//z+paso_z,w-paso_w
                        y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z + paso_z), 2)))) * Math.Exp(-((z + paso_z)) * (w - paso_w) * x[k]) * Math.Sin((w - paso_w) * (Math.Sqrt(1 - Math.Pow((z + paso_z), 2))) * x[k] + 1);
                    }
                    error_z[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {//z-paso_z,w-paso_w
                        y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z - paso_z), 2)))) * Math.Exp(-((z - paso_z)) * (w - paso_w) * x[k]) * Math.Sin((w - paso_w) * (Math.Sqrt(1 - Math.Pow((z - paso_z), 2))) * x[k] + 1);
                    }
                    error_z[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    if ((error_z[2] >= (1 - tolerancia) * error_z[0]) && (error_z[2] <= (1 + tolerancia) * error_z[0]))
                    {//Determinar hacia donde va el error en z
                        calcular_z = false;
                        error_w[0] = error_z[1];
                    }
                    else
                    {
                        if (error_z[2] < error_z[0])
                        {
                            min_z = z;
                        }
                        else
                        {
                            max_z = z;
                        }
                    }
                }
                calcular_z = true;
                max_z = 1;
                min_z = 0;
                while (calcular_z)
                {
                    z = aleatorio.NextDouble() * (max_z - min_z) + min_z;
                    for (int k = 0; k < y_estimada.Length; k++)
                    {//z,w
                        y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow(z, 2)))) * (Math.Exp(-z * (w) * x[k]) * Math.Sin((w) * (Math.Sqrt(1 - Math.Pow(z, 2))) * x[k] + 1)) ;
                    }
                    error_z[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {//z+paso_z,w
                        y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z + paso_z), 2)))) * Math.Exp(-(z + paso_z) * (w) * x[k]) * Math.Sin((w) * (Math.Sqrt(1 - Math.Pow((z + paso_z), 2))) * x[k] + 1);
                    }
                    error_z[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {//z-paso_z,w
                        y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z - paso_z), 2)))) * Math.Exp(-((z - paso_z)) * (w) * x[k]) * Math.Sin((w) * (Math.Sqrt(1 - Math.Pow((z - paso_z), 2))) * x[k] + 1);
                    }
                    error_z[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    if ((error_z[2] >= (1 - tolerancia) * error_z[0]) && (error_z[2] <= (1 + tolerancia) * error_z[0]))
                    {//Determinar hacia donde va el error en z
                        calcular_z = false;
                        error_w[1] = error_z[1];
                    }
                    else
                    {
                        if (error_z[2] < error_z[0])
                        {
                            min_z = z;
                        }
                        else
                        {
                            max_z = z;
                        }
                    }
                }
                z_central = z;
                if ((error_w[2] >= (1 - tolerancia) * error_w[0]) && (error_w[2] <= (1 + tolerancia) * error_w[0]))
                {//Determinar hacia donde va el error en w
                    if (error_w[1] > 10000 * tolerancia)
                    {
                        max_w = 10;
                        min_w = 0;
                    }
                    else
                    {
                        Console.WriteLine("El coeficiente de amortiguamiento es " + z_central + ". La frecuencia natural es " + w + "\nEl error es " + error_w[1]);
                        calcular_w = false;
                    }
                }
                else
                {
                    if (error_w[2] < error_w[0])
                    {
                        min_w = w;
                    }
                    else
                    {
                        max_w =w;
                    }
                }
            }
        }
    }
}
