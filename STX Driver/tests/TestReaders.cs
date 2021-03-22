using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Application;
using STX_Driver.src.Persistance.Readers;
using STX_Driver.src.Domain.Observers;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.tests
{
    public class TestReaders : ITestReaders, IObserverFromReaderToEngine
    {
        ISTXOperation init = null;
        public TestReaders()
        {
            init = new STXEngine("com3", "Data Source=192.168.1.5\\DARTSYSTEM;Initial Catalog=CTL_Group;Persist Security Info=True;User ID=sa;Password=junak");
        }

        public void ChangeCounter(int currentValue)
        {
            Console.WriteLine("zmiana {0}", currentValue.ToString());
        }

        public void SetNumberOfSesionInDataBase(int num, IReader reader)
        {
            throw new NotImplementedException();
        }

        public void TestLoadReaders()
        {
            try
            {
                Reader reader;
                IRepositoryOfReaders readers = new RepositoryOfReaders(new System.IO.Ports.SerialPort("com3"), this);
                reader = readers.GetItem((object)1);

                Console.WriteLine("Reader Name {0} / Adres: {1}", reader.Name ,reader.Adress);

            }
            catch (Exception ex)
            {
                Console.WriteLine("TestLoadReaders: {0}", ex.Message);
            }
        }
    }
}
