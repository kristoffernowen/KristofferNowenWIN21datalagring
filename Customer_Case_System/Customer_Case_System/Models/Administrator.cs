using System;
using System.Collections.Generic;

namespace Customer_Case_System.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            CaseDetails = new HashSet<CaseDetail>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<CaseDetail> CaseDetails { get; set; }
    }
}
