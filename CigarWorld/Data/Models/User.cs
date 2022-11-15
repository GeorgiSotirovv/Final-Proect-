using Microsoft.AspNetCore.Identity;

namespace CigarWorld.Data.Models
{
    public class User : IdentityUser
    {
        public string Introduction { get; set; } = "Empry";
        public string ProfilePictureUrl { get; set; } = "Empry";

        public ICollection<Cigar> Cigars { get; set; } = new HashSet<Cigar>();
        public ICollection<Ashtray> Ashtrays { get; set; } = new HashSet<Ashtray>();
        public ICollection<Cutter> Cutters { get; set; } = new HashSet<Cutter>();
        public ICollection<Humidor> Humidors { get; set; } = new HashSet<Humidor>();
        public ICollection<Lighter> Lighters { get; set; } = new HashSet<Lighter>();
        public ICollection<Cigarillo> Cigarillos { get; set; } = new HashSet<Cigarillo>();
        public ICollection<CigarPocketCase> CigarPocketCases { get; set; } = new HashSet<CigarPocketCase>();
    }
}
