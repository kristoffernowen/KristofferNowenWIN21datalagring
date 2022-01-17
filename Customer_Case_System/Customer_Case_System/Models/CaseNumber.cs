using System;
using System.Collections.Generic;

namespace Customer_Case_System.Models
{
    public partial class CaseNumber
    {
        public CaseNumber()
        {
            CaseDetails = new HashSet<CaseDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Header { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<CaseDetail> CaseDetails { get; set; }
    }
}
