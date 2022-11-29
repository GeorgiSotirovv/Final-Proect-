using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Humidors;


namespace CigarWorld.Models.JustModels
{
    public class AllHumidorViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxBrandLenght, MinimumLength = MinBrandLenght)]
        public string Brand { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(MinHeightLenght, MaxHeightLenght)]
        public double Height { get; set; } //The unit of measure is CM

        [Required]
        [Range(MinLengthLenght, MaxLengthLenght)]
        public double Length { get; set; } //The unit of measure is CM

        [Required]
        [Range(MinWeightLenght, MinWeightLenght)]
        public double Weight { get; set; } //The unit of measure is Kg

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
    }
}
