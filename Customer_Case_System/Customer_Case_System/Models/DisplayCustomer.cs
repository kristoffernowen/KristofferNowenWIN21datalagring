using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Case_System.Models
{
    public class DisplayCustomer 
    {
        public Customer Names { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public ContactInfo ContactInfo { get; set; } = null!;
    }
}
