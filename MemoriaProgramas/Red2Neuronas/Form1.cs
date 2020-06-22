using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.CompilerServices;

namespace Red2Neuronas
{
    public partial class Form1 : Form
    {
        double[,] datos;
        double[,] P, T, W, E;
        double[] b;
        int epocas;
        Random aleatorio;

        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = openFileDialog1.FileName;
                StreamReader lector = new StreamReader(ruta);
                var lineas = new List<string[]>();
                string[] Linea;
                while (!lector.EndOfStream)
                {
                    Linea = lector.ReadLine().Split(',');
                    lineas.Add(Linea);
                }
                datos = new double[lineas.Count, lineas[0].Length];
                for (int i = 0; i < lineas.Count; i++)
                {
                    for (int j = 0; j < lineas[0].Length; j++)
                    {
                        datos[i, j] = Convert.ToDouble(lineas[i][j]);

                    }
                }

                P = new double[2, datos.GetLength(0)];
                T = new double[2, datos.GetLength(0)];
                for (int i = 0; i < P.GetLength(0); i++)
                {
                    for (int j = 0; j < P.GetLength(1); j++)
                    {
                        P[i, j] = datos[j, i];
                        T[i, j] = datos[j, i+2];
                    }
                }
            }
            //Lee datos (x1,x2,y)
            for (int i = 0; i < P.GetLength(1); i++)
            {
                if (T[0, i] == 0 && T[1, i] == 1)
                {
                    chart1.Series["Muestra1"].Points.AddXY(P[0,i], P[1,i]);
                }
                if (T[0, i] == 1 && T[1, i] == 1)
                {
                    chart1.Series["Muestra2"].Points.AddXY(P[0, i], P[1, i]);
                }
                if (T[0, i] == 1 && T[1, i] == 0)
                {
                    chart1.Series["Muestra3"].Points.AddXY(P[0, i], P[1, i]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            W = new double[2, 2];
            E = new double[P.GetLength(0), P.GetLength(1)];
            b = new double[2];
            aleatorio = new Random();
            epocas = 500;
            for (int i = 0; i < W.GetLength(0); i++)
            {
                for (int j = 0; j < W.GetLength(1); j++)
                {
                    W[i, j] = 2 * aleatorio.NextDouble() - 1;
                }
            }

            for (int i = 0; i < E.GetLength(0); i++)
            {
                for (int j = 0; j < E.GetLength(1); j++)
                {
                    E[i, j] = 0;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                b[i] = 2 * aleatorio.NextDouble() - 1;
            }

            label1.Text = "|" + Math.Round(W[0, 0], 4) + "|";
            label2.Text = "|" + Math.Round(W[0, 1], 4) + "|";
            label3.Text = "|" + Math.Round(W[1, 0], 4) + "|";
            label4.Text = "|" + Math.Round(W[1, 1], 4) + "|";

            label6.Text = "|" + Math.Round(b[0], 4) + "|";
            label7.Text = "|" + Math.Round(b[1], 4) + "|";

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1.Series["Recta1"].Points.Clear();
            chart1.Series["Recta2"].Points.Clear();
            
            //for (int k = 0; k < epocas; k++)
            //{
                for (int i = 0; i < P.GetLength(1); i++)
                {
                    for (int j = 0; j < P.GetLength(0); j++)
                    {
                        E[j, i] = T[j, i] - MathIA.RNA.Hardlim(MathIA.Arithmetic.Dot(MathIA.RNA.GetRow(W, j), MathIA.RNA.GetCol(P, i)) + b[j]);
                        W = MathIA.Arithmetic.Sum(W, MathIA.Arithmetic.Prod(MathIA.RNA.GetCol(E, i), MathIA.RNA.GetCol(P, i)));
                        b[j] = b[j] + E[j, i];
                    }
                }
            //}

            //Dibujo de la recta
            for (int j = 0; j < 10; j++)
            {
                chart1.Series["Recta1"].Points.AddXY(j, j * (-W[0, 0] / W[0, 1]) - (b[0] / W[0, 1]));
                chart1.Series["Recta2"].Points.AddXY(j, j * (-W[1, 0] / W[1, 1]) - (b[1] / W[1, 1]));
            }

            label1.Text = "|" + Math.Round(W[0, 0], 4) + "|";
            label2.Text = "|" + Math.Round(W[0, 1], 4) + "|";
            label3.Text = "|" + Math.Round(W[1, 0], 4) + "|";
            label4.Text = "|" + Math.Round(W[1, 1], 4) + "|";

            label6.Text = "|" + Math.Round(b[0], 4) + "|";
            label7.Text = "|" + Math.Round(b[1], 4) + "|";

            
        }
    }
}
