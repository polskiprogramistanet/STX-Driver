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
    class PinChecker : IState
    {
        I_STXCommand command = null;
        IReaderOperation operation = null;
        Context context;
        InfoModelBase Info;

        public PinChecker(IReaderOperation reader)
        {
            this.operation = reader;
        }
        public void SetContext(Context context)
        {
            this.context = context;
        }

        public void SetExecute()
        {
            
        }
    }
}
