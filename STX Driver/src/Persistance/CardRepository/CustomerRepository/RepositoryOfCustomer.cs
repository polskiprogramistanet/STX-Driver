using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Entities;

namespace STX_Driver.src.Persistance.CardRepository.CustomerRepository
{
    class RepositoryOfCustomer : IDataBase, IRepositoryOfCustomer
    {
        string query = null;
        Customer item = null;
        public RepositoryOfCustomer(int id)
        {
            this.query = "SELECT [adr_IdObiektu],[adr_Nazwa],[adr_NazwaPelna],[adr_NIP],[adr_Adres],[adr_Telefon],[kh_EMail] FROM [dbo].[adr__Ewid] LEFT JOIN [dbo].[kh__Kontrahent] ON [adr_IdObiektu]=[kh_Id] WHERE [adr_TypAdresu] = 1 AND [adr_IdObiektu]=" + id + ";";
            DataService.SetQuery(this.query, this);
        }

        public object DbReader(IDataReader rd)
        {
            try
            {
                
                while (rd.Read())
                {
                    item = new Customer((int)rd[0]);
                    item.Name = rd[1].ToString();
                    item.FullName = rd[2].ToString();
                    item.NIP = rd[3].ToString();
                    item.Adress = rd[4].ToString();
                    item.PhoneNumber = rd[5].ToString();
                    item.Email = rd[6].ToString();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Customer GetCustomer()
        {
            return item;
        }
    }
}
