using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class CigarConfiguration : IEntityTypeConfiguration<Cigar>
    {
        public void Configure(EntityTypeBuilder<Cigar> builder)
        {

            builder
                .HasData(new Cigar()
                {
                    Id = 1,
                    Brand = "Cohiba",
                    Format = "Vitola",
                    Length = 119,
                    Ring = 52,
                    SmokingDuration = 90,
                    CountryOfManufacturing = "Cuba",
                    Comment = "This cigar is very unice. The taste, smoke from she and the flavor make the cigar a very special.",
                    ImageUrl = "https://kalimancaribe.com/images/thumbnails/650/366/detailed/5/COHIBA_BEHIKE_BHK_52.jpg",
                    StrengthId = 1
                });
        }
    }
}
