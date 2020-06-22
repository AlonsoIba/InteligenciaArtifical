using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntrenamientoPerceptron                   //Programa para entender el funcionmamiento de un perceptron
{
    public partial class Form1 : Form
    {
        double F, S, d1, d2, w1, w2, b,n,x1,x2,y,D,Y;

        double[] X1, X2, Ya,Error;
        int j=0;

        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            textBox1.Text = "1";
            textBox4.Text = "1";
            textBox6.Text = "0";
            textBox8.Text = "0";
            textBox2.Text = "1";
            textBox3.Text = "0";
            textBox5.Text = "1";
            textBox7.Text = "0";
            label25.Text = "Indica todos los patrones y\nvalores iniciales";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)           //Dibujo de la neurona
        {
            Graphics dibujo = e.Graphics;
            dibujo.DrawArc(Pens.Black, new Rectangle(300, 80, 50, 50), 0, 360);
            dibujo.DrawArc(Pens.Black, new Rectangle(300, 155, 50, 50), 0, 360);
            dibujo.DrawRectangle(Pens.Black, new Rectangle(420,130,50,25));
            dibujo.DrawLine(Pens.Black, 350, 105, 420, 142);
            dibujo.DrawLine(Pens.Black, 350, 170, 420, 142);
            dibujo.DrawLine(Pens.Black, 445, 200, 445, 155);
            dibujo.DrawLine(Pens.Black, 430, 175, 445, 155);
            dibujo.DrawLine(Pens.Black, 460, 175, 445, 155);
            dibujo.DrawLine(Pens.Black, 470,142,520,142);
            dibujo.DrawLine(Pens.Black, 500,130, 520, 142);
            dibujo.DrawLine(Pens.Black, 500, 154, 520, 142);
        }

        private void button1_Click(object sender, EventArgs e)      //Probar x1, x2, y
        {
            label4.Text = textBox1.Text;
            label5.Text = textBox2.Text;
            label10.Text = textBox12.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = textBox4.Text;
            label5.Text = textBox3.Text;
            label10.Text = textBox11.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = textBox6.Text;
            label5.Text = textBox5.Text;
            label10.Text = textBox10.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = textBox8.Text;
            label5.Text = textBox7.Text;
            label10.Text = textBox9.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label6.Text = textBox16.Text;
            label7.Text = textBox15.Text;
            label9.Text = textBox14.Text;
            label12.Text = textBox13.Text;
        }

        private void button6_Click(object sender, EventArgs e)      //Inicio del calculo
        {
            timer1.Start();
            label25.Text = "Calculando";
        }
        private void timer1_Tick(object sender, EventArgs e)        //Proceso de entrenamiento
        {

            chart1.Series["Recta"].Points.Clear();
            label4.Text = X1[j].ToString();                         //Renglon por renglon
            label5.Text = X2[j].ToString();
            label10.Text = Ya[j].ToString();

            x1 = Convert.ToDouble(label4.Text);                     //Entradas
            x2 = Convert.ToDouble(label5.Text);
            D = Convert.ToDouble(label10.Text);             
            w1 = Convert.ToDouble(label6.Text);                     //Pesos
            w2 = Convert.ToDouble(label7.Text);     
            b = Convert.ToDouble(label9.Text);                      //b
            n = Convert.ToDouble(label12.Text);                 

            F = w1 * x1 + w2 * x2 - b;                              //Función

            if (F < 0)                                              //Función de activación
            {
                Y = 0;
            }
            else
            {
                Y = 1;
            }

            S = D - Y;                                          //Algoritmo de reducción de error
            d1 = n * S * x1;
            d2 = n * S * x2;
            w1 = w1 + d1;
            w2 = w2 + d2;
            b = b - n * S;


            label8.Text = F.ToString();
            label11.Text = Y.ToString();
            label14.Text = "S = " + S.ToString();
            label15.Text = "d1 = " + d1.ToString();
            label16.Text = "d2 = " + d2.ToString();
            label17.Text = "w1 = " + w1.ToString();
            label19.Text = "w2 = " + w2.ToString();
            label18.Text = "b = " + b.ToString();

            for (int i = -1; i < 3; i++)
            {
                chart1.Series["Recta"].Points.AddXY(i, i * (-w1 / w2) + (b / w2));      //Grafica del avance
            }
            if (MathIA.Arithmetic.Sum(Error) == 0)                          //Error 0
            {
               timer1.Stop();
                label25.Text = "Listo";
            }
            Error[j] = S;
           
            if (S != 0)
            {
                label6.Text = w1.ToString();
                label7.Text = w2.ToString();
                label9.Text = b.ToString();

                chart1.Series["Recta"].Points.Clear();
                for (int i = -1; i < 3; i++)
                {
                    chart1.Series["Recta"].Points.AddXY(i, i * (-w1 / w2) + (b / w2));
                }
                
            }
            else
            {
                if (j < 3)                      //Vuelve a empezar
                {
                    Error[j] = S;
                    
                    j++;
                }
                else 
                {
                    j = 0;
                }
            }
            
        }


        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            chart1.Series["Entradas0"].Points.Clear();
            chart1.Series["Entradas1"].Points.Clear();
            X1 = new double[4] { Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox8.Text) };
            X2 = new double[4] { Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox7.Text) };
            Ya = new double[4] { Convert.ToDouble(textBox12.Text), Convert.ToDouble(textBox11.Text), Convert.ToDouble(textBox10.Text), Convert.ToDouble(textBox9.Text) };
            Error = new double[4] { 1, 1, 1, 1 };
            for (int i = 0; i < 4; i++)
            {
                if (Ya[i] == 0)
                {
                    chart1.Series["Entradas0"].Points.AddXY(X1[i], X2[i]);
                }
                else
                {
                    chart1.Series["Entradas1"].Points.AddXY(X1[i], X2[i]);
                }
            }
        }
    }
}
