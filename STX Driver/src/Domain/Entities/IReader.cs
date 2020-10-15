using STX_Driver.src.Domain.Entities.Cards;

namespace STX_Driver.src.Domain.Entities
{
    interface IReader
    {
        CardFlota Card { get; set; }

        void SendData();
    }
}