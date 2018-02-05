using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialPortSendTest
{
    class Program
    {

        static SerialPort SP1 = new SerialPort();
        static SerialPort SP2 = new SerialPort();

        static void Main(string[] args)
        {
            Console.WriteLine("Send test");

            Console.Write("SerialPort1 PortName:");
            SP1.PortName = Console.ReadLine();

            Console.Write("SerialPort2 PortName:");
            SP2.PortName = Console.ReadLine();

            SP1.Open();
            SP2.Open();

            Console.WriteLine("Send start");

            Send();

            Console.ReadKey(true);
        }

        static void Send()
        {
            Task task = Task.Factory.StartNew(() => {
                while(true)
                {
                    SendMsg(SP1, "SerialPort1");
                    Thread.Sleep(500);
                    SendMsg(SP2, "SerialPort2");
                    Thread.Sleep(500);
                }
            });
        }

        static void SendMsg(SerialPort serialPort,string str)
        {
            byte[] data = Encoding.GetEncoding(932).GetBytes(str);
            serialPort.Write(data, 0, data.Length);
            Console.WriteLine("Send:" + str);
        }
    }
}
