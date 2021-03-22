using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.OilSocket.Common;
using STX_Driver.src.Application;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Domain.Observers
{
    public interface IObserverFromReaderToEngine
    {
        void ChangeCounter(int currentValue);
        void SetNumberOfSesionInDataBase(int num, IReader reader);
    }
}
