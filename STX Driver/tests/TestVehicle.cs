using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Application;
using STX_Driver.src.Persistance.CardRepository.VehicleRepository;

namespace STX_Driver.tests
{
    public class TestVehicle : ITestVehicle
    {
        ISTXOperation engine = null;
        public TestVehicle()
        {
            engine = new STXEngine("com1", "Data Source=192.168.1.5\\DARTSYSTEM;Initial Catalog=CTL_Group;Persist Security Info=True;User ID=sa;Password=junak");
        }

        public void Test_LoadVehicle()
        {
            try
            {
               IRepositoryOfVehicle vehicle = new RepositoryOfVehicle(1004);
               var car = vehicle.GetVehicle();
               Console.WriteLine("Vehicle {0}", car.NumReg);

            }
            catch (Exception ex)
            {
                Console.WriteLine("TestVehicle.Test_LoadVehicle: {0}", ex.Message); ;
            }
        }
    }
}
