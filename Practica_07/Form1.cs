using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; //Libreria de comunicacion serial

namespace Practica_07
{
    public partial class Form1 : Form
    {
        public SerialPort ArduinoPort { get; set; }
        public Form1()
        {
            InitializeComponent();
            //Configuracion de comunicacion serial
            ArduinoPort = new System.IO.Ports.SerialPort();
            ArduinoPort.PortName = "COM4";
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();
            //Manejador de eventos
            this.FormClosing += CerrandoForm1;
            this.BtnEncender.Click += BtnEncender_Click;
            this.BtnApagar.Click += BtnApagar_Click;
        }
        private void CerrandoForm1(object sender, EventArgs e)
        {
            if (ArduinoPort.IsOpen)
            {
                ArduinoPort.Close();
            }
        }
        private void BtnEncender_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("b");
        }

        private void BtnApagar_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("a");
        }
    }
}