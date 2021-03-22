using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Entities
{
    class FuelTransaction
    {
        public int Id { get; set; }
        public int FuelId { get; set; }
        public int DSN { get; set; }
        public decimal Price { get; set; }
        public decimal PriceDiscount { get; set; }
        public decimal Volume { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountDiscount { get; set; }
    }
}
