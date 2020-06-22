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

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta_red = "C:\\Users\\soyal\\OneDrive - UNIVERSIDAD NACIONAL AUTÓNOMA DE MÉXICO\\Documentos\\2020-2\\InteligenciaArtificial\\Encog\\Train.txt";
            double[] Entrada = new double[2] { 10, 10 }; 
            BasicNetwork network = (BasicNetwork)EncogDirectoryPersistence.LoadObject(new FileInfo(ruta_red));
            IMLData EntradaN = new BasicMLData(Entrada);
            IMLData output = network.Compute(EntradaN);
            double prueba = output[0];
            Console.WriteLine(prueba);
            Console.ReadKey();

        }
    }
}
