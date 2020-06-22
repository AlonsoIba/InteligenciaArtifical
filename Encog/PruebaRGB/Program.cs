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


namespace PruebaRGB
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta_red = "C:\\Users\\soyal\\Downloads\\DatosRNA\\TrainRGBC4to6.csv";
            BasicNetwork network = (BasicNetwork)EncogDirectoryPersistence.LoadObject(new FileInfo(ruta_red));
            double[] Entrada = new double[4] { 520, 1340, 1823, 3742 };
            IMLData EntradaN = new BasicMLData(Entrada);
            IMLData Resultado = network.Compute(EntradaN);
            double max = 0;
            int index = 0;
            for (int j = 0; j < 6; j++)
            {
                if (Resultado[j] > max)
                {
                    max = Resultado[j];
                    index = j;
                }
            }
            switch (index)
            {
                case 0:
                    Console.WriteLine("Rojo");
                    break;

                case 1:
                    Console.WriteLine("Naranja");
                    break;

                case 2:
                    Console.WriteLine("Amarillo");
                    break;

                case 3:
                    Console.WriteLine("Verde");
                    break;

                case 4:
                    Console.WriteLine("Azul");
                    break;

                case 5:
                    Console.WriteLine("Cafe");
                    break;
            }
            Console.ReadKey();
        }
    }
}
