using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.STX.Commands;
using libProtocols.STX.Common;
using STX_Driver.src.Common.TextInfoModeling;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Domain.States
{
    class SomethingToSay : IState
    {
        I_STXCommand command = null;
        IReaderOperation operation = null;
        InfoModelBase Info;
        
        public SomethingToSay(IReaderOperation reader)
        {
            this.operation = reader;
        }
        public SomethingToSay(IReaderOperation reader, InfoModelBase Info)
        {
            this.operation = reader;
            this.Info = Info;
        }

        public void SetExecute()
        {
            command = new STXCmdSetText(this.operation.Adress, Info.GetFontInformation(), Info.GetInformationText());
            this.operation.AddCommand(this.command);
        }
    }
}
