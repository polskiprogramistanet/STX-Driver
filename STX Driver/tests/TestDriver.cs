using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Application;
using STX_Driver.src.Persistance.CardRepository.DriverRepository;

namespace STX_Driver.tests
{
    public class TestDriver : ITestDriver
    {
        ISTXOperation engine = null;
        public TestDriver()
        {
            engine = new STXEngine("com1", "Data Source=192.168.1.5\\DARTSYSTEM;Initial Catalog=CTL_Group;Persist Security Info=True;User ID=sa;Password=junak");
        }

        public void Test_LoadDriver()
        {
            try
            {
                IRepositoryOfDriver driver = new RepositoryOfDriver(0);
                var drv = driver.GetDriver();
                if(drv!=null) 
                    Console.WriteLine("Driver {0}", drv.FirstName + " " + drv.LastName);
                else
                    Console.WriteLine("Brak drivera");
            }
            catch (Exception ex)
            {
                Console.WriteLine("TestDriver.Test_LoadDriver: {0}", ex.Message); ;
            }
        }

    }
}
