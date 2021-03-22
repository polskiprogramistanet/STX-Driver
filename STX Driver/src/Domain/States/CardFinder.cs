using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProtocols.STX.Commands;
using STX_Driver.src.Domain.Entities;
using STX_Driver.src.Persistance.CardRepository;
using STX_Driver.src.Domain.Entities.Cards;
using STX_Driver.src.Common.TextInfoModeling;

namespace STX_Driver.src.Domain.States
{
    class CardFinder : IState
    {
        I_STXCommand command = null;
        IReaderOperation operation = null;
        string codeCard;
        Context context;
        IRepositoryOfCardOperation repository = null;
        InfoModelBase Info;

        public CardFinder(string code, IReaderOperation obj)
        {
            this.operation = obj;
            this.codeCard = code;
            this.Info = new FinderOfCard();
            this.repository = new RepositoryOfCard(code);
        }
        public void SetContext(Context context)
        {
            this.context = context;
        }
        public void SetExecute()
        {
            try
            {
                command = new STXCmdSetText(this.operation.Adress, Info.GetFontInformation(), Info.GetInformationText());
                this.operation.AddCommand(this.command);

                CardFlota card = repository.GetCard();
                this.operation.SetCard(card);

            }
            catch (Exception ex)
            {
                Console.WriteLine("CardFinder.SetExecute: {0}", ex.Message);
            }
        }
    }
}
