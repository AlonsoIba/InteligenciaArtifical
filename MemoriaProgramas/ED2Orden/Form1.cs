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
using MathIA;

namespace ED2Orden                                      //Determina la ecuación de un sistema subamortiguado segundo orden
{
    public partial class Form1 : Form
    {

        double[][] t, y, ypto, y2pto,u,estimacion,psi,theta,ECM;
        double A, B, C, D, E,wn,z,k,e;
        public Form1()
        {
            InitializeComponent();

            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Datos"].Points.Clear();
            chart1.Series["Estimacion"].Points.Clear();
            label1.Text = "";
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
                t = Matriz.Crear(1, lineas.Count);              //Vector t
                y = Matriz.Crear(1, lineas.Count);              //Vector y
                for (int i = 0; i < lineas.Count; i++)
                {
                    t[0][i] = Convert.ToDouble(lineas[i][0]);
                    y[0][i] = Convert.ToDouble(lineas[i][1]);
                    chart1.Series["Datos"].Points.AddXY(t[0][i], y[0][i]);          //Grafica de puntos
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ypto = Matriz.Derivada1(t, y);              //Derivadas de y
            y2pto = Matriz.Derivada2(t, y);
            u = Matriz.Escalon(t);                      //Entrada al sistema

            for (int i = 0; i < y[0].Length - 1; i++)
            {
                y[0][i] = y[0][i + 1];                  //Se elimina un valor al vector y. ya que las derivadas
            }                                           //tienen un elemento menos
            
            psi = Matriz.Crear(3, y[0].Length);         //Se genera una matriz de regresión
            for (int i = 0; i < y[0].Length - 2; i++)
            {
                psi[0][i] = y2pto[0][i];
                psi[1][i] = ypto[0][i];
                psi[2][i] = u[0][i];
            }
            theta = Matriz.EstimacionParametrica(y, psi);   //Estimación paramétrica por minimos cuadrados
            wn = Math.Sqrt(-theta[0][0]);                   //Frecuencia natural del sistema
            z = -theta[1][0] * wn / 2;                      //Factor de amortiguamiento
            k = theta[2][0];                                //Ganancia

            A = k;                                          //Coeficientes de la ecuación diferencial
            B = k / Math.Sqrt(1 - z*z);
            C = z * wn;
            D = wn * Math.Sqrt(1 - z * z);
            E = Math.Atan((Math.Sqrt(1 - z * z)) / z);
            
            
            estimacion = Matriz.Crear(1, t[0].Length);
            for (int i = 0; i < t[0].Length; i++)
            {
                estimacion[0][i] = A - B * Math.Exp(-C * t[0][i]) * Math.Sin(D * t[0][i] + E);      //Se evlúa la función obtenida
                chart1.Series["Estimacion"].Points.AddXY(t[0][i], estimacion[0][i]);
            }

            ECM = Matriz.ECM(estimacion, y);                                        //ECM entre el valor estimado y el valor real

            label1.Text = "A = " + Math.Round(A, 5).ToString() + "\t          B = " + Math.Round(B, 5).ToString() + "\t          C = " +
                Math.Round(C, 5).ToString() + "\t          D = " + Math.Round(D, 5).ToString() + "\t          E = " + Math.Round(E, 5).ToString()+
                "\nError Cuadrático Medio= "+ECM[0][0]/y[0].Length;
        }
    }
}
