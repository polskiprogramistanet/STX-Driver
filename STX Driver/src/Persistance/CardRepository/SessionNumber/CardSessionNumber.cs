using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Persistance.CardRepository.SessionNumber
{
    class CardSessionNumber : ISetCardNumberSessionOperationInDataBase
    {
        int num = 0;
        int id = 0;
        public CardSessionNumber(int num, int id)
        {
            this.num = num;
            this.id = id;
        }

        public void Execute()
        {
            try
            {

                DataService.GetDataSQLNonQuery("UPDATE [dbo].[Fuel_CardReader] SET [crd_Session] = " + num + " WHERE [crd_id] = " + id + "");

            }
            catch (Exception ex)
            {
                Console.WriteLine("CardSessionNumber.Execute: {0}", ex.Message);
            }
        }
    }
}
