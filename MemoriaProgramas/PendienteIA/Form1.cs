using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PendienteIA               //Determina la pendiente que mejor se acopla a una serie de puntos
{
    public partial class Form1 : Form
    {
        double[] y = new double[9] {1,2,3,4,5,6,7,8,9 };
        double[] x = new double[9] {1,2,3,4,5,6,7,8,9 };
        double[] Reg = new double[2];
        double m;
        double b =0;
        double max = 500;
        double min = -500;
        double temp = 0;
        double[] ECM=new double[2];
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 2;
            Reg = MathIA.Statistics.Regression(x, y);
            double mt = Reg[0];
            double bt = Reg[1];

            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series["Datos"].Points.AddXY(x[i], y[i]);                 //Añadir datos a la gráfica  
                //chart1.Series["Regresion"].Points.AddXY(x[i], x[i] * mt+bt);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            calcular_Pendiente();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Start();
        }
        private void calcular_Pendiente()
        {
            m = rand.NextDouble() * (max - min) + min;              //Valor aleatorio para la pendiente
            double[] y_real = new double[y.Length];
            for (int i = 0; i < x.Length; i++)
            {
                y_real[i] = m * x[i] + b;                             //Los valores reales calculados
            }

            ECM = MathIA.Statistics.ECM(y, y_real);        //Obtención del ECM
            if (ECM[1] > 0)                                         //ECM[1] es el signo de la resta entre y-y_real, para saber si la pendiente debe ser mayor o menor
            {
                min = m;                                            //Se cambia el valor inferior del random

            }
            else if (ECM[1] < 0)
            {
                max = m;                                            //Se cambia el valor máximo del random
            }
            label1.Text = "El error cuadrático medio es de " + ECM[0] + "\nLa pendiente es de " + m + " con una ordenada al origen en " + b;

            if (temp == m)
            {
                label1.Text = "El error cuadrático medio es de " + ECM[0] + "\nLa pendiente es de " + m + " con una ordenada al origen en " + b + "\nListo";
                timer1.Stop();
            }
            temp = m;
            chart2.Series["Error"].Points.AddXY(m, ECM[0]);
            chart1.Series["Estimado"].Points.Clear();
            for (int k = 0; k < x.Length; k++)
            {
                chart1.Series["Estimado"].Points.AddXY(x[k], y_real[k]);
            }
        }
    }
}
