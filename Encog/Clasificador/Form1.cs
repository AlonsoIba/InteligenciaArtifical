using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
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

namespace Clasificador
{
    public partial class Form1 : Form
    {
        double[][] Input,Output;
        BasicNetwork Red;
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            string ruta_red = "C:\\Users\\soyal\\OneDrive - UNIVERSIDAD NACIONAL AUTÓNOMA DE MÉXICO\\Documentos\\2020-2\\InteligenciaArtificial\\Encog\\Train.txt";
            Red = (BasicNetwork)EncogDirectoryPersistence.LoadObject(new FileInfo(ruta_red));

            string ruta_datos = "C:\\Users\\soyal\\OneDrive - UNIVERSIDAD NACIONAL AUTÓNOMA DE MÉXICO\\Documentos\\2020-2\\InteligenciaArtificial\\Encog\\DatosEntrenamiento.csv";
            StreamReader lector = new StreamReader(ruta_datos);
            var lineas = new List<string[]>();
            string[] Linea;
            while (!lector.EndOfStream)
            {
                Linea = lector.ReadLine().Split(',');
                lineas.Add(Linea);
            }
            Input = new double[lineas.Count][];
            Output = new double[lineas.Count][];
            for (int i = 0; i < lineas.Count; i++)
            {
                Input[i] = new double[2];
                Output[i] = new double[1];
                Input[i][0] = Convert.ToDouble(lineas[i][0]);
                Input[i][1] = Convert.ToDouble(lineas[i][1]);
                Output[i][0] = Convert.ToDouble(lineas[i][2]);
            }
            for (int i = 0; i < lineas.Count / 2; i++)
            {
                chart1.Series["Clase1"].Points.AddXY(Input[i][0], Input[i][1]);
            }
            for (int i = lineas.Count / 2; i < lineas.Count; i++)
            {
                chart1.Series["Clase2"].Points.AddXY(Input[i][0], Input[i][1]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Prueba"].Points.Clear();
            double[] Entrada = new double[2] { Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text) };
            IMLData EntradaNeurona = new BasicMLData(Entrada);
            IMLData Resultado = Red.Compute(EntradaNeurona);
            chart1.Series["Prueba"].Points.AddXY(Entrada[0],Entrada[1]);
            if (Resultado[0]<0.1)
            {
                label3.Text = "Pertenenece a la clase 1 con un valor de "+Resultado[0];
            }
            else if(Resultado[0]>0.9)
            {
                label3.Text = "Pertenenece a la clase 2 con un valor de " + Resultado[0];
            }
            else
            {
                label3.Text = "Indeterminado con un valor de " + Resultado[0];
            }

        }
    }
}
