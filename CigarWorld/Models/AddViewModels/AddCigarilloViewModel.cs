using CigarWorld.Data.Models;
using CigarWorld.Models.AddViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigarillo;

namespace CigarWorld.Models.AddModels
{
    public class AddCigarilloViewModel : BaseAddViewModel
    {
        public int FiterId { get; set; }

        public IEnumerable<FilterType> FilterTypes { get; set; } = new List<FilterType>();
    }
}
