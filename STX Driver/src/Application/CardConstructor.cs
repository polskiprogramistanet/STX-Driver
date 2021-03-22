using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Persistance;
using STX_Driver.src.Domain.Entities.Cards;
using STX_Driver.src.Domain.Observers;
using STX_Driver.src.Persistance.CardRepository;

namespace STX_Driver.src.Application
{

    class CardConstructor : ICardConstructor
    {
        IRepositoryOfCardOperation repository = null;
       
        public CardFlota Card { get; private set; }
        public CardConstructor(string codecard)
        {
            try
            {
                repository = new RepositoryOfCard(codecard);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Card constructor error: {0}", ex.Message);
            }
        }
        public CardFlota Execute()
        {
           this.Card = repository.GetCard();
            return Card;
        }
    }
}
