using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.EditViewModels
{
    public class EditLighterViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Comment { get; set; } = null!;
    }
}
