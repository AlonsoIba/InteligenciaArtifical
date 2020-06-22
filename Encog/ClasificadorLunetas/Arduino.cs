using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Distancia
{
    public class Arduino
    {
        private SerialPort placaArduino = new SerialPort();
        private string dato="";

        public string Dato
        {
            get
            {
                return dato;
            }
        }
        public event EventHandler NewDataReceived;

        public void AbrirArduinoConexion(string puerto)
        {
            try
            {
                if (!placaArduino.IsOpen)
                {
                    if (puerto != null || puerto != "")
                    {
                        placaArduino.DataReceived +=
                        placaArduino_DatoRecibido;
                        placaArduino.PortName = puerto;
                        placaArduino.Open();
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void placaArduino_DatoRecibido(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                dato = placaArduino.ReadTo("\x05");
                string[] arreglo1 = dato.Split(new string[] { "\x01" }, StringSplitOptions.RemoveEmptyEntries);
                dato = arreglo1[1];

                if (NewDataReceived != null)
                {
                    NewDataReceived(this, new EventArgs());
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        public void Enviar(string valor)
        {
            try
            {
                placaArduino.WriteLine(valor);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        public void CerrarFlujoDatosArduino()
        {
            try
            {
                if (placaArduino.IsOpen)
                {
                    placaArduino.DiscardInBuffer();
                    placaArduino.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}