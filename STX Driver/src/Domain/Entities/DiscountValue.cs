using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Entities
{
    class DiscountValue 
    {
        public int Id { get; set; }
        public int IdFuel { get; set; }
        public string FuelName { get; set; }
        public decimal []Price { get; set; }
        public decimal Discount { get; set; }
        public decimal []PriceOfDiscount { get; set; }
        public string ProductPRC { get; set; }
    }
}
