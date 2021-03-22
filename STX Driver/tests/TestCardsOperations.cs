using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Persistance.CardRepository;
using STX_Driver.src.Domain.Entities.Cards;
using STX_Driver.src.Application;

namespace STX_Driver.tests
{
    public class TestCardsOperations : ITestCardsOperations
    {
        public TestCardsOperations()
        {
            ISTXOperation init = new STXEngine("com3", "Data Source=192.168.1.5\\INSERTGT;Initial Catalog=BudTrans2012;Persist Security Info=True;User ID=sa;Password=junak");
        }
        public void TestLoadCard(string codeNum)
        {
            CardFlota card = null;

            IRepositoryOfCardOperation repository = new RepositoryOfCard("05004A0E85C4");
            card = repository.GetCard();
            Console.WriteLine("Karta numer = {0}", card.CardNumber);
            foreach(var e in card.Discounts)
            {
                Console.WriteLine("Rabat = paliwo={0} cena={1} cena z rabatem={2} rabat={3}", e.FuelName, e.Price[0], e.PriceOfDiscount[0], e.Discount);
            }

            Console.WriteLine("Kontrahent : {0}", card.Customer.Name);

            Console.WriteLine("Kierowca : {0}", card.Driver.LastName);
            if(card.Vehicle!=null)
                Console.WriteLine("Pojazd : {0}", card.Vehicle.NumReg);
        }
    }
}
