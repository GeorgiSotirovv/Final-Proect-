﻿using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.DetailsModels
{
    public class LighterDetailsViewModel
    {
        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Comment { get; set; } = null!;

        public IEnumerable<LighterReview> LighterReviews { get; set; } = new List<LighterReview>();
    }
}