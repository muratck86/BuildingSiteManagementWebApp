namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class SiteInvoice : BaseInvoice
    {
        public string Payee { get; set; }
        public byte[] InvoiceFile { get; set; }
    }
}
