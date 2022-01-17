using System;
using System.Collections.Generic;

namespace Customer_Case_System.Models
{
    public partial class CaseDetail
    {
        public int Id { get; set; }
        public int CaseNumbersId { get; set; }
        public string CaseDescription { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public DateTime DateOfLastChange { get; set; }
        public int StatusId { get; set; }
        public int? AdministratorId { get; set; }

        public virtual Administrator? Administrator { get; set; }
        public virtual CaseNumber CaseNumbers { get; set; } = null!;
        public virtual StatusOfCase Status { get; set; } = null!;
    }
}
