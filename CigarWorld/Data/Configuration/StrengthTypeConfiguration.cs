using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class StrengthTypeConfiguration : IEntityTypeConfiguration<StrengthType>
    {
        public void Configure(EntityTypeBuilder<StrengthType> builder)
        {
            builder.HasData(new StrengthType()
            {
                Id = 1,
                Name = "Mild"
            },
            new StrengthType()
            {
                Id = 2,
                Name = "Medium"
            },
            new StrengthType()
            {
                Id = 3,
                Name = "Full"
            });
        }
    }
}
