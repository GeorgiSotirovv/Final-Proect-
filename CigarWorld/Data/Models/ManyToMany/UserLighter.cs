using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.ManyToMany
{
    public class UserLighter
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Required]
        public int LighterId { get; set; }

        public Lighter Lighter { get; set; }
    }
}
