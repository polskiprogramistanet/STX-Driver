using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Domain.Observers
{
    interface IObserverReaderFromInitiation
    {
        void ChangeCounter(int currentValue);

        void FindCard(string code, Reader reader);
        void SetNumberOfSesionInDataBase(int number, Reader reader);
    }
}
