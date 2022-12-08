using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigarillo;
using static CigarWorld.Data.DataConstants.Humidors;

namespace CigarWorld.Models.EditViewModels
{
    public class EditHumidorViewModel : BaseEditViewModel
    {
        [Required]
        [Range(MinHeightLenght, MaxHeightLenght)]
        public double Height { get; set; } //The unit of measure is CM

        [Required]
        [Range(MinLengthLenght, MaxLengthLenght)]
        public double Length { get; set; } //The unit of measure is CM

        [Required]
        [Range(MinWeightLenght, MaxWeightLenght)]
        public double Weight { get; set; } //The unit of measure is Kg

        [Required]
        [StringLength(MaxMaterialOfManufactureLenght, MinimumLength = MinMaterialOfManufactureLenght)]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        [Range(MinCapacityLenght, MaxCapacityLenght)]
        public int Capacity { get; set; }
    }
}
