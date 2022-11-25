using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.ManyToMany
{
    public class UserAshtray
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Required]
        public int AshtrayId { get; set; }

        public Ashtray Ashtray { get; set; }
    }
}
