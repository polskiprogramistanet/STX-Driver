using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.STX.Commands;
using STX_Driver.src.Common.TextInfoModeling;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Domain.States
{
    class CardNoActive:IState
    {
        I_STXCommand command = null;
        IReaderOperation operation = null;
        Context context;
        InfoModelBase Info;

        public CardNoActive(IReaderOperation reader)
        {
            this.operation = reader;
        }

        public void SetContext(Context context)
        {
            this.context = context;
        }

        public void SetExecute()
        {
            Info = new TheCardIsBlockedInfo();
            command = new STXCmdSetText(this.operation.Adress, Info.GetFontInformation(), Info.GetInformationText());
            this.operation.AddCommand(this.command);
        }
    }
}
