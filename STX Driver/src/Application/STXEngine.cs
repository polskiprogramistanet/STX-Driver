using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using STX_Driver.src.Domain.Entities;
using STX_Driver.src.Persistance.CardRepository.SessionNumber;
using STX_Driver.src.Persistance.Readers;
using STX_Driver.src.Common;
using STX_Driver.src.Domain.Observers;
using libProtocols.OilSocket.Common;
using libProtocols.STX.Common;


namespace STX_Driver.src.Application
{
    public class STXEngine : ISTXOperation, IObserverFromReaderToEngine
    {
        SerialPort port;
        bool doIt = false;//zmiennna określająca prace silnika
        int counter = 0;
       
        IRepositoryOfReaders reader;
        readonly List<Reader> readers;
       
        public event EventHandler<CommandEnum> SetCommandToPomp;
        public event EventHandler<IReader> SetActiveReaderInPomp;
        public event EventHandler<ICard> SetCardToPomp;

        public STXEngine (string comport, string provider)
        {
            try
            {
                Configuration.Provider = provider;
                port = new SerialPort(comport);
                port.BaudRate = 56000;
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
            SetCommandToPomp?.Invoke(this, CommandEnum.Block);

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
                    //Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("STXEngine.Engine: {0}", ex.Message);
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
                switch (command)
                {
                     
                    case CommandEnum.Block:
                        readers[0].CheckCardStatus();
                        break;

                    case CommandEnum.Unblock:
                        readers[0].ReadyToTank();
                        break;
                    
                    case CommandEnum.SetPrice:
                        readers[0].PricesSets();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ConfrimCommand: {0}", ex.Message);
            }
        }

        public void SendInformation(string text, STXFontEnum font)
        {
            readers[counter].SetInformation(text, font);
        }

        public void SetNumberOfSesionInDataBase(int num, IReader reader)
        {
            CardSessionNumber sessionNumber = new CardSessionNumber(num, reader.Id);
            sessionNumber.Execute();

        }
    }
}
