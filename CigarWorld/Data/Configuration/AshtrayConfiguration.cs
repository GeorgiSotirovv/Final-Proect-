using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class AshtrayConfiguration : IEntityTypeConfiguration<Ashtray>
    {
        public void Configure(EntityTypeBuilder<Ashtray> builder)
        {
            builder

                .HasData(new Ashtray()
                {
                    Id = 1,
                    Brand = "Lubinski",
                    AshtrayId = 1,
                    CountryOfManufacturing = "China",
                    ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                    Comment = "Really nice and colorful ashtray."
                });
        }
    }
}
