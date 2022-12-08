using CigarWorld.Data.Models;
using CigarWorld.Models.AddViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.CigarPocketCase;

namespace CigarWorld.Models.AddModels
{
    public class AddCigarPocketCaseViewModel : BaseAddViewModel
    {
        [Required]
        [StringLength(MaxMaterialOfManufactureLenght, MinimumLength = MinMaterialOfManufactureLenght)]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        [Range(MinCapacityLenght, MaxCapacityLenght)]
        public int Capacity { get; set; }
    }
}
