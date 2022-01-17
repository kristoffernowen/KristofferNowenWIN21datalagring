using System;
using System.Collections.Generic;

namespace Customer_Case_System.Models
{
    public partial class ContactInfo
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; } = null!;
        public string PrimaryPhoneNumber { get; set; } = null!;
        public string SecondaryPhoneNumber { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}
