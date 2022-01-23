using System;
using System.Collections.Generic;

namespace Customer_Case_System.Models
{
    public partial class StatusOfCase
    {
        public const int StatusUnprocessed = 1;
        public const int StatusBeingProcessed = 2;
        public const int StatusClosed = 3;
        public StatusOfCase()
        {
            CaseDetails = new HashSet<CaseDetail>();
        }

        public int Id { get; set; }
        public string StatusOfCase1 { get; set; } = null!;

        public virtual ICollection<CaseDetail> CaseDetails { get; set; }
    }
}
