using System.Collections.Generic;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance
{
    interface IRepositoryOfDiscount
    {
        List<DiscountValue> Execute();
    }
}