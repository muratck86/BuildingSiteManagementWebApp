namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class Residence : BaseEntity
    {
        public string Floor { get; set; }
        public int DoorNo { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public ResidenceType ResidenceType { get; set; }
    }
}
