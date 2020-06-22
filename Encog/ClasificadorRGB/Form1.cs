using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

namespace ClasificadorRGB
{
    public partial class Form1 : Form
    {
        double[][] Input;
        double[] Entrada;
        BasicNetwork Red;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            string ruta_red = "C:\\Users\\soyal\\OneDrive - UNIVERSIDAD NACIONAL AUTÓNOMA DE MÉXICO\\Documentos\\2020-2\\InteligenciaArtificial\\Encog\\TrainRGB6.txt";
            Red = (BasicNetwork)EncogDirectoryPersistence.LoadObject(new FileInfo(ruta_red));

            string ruta_datos = "C:\\Users\\soyal\\OneDrive - UNIVERSIDAD NACIONAL AUTÓNOMA DE MÉXICO\\Documentos\\2020-2\\InteligenciaArtificial\\Encog\\RGB6.csv";
            StreamReader lector = new StreamReader(ruta_datos);
            var lineas = new List<string[]>();
            string[] Linea;
            while (!lector.EndOfStream)
            {
                Linea = lector.ReadLine().Split(',');
                lineas.Add(Linea);
            }
            Input = new double[lineas.Count][];
            for (int i = 0; i < lineas.Count; i++)
            {
                Input[i] = new double[3];
                Input[i][0] = Convert.ToDouble(lineas[i][0]);
                Input[i][1] = Convert.ToDouble(lineas[i][1]);
                Input[i][2] = Convert.ToDouble(lineas[i][2]);
            }
            for (int i = 0; i < lineas.Count / 6; i++)
            {
                chart1.Series["Rojo"].Points.AddXY(Input[i][0], Input[i][1]);
                chart2.Series["Rojo"].Points.AddXY(Input[i][0], Input[i][2]);
                chart3.Series["Rojo"].Points.AddXY(Input[i][1], Input[i][2]);
            }

            for (int i = lineas.Count / 6; i < lineas.Count / 3; i++)
            {
                chart1.Series["Naranja"].Points.AddXY(Input[i][0], Input[i][1]);
                chart2.Series["Naranja"].Points.AddXY(Input[i][0], Input[i][2]);
                chart3.Series["Naranja"].Points.AddXY(Input[i][1], Input[i][2]);
            }

            for (int i = lineas.Count/3; i < lineas.Count / 2; i++)
            {
                chart1.Series["Amarillo"].Points.AddXY(Input[i][0], Input[i][1]);
                chart2.Series["Amarillo"].Points.AddXY(Input[i][0], Input[i][2]);
                chart3.Series["Amarillo"].Points.AddXY(Input[i][1], Input[i][2]);
            }

            for (int i =  lineas.Count / 2; i < 2*lineas.Count/3; i++)
            {
                chart1.Series["Verde"].Points.AddXY(Input[i][0], Input[i][1]);
                chart2.Series["Verde"].Points.AddXY(Input[i][0], Input[i][2]);
                chart3.Series["Verde"].Points.AddXY(Input[i][1], Input[i][2]);
            }

            for (int i = 2*lineas.Count / 3; i < 5* lineas.Count / 6; i++)
            {
                chart1.Series["Azul"].Points.AddXY(Input[i][0], Input[i][1]);
                chart2.Series["Azul"].Points.AddXY(Input[i][0], Input[i][2]);
                chart3.Series["Azul"].Points.AddXY(Input[i][1], Input[i][2]);
            }

            for (int i = 5*lineas.Count / 6; i < lineas.Count ; i++)
            {
                chart1.Series["Cafe"].Points.AddXY(Input[i][0], Input[i][1]);
                chart2.Series["Cafe"].Points.AddXY(Input[i][0], Input[i][2]);
                chart3.Series["Cafe"].Points.AddXY(Input[i][1], Input[i][2]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Prueba"].Points.Clear();
            chart2.Series["Prueba"].Points.Clear();
            chart3.Series["Prueba"].Points.Clear();
            Entrada = new double[3] { trackBar1.Value, trackBar2.Value,trackBar3.Value };
            IMLData EntradaNeurona = new BasicMLData(Entrada);
            IMLData Resultado = Red.Compute(EntradaNeurona);
            chart1.Series["Prueba"].Points.AddXY(Entrada[0], Entrada[1]);
            chart2.Series["Prueba"].Points.AddXY(Entrada[0], Entrada[2]);
            chart3.Series["Prueba"].Points.AddXY(Entrada[1], Entrada[2]);
            pictureBox1.BackColor = Color.FromArgb(Convert.ToInt32(Entrada[0]), Convert.ToInt32(Entrada[1]),Convert.ToInt32(Entrada[2]));
            if(Resultado[0]>0.9&&Resultado[1]<0.1&&Resultado[2]<0.1)
            {
                label1.Text = "Es color rojo con un valor de \nR:" + Resultado[0]+"\nG:"+Resultado[1]+"\nB:"+Resultado[2];
            }
            else if (Resultado[0] > 0.9 && Resultado[1] > 0.9 && Resultado[2] > 0.9)
            {
                label1.Text = "Es color naranja con un valor de \nR:" + Resultado[0] + "\nG:" + Resultado[1] + "\nB:" + Resultado[2];
            }
            else if (Resultado[0] > 0.9 && Resultado[1] > 0.9 && Resultado[2] < 0.1)
            {
                label1.Text = "Es color amarillo con un valor de \nR:" + Resultado[0] + "\nG:" + Resultado[1] + "\nB:" + Resultado[2];
            }
            else if (Resultado[0] < 0.1 && Resultado[1] > 0.9 && Resultado[2] < 0.1)
            {
                label1.Text = "Es color verde con un valor de \nR:" + Resultado[0] + "\nG:" + Resultado[1] + "\nB:" + Resultado[2];
            }
            else if (Resultado[0] < 0.1 && Resultado[1] < 0.1 && Resultado[2] > 0.9)
            {
                label1.Text = "Es color azul con un valor de \nR:" + Resultado[0] + "\nG:" + Resultado[1] + "\nB:" + Resultado[2];
            }
            else if(Resultado[0] < 0.1 && Resultado[1] < 0.1 && Resultado[2] < 0.1)
            {
                label1.Text = "Es color café con un valor de \nR:" + Resultado[0] + "\nG:" + Resultado[1] + "\nB:" + Resultado[2];
            }
            else
            {
                label1.Text = "Indeterminado con un valor de \nR:" + Resultado[0] + "\nG:" + Resultado[1] + "\nB:" + Resultado[2];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }
    }
}
