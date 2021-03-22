using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using STX_Driver.src.Domain.Entities;
using STX_Driver.src.Domain.Entities.Cards;
using STX_Driver.src.Persistance;
using STX_Driver.src.Common;
using STX_Driver.src.Domain.Observers;
using libProtocols.OilSocket.Common;

namespace STX_Driver.src.Application
{
    public class Initiation : ISTXOperation, IObserverReaderFromInitiation
    {
        SerialPort port;
        bool doIt = false;
        int counter = 0;
        ICardConstructor cardConstructor = null;
        IRepositoryOfReader reader;
        readonly List<Reader> readers;
        public event EventHandler<ICard> SetCardToPump;
        public event EventHandler<CommandEnum> SetCommandToPump;
        public event EventHandler<IReader> SetActiveReaderInPump;

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
            doIt = true;
            Thread thread = new Thread(Engine);
            thread.Start();
        }

        public void StopEngine()
        {
            try
            {
                doIt = false;
                                
            }
            catch (Exception ex)
            {
                Console.WriteLine("StopEngine: {0}", ex.Message);
            }
        }

        void Engine()
        {
            try
            {
                while (doIt && readers.Count > 0)
                {
                    readers[counter].SendData();
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Engine: {0}", ex.Message);
            }
        }

        public void ChangeCounter(int currentValue)
        {
            //zmiana licznika przy wielu czytnikach
        }
        
        public void ConfrimCommand(CommandEnum command, object state)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void IObserverReaderFromInitiation.FindCard(string code, Reader reader)
        {
            try
            {
                Console.WriteLine("Szukam karty o kodzie : {0}", code);
                cardConstructor = new CardConstructor(code);
                reader.SetCard(cardConstructor.Execute());
                
                //SetCommandToPump?.Invoke(this, CommandEnum.Block);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void IObserverReaderFromInitiation.SetNumberOfSesionInDataBase(int number, Reader reader)
        {
            try
            {
                if (this.reader != null)
                    this.reader.SetSessionNumberToReader(number, reader);    
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetNumberOfSesionInDataBase: {0}", ex.Message);
            }
        }
    }
}
