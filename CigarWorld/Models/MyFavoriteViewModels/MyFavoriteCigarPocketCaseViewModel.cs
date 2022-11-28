using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.MyFavoriteViewModels
{
    public class MyFavoriteCigarPocketCaseViewModel : BaseFavoriteModel
    {
        [Required]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        public int Capacity { get; set; }
    }
}
