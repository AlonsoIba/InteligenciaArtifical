using System;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.ML.Train;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.Neural.Networks.Training.Propagation.Resilient;


namespace XOR
{
    class Program
    {

        public static double[][] XORInput = {
            new[] {0.5, 0.25},
            new[] {0.5, 0.75},
            new[] {0.25, 0.5},
            new[] {0.75, 0.5},
            new[] {0.5, 0.0},
            new[] {0.5, 1},
            new[] {0, 0.5},
            new[] {1, 0.5} };

        public static double[][] XORIdeal = {
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
            new[] {0.0},
            new[] {0.0},
            new[] {0.0},
            new[] {0.0}
        };
        static void Main(string[] args)
        {
            // create a neural network, without using a factory
            var network = new BasicNetwork();
            network.AddLayer(new BasicLayer(null, true, 2));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 10));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, 1));
            network.Structure.FinalizeStructure();
            network.Reset();

            // create training data
            IMLDataSet trainingSet = new BasicMLDataSet(XORInput, XORIdeal);

            // train the neural network
            IMLTrain train = new ResilientPropagation(network, trainingSet);

            int epoch = 1;

            do
            {
                train.Iteration();
                Console.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                epoch++;
            } while (train.Error > 0.0001);

            // test the neural network
            Console.WriteLine(@"Neural Network Results:");
            foreach (IMLDataPair pair in trainingSet)
            {
                IMLData output = network.Compute(pair.Input);
                Console.WriteLine(pair.Input[0] + @"," + pair.Input[1]
                                  + @", actual=" + output[0] + @",ideal=" + pair.Ideal[0]);
            }
            Console.ReadKey();  

        }
    }
}
