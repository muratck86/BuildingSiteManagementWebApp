using System;

namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class Resident : AppUser
    {
        public DateTime MoveInDate { get; set; } = DateTime.Now;
        public DateTime? MoveOutDate { get; set; } = null;

        public int ResidenceId { get; set; }
        public Residence Residence { get; set; }

    }
}
