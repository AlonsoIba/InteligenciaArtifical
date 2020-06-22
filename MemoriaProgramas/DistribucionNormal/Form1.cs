using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionNormal                                            //Genera una distribución normal de un valor
{                                                                       //de inicio a uno final, dando una mu y sigma
    public partial class Form1 : Form
    {
        double[] arr; //Una variable global nunca debe ser inicialziada
        double[] dist;

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
            chart1.Series["Distribución normal"].Points.Clear();
            double inicio = Convert.ToDouble(textBox1.Text) ;
            double fin = Convert.ToDouble(textBox2.Text);
            arr = MathIA.MatArr.Linspace(inicio, fin, 0.01);
            double mu = Convert.ToDouble(textBox4.Text);
            double sigma = Convert.ToDouble(textBox3.Text);
            dist = MathIA.Statistics.Normpdf(arr,mu,sigma);

            for (int i = 0; i < arr.Length; i++)
            {
                chart1.Series["Distribución normal"].Points.AddXY(arr[i], dist[i]);                 //Añadir datos a la gráfica
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
