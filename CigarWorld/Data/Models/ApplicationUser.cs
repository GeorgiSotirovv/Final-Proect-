using CigarWorld.Data.Models.ManyToMany;
using Microsoft.AspNetCore.Identity;

namespace CigarWorld.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Introduction { get; set; } = "Empry";
        public string ProfilePictureUrl { get; set; } = "Empry";

        public ICollection<UserCigar> UserCigars { get; set; } = new HashSet<UserCigar>();
        public ICollection<UserAshtray> UserAshtrays { get; set; } = new HashSet<UserAshtray>();
        public ICollection<UserCutter> UserCutters { get; set; } = new HashSet<UserCutter>();
        public ICollection<UserCigarPocketCase> UserCigarPocketCases { get; set; } = new HashSet<UserCigarPocketCase>();
        public ICollection<UserCigarillo> UserCigarillos { get; set; } = new HashSet<UserCigarillo>();
        public ICollection<UserHumidor> UserHumidors { get; set; } = new HashSet<UserHumidor>();

    }
}
