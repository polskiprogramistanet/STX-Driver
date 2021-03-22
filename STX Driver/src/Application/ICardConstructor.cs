using STX_Driver.src.Domain.Entities.Cards;

namespace STX_Driver.src.Application
{
    interface ICardConstructor
    {
        CardFlota Card { get; }
        CardFlota Execute();
    }
}