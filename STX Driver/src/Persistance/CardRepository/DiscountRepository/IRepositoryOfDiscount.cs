using System.Collections.Generic;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance.CardRepository.DiscountRepository
{
    interface IRepositoryOfDiscount
    {
        List<DiscountValue> GetDiscounts();
    }
}