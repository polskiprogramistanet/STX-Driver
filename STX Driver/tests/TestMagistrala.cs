using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.STX.Commands;
using STX_Driver.src.Application;
using STX_Driver.src.Domain.Dispatcher;
using STX_Driver.src.Domain.Observers;
using STX_Driver.src.Domain.Entities;
using STX_Driver.src.Persistance.Readers;

namespace STX_Driver.tests
{
    public class TestMagistrala : ITestMagistrala, IObserverDispatcher
    {
        ISTXOperation engine = null;
        IRepositoryOfReaders readers;
        Magistrala mag = null;
        Reader reader = null;

        public TestMagistrala()
        {
            engine = new STXEngine("com1", "Data Source=192.168.1.5\\DARTSYSTEM;Initial Catalog=CTL_Group;Persist Security Info=True;User ID=sa;Password=junak");
            readers = new RepositoryOfReaders(new System.IO.Ports.SerialPort("com1"), null);
            mag = new Magistrala(this);
        }
        public void SetData(byte[] buffor)
        {
            reader = readers.GetItem(0);
            mag.Init(buffor, reader);
        }

        public void SetNumberOfSession(int number)
        {
            throw new NotImplementedException();
        }
        public void AddCommand(I_STXCommand command)
        {
            throw new NotImplementedException();
        }

        public void GetCard(string code)
        {
            throw new NotImplementedException();
        }
    }
}
