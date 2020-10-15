using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Dispatcher
{
    class Magistrala
    {
        ResponseBase GetStateNothing;
        ResponseBase GetCardCode;
        ResponseBase GetPinCode;
        IDispatcherObserver observer;

        public Magistrala(IDispatcherObserver observer)
        {
            GetStateNothing = new RespGetStateNothing();
            GetCardCode = new RespGetCardCode();
            GetPinCode = new RespGetPinCode();
            this.observer = observer;
            GetStateNothing.SetNext(GetCardCode).SetNext(GetPinCode);
        }

        public void Init(byte[] buffer)
        {
            ResponseBase response = GetStateNothing;
            response.Handle(buffer);


        }


    }
}
