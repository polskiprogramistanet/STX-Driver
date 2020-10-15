using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance
{
    interface IRepositoryOfCustomer
    {
        Customer Execute();
    }
}