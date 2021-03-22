using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;
using STX_Driver.src.Domain.Entities;
using STX_Driver.src.Domain.States;

namespace STX_Driver.src.Domain.Dispatcher
{
    abstract class ResponseBase : IResponseHandler
    {
        IResponseHandler nextHandler;
        public virtual IState Handle(byte[] buffer, IReaderOperation obj)
        {
            if (this.nextHandler != null)
                return this.nextHandler.Handle(buffer, obj);
            else
                return null;
        }

        public IResponseHandler SetNext(IResponseHandler handler)
        {
            this.nextHandler = handler;
            return handler;
        }
    }
}
