using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;
using STX_Driver.src.Domain.Entities;
using STX_Driver.src.Domain.Observers;
using STX_Driver.src.Common.TextInfoModeling;
using libProtocols.STX.Commands;
using STX_Driver.src.Domain.States;


namespace STX_Driver.src.Domain.Dispatcher
{
    class Magistrala
    {
        ResponseBase CardChecker;
        ResponseBase GetStateNothing;
        ResponseBase GetCardCode;
        ResponseBase GetPinCode;
        ResponseBase TextHasBeenSend;
        ResponseBase SessionChecker;
        IObserverDispatcher observer;
        
        I_STXCommand command;
        IReaderOperation reader;

        public Magistrala(IObserverDispatcher observer)
        {
            CardChecker = new RespCardChecker();
            GetStateNothing = new RespGetStateNothing();
            GetCardCode = new RespGetCardCode();
            GetPinCode = new RespGetPinCode();
            TextHasBeenSend = new RespTextHasBeenSent();
            SessionChecker = new RespSessionChecker();
            this.observer = observer;
            
        }

        public void Init(byte[] buffer, IReaderOperation obj)
        {
            try
            {
                IState state = null;
                SessionChecker.SetNext(CardChecker).SetNext(GetPinCode).SetNext(TextHasBeenSend);
                ResponseBase response = SessionChecker;
                state = response.Handle(buffer, obj);
                if (state == null)
                    state = new SomethingToSay(obj, new ApplyTheCardInfo());
                Context context = new Context(state);
                context.DoThis();
                this.reader = obj;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Magistrala.Init {0}", ex.Message);
            }
           
        }
        //tworzenie odpowiedzi

    }
}
