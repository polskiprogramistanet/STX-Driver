using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Entities
{
    class Customer
    {
        public Customer(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NIP { get; set; }
        public string Adress { get; set; }
    }
}
