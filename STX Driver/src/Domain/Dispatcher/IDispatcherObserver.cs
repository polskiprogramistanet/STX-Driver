using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Protocol;

namespace STX_Driver.src.Domain.Dispatcher
{
    interface IDispatcherObserver
    {
        void SetCommand(ICommand command);
    }
}
