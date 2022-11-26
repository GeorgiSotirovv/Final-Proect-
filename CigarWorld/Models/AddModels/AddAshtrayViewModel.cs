using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Ashtray;

namespace CigarWorld.Models.AddModels
{
    public class AddAshtrayViewModel
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

        public int TypeId { get; set; }

        public int AshtrayType { get; set; } 

        public IEnumerable<AshtrayType> AshtrayTypes { get; set; } = new List<AshtrayType>();
    }
}
