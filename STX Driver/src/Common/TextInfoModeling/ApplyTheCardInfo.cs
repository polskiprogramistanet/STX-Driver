﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.STX.Common;

namespace STX_Driver.src.Common.TextInfoModeling
{
    class ApplyTheCardInfo : InfoModelBase
    {
        public override STXFontEnum GetFontInformation()
        {
            return STXFontEnum.Arial_16;
        }

        public override string GetInformationText()
        {
            return "Przyłóż kartę";
        }
    }
}
