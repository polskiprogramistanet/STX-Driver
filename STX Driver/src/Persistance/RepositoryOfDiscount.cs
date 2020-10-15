using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance
{
    class RepositoryOfDiscount : IDataBase, IRepositoryOfDiscount
    {
        List<DiscountValue> items = null;
        string query = null;
        public RepositoryOfDiscount(int id)
        {
            this.query = "SELECT [Id],[ProductId],[ProductName],[ProductDiscount],[ProductPRC],[HeaderId],[tc_CenaBrutto1],[tc_CenaBrutto2],[tc_CenaBrutto3] FROM [dbo].[Fuel_DiscPositions] LEFT JOIN [dbo].[tw_Cena] ON [ProductId]=[tc_IdTowar] WHERE [HeaderId]=" + id + ";";
        }

        public List<DiscountValue> Execute()
        {
            DataService.SetQuery(this.query, this);
            return items;
        }

        public object DbReader(IDataReader rd)
        {
            try
            {
                items = new List<DiscountValue>();
                while (rd.Read())
                {
                    DiscountValue item = new DiscountValue();
                    item.Id = (int)rd[0];
                    item.IdFuel = (int)rd[1];
                    item.FuelName = rd[2].ToString();
                    item.Discount = (decimal)rd[3];
                    item.ProductPRC = rd[4].ToString();
                    item.Price = new decimal[3];
                    item.Price[0] = (decimal)rd[6];
                    item.Price[1] = (decimal)rd[7];
                    item.Price[2] = (decimal)rd[8];
                    item.PriceOfDiscount = new decimal[3];
                    if(item.Price[0]> item.Discount)
                        item.PriceOfDiscount[0] = item.Price[0] - item.Discount;
                    if (item.Price[1] > item.Discount)
                        item.PriceOfDiscount[1] = item.Price[1] - item.Discount;
                    if (item.Price[2] > item.Discount)
                        item.PriceOfDiscount[2] = item.Price[2] - item.Discount;
                    items.Add(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
