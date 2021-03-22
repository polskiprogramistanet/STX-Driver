using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using libProtocols.STX.Commands;
using libProtocols.STX.Common;
using STX_Driver.src.Domain.Entities.Cards;
using STX_Driver.src.Common.Enums;
using STX_Driver.src.Domain.Dispatcher;
using STX_Driver.src.Domain.Observers;
using STX_Driver.src.Application;

namespace STX_Driver.src.Domain.Entities
{
    public class Reader : IReader, IObserverDispatcher, IReaderOperation, IObserverTimeOutOperation
    {
        readonly SerialPort port;
        Magistrala mag = null;
        TimeOut timeOut = null;
        I_STXCommand command = null;
        ResponseEnum responseType = ResponseEnum.Nothing;
        STXStatusEnum status = STXStatusEnum.Status;
        readonly IObserverFromReaderToEngine ObservatorFromInitiation = null;
        public Queue<I_STXCommand> Commands { get; set; }
        public Reader(SerialPort port, int adress, IObserverFromReaderToEngine Observator)
        {
            this.port = port;
            this.port.ReadTimeout = 5000;
            this.Adress = adress;
            this.ObservatorFromInitiation = Observator;
            this.mag = new Magistrala(this);
            this.timeOut = new TimeOut(this);
            this.Commands = new Queue<I_STXCommand>();
            this.Commands.Enqueue(new STXCmdSetText(this.Adress, STXFontEnum.Arial_16, "Przyłóż karte"));
        }
        public int Id { get; set; }
        public int DSN { get; set; }
        public int CDN { get; set; }
        public int Adress { get; private set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int NumSession { get; private set; }
        public int NumOk { get; private set; }
        public bool Bussy { get; set; }
        public string PinReader { get; private set; }
        public CardFlota Card { get; set; }


        public void SendData()
        {
            byte[] buffer = null;
            
            try
            {
                if(this.Commands.Count==0 || this.Commands.Count > 1)
                    Console.WriteLine("Ilość komend: {0}", this.Commands.Count);

                if (this.Commands.Count != 0)
                {
                    command = this.Commands.Dequeue();
                }
                else
                {
                    command = new STXCmdStatus(this.Adress, status);
                }  

                this.port.Write(command.Value, 0, command.Value.Length);
                Thread.Sleep(50);
                buffer = new byte[this.port.BytesToRead];
                
                this.port.Read(buffer, 0, this.port.BytesToRead);
                if(buffer.Length>0)
                    mag.Init(buffer, this);
 

            }
            catch (TimeoutException tex)
            {
                Console.WriteLine("timeout: {0}", tex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
        public void AddCommand(I_STXCommand command)
        {
            this.Commands.Enqueue(command);
        }
        public void SetInformation(string value, STXFontEnum font)
        {
            I_STXCommand command = new STXCmdSetText(this.Adress, font, value);
           
                if (Commands.Count>=0 && Commands.Count <= 1)
                    this.Commands.Enqueue(command);
                else
                    Console.WriteLine("Nie dodano komendy {0}", value );
            
           
        }
        public void SetStateType(STXStatusEnum status)
        {
            this.status = status;
        }
        public void SetNumberOfSession(int num)
        {
            this.NumSession = num;
            this.ObservatorFromInitiation.SetNumberOfSesionInDataBase(num, this);
        }
        public void FinishedTimeOut()
        {
            Console.WriteLine("Time out off");
            this.Bussy = false;
            //this.SetInformation("Przyłóż karte", STXFontEnum.Arial_16);
        }
        public void CheckCardStatus()
        {
            try
            {
        
                
                //if (this.Card.ExpirationDate < DateTime.Now && this.Card.State== StatusCardEnum.cardNotAvailable)
                //{
                //    this.Commands.Enqueue(new CmdSetText(this.Adress, FontEnum.Arial_16, "Karta zablokowana"));
                //    //this.timeOut.Starter();
                //}
                //else
                //{
                //    if(this.Card.PINActive == 1)
                //    {
                //        this.Commands.Enqueue(new CmdSetText(this.Adress, FontEnum.Arial_16, "Wprowadź PIN"));
                //    }

                //    this.Commands.Enqueue(new CmdSetText(this.Adress, FontEnum.Arial_16, "Programuje ceny"));
                //    this.ObservatorFromInitiation.SetCommandFromReader(libProtocols.OilSocket.Common.CommandEnum.SetPrice, this);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reader.CheckCardStatus: {0}", ex.Message);
            }
        }
        public void PricesSets()
        {
            try
            {
                //this.Commands.Enqueue(new CmdSetText(this.Adress, FontEnum.Arial_16, "Ceny zaprogramowane"));
                //this.ObservatorFromInitiation.SetCommandFromReader(libProtocols.OilSocket.Common.CommandEnum.Unblock, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reader.CheckCardStatus: {0}", ex.Message);
            }
        }
        public void ReadyToTank()
        {
            try
            {
                //this.Commands.Enqueue(new CmdSetText(this.Adress, FontEnum.Arial_16, "Możesz tankować"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reader.ReadyToTank: {0}", ex.Message);
            }
        }
        public void SetBussy(bool value)
        {
            this.Bussy = value;
            if(value)
                this.timeOut.Starter(5);
        }
        public STXStatusEnum GetStateType()
        {
            return this.status;
        }
        public void SetResponseType(ResponseEnum responseType)
        {
            this.responseType = responseType;
        }
        public ResponseEnum GetResponseType()
        {
            return this.responseType;
        }
        public void SetOKNum(int num)
        {
            this.NumOk = num;
        }
        public void SetReaderPin(string pin)
        {
            this.PinReader = pin;
        }
        public CardFlota GetCard()
        {
           return this.Card;
        }
        public void SetCard(CardFlota card)
        {
            this.Card = card;
        }
    }
}