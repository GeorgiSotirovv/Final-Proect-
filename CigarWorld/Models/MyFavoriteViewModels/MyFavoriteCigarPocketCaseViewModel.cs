using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.CigarPocketCase;

namespace CigarWorld.Models.MyFavoriteViewModels
{
    public class MyFavoriteCigarPocketCaseViewModel : BaseFavoriteModel
    {
        [Required]
        [StringLength(MaxMaterialOfManufactureLenght, MinimumLength = MinMaterialOfManufactureLenght)]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        public int Capacity { get; set; }
    }
}
