using Microsoft.AspNetCore.Identity;

namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class Person : IdentityUser
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
