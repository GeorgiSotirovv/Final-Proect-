using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class AshtrayTypeConfiguration : IEntityTypeConfiguration<AshtrayType>
    {
        public void Configure(EntityTypeBuilder<AshtrayType> builder)
        {
            builder.HasData(new AshtrayType
            {

                Id = 1,
                Name = "For cigars"
            },
            new AshtrayType()
            {
                Id = 2,
                Name = "For Cigarillos"

            });
        }
    }
}
