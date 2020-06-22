using System;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.ML.Train;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Persist;
using Encog.Util.Simple;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;

namespace EntrenamientoRGB
{   /// <summary>
/// En este programa se realiza el entrenamiento de una red neuronal para una muestra de datos dada en un archivo .csv
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string ruta_datos = "C:\\Users\\soyal\\Downloads\\Muestra2RGBC.csv";
            StreamReader lector = new StreamReader(ruta_datos);
            var lineas = new List<string[]>();
            string[] Linea;
            while (!lector.EndOfStream)
            {
                Linea = lector.ReadLine().Split(',');
                lineas.Add(Linea);
            }
            double[][] Input = new double[lineas.Count][];
            double[][] Output = new double[lineas.Count][];
            for (int i = 0; i < lineas.Count; i++)
            {
                Input[i] = new double[4];
                Output[i] = new double[6];
                Input[i][0] = Convert.ToDouble(lineas[i][0]);       //Canal R
                Input[i][1] = Convert.ToDouble(lineas[i][1]);       //Canal G
                Input[i][2] = Convert.ToDouble(lineas[i][2]);       //Canal B
                Input[i][3] = Convert.ToDouble(lineas[i][3]);       //Canal C
                Output[i][0] = Convert.ToDouble(lineas[i][4]);      //1 si es rojo
                Output[i][1] = Convert.ToDouble(lineas[i][5]);      //1 si es naranja
                Output[i][2] = Convert.ToDouble(lineas[i][6]);      //1 si es amarillo
                Output[i][3] = Convert.ToDouble(lineas[i][7]);      //1 si es verde
                Output[i][4] = Convert.ToDouble(lineas[i][8]);      //1 si es azul
                Output[i][5] = Convert.ToDouble(lineas[i][9]);      //1 si es cafe
                Console.WriteLine("\t" + Input[i][0] + "\t" + Input[i][1] + "\t" + Input[i][2] + "\t" + Input[i][3] + "\t" + Output[i][0] + "\t" + Output[i][1] + "\t" + Output[i][2] + "\t" + Output[i][3] + "\t" + Output[i][4] + "\t" + Output[i][5] + "\t");
            }
            Console.ReadKey();
            string ruta_red = "C:\\Users\\soyal\\Downloads\\TrainRGBC4to6.csv";
            IMLDataSet trainingSet = new BasicMLDataSet(Input, Output);    //Se dan entradas y salidas a la red
            BasicNetwork network = EncogUtility.SimpleFeedForward(4, 200, 200, 6, false);  //Diseño de red
            EncogUtility.TrainToError(network, trainingSet, 0.0001);              //Método de entrenamiento
            double error = network.CalculateError(trainingSet);
            EncogDirectoryPersistence.SaveObject(new FileInfo(ruta_red), network);  //Guardar red entrenada
            Console.WriteLine("Ready");
            Console.ReadKey();
        }
    }
}
