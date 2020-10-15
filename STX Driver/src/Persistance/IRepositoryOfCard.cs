using STX_Driver.src.Domain.Entities.Cards;

namespace STX_Driver.src.Persistance
{
    interface IRepositoryOfCard
    {
        CardFlota Execute();
    }
}