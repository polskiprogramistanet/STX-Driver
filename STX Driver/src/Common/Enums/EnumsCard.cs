using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Common.Enums
{
    internal enum CardTypeEnum
    {
        Loyality,
        Flota
    }
    internal enum StatusCardEnum
    {
        cardAvailable = 0,
        cardNotAvailable = 1
    }

    internal enum CommandEnum
    {
        Status = 0,
        SetText = 1

    }

    internal enum FontEnum
    {
        LuicidaConsole_8 = 0x00,
        LuicidaConsole_12_Bold = 0x01,
        LuicidaConsole_16_Bold = 0x02,
        Arial_8 = 0x03,
        Arial_12 = 0x04,
        Arial_16 = 0x05,
        Arial_Black_8 = 0x06,
        Arial_Black_12 = 0x07,
        Arial_Black_16 = 0x08,
        Arial_Narrow_8 = 0x09,
        Arial_Narrow_12 = 0x0A,
        Arial_Narrow_16 = 0x0B,
        Calibri_8 = 0x0C,
        Calibri_12 = 0x0D,
        Calibri_16 = 0x0E,
        Calibri_54_Bold = 0x0F,
        Arial_Narrow_54 = 0x10
    }

    internal enum ResponseEnum
    {

    }
}
