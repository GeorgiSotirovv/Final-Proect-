using CigarWorld.Data.Models.ManyToMany;
using Microsoft.AspNetCore.Identity;

namespace CigarWorld.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Introduction { get; set; } = "Empry";
        public string ProfilePictureUrl { get; set; } = "Empry";

        public ICollection<UserCigar> UserCigar { get; set; } = new HashSet<UserCigar>();

    }
}
