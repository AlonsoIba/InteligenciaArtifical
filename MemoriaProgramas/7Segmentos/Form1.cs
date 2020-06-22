using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7Segmentos
{
    public partial class Form1 : Form
    {
        int[,] P = new int[10, 7] { { 1, 1, 1, 1, 1, 1, 0 }, 
                                    { 0, 1, 1, 0, 0, 0, 0 }, 
                                    { 1, 1, 0, 1, 1, 0, 1 },
                                    { 1, 1, 1, 1, 0, 0, 1 }, 
                                    { 0, 1, 1, 0, 0, 1, 1 }, 
                                    { 1, 0, 1, 1, 0, 1, 1 },
                                    { 1, 0, 1, 1, 1, 1, 1 }, 
                                    { 1, 1, 1, 0, 0, 0, 0 }, 
                                    { 1, 1, 1, 1, 1, 1, 1 }, 
                                    { 1, 1, 1, 1, 0, 1, 1 }};
        int[] ta = new int[10] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
        int[] tb = new int[10] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 };
        int[] tc = new int[10] { 0, 0, 1, 1, 0, 1, 0, 1, 0, 0 };
        double[] W,E;
        double b;
        int[] t;
        Random aleatorio;
public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = ta;
            aleatorio = new Random();
            for(int i=0;i<W.Length;i++)
            {
                W[i] = 2 * aleatorio.NextDouble() - 1;
            }
            b = 2 * aleatorio.NextDouble() - 1;
        }
    }
}
