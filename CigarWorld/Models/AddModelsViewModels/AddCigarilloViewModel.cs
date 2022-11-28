using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigarillo;

namespace CigarWorld.Models.AddModels
{
    public class AddCigarilloViewModel
    {
        [Required]
        [StringLength(MaxBrandLenght, MinimumLength = MinBrandLenght)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(MaxCountryOfManufacturingLenght, MinimumLength = MinCountryOfManufacturingLenght)]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        [StringLength(MaxCommentLenght, MinimumLength = MinCommentLenght)]
        public string Comment { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public int FiterId { get; set; }

        public int FilterType { get; set; } 

        public string FilterTypeName { get; set; } 

        public IEnumerable<FilterType> FilterTypes { get; set; } = new List<FilterType>();
    }
}
