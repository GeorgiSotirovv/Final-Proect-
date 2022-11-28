using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cutter;

namespace CigarWorld.Models.AddModels
{
    public class AddCutterViewModel
    {
        [Required]
        [StringLength(MaxBrandLenght, MinimumLength = MinBrandLenght)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(MaxCountryOfManufacturingLenght, MinimumLength = MinCountryOfManufacturingLenght)]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(MaxCommentLenght, MinimumLength = MinCommentLenght)]
        public string Comment { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }

        public int CutterType { get; set; } 

        public string CutterTypeName { get; set; } = null!;

        public IEnumerable<CutterType> CutterTypes { get; set; } = new List<CutterType>();
    }
}
