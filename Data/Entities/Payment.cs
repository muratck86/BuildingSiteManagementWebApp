using System;

namespace BuildingSiteManagementWebApp.Data.Entities
{

    public class Payment : BaseEntity
    {
        public DateTime PaymentDate { get; set; }

        public int InvoiceId { get; set; }
        public BaseInvoice Invoice { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
