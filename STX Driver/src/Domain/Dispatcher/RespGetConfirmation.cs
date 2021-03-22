using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Domain.Dispatcher
{
    class RespGetConfirmation : ResponseBase
    {
        public override ResponseEnum Handle(byte[] buffer, IReaderOperation obj)
        {
            if (buffer.Length == 4)
            {
                return ResponseEnum.Nothing;
            }
            else
            {
                return base.Handle(buffer, obj);
            }
        }
    }
}
