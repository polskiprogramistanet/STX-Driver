using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;
using STX_Driver.src.Domain.Entities;
using STX_Driver.src.Domain.States;
using STX_Driver.src.Common;
using STX_Driver.src.Common.TextInfoModeling;
using libProtocols.STX.Common;
using STX_Driver.src.Domain.Entities.Cards;

namespace STX_Driver.src.Domain.Dispatcher
{
    class RespCardChecker : ResponseBase
    {
        CardFlota card;
        public override IState Handle(byte[] buffer, IReaderOperation obj)
        {
            

            if (buffer[2]==0x16 && obj.GetCard()!=null && obj.GetStateType()==STXStatusEnum.Status)//oznacza że zapytaniem był status
            {
                card = obj.GetCard();
                if (card.ExpirationDate < DateTime.Now || card.State == StatusCardEnum.cardNotAvailable)
                    return new CardNoActive(obj);
                else
                {
                    if (card.PINActive == 1)

                        return new PinActive(obj);
                    else
                        return new SomethingToSay(obj, new RefuelingAuthorizationInfo());
                }
            }
            else
            {
                return base.Handle(buffer, obj);
            }
        }
    }
}
