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

namespace Examen
{
    public partial class Form1 : Form
    {
        MathIA.ObjStac[][] muestras;
        double maxTemp,maxCol,maxTri,maxTen,minTen,minCal,maxCal,minMg,maxMg;
        public Form1()
        {
            InitializeComponent();
            string ruta_datos = "MuestrasExamen.csv";  //Lecutra de datos
            StreamReader lector = new StreamReader(ruta_datos);
            var lineas = new List<string[]>();
            string[] Linea;
            while (!lector.EndOfStream)
            {
                Linea = lector.ReadLine().Split(',');
                lineas.Add(Linea);
            }

            double[] MS0 = new double[147];
            double[] MS1 = new double[147];
            double[] MS2 = new double[147];
            double[] MS3 = new double[147];
            double[] MS4 = new double[147];
            double[] MS5 = new double[147];
            double[] MS6 = new double[147];
            double[] MS7 = new double[147];
            double[] MS8 = new double[147];
            for (int i = 0; i < 147; i++)
            {
                MS0[i] = Convert.ToDouble(lineas[i][0]);
                MS1[i] = Convert.ToDouble(lineas[i][1]);
                MS2[i] = Convert.ToDouble(lineas[i][2]);
                MS3[i] = Convert.ToDouble(lineas[i][3]);
                MS4[i] = Convert.ToDouble(lineas[i][4]);
                MS5[i] = Convert.ToDouble(lineas[i][5]);
                MS6[i] = Convert.ToDouble(lineas[i][6]);
                MS7[i] = Convert.ToDouble(lineas[i][7]);
                MS8[i] = Convert.ToDouble(lineas[i][8]);
            }
            double[] MNS0 = new double[67];
            double[] MNS1 = new double[67];
            double[] MNS2 = new double[67];
            double[] MNS3 = new double[67];
            double[] MNS4 = new double[67];
            double[] MNS5 = new double[67];
            double[] MNS6 = new double[67];
            double[] MNS7 = new double[67];
            double[] MNS8 = new double[67];
            for (int i = 147; i < 147 + 67; i++)
            {
                MNS0[i - 147] = Convert.ToDouble(lineas[i][0]);
                MNS1[i - 147] = Convert.ToDouble(lineas[i][1]);
                MNS2[i - 147] = Convert.ToDouble(lineas[i][2]);
                MNS3[i - 147] = Convert.ToDouble(lineas[i][3]);
                MNS4[i - 147] = Convert.ToDouble(lineas[i][4]);
                MNS5[i - 147] = Convert.ToDouble(lineas[i][5]);
                MNS6[i - 147] = Convert.ToDouble(lineas[i][6]);
                MNS7[i - 147] = Convert.ToDouble(lineas[i][7]);
                MNS8[i - 147] = Convert.ToDouble(lineas[i][8]);
            }

            double[] HS0 = new double[65];
            double[] HS1 = new double[65];
            double[] HS2 = new double[65];
            double[] HS3 = new double[65];
            double[] HS4 = new double[65];
            double[] HS5 = new double[65];
            double[] HS6 = new double[65];
            double[] HS7 = new double[65];
            double[] HS8 = new double[65];
            for (int i = 147 + 67; i < 147 + 67 + 65; i++)
            {
                HS0[i - 214] = Convert.ToDouble(lineas[i][0]);
                HS1[i - 214] = Convert.ToDouble(lineas[i][1]);
                HS2[i - 214] = Convert.ToDouble(lineas[i][2]);
                HS3[i - 214] = Convert.ToDouble(lineas[i][3]);
                HS4[i - 214] = Convert.ToDouble(lineas[i][4]);
                HS5[i - 214] = Convert.ToDouble(lineas[i][5]);
                HS6[i - 214] = Convert.ToDouble(lineas[i][6]);
                HS7[i - 214] = Convert.ToDouble(lineas[i][7]);
                HS8[i - 214] = Convert.ToDouble(lineas[i][8]);
            }

            double[] HNS0 = new double[67];
            double[] HNS1 = new double[67];
            double[] HNS2 = new double[67];
            double[] HNS3 = new double[67];
            double[] HNS4 = new double[67];
            double[] HNS5 = new double[67];
            double[] HNS6 = new double[67];
            double[] HNS7 = new double[67];
            double[] HNS8 = new double[67];
            for (int i = 279; i < 147 + 67 + 65 + 67; i++)
            {
                HNS0[i - 279]= Convert.ToDouble(lineas[i][0]);
                HNS1[i - 279] = Convert.ToDouble(lineas[i][1]);
                HNS2[i - 279] = Convert.ToDouble(lineas[i][2]);
                HNS3[i - 279] = Convert.ToDouble(lineas[i][3]);
                HNS4[i - 279] = Convert.ToDouble(lineas[i][4]);
                HNS5[i - 279] = Convert.ToDouble(lineas[i][5]);
                HNS6[i - 279] = Convert.ToDouble(lineas[i][6]);
                HNS7[i - 279] = Convert.ToDouble(lineas[i][7]);
                HNS8[i - 279] = Convert.ToDouble(lineas[i][8]);
            }
            //Muestras como objetos estadisticos
            muestras = new MathIA.ObjStac[][] { new MathIA.ObjStac[] { new MathIA.ObjStac(MS0), new MathIA.ObjStac(MS1), new MathIA.ObjStac(MS2),
                                                                       new MathIA.ObjStac(MS3), new MathIA.ObjStac(MS4), new MathIA.ObjStac(MS5),
                                                                        new MathIA.ObjStac(MS6), new MathIA.ObjStac(MS7), new MathIA.ObjStac(MS8)},
                                                new MathIA.ObjStac[] { new MathIA.ObjStac(MNS0), new MathIA.ObjStac(MNS1), new MathIA.ObjStac(MNS2),
                                                                       new MathIA.ObjStac(MNS3), new MathIA.ObjStac(MNS4), new MathIA.ObjStac(MNS5),
                                                                        new MathIA.ObjStac(MNS6), new MathIA.ObjStac(MNS7), new MathIA.ObjStac(MNS8)},
                                                new MathIA.ObjStac[] { new MathIA.ObjStac(HS0), new MathIA.ObjStac(HS1), new MathIA.ObjStac(HS2),
                                                                       new MathIA.ObjStac(HS3), new MathIA.ObjStac(HS4), new MathIA.ObjStac(HS5),
                                                                        new MathIA.ObjStac(HS6), new MathIA.ObjStac(HS7), new MathIA.ObjStac(HS8)},
                                                new MathIA.ObjStac[] { new MathIA.ObjStac(HNS0), new MathIA.ObjStac(HNS1), new MathIA.ObjStac(HNS2),
                                                                       new MathIA.ObjStac(HNS3), new MathIA.ObjStac(HNS4), new MathIA.ObjStac(HNS5),
                                                                        new MathIA.ObjStac(HNS6), new MathIA.ObjStac(HNS7), new MathIA.ObjStac(HNS8)}};


            IniciarGrafica(chart1);
            IniciarGrafica(chart2);
            IniciarGrafica(chart3);
            IniciarGrafica(chart4);
            IniciarGrafica(chart5);
            IniciarGrafica(chart6);
            IniciarGrafica(chart7);
            IniciarGrafica(chart8);
            IniciarGrafica(chart9);

            GraficaColor("Mujeres saludables", muestras[0]);
            GraficaColor("Mujeres enfermas", muestras[1]);
            GraficaColor("Hombres saludables", muestras[2]);
            GraficaColor("Hombres enfermos", muestras[3]);

            MeanSTD(label1, label2, label3, label4, 0);
            MeanSTD(label5, label6, label7, label8, 1);
            MeanSTD(label9, label10, label11, label12, 2);
            MeanSTD(label13, label14, label15, label16, 3);
            MeanSTD(label17, label18, label19, label20, 4);
            MeanSTD(label21, label22, label23, label24, 5);
            MeanSTD(label25, label26, label27, label28, 6);
            MeanSTD(label29, label30, label31, label32, 7);
            MeanSTD(label33, label34, label35, label36, 8);
        }

