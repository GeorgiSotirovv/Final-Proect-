using CigarWorld.Models.ShowAllItemsViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Lighter;

namespace CigarWorld.Models.JustModels
{
    public class AllLighterViewModel : BaseAllViewModel
    {
        public bool IsFavorite { get; set; }
    }
}
