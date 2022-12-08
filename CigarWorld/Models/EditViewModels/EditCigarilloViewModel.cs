using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigarillo;

namespace CigarWorld.Models.EditViewModels
{
    public class EditCigarilloViewModel : BaseEditViewModel
    {
        public int FiterId { get; set; }

        public IEnumerable<FilterType> FilterTypes { get; set; } = new List<FilterType>();
    }
}
