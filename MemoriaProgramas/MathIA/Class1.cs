using System;

namespace MathIA
{//Agregar comentarios 
    /// <summary>
    /// Métodos estadísticos
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// Promedio de un arreglo
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Mean(double[] input)                               //Promedio
        {
            double output = Arithmetic.Sum(input) / input.Length;
            return output;
        }
        /// <summary>
        /// Varianza muestral de un arreglo
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Varm(double[] input)                               //Varianza muestral
        {
            double output = Arithmetic.Sum(Arithmetic.Power(Arithmetic.Sum(-Statistics.Mean(input), input), 2)) / (input.Length - 1);
            return output;
        }
        /// <summary>
        /// Desviación muestral de un arreglo
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Stdm(double[] input)                               //Desviación estándar muestral
        {
            double output = ExpLog.Sqrt(Statistics.Varm(input));
            return output;
        }/// <summary>
        /// Varianza poblacional de un arreglo
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Varp(double[] input)                               //Varianza poblacional
        {
            double output = Arithmetic.Sum(Arithmetic.Power(Arithmetic.Sum(-Statistics.Mean(input), input), 2)) / (input.Length);
            return output;
        }
        /// <summary>
        /// Desviación poblacional de un arreglo
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Stdp(double[] input)                               //Desviación estándar de la población
        {
            double output = ExpLog.Sqrt(Statistics.Varp(input));
            return output;
        }
        /// <summary>
        /// Distribución normal para la media y desviación estándar establecidas
        /// </summary>
        /// <param name="input">Valor a evaluar</param>
        /// <param name="mu">Media</param>
        /// <param name="sigma">Desvaición estándar</param>
        /// <returns></returns>
        public static double Normpdf(double input, double mu, double sigma)                               
        {
            double output = Math.Exp(-0.5 * Math.Pow((input - mu) / sigma, 2)) / (sigma * Math.Sqrt(2 * Math.PI));  // 
            return output;
        }
        /// <summary>
        /// Distribución normal para la media y desviación estándar establecidas, a un arreglo
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <param name="mu">Media</param>
        /// <param name="sigma">Desvaición estándar</param>
        /// <returns></returns>
        public static double[] Normpdf(double[] input, double mu, double sigma)                      
        {
            double[] output = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = Statistics.Normpdf(input[i], mu, sigma);
            }
            return output;
        }
        /// <summary>
        /// Genera un valor de la media menos tres desviaciones estándar del arreglo de entrada
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Min(double[] input)                                //A 3 std hay 99% de los datos
        {
            double output = Statistics.Mean(input) - 3 * Statistics.Stdm(input);
            return output;
        }
        /// <summary>
        /// Genera un valor de la media más tres desviaciones estándar del arreglo de entrada
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Max(double[] input)
        {
            double output = Statistics.Mean(input) + 3 * Statistics.Stdm(input);
            return output;
        }
        /// <summary>
        /// Calcula el likelyhood de un número a una muestra
        /// </summary>
        /// <param name="input">Entrada</param>
        /// <param name="muestra">Muestra a comparar</param>
        /// <returns></returns>
        public static double Likelyhood(double input, ObjStac muestra)
        {
            double mu = muestra.Mean;
            double sigma = muestra.Std;
            double output = Statistics.Normpdf(input, mu, sigma);
            return output;
        }
        /// <summary>
        /// Regresión lineal, genera un arreglo donde el primer valor es la pendeinte y el segundo valor es la ordenada al origen
        /// </summary>
        /// <param name="x">Abscisas</param>
        /// <param name="y">Ordenadas</param>
        /// <returns></returns>
        public static double[] Regression(double[] x, double[] y)             //Devuelve un arreglo donde el primer valor es m y el segundo es b
        {
            double[] output = new double[2];
            double dot = Arithmetic.Dot(x, y);
            double[] pow = Arithmetic.Power(x, 2);
            double m = (x.Length * dot - Arithmetic.Sum(x) * Arithmetic.Sum(y)) / (x.Length * Arithmetic.Sum(pow) - Arithmetic.Power(Arithmetic.Sum(x), 2));
            double b = (Arithmetic.Sum(y) - m * Arithmetic.Sum(x)) / x.Length;
            output[0] = m;
            output[1] = b;
            return output;
        }
        /// <summary>
        /// Calculo del Error Cuadrático Medio, dando el signo
        /// </summary>
        /// <param name="y"></param>
        /// <param name="y_real"></param>
        /// <returns></returns>
        public static double[] ECM(double[] y, double[] y_real)             //Devuelve ECM y signo de error
        {
            double ECM = Arithmetic.Sum(Arithmetic.Power(Arithmetic.Sum(y, Arithmetic.Prod(-1, y_real)), 2)) / y.Length;
            double signo = Arithmetic.Sum(Arithmetic.Sum(y, Arithmetic.Prod(-1, y_real)));
            double[] output = new double[2] { ECM, signo };
            return output;
        }

    }
    /// <summary>
    /// Genera un objeto estadísitco teninedo como entrada un arreglo de datos
    /// </summary>
    public class ObjStac
    {
        public double[] Valores;
        public int Cantidad;
        public ObjStac(double[] datos)
        {
            Valores = datos;
            Cantidad = datos.GetLength(0);
        }
        /// <summary>
        /// Datos del arreglo
        /// </summary>
        public double[] Datos
        {
            get
            {
                return Valores;
            }
        }
        /// <summary>
        /// Promedio
        /// </summary>
        public double Mean
        {
            get
            {
                return Statistics.Mean(Valores);
            }
        }
        /// <summary>
        /// Desviación estándar
        /// </summary>
        public double Std
        {
            get
            {
                return Statistics.Stdm(Valores);
            }
        }
        /// <summary>
        /// Varianza
        /// </summary>
        public double Var
        {
            get
            {
                return Statistics.Varm(Valores);
            }
        }
        /// <summary>
        /// Valor mínimo a tres desviaciones estándar de la media
        /// </summary>
        public double Min
        {
            get 
            {
                return Statistics.Min(Valores);
            }
        }
        /// <summary>
        /// Valor máximo a tres desvaciones estándar de la media
        /// </summary>
        public double Max
        {
            get
            {
                return Statistics.Max(Valores);
            }
        }
        /// <summary>
        /// Vector del valor mínimo al máximo, con un intervalo de 0.05 veces la desviación estándar
        /// </summary>
        public double[] x
        {
            get 
            {
                return MatArr.Linspace(Statistics.Min(Valores), Statistics.Max(Valores),Statistics.Stdm(Valores)/20);
            }
        }
        /// <summary>
        /// Distribución normal
        /// </summary>
        public double[] y
        {
            get
            {
                return Statistics.Normpdf(MatArr.Linspace(Statistics.Min(Valores), Statistics.Max(Valores), Statistics.Stdm(Valores) / 20), Statistics.Mean(Valores), Statistics.Stdm(Valores));
            }
        }
    }
    /// <summary>
    /// Operaciones exponenciales y logaritmicas
    /// </summary>
    public class ExpLog
    {
        /// <summary>
        /// Devuelve la raíz de un número
        /// </summary>
        /// <param name="input">Número</param>
        /// <returns></returns>
        public static double Sqrt(double input)
        {
            double i = 0;
            double x1 = 0;
            double output=0;
            while ((i * i) <= input)
            {
                i += 0.1;
                x1 = i;
                for (int j = 0; j < 10; j++)
                {
                    output = input;
                    output /= x1;
                    output += x1;
                    output /= 2;
                    x1 = output;
                }
            }
            return output;
        }
        /// <summary>
        /// Devuelve la raíz de cada elemento del arreglo de entrada
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double[] Sqrt(double[] input)                                 //Raiz cuadrada de cada valor de un arreglo
        {
            double[] output=new double[input.Length];                               //No utilizar input como return
            for(int i=0;i<input.Length;i++)
            {
                output[i] = ExpLog.Sqrt(input[i]);
            }
            return output;
        }
    }
    /// <summary>
    /// Operaciones aritméticas
    /// </summary>
    public class Arithmetic
        {
        /// <summary>
        /// Suma de elementos de un arreglo
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Sum(double[] input)                                   //Suma de valores de un vector
        {
            double output = 0;
            for (int i = 0; i < input.Length; i++)
            {
                output = output + input[i];
            }
            return output;
        }
        /// <summary>
        /// Suma un escalar a cada elemento del arreglo de entrada
        /// </summary>
        /// <param name="esc">Escalar</param>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double[] Sum(double esc, double[] input)                      //Suma de escalar a cada elemento de un vector
        {
            double[] output = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = input[i] + esc;
            }
            return output;
        }
        /// <summary>
        /// Suma de dos arreglos multidimensionales elemento a elemento (deben tener las mismas dimensiones)
        /// </summary>
        /// <param name="in1">Arreglo de entrada 1</param>
        /// <param name="in2">Arreglo de entrada 2</param>
        /// <returns></returns>
        public static double[,] Sum(double[,] in1, double[,] in2)                   //Suma de dos arreglos elemento a elemento
        {
            double[,] output = new double[in1.GetLength(0), in2.GetLength(0)];
            for (int j = 0; j < in2.GetLength(0); j++)
            {
                for (int i = 0; i < in1.GetLength(0); i++)
                {
                    output[i, j] = in1[i, j] + in2[i, j];
                }
            }
            return output;
        }
        /// <summary>
        /// Suma de dos arreglos elemento a elemento
        /// </summary>
        /// <param name="in1">Arreglo de entrada 1</param>
        /// <param name="in2">Arreglo de entrada 2</param>
        /// <returns></returns>
        public static double[] Sum(double[] in1, double[] in2)                   //Suma de dos arreglos elemento a elemento
        {
            double[] output = new double[in1.Length];
            for (int j = 0; j < in1.GetLength(0); j++)
            {
                    output[j] = in1[j] + in2[j];
            }
            return output;
        }
        /// <summary>
        /// Elevar un número a la potencia especificada
        /// </summary>
        /// <param name="input">Número</param>
        /// <param name="pot">Potencia</param>
        /// <returns></returns>
        public static double Power(double input,int pot)                        //Elevar un númeor a una potencia
        {
            double output = 1;
            if (pot > 0)
            {
                for (int i = 0; i < pot; i++)
                {
                    output = output * input;
                }
            }
            else if(pot<0)
            {
                double potinv = MathIA.ExpLog.Sqrt(pot*pot);
                for (int i = 0; i < potinv; i++)
                {
                    output = output * input;
                }
                output = 1 / output;
            }
            return output;
        }
        /// <summary>
        /// Elevar cada elemento de un arreglo a la potencia especificada
        /// </summary>
        /// <param name="input">Arreglo de entrada</param>
        /// <param name="pot">Potencia</param>
        /// <returns></returns>
        public static double[] Power(double[] input, int pot)
        {
            double[] output = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = Power(input[i],pot);
            }
            return output;
        }
        /// <summary>
        /// Restar un escalar a cada elemento de un arreglo de entrada
        /// </summary>
        /// <param name="esc">Escalar</param>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double[] Minus(double esc, double[] input)                      //Resta de escalar a cada elemento de un vector
        {
            double[] output = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = input[i] - esc;
            }
            return output;
        }
        /// <summary>
        /// Multiplicar cada elemento de un arreglo por un escalar
        /// </summary>
        /// <param name="esc">Escalar</param>
        /// <param name="input">Arreglo de entrada</param>
        /// <returns></returns>
        public static double[] Prod(double esc, double[] input)                     //Multiplicar un arrreglo por un escalar
        {
            double[] output = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = input[i] *esc;
            }
            return output;
        }
        /// <summary>
        /// Multiplicación elemento a elemento entre dos arreglos
        /// </summary>
        /// <param name="input">Arreglo de entrada 1</param>
        /// <param name="input2">Arreglo de entrada 2</param>
        /// <returns></returns>
        public static double [,] Prod(double[] input,double[] input2)
        {
            double[,] output = new double[input.Length, input2.Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input2.Length; j++)
                {
                    output[i, j] = input[i] * input2[j];
                }
            }
            return output;
        }
        /// <summary>
        /// Valor absoluto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double Abs(double input)
        {
            double output = ExpLog.Sqrt(MathIA.Arithmetic.Power(input, 2));
            return output;

        }
        /// <summary>
        /// Producto punto entre dos arreglos
        /// </summary>
        /// <param name="x">Arreglo de entrada 1</param>
        /// <param name="y">Arreglo de entrada 2</param>
        /// <returns></returns>
        public static double Dot(double[] x, double[] y)                //Producto punto
        {
            double[] output = new double[x.Length];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = x[i] * y[i];
            }
            return Arithmetic.Sum(output);
        }
    }
    /// <summary>
    /// Generación de arreglos
    /// </summary>
    public class MatArr
    {
        /// <summary>
        /// Arreglo de inicio a final con intervalo especificado
        /// </summary>
        /// <param name="inicio">Inicio</param>
        /// <param name="final">Fin</param>
        /// <param name="intervalo">Intervalo</param>
        /// <returns></returns>
        public static double[] Linspace(double inicio, double final, double intervalo) 
            {
                int n = Convert.ToInt32(1 + (final-inicio) / intervalo);
                double[] output = new double[n];
                for(int i=0;i<n;i++)
                {
                    output[i] = inicio + intervalo * i;
                }
                return output;
            }
        /// <summary>
        /// Busca un elemento en un arreglo
        /// </summary>
        /// <param name="arreglo">Arreglo</param>
        /// <param name="valor">Elemento a buscar</param>
        /// <returns></returns>
        public static int Buscar(double[] arreglo, double valor)                    
        {
            bool estado = true;
            int z = 0;
            while (estado)
            {
                if (valor == arreglo[z])
                {
                    estado = false;
                }
                z++;
            }
            int output = z-1;
            return output;
        }
    }
    /// <summary>
    /// Métodos de integración numérica
    /// </summary>
    public class Integral
    {
        /// <summary>
        /// Método de Simpson
        /// </summary>
        /// <param name="a">Inicio</param>
        /// <param name="b">Fin</param>
        /// <param name="y">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Simpson(double a, double b, double[] y)
        {
            double output = 0;
            double h = (b - a) / (y.Length - 1);
            double[] pares = new double[y.Length / 2 - 1];
            double[] impares = new double[y.Length / 2];
            for (int i = 1; i <= pares.Length; i++)
            {
                pares[i - 1] = y[2 * i];

            }
            for (int i = 1; i <= impares.Length; i++)
            {
                impares[i - 1] = y[2 * i - 1];

            }
            output = (h / 3) * (y[0] + y[y.Length - 1] + 2 * MathIA.Arithmetic.Sum(pares) + 4 * MathIA.Arithmetic.Sum(impares));
            return output;
        }
        /// <summary>
        /// Método por regla del trapecio
        /// </summary>
        /// <param name="a">Incio</param>
        /// <param name="b">Fin</param>
        /// <param name="y">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Trapz(double a, double b, double[] y)          //Regla del trapecio
        {
            double output = 0;
            double h = (b - a) / (y.Length);
            double[] trapecios = new double[y.Length - 2];
            for (int i = 1; i < trapecios.Length + 1; i++)
            {
                trapecios[i - 1] = y[i];
            }
            output = h * (y[0] + y[y.Length - 1] + Arithmetic.Sum(trapecios));
            return output;
        }
        /// <summary>
        /// Método por regla del rectángulo
        /// </summary>
        /// <param name="a">Incio</param>
        /// <param name="b">Fin</param>
        /// <param name="y">Arreglo de entrada</param>
        /// <returns></returns>
        public static double Rectangulo(double a, double b, double[] y)         //Regla del rectángulo
        {
            double output = 0;
            double h = (b - a) / (y.Length);
            output = h * (Arithmetic.Sum(y)-y[y.Length-1]);
            return output;
        }
    }
    /// <summary>
    /// Funciones y operaciones básicas para Redes Neuronales Artificiales
    /// </summary>
    public class RNA                                //Se utilizó para los videos de Jeff Heaton
    {
        /// <summary>
        /// Función de activación Hardlim
        /// </summary>
        /// <param name="input">Entrada</param>
        /// <returns></returns>
        public static double Hardlim(double input)                          //Función de activación
        {
            double output;
            if (input >= 0)
            {
                output = 1;
            }
            else
            {
                output = 0;
            }
            return output;
        }
        /// <summary>
        /// Obten la fila de un arreglo multidimensional
        /// </summary>
        /// <param name="input">Arreglo multidimensional</param>
        /// <param name="fila">Fila</param>
        /// <returns></returns>
        public static double[] GetRow(double[,] input,int fila)
        {
            double[] output=new double[input.GetLength(1)];
            for (int i = 0; i < input.GetLength(1); i++)
            {
                output[i] = input[fila, i];
            }
            return output;
        }
        /// <summary>
        /// Obten la columna de un arreglo multidimensional
        /// </summary>
        /// <param name="input">Arreglo multidimensional</param>
        /// <param name="col">Columna</param>
        /// <returns></returns>
        public static double[] GetCol(double[,] input, int col)
        {
            double[] output = new double[input.GetLength(0)];
            for (int i = 0; i < input.GetLength(0); i++)
            {
                output[i] = input[i,col];
            }
            return output;
        }
        /// <summary>
        /// Transposición de un arreglo multidimensional
        /// </summary>
        /// <param name="input">Arreglo multidimensional</param>
        /// <returns></returns>
        public static double[,] Transpose(double[,] input)
        {
            double[,] output = new double[input.GetLength(1), input.GetLength(0)];
            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    output[i, j] = input[j, i];
                }
            }
            return output;
        }

    }
    /// <summary>
    /// Manejo de arreglos como matrices
    /// </summary>
    public class Matriz                                             //Clase para manejar arreglos como matrices
    {
        /// <summary>
        /// Crear una matriz
        /// </summary>
        /// <param name="renglones">Renglones</param>
        /// <param name="columnas">Columnas</param>
        /// <returns></returns>
        public static double[][] Crear(int renglones, int columnas)
        {
            double[][] output = new double[renglones][];
            for (int i = 0; i < renglones; ++i)
            {
                output[i] = new double[columnas];
            }
            return output;
        }
        /// <summary>
        /// Crear una matriz identidad de n por n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double[][] Identidad(int n)
        {
            double[][] output = Crear(n, n);
            for (int i = 0; i < n; ++i)
            {
                output[i][i] = 1.0;
            }
            return output;
        }
        /// <summary>
        /// Crear una matriz de ceros de n por n
        /// </summary>
        /// <param name="renglones"></param>
        /// <param name="columnas"></param>
        /// <returns></returns>
        public static double[][] Zeros(int renglones,int columnas)
        {
            double[][] output = Crear(renglones, columnas);
            for (int i = 0; i < renglones; ++i)
            {
                output[i] = new double[columnas];
                for(int j=0;j<columnas;j++)
                {
                    output[i][j] = 0;
                }
            }
            return output;
        }
        /// <summary>
        /// Vector de unos, como si fuera una entrada escalón
        /// </summary>
        /// <param name="t">Vector de tiempo</param>
        /// <returns></returns>
        public static double[][] Escalon(double[][] t)
        {

            double[][] output = new double[1][];
            output[0] = new double[t[0].Length];
            for (int i = 0; i < t[0].Length; i++)
            {
                output[0][i] = 1;
            }
            return output;
        }
        /// <summary>
        /// Cortar un vector 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="inicio"></param>
        /// <param name="final"></param>
        /// <returns></returns>
        public static double[][] Cortar(double[][] x, int inicio, int final)
        {

            double[][] output = new double[1][];
            output[0] = new double[final-inicio+1];
            for (int i = 0; i < output[0].Length; i++)
            {
                output[0][i] = x[0][i+inicio];
            }
            return output;
        }
        /// <summary>
        /// Generar un vector de inicio a fin con un intervalo dado
        /// </summary>
        /// <param name="inicio">Inicio</param>
        /// <param name="final">Final</param>
        /// <param name="intervalo">Intervalo</param>
        /// <returns></returns>
        public static double[][] Vector(double inicio, double final, double intervalo)
        {
            int n = Convert.ToInt32(1 + (final - inicio) / intervalo);
            double[][] output = new double[1][];
            output[0]=new double[n];
            for (int i = 0; i < n; i++)
            {
                output[0][i] = inicio + intervalo * i;
            }
            return output;
        }
        /// <summary>
        /// Suma de matrices
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double[][] Suma(double[][] A, double[][] B)
        {
            int aRenglones = A.Length; int aColumnas = A[0].Length;
            double[][] output = Crear(aRenglones, aColumnas);

            for (int i = 0; i < aRenglones; ++i)
            {
                for (int j = 0; j < aColumnas; ++j)
                {
                    output[i][j] = A[i][j] + B[i][j];
                }
            }
            return output;
        }
        /// <summary>
        /// Transposción de matriz
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static double[][] Transponer(double[][] A)
        {
            int aRenglones = A.Length; int aColumnas = A[0].Length;
            double[][] output = Crear(aColumnas, aRenglones);

            for (int i = 0; i < aColumnas; ++i)
            {
                for (int j = 0; j < aRenglones; ++j)
                {
                    output[i][j] = A[j][i];
                }
            }
            return output;
        }
        /// <summary>
        /// Resta de matrices
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double[][] Resta(double[][] A, double[][] B)
        {
            int aRenglones = A.Length; int aColumnas = A[0].Length;
            double[][] output = Crear(aRenglones, aColumnas);

            for (int i = 0; i < aRenglones; ++i)
            {
                for (int j = 0; j < aColumnas; ++j)
                {
                        output[i][j] = A[i][j] - B[i][j];
                }
            }
            return output;
        }
        /// <summary>
        /// Producto punto entre matrices
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double[][] Producto(double[][] A, double[][] B)
        {
            int aRenglones = A.Length; int aColumnas = A[0].Length;
            int bRenglones = B.Length; int bColumnas = B[0].Length;
            double[][] output = Crear(aRenglones, bColumnas);

            for (int i = 0; i < aRenglones; ++i)
            {
                for (int j = 0; j < bColumnas; ++j)
                {
                    for (int k = 0; k < aColumnas; ++k)
                    {
                        output[i][j] += A[i][k] * B[k][j];
                    }
                }
            }
            return output;
        }
        /// <summary>
        /// Producto de una matriz por un escalar
        /// </summary>
        /// <param name="A"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static double[][] Producto(double[][] A, double e)
        {
            int aRenglones = A.Length; int aColumnas = A[0].Length;
            double[][] output = Crear(aRenglones, aColumnas);

            for (int i = 0; i < aRenglones; ++i)
            {
                for (int j = 0; j < aColumnas; ++j)
                {
                        output[i][j] += A[i][j] * e;
                }
            }
            return output;
        }
        /// <summary>
        /// Matriz inversa
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[][] Inversa(double[][] matrix)
        {
            int n = matrix.Length;
            double[][] output = Duplicar(matrix);

            int[] perm;
            int toggle;
            double[][] LU = Descomposicion(matrix, out perm, out toggle);
            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }

                double[] x = Solucionador(LU, b);

                for (int j = 0; j < n; ++j)
                    output[j][i] = x[j];
            }
            return output;
        }
        /// <summary>
        /// Duplicar una matriz
        /// </summary>
        /// <param name="matriz"></param>
        /// <returns></returns>
        public static double[][] Duplicar(double[][] matriz)
        {
            double[][] output = Crear(matriz.Length, matriz[0].Length);
            for (int i = 0; i < matriz.Length; ++i)
            {
                for (int j = 0; j < matriz[i].Length; ++j)
                {
                    output[i][j] = matriz[i][j];
                }
            }
            return output;
        }
        /// <summary>
        /// Solucionador LU
        /// </summary>
        /// <param name="LU">Matriz LU</param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[] Solucionador(double[][] LU, double[] b)
        {
            int n = LU.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                double suma = x[i];
                for (int j = 0; j < i; ++j)
                    suma -= LU[i][j] * x[j];
                x[i] = suma;
            }

            x[n - 1] /= LU[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= LU[i][j] * x[j];
                x[i] = sum / LU[i][i];
            }

            return x;
        }
        /// <summary>
        /// Descomposición LU
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="perm"></param>
        /// <param name="toggle"></param>
        /// <returns></returns>
        public static double[][] Descomposicion(double[][] matriz, out int[] perm, out int toggle)
        {
            int renglones = matriz.Length;
            int columnas = matriz[0].Length;

            int n = renglones;

            double[][] output = Duplicar(matriz);
            perm = new int[n];
            for (int i = 0; i < n; ++i) { perm[i] = i; }
            {
                toggle = 1;
            }
            for (int j = 0; j < n - 1; ++j)
            {
                double columnaMax = Math.Abs(output[j][j]);
                int pRenglon = j;

                for (int i = j + 1; i < n; ++i)
                {
                    if (Math.Abs(output[i][j]) > columnaMax)
                    {
                        columnaMax = Math.Abs(output[i][j]);
                        pRenglon = i;
                    }
                }

                if (pRenglon != j)
                {
                    double[] rowPtr = output[pRenglon];
                    output[pRenglon] = output[j];
                    output[j] = rowPtr;

                    int tmp = perm[pRenglon];
                    perm[pRenglon] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle;
                }



                if (output[j][j] == 0.0)
                {
                    int goodRow = -1;
                    for (int row = j + 1; row < n; ++row)
                    {
                        if (output[row][j] != 0.0)
                            goodRow = row;
                    }
                    double[] rowPtr = output[goodRow];
                    output[goodRow] = output[j];
                    output[j] = rowPtr;
                    int tmp = perm[goodRow];
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;
                    toggle = -toggle;
                }

                for (int i = j + 1; i < n; ++i)
                {
                    output[i][j] /= output[j][j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        output[i][k] -= output[i][j] * output[j][k];
                    }
                }
            }
            return output;
        }
        /// <summary>
        /// Estimación paramétrica por mínimos cuadrados
        /// </summary>
        /// <param name="y">Vector de salidas</param>
        /// <param name="psi">Vector regresor</param>
        /// <returns></returns>
        public static double[][] EstimacionParametrica(double[][] y, double[][] psi)
        {
            double[][] theta = Matriz.Zeros(psi.GetLength(0), 1);
            double[][] P = Matriz.Identidad(psi.GetLength(0));
            P = Matriz.Producto(P, 100000000);
            double[][] e = Matriz.Crear(y[0].Length, 1);
            e = Matriz.Resta(Matriz.Transponer(y), Matriz.Producto(Matriz.Transponer(psi), theta));
            theta = Matriz.Suma(theta, Matriz.Producto(Matriz.Producto(P, psi),
                        Matriz.Producto(Matriz.Inversa(Matriz.Suma(Matriz.Identidad(y[0].Length), Matriz.Producto(
                        Matriz.Transponer(psi), Matriz.Producto(P, psi)))), e)));
            P = Matriz.Resta(P, Matriz.Producto(Matriz.Producto(P, psi),
                    Matriz.Producto(Matriz.Inversa(Matriz.Suma(Matriz.Identidad(y[0].Length), Matriz.Producto(
                    Matriz.Transponer(psi), Matriz.Producto(P, psi)))), Matriz.Producto(Matriz.Transponer(psi), P))));

            return theta;
        }
        /// <summary>
        /// Primera derivada numérica
        /// </summary>
        /// <param name="t"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double[][] Derivada1(double[][]t,double[][]y)
        {
            double[][] ypto = Matriz.Crear(1, y[0].Length - 1);
            for (int i = 1; i < y[0].Length - 1; i++)
            {
                ypto[0][i - 1] = (y[0][i + 1] - y[0][i - 1]) / (2 * (t[0][i + 1] - t[0][i]));
            }
            return ypto;
        }
        /// <summary>
        /// Segunda derivada numérica
        /// </summary>
        /// <param name="t"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double[][] Derivada2(double[][] t, double[][] y)
        {
            double[][] y2pto = Matriz.Crear(1, y[0].Length - 1);
            for (int i = 1; i < y[0].Length - 1; i++)
            {
                y2pto[0][i - 1] = (y[0][i + 1] - 2 * y[0][i] + y[0][i - 1]) / ((t[0][i + 1] - t[0][i]) * (t[0][i + 1] - t[0][i]));
            }
            return y2pto;
        }
        /// <summary>
        /// Error Cuadrático Medio
        /// </summary>
        /// <param name="y">Arreglo estimado</param>
        /// <param name="y_real">Arreglo real</param>
        /// <returns></returns>
        public static double[][] ECM(double[][] y, double[][] y_real)
        {
            double[][] ECM = Matriz.Producto(Matriz.Resta(y, y_real),Matriz.Transponer(Matriz.Resta(y, y_real)));
            return ECM;
        }

    }

}