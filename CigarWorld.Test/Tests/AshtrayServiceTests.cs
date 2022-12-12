using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.BaseModels;
using CigarWorld.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CigarWorld.Test.Tests
{
    public class AshtrayTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IAshtrayService, AshtrayService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<CigarWorldDbContext>();

            var ashtray = new Ashtray()
            {
                Id = 1,
                Brand = "Lubinski",
                AshtrayId = 1,
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray."
            };
        }

        [Test]
        public async Task AddAshtray()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var Model = new AddAshtrayViewModel()
            {
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
                TypeId = 1,
            };

            int expectedReturnId = 1;

            await service.AddAshtraysAsync(Model);

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var si = (await service.GetAllAshtrayAsync(userId)).FirstOrDefault();

            Assert.DoesNotThrowAsync(async () => await service.AddAshtraysAsync(Model));
        }
    }


}
