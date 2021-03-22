using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Common
{
    class GetNumberSession
    {
        byte[] buffer;
        int result = 0;
        static Encoding encoding = Encoding.UTF8;
        public GetNumberSession(byte[] buffer)
        {
            this.buffer = buffer;
        }

        public int GetNumSession()
        {
            result = buffer[3];
            return result;
        }

    }
}
