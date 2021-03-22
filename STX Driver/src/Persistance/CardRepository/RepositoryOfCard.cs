using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Entities.Cards;
using STX_Driver.src.Common.Enums;
using STX_Driver.src.Persistance.CardRepository.VehicleRepository;
using STX_Driver.src.Persistance.CardRepository.DriverRepository;
using STX_Driver.src.Persistance.CardRepository.DiscountRepository;
using STX_Driver.src.Persistance.CardRepository.CustomerRepository;
using InsERT;

namespace STX_Driver.src.Persistance.CardRepository
{
    class RepositoryOfCard : IDataBase, IRepositoryOfCardOperation
    {
        string query = null;
        CardFlota card = null;
        IRepositoryOfDiscount discount = null;
        IRepositoryOfCustomer customer = null;
        IRepositoryOfDriver driver = null;
        IRepositoryOfVehicle vehicle = null;

        public RepositoryOfCard(string codeCard)
        {
            query = "SELECT [Id],[CodeCard],[NumberCard],[CreateDate],[ExpirationDate],[LastUsingDate],[Points],[DiscountId],[CustomerId],[TypeCard],[TypeDocument],[State],[DriverId],[VehicleId],[PrePayId],[PinCode],[PinActive],[LimitCountDocs],[LimitAmountDocs],[LimitDateDocs],[SendEmailOfWelcome],[SendEmailOfTransaction],[ScenarioId] FROM [dbo].[Fuel_Cards] WHERE [CodeCard]='" + codeCard + "';";
        }

        public CardFlota GetCard()
        {
            try
            {
                DataService.SetQuery(query, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CardFlota GetCard: {0}", ex.Message); 
            }
            return card;
        }

        public object DbReader(IDataReader rd)
        {
            try
            {
                while (rd.Read())
                {
                     
                            card = new CardFlota((int)rd[0]);
                            card.CardCode = rd[1].ToString();
                            card.CardNumber = rd[2].ToString();
                            card.CreationDate = (DateTime)rd[3];
                            card.ExpirationDate = (DateTime)rd[4];
                            card.LastUsingDate = (DateTime)rd[5];
                            card.Points = (int)rd[6];
                            card.DiscountId = (int)rd[7];
                            discount = new RepositoryOfDiscount(card.DiscountId);
                            card.Discounts = discount.GetDiscounts();
                            card.CustomerId = (int)rd[8];
                            customer = new RepositoryOfCustomer(card.CustomerId);
                            card.Customer = customer.GetCustomer();
                            card.DocumentType = (SubiektDokumentEnum)rd[10];
                            card.State = (StatusCardEnum)rd[11];
                            card.DriverId = (int)rd[12];
                            driver = new RepositoryOfDriver(card.DriverId);
                            card.Driver = driver.GetDriver();
                            card.VehicleId = (int)rd[13];
                            vehicle = new RepositoryOfVehicle(card.VehicleId);
                            card.Vehicle = vehicle.GetVehicle();
                            card.PINCode = rd[15].ToString().Trim();
                            card.PINActive = (int)rd[16];
                            card.SendEmail = (int)rd[21];

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DbReader: {0}", ex.Message); 

            }
            return null;
        }
    }
}
