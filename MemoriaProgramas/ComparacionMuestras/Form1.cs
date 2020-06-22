using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparacionMuestras               //Comparación entre 3 muestras para determinar a cual pertenece un dato
{
    public partial class Form1 : Form
    {
        MathIA.ObjStac muestra1;
        MathIA.ObjStac muestra2;
        MathIA.ObjStac muestra3;
        public Form1()
        {           
            InitializeComponent();

            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;           //Formato a las gráficas
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        private void Button1_Click(object sender, EventArgs e)              //Por cada click se evalua el dato
        {
            chart2.Series["Dato"].Points.Clear();
            double valor = Convert.ToDouble(textBox1.Text);                 //El dato se toma del text box
            double like1 = MathIA.Statistics.Likelyhood(valor, muestra1);   //Se calcula el likelyhood para cada muestra
            double like2 = MathIA.Statistics.Likelyhood(valor, muestra2);
            double like3 = MathIA.Statistics.Likelyhood(valor, muestra3);
            double prob = 0;
            if (like1 > like2 && like1 > like3)                            //Se determina a que muestra pertenece,
            {                                                              //viendo que likely es mayor
                label4.Text = "Tu dato pertenece a la muestra 1";
                prob = MathIA.Statistics.Normpdf(valor, muestra1.Mean, muestra1.Std);
            }
            else if(like2>like3)
                {
                    label4.Text = "Tu dato pertenece a la muestra 2";

                prob = MathIA.Statistics.Normpdf(valor, muestra2.Mean, muestra2.Std);
            }
            else
            {
                label4.Text = "Tu dato pertenece a la muestra 3";

                prob = MathIA.Statistics.Normpdf(valor, muestra3.Mean, muestra3.Std);
            }

            chart2.Series["Dato"].Points.AddXY(valor, prob);
        }

        private void Button2_Click(object sender, EventArgs e)                  //Se generan 3 distribuciones diferentes
        {
            chart1.Series["Muestra 1"].Points.Clear();
            chart1.Series["Muestra 2"].Points.Clear();
            chart1.Series["Muestra 3"].Points.Clear();
            chart2.Series["Distribución 1"].Points.Clear();
            chart2.Series["Distribución 2"].Points.Clear();
            chart2.Series["Distribución 3"].Points.Clear();
            chart2.Series["Dato"].Points.Clear();
            double ini1 = Convert.ToDouble(textBox2.Text);                       //El valor medio de cada muestra
            double ini2 = Convert.ToDouble(textBox3.Text);
            double ini3 = Convert.ToDouble(textBox4.Text);
            double[] datos1 = new double[50];
            double[] datos2 = new double[50];
            double[] datos3 = new double[50];
            Random rand = new Random();
            for (int i = 0; i < datos1.Length; i++)
            {
                datos1[i] = rand.NextDouble() * 5+  ini1;                         //La muestra 1 tiene una dispersión de +-2.5
                datos2[i] = rand.NextDouble() * 3+  ini2;                         //La muestra 2 tiene una dispersión de +-1.5
                datos3[i] = rand.NextDouble() * 4 + ini3;                         //La muestra 3 tiene una dispersión de +-2
            }
            muestra1 = new MathIA.ObjStac(datos1);                                //Se genera la clase estadistica para cada muestra
            muestra2 = new MathIA.ObjStac(datos2);
            muestra3 = new MathIA.ObjStac(datos3);
            double max;
            if (muestra1.Max > muestra2.Max && muestra1.Max > muestra3.Max)      //Se determina el mayor valor para el chart
            {
                max = muestra1.Max;
            }
            else if(muestra2.Max>muestra3.Max)
                {
                    max = muestra2.Max;
                }
                else
                {
                    max = muestra3.Max;
                }
            double min; 
            if (muestra1.Min < muestra2.Min && muestra1.Min < muestra3.Min)         //Se determina el valor menor para el chart
            {
                min = muestra1.Min;
            }
            else if (muestra2.Min < muestra3.Min)
            {
                min = muestra2.Min;
            }
            else
            {
                min = muestra3.Min;
            }


            chart1.ChartAreas[0].AxisX.Maximum = datos1.Length;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = max;
            chart1.ChartAreas[0].AxisY.Minimum = min;

            for (int i = 0; i < datos1.Length; i++)
            {
                chart1.Series["Muestra 1"].Points.AddXY(i, muestra1.Valores[i]);                 //Añadir datos a la gráfica
                chart1.Series["Muestra 2"].Points.AddXY(i, muestra2.Valores[i]);
                chart1.Series["Muestra 3"].Points.AddXY(i, muestra3.Valores[i]);
            }

            chart2.ChartAreas[0].AxisX.Maximum = max;
            chart2.ChartAreas[0].AxisX.Minimum = min;
            chart2.ChartAreas[0].AxisY.Maximum = 0.55;
            chart2.ChartAreas[0].AxisY.Minimum = 0;

            for (int i = 0; i < muestra1.x.Length; i++)                                             //Graficar las distribuciones
            {
                chart2.Series["Distribución 1"].Points.AddXY(muestra1.x[i], muestra1.y[i]);
            }
            for (int i = 0; i < muestra2.x.Length; i++)
            {
                chart2.Series["Distribución 2"].Points.AddXY(muestra2.x[i], muestra2.y[i]);
            }
            for (int i = 0; i < muestra3.x.Length; i++)
            {
                chart2.Series["Distribución 3"].Points.AddXY(muestra3.x[i], muestra3.y[i]);
            }
        }
    }
}
