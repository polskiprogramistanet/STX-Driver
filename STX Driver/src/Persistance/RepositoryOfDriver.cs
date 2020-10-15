using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Entities;


namespace STX_Driver.src.Persistance
{
    class RepositoryOfDriver : IDataBase, IRepositoryOfDriver
    {
        string query = null;
        Driver item = null;
        public RepositoryOfDriver(int id)
        {
            query = "SELECT [drv_Id],[drv_FirstName],[drv_LastName],[drv_IdKh],[drv_Block] FROM [dbo].[Fuel_Drivers] WHERE [drv_Id]=" + id + ";";
        }

        public Driver Execute()
        {
            DataService.SetQuery(query, this);
            return item;
        }
        public object DbReader(IDataReader rd)
        {
            try
            {
                while (rd.Read())
                {
                    item = new Driver((int)rd[0]);
                    item.FirstName = rd[1].ToString().Trim();
                    item.LastName = rd[2].ToString().Trim();
                    item.CustomerId = (int)rd[3];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return item;
        }
    }
}
