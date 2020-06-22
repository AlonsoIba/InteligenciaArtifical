using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integral                              //Integral numerica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Distribución"].Points.Clear();
            chart1.Series["a"].Points.Clear();
            chart1.Series["b"].Points.Clear();
            double inicio = Convert.ToDouble(textBox1.Text);        //Determinar inicio y fin de distribución
            double fin = Convert.ToDouble(textBox2.Text);
            double [] arr = MathIA.MatArr.Linspace(inicio, fin, 0.01);      //Vector espaciado 0.01 de inicio a fin
            double mu = Convert.ToDouble(textBox4.Text);                    //Media
            double sigma = Convert.ToDouble(textBox3.Text);                 //Desviación
            double [] dist = MathIA.Statistics.Normpdf(arr, mu, sigma);     //Distribución normal

            double a = Convert.ToDouble(textBox6.Text);
            double b = Convert.ToDouble(textBox5.Text);
            double[] x = MathIA.MatArr.Linspace(a, b, 0.01);
            double[] y = MathIA.Statistics.Normpdf(x, mu, sigma);
            double output = MathIA.Integral.Simpson(a, b, y);       //Integral por método de Simpson
            double[] integral = new double[y.Length];
            label5.Text = "La probabilidad de " +a+" a "+b+" es "+ output;

            chart1.Series["a"].Points.AddXY(a, 0);
            chart1.Series["a"].Points.AddXY(a, y[0]);
            chart1.Series["b"].Points.AddXY(b, 0);
            chart1.Series["b"].Points.AddXY(b, y[y.Length-1]);


            for (int i = 0; i < arr.Length; i++)
            {
                chart1.Series["Distribución"].Points.AddXY(arr[i], dist[i]);                 //Añadir datos a la gráfica  
            }
        }
    }
}
