using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;
using InsERT;

namespace STX_Driver.src.Domain.Entities.Cards
{
    class CardFlota : CardBase
    {
        public CardFlota(int id) : base(id)
        {

        }
        public int Points { get; set; }
        public int DiscountId { get; set; }
        public List<DiscountValue> Discounts { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public SubiektDokumentEnum DocumentType { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
