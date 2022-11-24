using CigarWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class HumidorConfiguration : IEntityTypeConfiguration<Humidor>
    {
        public void Configure(EntityTypeBuilder<Humidor> builder)
        {
            builder.HasData(new Humidor()
             {
                 Id = 1,
                 Brand = "The Hampton",
                 ImageUrl = "https://www.cigarhumidors-online.com/media/catalog/product/cache/1/image/430x295/9df78eab33525d08d6e5fb8d27136e95/h/m/hmptnblu6.jpg",
                 Height = 20,
                 Length = 20,
                 Weight = 5,
                 Capacity = 50,
                 MaterialOfManufacture = "Оak",
                 CountryOfManufacturing = "Cuba",
                 Comment = "This remarkable black lacquer piece features a diamond pattern bonded leather inlay w/ red accent stitching."
             });
        }
    }
}
