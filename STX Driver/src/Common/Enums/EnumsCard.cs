using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Common.Enums
{
    public enum CardTypeEnum
    {
        Loyality,
        Flota
    }
    public enum StatusCardEnum
    {
        cardAvailable = 0,
        cardNotAvailable = 1
    }
    public enum ResponseEnum
    {
        Nothing = 0,
        NothingToSay = 1,
        CardActive = 2,
        GetCardPin = 3,
        TextHasBeenSend = 4
    }   
}
