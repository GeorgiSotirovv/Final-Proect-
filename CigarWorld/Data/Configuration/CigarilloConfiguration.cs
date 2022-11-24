using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class CigarilloConfiguration : IEntityTypeConfiguration<Cigarillo>
    {
        public void Configure(EntityTypeBuilder<Cigarillo> builder)
        {
            builder.HasData(new Cigarillo
            {
                Id = 1,
                Brand = "Clubmaster",
                CountryOfManufacturing = "Germany",
                ImageUrl = "https://i.colnect.net/f/4259/015/Clubmaster-Mini.jpg",
                Comment = "This Cigarillos have a very nice taste and nice flavor.",
                FiterId = 1,
            });
        }
    }
}
