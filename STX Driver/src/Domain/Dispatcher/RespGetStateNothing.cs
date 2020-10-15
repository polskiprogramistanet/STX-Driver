using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Dispatcher
{
    class RespGetStateNothing : ResponseBase
    {
        public override object Handle(byte[] buffer)
        {
            Console.WriteLine(BitConverter.ToString(buffer));
            if (buffer.Length > 4)
            {

            }
            else
            {

            }


            return base.Handle(buffer);
        }

    }
}
