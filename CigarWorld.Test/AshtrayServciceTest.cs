using CigarWorld.Contracts;
using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CigarWorld.Test
{
    public class Tests
    {
		private ServiceProvider serviceProvider;
		private InMemoryDbContext dbContext;


		public async Task Setup()
		{
			dbContext = new InMemoryDbContext();
			var serviceCollection = new ServiceCollection();

			serviceProvider = serviceCollection
				.AddSingleton(sp => dbContext.CreateContext())
				.AddSingleton<IAshtrayService, AshtrayService>()
				.BuildServiceProvider();

			var repo = serviceProvider.GetService<IAshtrayService>();

            await SeedDbAsync(repo);
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