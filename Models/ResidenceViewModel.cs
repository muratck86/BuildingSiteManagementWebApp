using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;

namespace BuildingSiteManagementWebApp.Models
{
    public class ResidenceViewModel
    {
        public int Id { get; set; }
        public string Floor { get; set; }
        public int DoorNo { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<Resident> Residents { get; set; }
        public ResidenceType ResidenceType { get; set; }
    }
}
