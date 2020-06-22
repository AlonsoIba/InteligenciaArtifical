using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PendienteOrdenadaIA               //Estimaición de pendiente y ordenada a una serie de puntos
{                                           //por descenso de gradiente, para b y m
    public partial class Form1 : Form
    {
        double[] x,y,y_estimada,error_b,error_m;
        double m,max_m,min_m,paso_m,b,max_b,min_b,paso_b,b_central,tolerancia;
        bool calcular_b;
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

            y = new double[5] { -4,-1,0,1,4 };
            x = new double[5] { -2,-1,0,1,2 };
            m = 0;
            max_m = 100;
            min_m = -100;
            paso_m = 1;
            b_central=0;
            b = 0;
            max_b=500;
            min_b=-500;
            paso_b = 1;
            y_estimada = new double[5];
            error_b = new double[3];
            error_m = new double[3];
            
            calcular_b = true;

            estimacion = new double[5];

            tolerancia = 0.000000000000001; 

            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series["Puntos"].Points.AddXY(x[i], y[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1.Series["Recta"].Points.Clear();
            m = aleatorio.NextDouble() * (max_m - min_m) + min_m;
            calcular_b = true;
            max_b = 500;
            min_b = -500;
            while (calcular_b)
            {
                b = aleatorio.NextDouble() * (max_b - min_b) + min_b;
                for (int k = 0; k < y_estimada.Length; k++)
                {    
                    y_estimada[k] = (m + paso_m) * x[k] + b;
                } 
                error_b[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));   
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = (m + paso_m) * x[k] + b + paso_b;   
                }
                error_b[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = (m + paso_m) * x[k] + b - paso_b;   
                }
                error_b[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                if ((error_b[2] >= (1 - tolerancia) * error_b[0]) && (error_b[2] <= (1 + tolerancia) * error_b[0]))
                {
                    calcular_b = false;   
                    error_m[2] = error_b[1];
                }
                else
                {
                    if (error_b[2] < error_b[0])   
                    {
                        min_b = b;   
                    }
                    else
                    {
                        max_b = b;   
                    }
                }
            }
            calcular_b = true;
            max_b = 500;
            min_b = -500;
            while (calcular_b)
            {
                b = aleatorio.NextDouble() * (max_b - min_b) + min_b;   
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = (m - paso_m) * x[k] + b;                    
                }               
                error_b[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));                
                for (int k = 0; k < y_estimada.Length; k++)                
                {                
                    y_estimada[k] = (m - paso_m) * x[k] + b + paso_b;                   
                }                
                error_b[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));               
                for (int k = 0; k < y_estimada.Length; k++)                
                {                
                    y_estimada[k] = (m - paso_m) * x[k] + b - paso_b;                   
                }                
                error_b[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                if ((error_b[2] >= (1 - tolerancia) * error_b[0]) && (error_b[2] <= (1 + tolerancia) * error_b[0]))
                {
                    calcular_b = false;   
                    error_m[0] = error_b[1];
                }
                else
                {
                    if (error_b[2] < error_b[0])   
                    {
                        min_b = b;   
                    }
                    else
                    {
                        max_b = b;   
                    }
                }
            }
            calcular_b = true;
            max_b = 500;
            min_b = -500;
            while (calcular_b)
            {
                b = aleatorio.NextDouble() * (max_b - min_b) + min_b;   
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = m * x[k] + b;   
                }
                error_b[1] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = m * x[k] + b + paso_b;   
                }
                error_b[2] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                for (int k = 0; k < y_estimada.Length; k++)
                {
                    y_estimada[k] = m * x[k] + b - paso_b;   
                }
                error_b[0] = MathIA.Arithmetic.Sum(MathIA.Arithmetic.Power(MathIA.Arithmetic.Sum(y, MathIA.Arithmetic.Prod(-1, y_estimada)), 2));
                if ((error_b[2] >= (1 - tolerancia) * error_b[0]) && (error_b[2] <= (1 + tolerancia) * error_b[0]))
                {
                    calcular_b = false;
                    error_m[1] = error_b[1];
                }
                else
                {
                    if (error_b[2] < error_b[0])
                    {
                        min_b = b;
                    }
                    else
                    {
                        max_b = b;
                    }
                }
            }
            b_central = b;
            label1.Text="La pendiente es " + m + ". La ordenada al origen es " + b_central + "\nEl error es " + error_m[1];
            for(int i=0;i<estimacion.Length;i++)
            {
                estimacion[i] = x[i] * m + b_central;
            }
            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series["Recta"].Points.AddXY(x[i], estimacion[i]);
            }
            if ((error_m[2] >= (1 - tolerancia) * error_m[0]) && (error_m[2] <= (1 + tolerancia) * error_m[0]))
            {
                label1.Text="La ecuación es: y = " + m + "x + " + b_central+"\nLa tolerancia es de "+tolerancia;   
                timer1.Stop();
            }
            else
            {
                if (error_m[2] < error_m[0])   
                {
                    min_m = m;
                }
                else
                { 
                    max_m = m;
                }   
            }
        }
    }
}