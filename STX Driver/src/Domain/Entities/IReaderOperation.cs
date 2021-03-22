using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using STX_Driver.src.Domain.Entities.Cards;
using STX_Driver.src.Domain.Observers;
using libProtocols.STX.Common;
using STX_Driver.src.Common.Enums;
using libProtocols.STX.Commands;

namespace STX_Driver.src.Domain.Entities
{
    interface IReaderOperation
    {
        int Adress { get; }
        int NumSession { get; }
        int NumOk { get; }
        int Id { get; }
        void SetNumberOfSession(int num);
        void SetOKNum(int num);
        void SetReaderPin(string pin);
        void AddCommand(I_STXCommand command);
        STXStatusEnum GetStateType();
        void SetResponseType(ResponseEnum responseType);
        ResponseEnum GetResponseType();
        CardFlota GetCard();
        void SetCard(CardFlota card);
        void SetStateType(STXStatusEnum status);
    }
}
