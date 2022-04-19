namespace BuildingSiteManagementWebApp.Models
{
    public class BuildingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfFloors { get; set; }
        public int Basements { get; set; }
        public bool HasRoof { get; set; }
        public int NumberOfResidences { get; set; }
    }
}
