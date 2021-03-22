using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.Entities
{
    public class Driver
    {
        public Driver(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerId { get; set; }
    }
}
