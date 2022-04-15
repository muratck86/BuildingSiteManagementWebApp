namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class Residence : BaseEntity
    {
        public int Floor { get; set; }
        public int No { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
