using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Entities
{
    interface IReaderOperation
    {
        void SendCommand();
        IReaderObserver Observator { set; }
    }
}
