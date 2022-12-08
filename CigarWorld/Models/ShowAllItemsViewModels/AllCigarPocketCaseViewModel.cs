using CigarWorld.Models.ShowAllItemsViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.CigarPocketCase;

namespace CigarWorld.Models.JustModels
{
    public class AllCigarPocketCaseViewModel : BaseAllViewModel
    {
        [Required]
        [StringLength(MaxMaterialOfManufactureLenght, MinimumLength = MinMaterialOfManufactureLenght)]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        [MinLength(MinCapacityLenght)]
        public int Capacity { get; set; }

        public bool IsFavorite { get; set; }
    }
}

