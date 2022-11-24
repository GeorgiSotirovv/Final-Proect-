using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.ManyToMany
{
    public class UserCutter
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Required]
        public int CutterId { get; set; }

        public Cutter Cutter { get; set; }
    }
}
