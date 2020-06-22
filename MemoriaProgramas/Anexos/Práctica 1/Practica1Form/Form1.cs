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

namespace Practica1Form
{
    public partial class Form1 : Form
    {
        double contador;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contador = 0;
            Thread hilo = new Thread(Ciclos);
            hilo.Start();
            button1.Enabled = false;
            //button1.Text = "1";
        }

        public void Ciclos()
        {
            for (int i = 0; i < 10000000; i++)
            {
                for (int j = 0; j < 10000000; j++)
                {
                    for (int k = 0; k < 10000000; k++)
                    {
                        contador++;
                        if(InvokeRequired)
                        {
                            Invoke(new Action(() =>button1.Text = contador.ToString()));
                        }
                    }
                }
            }
        }
    }
}
