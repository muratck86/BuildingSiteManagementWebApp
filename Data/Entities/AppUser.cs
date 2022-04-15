using Microsoft.AspNetCore.Identity;

namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class AppUser : IdentityUser, IEntity
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
