using System;
using System.Collections.Generic;

namespace Customer_Case_System.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CaseNumbers = new HashSet<CaseNumber>();
            ContactInfos = new HashSet<ContactInfo>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public int? AddressId { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<CaseNumber> CaseNumbers { get; set; }
        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
