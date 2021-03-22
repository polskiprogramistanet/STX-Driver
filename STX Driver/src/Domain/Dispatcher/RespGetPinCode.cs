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
    class RespGetPinCode : ResponseBase
    {
        public override IState Handle(byte[] buffer, IReaderOperation obj)
        {
            if(buffer[15] != obj.NumOk && buffer[10]==0x04 && obj.GetCard()!=null)
            
                return new PinChecker(obj);

            else

                return base.Handle(buffer, obj);
        }
    }
}
