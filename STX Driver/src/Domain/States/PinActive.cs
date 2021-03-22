using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.STX.Commands;
using STX_Driver.src.Common.TextInfoModeling;
using STX_Driver.src.Domain.Entities;
using libProtocols.STX.Common;

namespace STX_Driver.src.Domain.States
{
    class PinActive : IState
    {
        I_STXCommand command = null;
        IReaderOperation operation = null;
        Context context;
        InfoModelBase Info;

        public PinActive(IReaderOperation reader)
        {
            this.operation = reader;
        }
        public void SetContext(Context context)
        {
            this.context = context;
        }

        public void SetExecute()
        {

            if(this.operation.GetStateType() == STXStatusEnum.Status)
            {
                Info = new EnterThePINInfo();
                command = new STXCmdSetText(this.operation.Adress, Info.GetFontInformation(), Info.GetInformationText());
                this.operation.SetStateType(STXStatusEnum.Pin_4);
            }
            else
            {
                command = new STXCmdStatus(this.operation.Adress, this.operation.GetStateType());
            }    
            
            this.operation.AddCommand(this.command);
        }
    }
}
