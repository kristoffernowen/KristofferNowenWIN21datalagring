using System;

namespace Customer_Case_System.Models
{
    internal class CaseWithCustomerInfo
    {
        public string? Header{ get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public DateTime ? CreatedDate { get; set; }
        public DateTime ? ModifiedDate { get; set; }
    }
}
