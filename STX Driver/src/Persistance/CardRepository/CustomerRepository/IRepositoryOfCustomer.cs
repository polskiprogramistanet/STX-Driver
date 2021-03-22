using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance.CardRepository.CustomerRepository
{
    interface IRepositoryOfCustomer
    {
        Customer GetCustomer();
    }
}