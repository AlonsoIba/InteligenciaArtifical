using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.ML.Train;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Persist;
using Encog.Util.Simple;
using System.IO;
using System.IO.Ports;
using Distancia;

namespace ClasificadorLunetas
{
    public partial class Form1 : Form
    {
        double[] Entrada;
        double R,G,B,max;
        string[] Lectura;
        int index;
        BasicNetwork Red;
        Arduino ColorRGB = new Arduino();
        bool status = false;
        public Form1()
        {
            InitializeComponent();
            string[] puertos = SerialPort.GetPortNames();
            
            timer1.Start();
            foreach (string puerto in puertos)
            {
                comboBox1.Items.Add(puerto);
            }
            ColorRGB.NewDataReceived += Color_NewDataReceived;

        }
        private void Color_NewDataReceived(object sender, EventArgs e)
        {
            try
            {
                CambiarValorControles(ColorRGB.Dato);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        delegate void CambiarValoresControlesDelegado(string valor);

        private void CambiarValorControles(string valor)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CambiarValoresControlesDelegado delegado = new CambiarValoresControlesDelegado(CambiarValorControles);
                    this.Invoke(delegado, valor);
                }
                else
                {

                    status = true;
                    if (status)
                    {
                        
                        Lectura = ColorRGB.Dato.Split(',');
                        trackBar1.Value = Convert.ToInt32(Lectura[0]);
                        trackBar2.Value = Convert.ToInt32(Lectura[1]);
                        trackBar3.Value = Convert.ToInt32(Lectura[2]);
                        trackBar4.Value = Convert.ToInt32(Lectura[3]);
                        Entrada = new double[4] { trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value };
                        IMLData EntradaNeurona = new BasicMLData(Entrada);
                        IMLData Resultado = Red.Compute(EntradaNeurona);
                        max = Resultado[0];
                        index = new int();
                        for (int i = 0; i <6; i++)
                        {
                            if (Resultado[i] > max)
                            {
                                max = Resultado[i];
                                index = i;
                            }
                        }
                        switch(index)
                        {
                            case 0:
                                label5.Text = "Es color rojo con un valor de :" + Resultado[index];
                                ColorRGB.Enviar("r");
                                break;

                            case 1:
                                label5.Text = "Es color naranja con un valor de :" + Resultado[index];
                                ColorRGB.Enviar("n");
                                break;

                            case 2:
                                label5.Text = "Es color amarillo con un valor de :" + Resultado[index];
                                ColorRGB.Enviar("a");
                                break;

                            case 3:
                                label5.Text = "Es color verde con un valor de :" + Resultado[index];
                                ColorRGB.Enviar("g");
                                break;

                            case 4:
                                label5.Text = "Es color azul con un valor de :" + Resultado[index];
                                ColorRGB.Enviar("b");
                                break;

                            case 5:
                                label5.Text = "Es color cafe con un valor de :" + Resultado[index];
                                ColorRGB.Enviar("c");
                                break;

                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] puertos = SerialPort.GetPortNames();
            foreach (string puerto in puertos)
            {
                comboBox1.Items.Add(puerto);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta_red = openFileDialog1.FileName;
                Red = (BasicNetwork)EncogDirectoryPersistence.LoadObject(new FileInfo(ruta_red));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string puerto = comboBox1.SelectedItem.ToString();
                ColorRGB.AbrirArduinoConexion(puerto);
                ColorRGB.Enviar("");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ColorRGB.CerrarFlujoDatosArduino();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "R = "+trackBar1.Value.ToString();
            label2.Text = "G = " + trackBar2.Value.ToString();
            label3.Text = "B = " + trackBar3.Value.ToString();
            label4.Text = "C = " + trackBar4.Value.ToString();

            R = 255 * trackBar1.Value / trackBar4.Value;
            G = 255 * trackBar2.Value / trackBar4.Value;
            B = 255 * trackBar3.Value / trackBar4.Value;

            if(R>255)
            {
                R = 255;
            }
            if (G > 255)
            {
                G = 255;
            }
            if (B > 255)
            {
                B = 255;
            }
            pictureBox1.BackColor = Color.FromArgb(Convert.ToInt32(R),Convert.ToInt32(G),Convert.ToInt32(B));
        }
    }
}
