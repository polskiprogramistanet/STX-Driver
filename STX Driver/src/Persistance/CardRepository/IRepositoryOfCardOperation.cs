using STX_Driver.src.Domain.Entities.Cards;

namespace STX_Driver.src.Persistance.CardRepository
{
    interface IRepositoryOfCardOperation
    {
        CardFlota GetCard();
    }
}