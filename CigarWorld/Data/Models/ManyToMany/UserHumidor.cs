using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.ManyToMany
{
    public class UserHumidor
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Required]
        public int HumidorId { get; set; }

        public Humidor Humidor { get; set; }
    }
}
