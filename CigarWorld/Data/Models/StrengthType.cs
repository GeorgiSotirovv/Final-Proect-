using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models
{
    public class StrengthType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; } = null!;
    }
}
