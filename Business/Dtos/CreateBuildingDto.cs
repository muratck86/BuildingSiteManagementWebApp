namespace BuildingSiteManagementWebApp.Business.Dtos
{
    public class CreateBuildingDto
    {
        public string Name { get; set; }
        public int Floors { get; set; }
        public int Basements { get; set; }
        public bool HasRoof { get; set; }
    }
}
