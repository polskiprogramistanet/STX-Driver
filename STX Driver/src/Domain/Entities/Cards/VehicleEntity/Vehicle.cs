using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Entities.Cards.VehicleEntity
{
    public class Vehicle
    {
        public Vehicle(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string NumReg { get; set; }
        public string Brand { get; set; }
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
    }
}
