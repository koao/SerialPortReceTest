using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace SerialPortReceTest
{
    class Program
    {

        static SerialPort SP1 = new SerialPort();
        static SerialPort SP2 = new SerialPort();

        static void Main(string[] args)
        {
            Console.WriteLine("Receive test");

            Console.Write("SerialPort1 PortName:");
            SP1.PortName = Console.ReadLine();

            Console.Write("SerialPort2 PortName:");
            SP2.PortName = Console.ReadLine();

            SP1.DataReceived += SP1_DataReceived;
            SP2.DataReceived += SP2_DataReceived;

            SP1.Open();
            SP2.Open();

            Console.WriteLine("Receive wait");

            Console.ReadKey(true);
        }

        private static void SP1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[SP1.BytesToRead];
            SP1.Read(data, 0, SP1.BytesToRead);
            Console.WriteLine("Receive:" + Encoding.GetEncoding(932).GetString(data));
        }

        private static void SP2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100000);

            byte[] data = new byte[SP2.BytesToRead];
            SP2.Read(data, 0, SP2.BytesToRead);
            Console.WriteLine("Receive:" + Encoding.GetEncoding(932).GetString(data));
        }

    }
}
