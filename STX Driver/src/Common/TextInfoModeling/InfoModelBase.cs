using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.STX.Common;

namespace STX_Driver.src.Common.TextInfoModeling
{
    abstract class InfoModelBase
    {
       
        public abstract string GetInformationText();
        public abstract STXFontEnum GetFontInformation();
         
    }
}
