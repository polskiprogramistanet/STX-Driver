using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.STX.Common;
using libProtocols.STX.Commands;

namespace STX_Driver.src.Domain.Observers
{
    interface IObserverDispatcher
    {
        void AddCommand(I_STXCommand command);
       
        void SetNumberOfSession(int number);
    }
}
