using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Entities.Cards;

namespace STX_Driver.src.Domain.Observers
{
    interface IObserverCardConstructor
    {
        void SetCard(CardFlota card);
        void SetInformation(object value);
    }
}
