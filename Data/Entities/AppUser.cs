using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class AppUser : IdentityUser, IEntity
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Message> SentMessages { get; set; }
        public List<Message> ReceivedMessages { get; set; }

        public List<Residence> OwnedResidences { get; set; }
        public List<Residence> RentedResidences { get; set; }
    }
}
