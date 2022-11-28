using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.Reviews
{
    public class CigarilloReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Review { get; set; }

        [Required]

        public int CigarilloId { get; set; }
    }
}
