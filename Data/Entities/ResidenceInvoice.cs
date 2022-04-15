namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class ResidenceInvoice : BaseInvoice
    {
        public int Type { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public int ResidenceId { get; set; }
        public Residence Residence { get; set; }
    }
}
