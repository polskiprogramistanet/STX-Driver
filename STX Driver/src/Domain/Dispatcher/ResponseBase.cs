using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Dispatcher
{
    abstract class ResponseBase : IResponseHandler
    {
        IResponseHandler nextHandler;
        public virtual object Handle(byte[] buffer)
        {
            if (this.nextHandler != null)
                return this.nextHandler.Handle(buffer);
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
