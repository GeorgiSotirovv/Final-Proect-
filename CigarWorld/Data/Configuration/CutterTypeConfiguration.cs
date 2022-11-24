using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class CutterTypeConfiguration : IEntityTypeConfiguration<CutterType>
    {
        public void Configure(EntityTypeBuilder<CutterType> builder)
        {

            builder.HasData(new CutterType
             {
                 Id = 1,
                 Name = "Guillotine"
             },
               new CutterType()
               {
                   Id = 2,
                   Name = "V-Cut"
               },
               new CutterType()
               {
                   Id = 3,
                   Name = "Point"
               });
        }
    }
}
