using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class FilterTypeConfiguration : IEntityTypeConfiguration<FilterType>
    {
        public void Configure(EntityTypeBuilder<FilterType> builder)
        {

            builder
               .HasData(new FilterType
               {
                   Id = 1,
                   Name = "Standard"
               },
               new FilterType()
               {
                   Id = 2,
                   Name = "Cherry"
               },
               new FilterType()
               {
                   Id = 3,
                   Name = "Mint"
               },
               new FilterType()
               {
                   Id = 4,
                   Name = "Vanila"
               },
               new FilterType()
               {
                   Id = 5,
                   Name = "Other"
               });
        }
    }
}
