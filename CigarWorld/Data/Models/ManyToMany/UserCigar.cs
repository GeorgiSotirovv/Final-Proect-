using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.ManyToMany
{
    public class UserCigar
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Required]
        public int CigarId { get; set; }

        public Cigar Cigar { get; set; }
    }
}
