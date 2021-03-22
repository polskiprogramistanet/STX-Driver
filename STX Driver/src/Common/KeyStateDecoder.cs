using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Common
{
    public class KeyStateDecoder : IKeyStateDecoder
    {
        byte[] keyBuffer;
        string hex;
        string keyReader;
        public KeyStateDecoder(byte[] buffor)
        {
            keyBuffer = new byte[] { buffor[12], buffor[11] };
            hex = BitConverter.ToString(keyBuffer);
            hex = hex.Replace("-", "");
            keyReader = null;
        }

        public int DecodeKeyState()
        {
           
            int value = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            
            return value;
        }
    }
}
