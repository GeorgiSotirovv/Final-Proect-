using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.MyFavoriteViewModels
{
    public class MyFavoriteHomidorViewModel : BaseFavoriteModel
    {
        [Required]
        public double Height { get; set; } //The unit of measure is CM

        [Required]
        public double Length { get; set; } //The unit of measure is CM

        [Required]

        public double Weight { get; set; } //The unit of measure is Kg

        [Required]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        public int Capacity { get; set; }

    }
}
