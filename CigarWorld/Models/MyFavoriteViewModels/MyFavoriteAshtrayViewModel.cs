using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.MyFavoriteViewModels
{
    public class MyFavoriteAshtrayViewModel : BaseFavoriteModel
    {
        public string AshtrayType { get; set; }

        public IEnumerable<AshtrayType> AshtrayTypes { get; set; } = new List<AshtrayType>();
    }
}
