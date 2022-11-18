using Microsoft.AspNetCore.Identity;

namespace CigarWorld.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Introduction { get; set; } = "Empry";
        public string ProfilePictureUrl { get; set; } = "Empry";

        public List<User> UserProducts { get; set; } = new List<User>();
    }
}
