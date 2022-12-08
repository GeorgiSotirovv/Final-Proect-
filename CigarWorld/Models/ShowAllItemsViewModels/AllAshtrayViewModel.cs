using CigarWorld.Data.Models;
using CigarWorld.Models.ShowAllItemsViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Ashtray;
namespace CigarWorld.Models.BaseModels
{
    public class AllAshtrayViewModel : BaseAllViewModel
    {
        public string Type { get; set; } = null!;

        public bool IsFavorite { get; set; }
    }
}
