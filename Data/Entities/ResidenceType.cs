namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class ResidenceType : BaseEntity
    {
        public int ResidenceId { get; set; }
        public Residence Residence { get; set; }
        public int HomeTypeId { get; set; }
        public HomeType HomeType { get; set; }
    }
}
