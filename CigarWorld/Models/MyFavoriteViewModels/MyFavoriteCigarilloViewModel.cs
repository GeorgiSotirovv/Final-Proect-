using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.MyFavoriteViewModels
{
    public class MyFavoriteCigarilloViewModel : BaseFavoriteModel
    {
        public string FilterType { get; set; }

        public IEnumerable<FilterType> FilterTypes { get; set; } = new List<FilterType>();
    }
}
