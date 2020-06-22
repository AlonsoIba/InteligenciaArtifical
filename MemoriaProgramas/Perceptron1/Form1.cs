using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron1
{
    public partial class Form1 : Form
    {
        double[] Error;
        double[,] datos;
        double w1, w2, b, n, F, Y, S, d1, d2, D;
        int k, aux;
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        private void button3_Click(object sender, EventArgs e)
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

            }
            Error = new double[datos.GetLength(0)];
            //Lee datos (x1,x2,y)
            for (int i = 0; i < datos.GetLength(0); i++)
            {
                Error[i] = 1;
                if (datos[i, 2] == 0)
                {
                    chart1.Series["Entradas0"].Points.AddXY(datos[i, 0], datos[i, 1]);
                }
                if (datos[i, 2] == 1)
                {
                    chart1.Series["Entradas1"].Points.AddXY(datos[i, 0], datos[i, 1]);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            w1 = Convert.ToDouble(textBox1.Text);
            w2 = Convert.ToDouble(textBox2.Text);
            b = Convert.ToDouble(textBox3.Text);
            n = Convert.ToDouble(textBox4.Text);
            S = 1;
            k = 0;
            //Dibujo de la recta
            for (int j = -1; j < 5; j++)
            {
                chart1.Series["Recta"].Points.AddXY(j, j * (-w1 / w2) + (b / w2));
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            aux++;
            if (S != 0)
            {
                //Calculo de la función hardlim
                F = w1 * datos[k, 0] + w2 * datos[k, 1] - b;
                if (F < 0)
                {
                    Y = 0;
                }
                else
                {
                    Y = 1;
                }
                //Cálculo del error
                D = datos[k, 2];
                S = D - Y;
                d1 = n * S * datos[k, 0];
                d2 = n * S * datos[k, 1];
                w1 = w1 + d1;
                w2 = w2 + d2;
                b = b - n * S;
                textBox1.Text = w1.ToString();
                textBox2.Text = w2.ToString();
                textBox3.Text = b.ToString();
                chart1.Series["Recta"].Points.Clear();
                //Dibujo de la recta    
                for (int j = -1; j < 5; j++)
                {
                    chart1.Series["Recta"].Points.AddXY(j, j * (-w1 / w2) + (b / w2));
                }
            }
            else
            {
                for (int j = 0; j < datos.GetLength(0); j++)
                {
                    F = w1 * datos[j, 0] + w2 * datos[j, 1] - b;
                    if (F < 0)
                    {
                        Y = 0;
                    }
                    else
                    {
                        Y = 1;
                    }
                    //Cálculo del error
                    D = datos[j, 2];
                    Error[j] = D - Y;
                }
                if(MathIA.Arithmetic.Sum(Error)==0)
                {
                    timer1.Stop();
                    label3.Text = "Listo";
                }
                S = 1;
                //Volver a la primera fila
                if (k < datos.GetLength(0) - 1)
                {
                    k++;
                }
                else
                {
                    k = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            label3.Text = "Calculando";
        }
    }
}
