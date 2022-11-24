using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class LighterConfiguration : IEntityTypeConfiguration<Lighter>
    {
        public void Configure(EntityTypeBuilder<Lighter> builder)
        {
            builder
               .HasData(new Lighter
               {
                   Id = 1,
                   Brand = "Cohiba",
                   CountryOfManufacturing = "Cuba",
                   ImageUrl = "https://lacasadelhabano-thehague.com/wp-content/uploads/2020/10/briquet-ligne-2-cohiba-016110-01.png",
                   Comment = "Very nice lighter."
               });
        }
    }
}
