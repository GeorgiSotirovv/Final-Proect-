using CigarWorld.Models.ShowAllItemsViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Humidors;


namespace CigarWorld.Models.JustModels
{
    public class AllHumidorViewModel : BaseAllViewModel
    {
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
        [StringLength(MaxMaterialOfManufactureLenght, MinimumLength = MinMaterialOfManufactureLenght)]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        [MinLength(MinCapacityLenght)]
        public int Capacity { get; set; }

        public bool IsFavorite { get; set; }
    }
}
