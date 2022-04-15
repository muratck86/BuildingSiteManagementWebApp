using System.ComponentModel.DataAnnotations;

namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; set; }
        public int Floors { get; set; }
    }
}
