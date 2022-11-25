using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.ManyToMany
{
    public class UserCigarPocketCase
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Required]
        public int CigarPocketCaseId { get; set; }

        public CigarPocketCase CigarPocketCase { get; set; }
    }
}
