using BuildingSiteManagementWebApp.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BuildingSiteManagementWebApp.Models
{
    public class ResidenceInputModel
    {
        [Required]
        public int BuildingId { get; set; }
        [Required]
        public string Floor { get; set; }
        [Required]
        public int DoorNo { get; set; }
        [Required]
        public int ResidenceType { get; set; }
    }
}
