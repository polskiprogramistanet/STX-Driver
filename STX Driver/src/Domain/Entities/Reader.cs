using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using STX_Driver.src.Domain.Entities.Cards;
using STX_Driver.src.Domain.Protocol;
using STX_Driver.src.Common.Enums;
using STX_Driver.src.Domain.Dispatcher;

namespace STX_Driver.src.Domain.Entities
{
    class Reader : IReader, IDispatcherObserver
    {
        readonly SerialPort port;
        Magistrala mag;
        ICommand command;
        IReaderObserver Observator = null;
        public Queue<ICommand> Commands { get; set; }
        public Reader(SerialPort port, int adress, IReaderObserver Observator)
        {
            this.port = port;
            this.port.ReadTimeout = 5000;
            this.Adress = adress;
            this.Observator = Observator;
            this.mag = new Magistrala(this);
            this.Commands = new Queue<ICommand>();
            this.Commands.Enqueue(new CmdSetText(this.Adress, FontEnum.Arial_16, "Przyłóż karte"));
        }
        public int Id { get; set; }
        public int DSN { get; set; }
        public int Adress { get; private set; }
        public CardFlota Card { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public void SendData()
        {
            byte[] buffer = null;
            
            try
            {
                if (this.Commands.Count != 0)
                {
                    command = this.Commands.Dequeue();
                }
                else
                {
                    command = new CmdStatus(this.Adress);
                }  
                this.port.Write(command.Value, 0, command.Value.Length);
                Thread.Sleep(50);
                buffer = new byte[this.port.BytesToRead];
                this.port.Read(buffer, 0, this.port.BytesToRead);
                mag.Init(buffer);
                Console.WriteLine(BitConverter.ToString(buffer));

            }
            catch (TimeoutException tex)
            {
                Console.WriteLine("timeout: {0}",tex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
        public void SetCommand(ICommand command)
        {
            this.Commands.Enqueue(command);
        }

        
        
    }
}
