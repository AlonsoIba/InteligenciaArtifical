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

namespace Entrenamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            //Datos excel
            string ruta_datos = "C:\\Users\\soyal\\OneDrive - UNIVERSIDAD NACIONAL AUTÓNOMA DE MÉXICO\\Documentos\\2020-2\\InteligenciaArtificial\\Encog\\DatosEntrenamiento.csv";
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
                Input[i] = new double[2];
                Output[i] = new double[1];
                Input[i][0] = Convert.ToDouble(lineas[i][0]); ;
                Input[i][1] = Convert.ToDouble(lineas[i][1]);
                Output[i][0] = Convert.ToDouble(lineas[i][2]);
                Console.WriteLine("|" + Input[i][0] + "|" + Input[i][1] + "|" + Output[i][0] + "|");
            }

            Console.ReadKey();

            string  ruta_red = "C:\\Users\\soyal\\OneDrive - UNIVERSIDAD NACIONAL AUTÓNOMA DE MÉXICO\\Documentos\\2020-2\\InteligenciaArtificial\\Encog\\Train.txt";
            IMLDataSet trainingSet = new BasicMLDataSet(Input, Output);    //Se dan entradas y salidas a la red
            BasicNetwork network = EncogUtility.SimpleFeedForward(2, 6, 0,1, false);  //Diseño de red
            EncogUtility.TrainToError(network, trainingSet, 0.0001);              //Método de entrenamiento
            double error = network.CalculateError(trainingSet);
            EncogDirectoryPersistence.SaveObject(new FileInfo(ruta_red), network);  //Guardar red entrenada
            Console.WriteLine("Ready");
            Console.ReadKey();
        }
    }
}
