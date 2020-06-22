using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovOscilatorioForm                            //Movimiento oscilatorio por gradiente descendiente
{                                                       //Consiste en ir variando las variables en la función
    public partial class Form1 : Form
    {
        double[] x, y, y_estimada, error_w, error_z;
        double w, max_w, min_w, paso_w, z, max_z, min_z, paso_z, z_central, tolerancia;
        bool calcular_z;
        double[] estimacion;
        Random aleatorio = new Random();
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.Maximum=1.5;

            x = new double[6] { 0, 1, 2, 3, 4, 5 };
            y = new double[6] { 0.1309325039, 1.152254017, 1.126559309, 0.8546077958, 1.080655028, 0.9767980784 };
            w = 0;
            max_w = 10;
            min_w = 0;
            paso_w = 0.1;
            z = 0;
            paso_z = 0.001;
            tolerancia = 0.00000001;
            y_estimada = new double[6];
            error_z = new double[3];
            error_w = new double[3];
            estimacion = new double[6];


            calcular_z = true;

            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series["Datos"].Points.AddXY(x[i], y[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1.Series["Estimación"].Points.Clear();
            w = aleatorio.NextDouble() * (max_w - min_w) + min_w;
            calcular_z = true;
            max_z = 1;
            min_z = 0;
            while (calcular_z)
            {
                z = aleatorio.NextDouble() * (max_z - min_z) + min_z;

                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow(z, 2)))) * Math.Exp(-z * (w + paso_w) * x[k]) * Math.Sin((w + paso_w) * (Math.Sqrt(1 - Math.Pow(z, 2))) * x[k] + 1);
                }
                error_z[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z + paso_z), 2)))) * Math.Exp(-((z + paso_z)) * (w + paso_w) * x[k]) * Math.Sin((w + paso_w) * (Math.Sqrt(1 - Math.Pow((z + paso_z), 2))) * x[k] + 1);
                }
                error_z[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z - paso_z), 2)))) * Math.Exp(-((z - paso_z)) * (w + paso_w) * x[k]) * Math.Sin((w + paso_w) * (Math.Sqrt(1 - Math.Pow((z - paso_z), 2))) * x[k] + 1);
                }
                error_z[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                if ((error_z[2] >= (1 - tolerancia) * error_z[0]) && (error_z[2] <= (1 + tolerancia) * error_z[0]))
                {
                    calcular_z = false;
                    error_w[2] = error_z[1];
                }
                else
                {
                    if (error_z[2] < error_z[0])
                    {
                        min_z = z;
                    }
                    else
                    {
                        max_z = z;
                    }
                }
            }

            calcular_z = true;
            max_z = 1;
            min_z = 0;
            while (calcular_z)
            {
                z = aleatorio.NextDouble() * (max_z - min_z) + min_z;
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow(z, 2)))) * Math.Exp(-z * (w - paso_w) * x[k]) * Math.Sin((w - paso_w) * (Math.Sqrt(1 - Math.Pow(z, 2))) * x[k] + 1);
                }
                error_z[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z + paso_z), 2)))) * Math.Exp(-((z + paso_z)) * (w - paso_w) * x[k]) * Math.Sin((w - paso_w) * (Math.Sqrt(1 - Math.Pow((z + paso_z), 2))) * x[k] + 1);
                }
                error_z[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z - paso_z), 2)))) * Math.Exp(-((z - paso_z)) * (w - paso_w) * x[k]) * Math.Sin((w - paso_w) * (Math.Sqrt(1 - Math.Pow((z - paso_z), 2))) * x[k] + 1);
                }
                error_z[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                if ((error_z[2] >= (1 - tolerancia) * error_z[0]) && (error_z[2] <= (1 + tolerancia) * error_z[0]))
                {
                    calcular_z = false;
                    error_w[0] = error_z[1];
                }
                else
                {
                    if (error_z[2] < error_z[0])
                    {
                        min_z = z;
                    }
                    else
                    {
                        max_z = z;
                    }
                }
            }
            calcular_z = true;
            max_z = 1;
            min_z = 0;
            while (calcular_z)
            {
                z = aleatorio.NextDouble() * (max_z - min_z) + min_z;
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow(z, 2)))) * (Math.Exp(-z * (w) * x[k]) * Math.Sin((w) * (Math.Sqrt(1 - Math.Pow(z, 2))) * x[k] + 1));
                }
                error_z[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z + paso_z), 2)))) * Math.Exp(-(z + paso_z) * (w) * x[k]) * Math.Sin((w) * (Math.Sqrt(1 - Math.Pow((z + paso_z), 2))) * x[k] + 1);
                }
                error_z[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = 1 - (1 / (Math.Sqrt(1 - Math.Pow((z - paso_z), 2)))) * Math.Exp(-((z - paso_z)) * (w) * x[k]) * Math.Sin((w) * (Math.Sqrt(1 - Math.Pow((z - paso_z), 2))) * x[k] + 1);
                }
                error_z[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                if ((error_z[2] >= (1 - tolerancia) * error_z[0]) && (error_z[2] <= (1 + tolerancia) * error_z[0]))
                {
                    calcular_z = false;
                    error_w[1] = error_z[1];
                }
                else
                {
                    if (error_z[2] < error_z[0])
                    {
                        min_z = z;
                    }
                    else
                    {
                        max_z = z;
                    }
                }
            }
            z_central = z;
            label1.Text = "La frecuencia natural es " + w + "\nEl factor de amortiguamiento es " + z+ "\nEl error es " + error_w[1];
            for (int i = 0; i < estimacion.Length; i++)
            {
                estimacion[i] = 1 - (1 / (Math.Sqrt(1 - Math.Pow(z_central, 2)))) * (Math.Exp(-z_central * (w) * x[i]) * Math.Sin((w) * (Math.Sqrt(1 - Math.Pow(z_central, 2))) * x[i] + 1));
            }
            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series["Estimación"].Points.AddXY(x[i], estimacion[i]);
            }
            if ((error_w[2] >= (1 - tolerancia) * error_w[0]) && (error_w[2] <= (1 + tolerancia) * error_w[0]))
            {
                if (error_w[1] > 10000 * tolerancia)
                {
                    max_w = 10;
                    min_w = 0;
                }
                else
                {
                    timer1.Stop();

                    label1.Text = "La frecuencia natural es " + w + "\nEl factor de amortiguamiento es " + z + "\nListo";
                }
            }
            else
            {
                if (error_w[2] < error_w[0])
                {
                    min_w = w;
                }
                else
                {
                    max_w = w;
                }
            }
        }
    }
}
