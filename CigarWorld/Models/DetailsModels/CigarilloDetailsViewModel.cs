﻿using CigarWorld.Data.Models;
using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.DetailsModels
{
    public class CigarilloDetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        public string Comment { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Filter { get; set; } = null!;

        public IEnumerable<FilterType> FilterTypes { get; set; } = new List<FilterType>();

        public IEnumerable<CigarilloReview> CigarilloReviews { get; set; } = new List<CigarilloReview>();
    }
}
