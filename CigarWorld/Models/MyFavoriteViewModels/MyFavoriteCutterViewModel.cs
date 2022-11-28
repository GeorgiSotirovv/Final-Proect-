using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.MyFavoriteViewModels
{
    public class MyFavoriteCutterViewModel : BaseFavoriteModel
    {
        [Required]
        public string Type { get; set; }

        public IEnumerable<CutterType> CutterTypes { get; set; } = new List<CutterType>();
    }
}
