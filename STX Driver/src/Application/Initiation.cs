using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using STX_Driver.src.Domain.Entities;
using STX_Driver.src.Persistance;
using STX_Driver.src.Common;

namespace STX_Driver.src.Application
{
    public class Initiation : IInitOperation, IReaderObserver
    {
        public event EventHandler<object> GetReaderData;
        SerialPort port;
        bool doIt = false;
        int counter = 0;
        IRepositoryOfReader reader;
        readonly List<Reader> readers;
        public Initiation (string comport, string provider)
        {
            try
            {
                Configuration.Provider = provider;
                port = new SerialPort(comport);
                port.BaudRate = 115200;
                port.DataBits = 8;
                port.ReadTimeout = 5000;
                port.WriteTimeout = 5000;
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.ReceivedBytesThreshold = 1;
                port.Open();
                if (port.IsOpen)
                {
                    reader = new RepositoryOfReaders(port, this);
                    readers = reader.GetItems();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Initiation ctor: {0}", ex.Message);
            }
        }      

        public void StartEngine()
        {
            Thread thread = new Thread(Engine);
            thread.Start();
        }

        public void StopEngine()
        {
            try
            {
                doIt = true;

                while (doIt && readers.Count > 0)
                {

                    readers[counter].SendData();

                    Thread.Sleep(500);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void Engine()
        {
            try
            {
                doIt = true;
                while (doIt && readers.Count > 0)
                {
                    readers[counter].SendData();
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ChangeCounter(int currentValue)
        {
            //zmiana licznika przy wielu czytnikach
        }
    }
}
