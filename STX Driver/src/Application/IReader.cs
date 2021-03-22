using System.Collections.Generic;
using libProtocols.STX.Commands;
using libProtocols.STX.Common;
using STX_Driver.src.Application;
using STX_Driver.src.Domain.Entities.Cards;

namespace STX_Driver.src.Application
{
    public interface IReader
    {
        int Adress { get; }
         
        Queue<I_STXCommand> Commands { get; set; }
        int DSN { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int Number { get; set; }
        int NumSession { get; }
        CardFlota Card { get; set; }

        void SendData();
        void AddCommand(I_STXCommand command);
        void SetInformation(string value, STXFontEnum font);
        void SetStateType(STXStatusEnum status);
        void SetNumberOfSession(int num);
        void SetBussy(bool value);
    }
}