using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.CigarPocketCase;

namespace CigarWorld.Models.JustModels
{
    public class AllCigarPocketCaseViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxBrandLenght, MinimumLength = MinBrandLenght)]
        public string Brand { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(MaxCountryOfManufacturingLenght, MinimumLength = MinCountryOfManufacturingLenght)]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        [StringLength(MaxMaterialOfManufactureLenght, MinimumLength = MinMaterialOfManufactureLenght)]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        [MinLength(MinCapacityLenght)]
        public int Capacity { get; set; }

        [Required]
        [StringLength(MaxCommentLenght, MinimumLength = MinCommentLenght)]
        public string Comment { get; set; } = null!;

        public bool IsFavorite { get; set; }
    }
}

