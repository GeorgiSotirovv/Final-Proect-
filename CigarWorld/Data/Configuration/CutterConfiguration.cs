using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class CutterConfiguration : IEntityTypeConfiguration<Cutter>
    {
        public void Configure(EntityTypeBuilder<Cutter> builder)
        {
            builder.HasData(new Cutter
            {
                Id = 1,
                Brand = "Cohiba",
                ImageUrl = "https://mikescigars.com/media/catalog/product/cache/0fe343e181b5504db207ac8c729e73b7/h/t/Cohiba-Cutter-each.jpg",
                CountryOfManufacturing = "Chuba",
                TypeId = 1,
                Comment = "Really nice and sharp cutter."
            });
        }
    }
}
