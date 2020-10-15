using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Protocol
{
    class CreatorCRC
    {
        byte[] data = null;
        byte result;
        public CreatorCRC(byte[] data)
        {
            this.data = data;
        }

        public byte Execute()
        {
            foreach(var b in data)
            {
                result = (byte)((int)result + (int)b);
            }
            return result;
        }
    }
}
