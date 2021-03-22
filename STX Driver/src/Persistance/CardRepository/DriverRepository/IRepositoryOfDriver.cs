using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance.CardRepository.DriverRepository
{
    interface IRepositoryOfDriver
    {
        Driver GetDriver();
    }
}