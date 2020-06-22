using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoPi         //En este programa se calcula el valor de pi y se observa el comportamiento del error
{
    public partial class Form1 : Form
    {
        int contador = 0;
        double aux = 0;
        double error = 0;
        bool estado = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (estado)
            {
                timer1.Start();
                button1.Text = "Stop";

                estado = false;
            }
            else
            {
                timer1.Stop();
                button1.Text = "Start";
                estado = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            aux = Math.Pow(-1, contador) * 4 / (2 * contador + 1) + aux;            //Fórmula para determinar pi
            error = 100000 * ((Math.PI - aux) / Math.PI);                           //Se escala el error para apreciarlo
            label2.Text = "Pi = " + aux.ToString();
            label3.Text = "Error = " + error.ToString();
            chart1.Series["Series1"].Points.AddXY(contador, error);
            contador++;

            label1.Text = "Iteraciones: "+ contador.ToString();
        }
    }
}
