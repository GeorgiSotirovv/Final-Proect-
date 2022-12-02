using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigarillo;

namespace CigarWorld.Models.EditViewModels
{
    public class EditHumidorViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public double Height { get; set; } //The unit of measure is CM

        [Required]
        public double Length { get; set; } //The unit of measure is CM

        [Required]
        public double Weight { get; set; } //The unit of measure is Kg

        [Required]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        public int Capacity { get; set; }

        [Required]
        public string Comment { get; set; } = null!;
    }
}
