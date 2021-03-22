using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.States;
using STX_Driver.src.Domain.Entities;
using STX_Driver.src.Common;
 

namespace STX_Driver.src.Domain.Dispatcher
{
    class RespSessionChecker : ResponseBase
    {
        public override IState Handle(byte[] buffer, IReaderOperation obj)
        {
            GetNumberSession numberSession;

            if (buffer[2] == 0x16 && obj.NumSession!= new GetNumberSession(buffer).GetNumSession())//oznacza że zapytaniem był status
            {
                numberSession = new GetNumberSession(buffer);
                int num = numberSession.GetNumSession();
                 
                obj.SetNumberOfSession(num);
                GetCardCode cardCode = new GetCardCode(buffer);
                string code = cardCode.GetStringCode();
                
                return new CardFinder(code, obj);
            }
            else
            {
                return base.Handle(buffer, obj);
            }
                    
        }

    }
}
