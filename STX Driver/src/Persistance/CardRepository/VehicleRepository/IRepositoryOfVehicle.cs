using STX_Driver.src.Domain.Entities.Cards.VehicleEntity;

namespace STX_Driver.src.Persistance.CardRepository.VehicleRepository
{
    interface IRepositoryOfVehicle
    {
        Vehicle GetVehicle();
    }
}