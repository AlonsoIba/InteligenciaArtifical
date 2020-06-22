using System;

namespace PruebasIA03_26
{
    class Program                                       //Estimación de pendiente y ordenada por descenso de gradiente
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temas Selectos de Programación 2");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Grupo: 7");
            Console.WriteLine("Ibáñez López Lena Alonso");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tema: Obtención de pendiente y ordenada al origen mediante IA");
            Console.WriteLine("Fecha: 26 de marzo de 2020");
            Console.WriteLine("---------------------------------");


            double[] y = new double[5] { 4,1,0,1,4 };
            double[] x = new double[5] { -2,-1,0,1,2 };
            double m = 0;
            double max_m = 100;
            double min_m = -100;
            double paso_m = 1;
            double b_central;
            double b = 0;
            double max_b;
            double min_b;
            double paso_b = 1;
            double[] y_estimada = new double[5];
            double[] error_b = new double[3];
            double[] error_m = new double[3];
            double tolerancia = 0.000000000000001;

            Random aleatorio = new Random();
            bool calcular_b = true;
            bool calcular_m = true ;
            TimeSpan stop1;
            TimeSpan start1 = new TimeSpan(DateTime.Now.Ticks);
            while (calcular_m)
            {
                //Console.ReadKey();
                m = aleatorio.NextDouble()*(max_m-min_m)+min_m;
               
                calcular_b = true;
                max_b = 500;
                min_b = -500;
                while (calcular_b)
                {
                    b = aleatorio.NextDouble() * (max_b - min_b) + min_b;
                    for (int k = 0; k < y_estimada.Length; k++)
                    {
                        y_estimada[k] = (m+paso_m) * x[k] + b;
                    }
                    error_b[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {
                        y_estimada[k] = (m + paso_m) * x[k] + b + paso_b;
                    }
                    error_b[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {
                        y_estimada[k] = (m + paso_m) * x[k] + b - paso_b;
                    }
                    error_b[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    if ((error_b[2] >= (1 - tolerancia) * error_b[0]) &&(error_b[2] <= (1+tolerancia)*error_b[0]))
                    {
                        calcular_b = false;
                        error_m[2] = error_b[1];
                    }
                    else
                    {
                        if (error_b[2] < error_b[0])
                        {
                            min_b = b;
                        }
                        else
                        {
                            max_b = b;
                        }
                    }
                }

                calcular_b = true;
                max_b = 500;
                min_b = -500;
                while (calcular_b)
                {
                    b = aleatorio.NextDouble() * (max_b - min_b) + min_b;
                    for (int k = 0; k < y_estimada.Length; k++)
                    {
                        y_estimada[k] = (m-paso_m) * x[k] + b;
                    }
                    error_b[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {
                        y_estimada[k] = (m-paso_m) * x[k] + b + paso_b;
                    }
                    error_b[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {
                        y_estimada[k] = (m-paso_m) * x[k] + b - paso_b;
                    }
                    error_b[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    if ((error_b[2] >= (1 - tolerancia) * error_b[0]) && (error_b[2] <= (1 + tolerancia) * error_b[0]))
                        {
                        calcular_b = false;
                        error_m[0] = error_b[1];
                    }
                    else
                    {
                        if (error_b[2] < error_b[0])
                        {
                            min_b = b;
                        }
                        else
                        {
                            max_b = b;
                        }
                    }
                }
                calcular_b = true;
                max_b = 500;
                min_b = -500;
                while (calcular_b)
                {
                    b = aleatorio.NextDouble() * (max_b - min_b) + min_b;
                    for (int k = 0; k < y_estimada.Length; k++)
                    {
                        y_estimada[k] = m * x[k] + b;
                    }
                    error_b[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {
                        y_estimada[k] = m * x[k] + b + paso_b;
                    }
                    error_b[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    for (int k = 0; k < y_estimada.Length; k++)
                    {
                        y_estimada[k] = m * x[k] + b - paso_b;
                    }
                    error_b[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                    if((error_b[2] >= (1 - tolerancia) * error_b[0]) && (error_b[2] <= (1 + tolerancia) * error_b[0]))
                        {
                        calcular_b = false;
                        error_m[1] = error_b[1];
                    }
                    else
                    {
                        if (error_b[2] < error_b[0])
                        {
                            min_b = b;
                        }
                        else
                        {
                            max_b = b;
                        }
                    }
                }
                b_central = b;
                Console.WriteLine("La pendiente es " + m + ". La ordenada al origen es " + b_central+"\nEl error es " + error_m[1]);
                if((error_m[2] >= (1 - tolerancia) * error_m[0]) && (error_m[2] <= (1 + tolerancia) * error_m[0]))
                    {
                    Console.WriteLine("La ecuación es: y = " + m + "x + " + b_central);
                    calcular_m = false;
                }
                else
                {
                    if (error_m[2] < error_m[0])
                    {
                        min_m = m;
                    }
                    else
                    {
                        max_m = m;
                    }
                }
            }
            stop1 = new TimeSpan(DateTime.Now.Ticks);
            Console.WriteLine("El programa con inteligencia artificial tardó " + stop1.Subtract(start1).TotalMilliseconds + " milisegundos");
            TimeSpan stop2;
            TimeSpan start2 = new TimeSpan(DateTime.Now.Ticks);
            double[] regression = MathIA.Statistics.Regression(x, y);
            Console.WriteLine("La pendiente es " + regression[0]);
            Console.WriteLine("La ordenada al origen es " + regression[1]);
            stop2 = new TimeSpan(DateTime.Now.Ticks);
            Console.WriteLine("La regresión lineal tardó " + stop2.Subtract(start1).TotalMilliseconds + " milisegundos");

        }
    }
}
