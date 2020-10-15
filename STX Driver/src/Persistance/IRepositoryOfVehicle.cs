using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance
{
    interface IRepositoryOfVehicle
    {
        Vehicle Execute();
    }
}