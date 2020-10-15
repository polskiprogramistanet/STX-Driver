using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;


namespace STX_Driver.src.Domain.Entities.Cards
{
    abstract class CardBase
    {
        public CardBase(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string CardCode { get; set; }
        public string CardNumber { get; set; }
        public string PINCode { get; set; }
        public int PINActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime LastUsingDate { get; set; }
        public int SendEmail { get; set; }
        public int SendSMS { get; set; }
        public CardTypeEnum CardType { get; set; }
        public StatusCardEnum State { get; set; }
    }
}
