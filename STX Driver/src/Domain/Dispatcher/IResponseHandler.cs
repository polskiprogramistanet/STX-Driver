using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Dispatcher
{
    interface IResponseHandler
    {
        IResponseHandler SetNext(IResponseHandler handler);
        object Handle(byte[] buffer);
    }
}
