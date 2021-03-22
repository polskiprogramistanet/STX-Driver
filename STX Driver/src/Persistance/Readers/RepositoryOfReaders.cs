using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Entities;
using System.IO.Ports;
using STX_Driver.src.Domain.Observers;

namespace STX_Driver.src.Persistance.Readers
{
    class RepositoryOfReaders : IDataBase, IRepositoryOfReaders
    {
        List<Reader> items;
        string query=null;
        SerialPort port=null;
        IObserverFromReaderToEngine observer = null;

        public RepositoryOfReaders(SerialPort port, IObserverFromReaderToEngine observer)
        {
            this.query = "SELECT [crd_id],[crd_ModelId],[crd_ModelName],[crd_Num],[crd_Adress],[crd_DSN],[crd_CDN],[crd_Session] FROM [dbo].[Fuel_CardReader] ORDER BY [crd_DSN];";
            this.port = port;
            this.observer = observer;
            DataService.SetQuery(this.query, this);
        }
        public object DbReader(IDataReader rd)
        {
            try
            {
                this.items = new List<Reader>();
                while (rd.Read())
                {
                    Reader item = new Reader(port, int.Parse(rd[4].ToString()), observer);
                    item.DSN = (int)rd[5];
                    item.Id = (int)rd[0];
                    item.Name = rd[2].ToString().Trim();
                    item.Number = (int)rd[3];
                    item.SetNumberOfSession((int)rd[7]);
                    item.CDN = (int)rd[6];
                    this.items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
            return null;
        }

        public Reader GetItem(string address)
        {
            if (this.items.Count == 0) throw new Exception("Brak czytników");
            return this.items.Find(x => x.Adress.ToString() == address);
        }

        public Reader GetItem(int i)
        {
            if (this.items.Count == 0) throw new Exception("Brak czytników");
            return this.items[i];
        }

        public Reader GetItem(object num)
        {
            if (this.items.Count == 0) throw new Exception("Brak czytników");
            return this.items.Find(x => x.Number == (int)num);
        }

        public List<Reader> GetItems()
        {
            return items;
        }

        
    }
}
