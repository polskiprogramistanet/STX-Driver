using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Entities;
using System.IO.Ports;
using STX_Driver.src.Domain.Observers;

namespace STX_Driver.src.Persistance
{
    class RepositoryOfReaders : IDataBase, IRepositoryOfReader
    {
        List<Reader> readers;
        string query=null;
        SerialPort port=null;
        IObserverFromReaderToEngine observer = null;
        public RepositoryOfReaders(SerialPort port, IObserverFromReaderToEngine observer)
        {
            this.query = "SELECT [crd_id],[crd_ModelId],[crd_ModelName],[crd_Num],[crd_Adress],[crd_DSN],[crd_CDN],[crd_Session]FROM [dbo].[Fuel_CardReader] ORDER BY [crd_DSN];";
            this.port = port;
            this.observer = observer;
            DataService.SetQuery(this.query, this);
        }
        public object DbReader(IDataReader rd)
        {
            try
            {
                this.readers = new List<Reader>();
                while (rd.Read())
                {
                    Reader item = new Reader(port, (int)rd[6] + 1, observer);
                    item.DSN = (int)rd[5];
                    item.Id = (int)rd[0];
                    item.Name = rd[2].ToString().Trim();
                    item.Number = (int)rd[3];
                    item.SetNumberOfSession((int)rd[7]);
                    this.readers.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public List<Reader> GetItems()
        {
            return readers;
        }

        public void SetSessionNumberToReader(int num, Reader reader)
        {
            try
            {

                DataService.GetDataSQLNonQuery("UPDATE [dbo].[Fuel_CardReader] SET [crd_Session] = " + num + " WHERE [crd_id] = " + reader.Id +"");
            }
            catch (Exception ex)
            {
                Console.WriteLine("RepositoryOfReaders.SetSessionNumberToReader: {0}", ex.Message);
            }
        }
    }
}
