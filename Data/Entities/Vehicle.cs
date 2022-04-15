namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Plate { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsDeleted { get; set; }

        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
    }
}
