using CigarWorld.Models.ShowAllItemsViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cutter;

namespace CigarWorld.Models.Models
{
    public class AllCutterViewModel : BaseAllViewModel
    {
        public string Type { get; set; } = null!;

        public bool IsFavorite { get; set; }
    }
}