        public void IniciarGrafica(Chart chart) //Formato gráficas
        {
            chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        public void MeanSTD(Label l1,Label l2,Label l3, Label l4,int index)     //Media y desviación
        {
            l1.Text = "Mujeres saludables: \tPromedio = \t" + muestras[0][index].Mean.ToString() + "\tDesvaición Estándar = \t" + muestras[0][index].Std.ToString();
            l2.Text = "Mujeres enfermas: \tPromedio = \t" + muestras[1][index].Mean.ToString() + "\tDesvaición Estándar = \t" + muestras[1][index].Std.ToString();
            l3.Text = "Hombres saludables: \tPromedio = \t" + muestras[2][index].Mean.ToString() + "\tDesvaición Estándar = \t" + muestras[2][index].Std.ToString();
            l4.Text = "Hombres enfermos: \tPromedio = \t" + muestras[3][index].Mean.ToString() + "\tDesvaición Estándar = \t" + muestras[3][index].Std.ToString();

        }
        public void GraficaColor(string color, MathIA.ObjStac[] Muestra)        //Grafica distribuciones
        {
            for (int i = 0; i < Muestra[0].x.Length; i++)
            {
                chart1.Series[color].Points.AddXY(Muestra[0].x[i], Muestra[0].y[i]);
            }
            for (int i = 0; i < Muestra[1].x.Length; i++)
            {
                chart2.Series[color].Points.AddXY(Muestra[1].x[i], Muestra[1].y[i]);
            }
            for (int i = 0; i < Muestra[2].x.Length; i++)
            {
                chart3.Series[color].Points.AddXY(Muestra[2].x[i], Muestra[2].y[i]);
            }
            for (int i = 0; i < Muestra[3].x.Length; i++)
            {
                chart4.Series[color].Points.AddXY(Muestra[3].x[i], Muestra[3].y[i]);
            }
            for (int i = 0; i < Muestra[4].x.Length; i++)
            {
                chart5.Series[color].Points.AddXY(Muestra[4].x[i], Muestra[4].y[i]);
            }
            for (int i = 0; i < Muestra[5].x.Length; i++)
            {
                chart6.Series[color].Points.AddXY(Muestra[5].x[i], Muestra[5].y[i]);
            }
            for (int i = 0; i < Muestra[6].x.Length; i++)
            {
                chart7.Series[color].Points.AddXY(Muestra[6].x[i], Muestra[6].y[i]);
            }
            for (int i = 0; i < Muestra[7].x.Length; i++)
            {
                chart8.Series[color].Points.AddXY(Muestra[7].x[i], Muestra[7].y[i]);
            }
            for (int i = 0; i < Muestra[8].x.Length; i++)
            {
                chart9.Series[color].Points.AddXY(Muestra[8].x[i], Muestra[8].y[i]);
            }
        }

        private void button6_Click(object sender, EventArgs e)      //Calcular likely de cada caracterisitca
        {
            maxMg = Convert.ToDouble(textBox8.Text);
            chart9.Series["Maximo"].Points.Clear();
            chart9.Series["Maximo"].Points.AddXY(maxMg, 0);
            chart9.Series["Maximo"].Points.AddXY(maxMg, MathIA.Statistics.Likelyhood(maxMg, muestras[3][8]));
            minMg = Convert.ToDouble(textBox7.Text);
            chart9.Series["Minimo"].Points.Clear();
            chart9.Series["Minimo"].Points.AddXY(minMg, 0);
            chart9.Series["Minimo"].Points.AddXY(minMg, MathIA.Statistics.Likelyhood(minMg, muestras[3][8]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maxTemp = Convert.ToDouble(textBox1.Text);
            chart4.Series["Dato"].Points.Clear();
            chart4.Series["Dato"].Points.AddXY(maxTemp, 0);
            chart4.Series["Dato"].Points.AddXY(maxTemp,MathIA.Statistics.Likelyhood(maxTemp,muestras[2][3]));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            maxCal = Convert.ToDouble(textBox6.Text);
            chart8.Series["Maximo"].Points.Clear();
            chart8.Series["Maximo"].Points.AddXY(maxCal, 0);
            chart8.Series["Maximo"].Points.AddXY(maxCal, MathIA.Statistics.Likelyhood(maxCal, muestras[3][7]));
            minCal = Convert.ToDouble(textBox5.Text);
            chart8.Series["Minimo"].Points.Clear();
            chart8.Series["Minimo"].Points.AddXY(minCal, 0);
            chart8.Series["Minimo"].Points.AddXY(minCal, MathIA.Statistics.Likelyhood(minCal, muestras[3][7]));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            maxTen = Convert.ToDouble(textBox9.Text);
            chart7.Series["Maximo"].Points.Clear();
            chart7.Series["Maximo"].Points.AddXY(maxTen, 0);
            chart7.Series["Maximo"].Points.AddXY(maxTen, MathIA.Statistics.Likelyhood(maxTen, muestras[3][6]));
            minTen = Convert.ToDouble(textBox4.Text);
            chart7.Series["Minimo"].Points.Clear();
            chart7.Series["Minimo"].Points.AddXY(minTen, 0);
            chart7.Series["Minimo"].Points.AddXY(minTen, MathIA.Statistics.Likelyhood(minTen, muestras[1][6]));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            maxTri = Convert.ToDouble(textBox3.Text);
            chart6.Series["Dato"].Points.Clear();
            chart6.Series["Dato"].Points.AddXY(maxTri, 0);
            chart6.Series["Dato"].Points.AddXY(maxTri, MathIA.Statistics.Likelyhood(maxTri, muestras[1][5]));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maxCol = Convert.ToDouble(textBox2.Text);
            chart5.Series["Dato"].Points.Clear();
            chart5.Series["Dato"].Points.AddXY(maxCol, 0);
            chart5.Series["Dato"].Points.AddXY(maxCol, MathIA.Statistics.Likelyhood(maxCol, muestras[0][4]));
        }
    }
}

