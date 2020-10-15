using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance
{
    class RepositoryOfVehicle : IDataBase, IRepositoryOfVehicle
    {
        string query = null;
        Vehicle item = null;
        public RepositoryOfVehicle(int id)
        {
            query = "SELECT [car_id],[car_brand],[car_noReg],[car_idKh],[car_idDriver],[car_Type] FROM [dbo].[Fuel_Vehicles] WHERE [car_id] = " + id + ";";
        }

        public object DbReader(IDataReader rd)
        {
            try
            {
                while (rd.Read())
                {
                    item = new Vehicle((int)rd[0]);
                    item.Brand = rd[1].ToString().Trim();
                    item.NumReg = rd[2].ToString().Trim();
                    item.CustomerId = (int)rd[3];
                    item.DriverId = (int)rd[4];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Vehicle Execute()
        {

            return item;
        }
    }
}
