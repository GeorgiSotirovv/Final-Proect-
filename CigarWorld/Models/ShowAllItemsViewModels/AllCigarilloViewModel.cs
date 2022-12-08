using CigarWorld.Models.ShowAllItemsViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigarillo;

namespace CigarWorld.Models.Models
{
    public class AllCigarilloViewModel : BaseAllViewModel
    {
        [Required]
        public string Filter { get; set; } = null!;

        public bool IsFavorite { get; set; }
    }
}
