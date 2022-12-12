using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Models.AddModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CigarWorld.Test
{
    public class Tests
    {
		private ServiceProvider serviceProvider;
		private InMemoryDbContext dbContext;


		public async Task Setup()
		{
            var contextOptions = new DbContextOptionsBuilder<CigarWorldDbContext>()
               .UseInMemoryDatabase("HouseDB")
               .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

		[Test]
        public void Test1()
        {
            var ashtray = new AddAshtrayViewModel()
            {
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
            };

            var service = serviceProvider.GetService<IAshtrayService>();

            Assert.DoesNotThrowAsync(async () => await service.AddAshtraysAsync(ashtray));
        }

        [TearDown]
		public void TearDown()
        {
            dbContext.Dispose();
        }


        private async Task SeedDbAsync(IAshtrayService repo)
        {
            var ashtray = new AddAshtrayViewModel()
            {
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
            };

            await repo.AddAshtraysAsync(ashtray);
        }
    }
}