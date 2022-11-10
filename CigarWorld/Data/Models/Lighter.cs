using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Lighter;

namespace CigarWorld.Data.Models
{
    public class Lighter
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(MaxBrandLenght, MinimumLength = MinBrandLenght)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(MaxCountryOfManufacturingLenght, MinimumLength = MinCountryOfManufacturingLenght)]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(MaxCommentLenght, MinimumLength = MinCommentLenght)]
        public string Comment { get; set; } = null!;
    }
}
