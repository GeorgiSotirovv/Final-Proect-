using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CigarWorld.Data.DataConstants.Cigarillo;

namespace CigarWorld.Data.Models
{
    public class Cigarillo
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
        [StringLength(MaxCommentLenght, MinimumLength = MinCommentLenght)]
        public string Comment { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; }


        public int FiterId { get; set; }

        [ForeignKey(nameof(FiterId))]
        public FilterType? FilterType { get; set; }
    }
}
