using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Common
{
    class GetCardCode
    {
        string strCodeCard = null;
        static Encoding encoding = Encoding.UTF8;
        byte[] buffer;
        public GetCardCode(byte[] buffer)
        {
            try
            {
                this.buffer = new byte[5];

                Buffer.BlockCopy(buffer, 4, this.buffer, 0, 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public string GetStringCode()
        {
            //strCodeCard = encoding.GetString(this.buffer);
            strCodeCard = BitConverter.ToString(this.buffer).Replace("-", "");
            return strCodeCard;
        }

        public byte[] GetBytesCode()
        {

            return buffer;
        }
    }

}
