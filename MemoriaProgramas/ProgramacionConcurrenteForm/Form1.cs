using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProgramacionConcurrenteForm
{
    public partial class Form1 : Form
    {
        long cantidad = 100000000;
        Thread hilo1;
        Thread hilo2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            hilo1 = new Thread(calculo_pi);
            button1.Enabled=false;
            hilo1.Start();

        }
        public void calculo_pi()
        {
            double pi = 0;
            for (long i = 0; i < cantidad; i++)
            {
                pi = Math.Pow(-1, i) * 4 / (2 * i + 1) + pi;          //Método numérico para obtener pi   
            }
            if (InvokeRequired)
            {
                Invoke(new Action(() => label2.Text = "Pi = " + pi));       //Mandar a otro subproceso que lo creó
                Invoke(new Action(() => button1.Text = "Listo"));
            }
            
        }
        public void calculo_e()
        {

            double e = 0;
            for (long i = 1; i < cantidad; i++)
            {
                e = Math.Pow((1.0 + 1.0/i), i);          //Interés compuesto para estimar e 
            }

            if (InvokeRequired)
            {
                Invoke(new Action(() => label3.Text = "e = " + e));       //Mandar a otro subproceso que lo creó
                Invoke(new Action(() => button2.Text = "Listo"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hilo2 = new Thread(calculo_e);
            button2.Enabled = false;
            hilo2.Start();
        }
    }
}
