using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReadabilityDemo.Contracts
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? WeddingDate { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? LastVisitedAtStore { get; set; }
    }
}
