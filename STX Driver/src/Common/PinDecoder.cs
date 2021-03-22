using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Common
{
    public class PinDecoder : IPinDecoder
    {
        byte[] pinBuffer;
        string hex;
        string pinReader;

        public PinDecoder(byte[] buffer)
        {
            pinBuffer = new byte[] { buffer[18], buffer[17] };
            hex = BitConverter.ToString(pinBuffer);
            hex = hex.Replace("-", "");
            pinReader = null;
        }
        public string DecodePinReader()
        {
            string result;
            int value = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            result = value.ToString();
            pinReader = result;
            return result;
        }
        public bool PinCardComparator(string cardPin, string readerPin)
        {
            bool result=false;
            int wynik = String.Compare(cardPin, readerPin);
            if (wynik == 0)
                result = true;
            else
                result = false;
            return result;
        }

        public bool PinCardComparator(string cardPin)
        {
            bool result = false;
            int wynik = String.Compare(cardPin, this.pinReader);

            return result;
        }
    }
}
