using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.OilSocket.Common;


namespace STX_Driver.src.Application
{
    public interface ISTXOperation
    {
        event EventHandler<CommandEnum> SetCommandToPomp;
        event EventHandler<IReader> SetActiveReaderInPomp;
        //event EventHandler<string> SetCodeCard;

        void StartEngine();
        void StopEngine();
        void ConfrimCommand(CommandEnum command, object state);
        //void SendInformation(string text, libProtocols.STX.Common.STXFontEnum font);
        //void SendInformation(string text, libProtocols.STX.Common.STXFontEnum font, bool bussy);
        //void SendInformation(string text, libProtocols.STX.Common.STXFontEnum font, libProtocols.STX.Common.STXStatusEnum readPin);
        //bool GetBussyState(int dsn);
        //void SetBussyState(int dsn, bool value);
        //void CheckPin(int dsn, string pinCard);
    }
}
