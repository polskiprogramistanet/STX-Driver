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
    class RespTextHasBeenSent : ResponseBase
    {
        public override IState Handle(byte[] buffer, IReaderOperation obj)
        {
            if (buffer[2] == 0x00)
            {
                //status something to say
                
                return new TextHasBeenSend(obj); ;
            }
            else
            {
                return base.Handle(buffer, obj);
            }

        }
    }
}
