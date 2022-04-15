using System;

namespace BuildingSiteManagementWebApp.Data.Entities
{
    public abstract class BaseInvoice : BaseEntity
    {
        public DateTime IssueDate { get; set; }
        public decimal InvAmount { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
    }
}
