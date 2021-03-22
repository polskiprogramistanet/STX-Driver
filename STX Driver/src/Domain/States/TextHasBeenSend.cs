using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.STX.Commands;
using libProtocols.STX.Common;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Domain.States
{
    class TextHasBeenSend : IState
    {
        I_STXCommand command = null;
        IReaderOperation operation = null;
        Context context; 
        public TextHasBeenSend(IReaderOperation reader)
        {
            this.operation = reader;
        }
        public void SetContext(Context context)
        {
            this.context = context;
        }
        public void SetExecute()
        {
            this.command = new STXCmdStatus(this.operation.Adress, this.operation.GetStateType());
            this.operation.AddCommand(this.command);
        }
    }
}
