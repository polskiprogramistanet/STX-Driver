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
    interface IResponseHandler
    {
        IResponseHandler SetNext(IResponseHandler handler);
        IState Handle(byte[] buffer, IReaderOperation obj);
    }
}
