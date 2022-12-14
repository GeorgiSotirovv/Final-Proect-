using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Models.AddModels;
using CigarWorld.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CigarWorld.Test.Tests
{
    public class HumidorServiceTest
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
                .AddSingleton<IHumidorsService, HumidorService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<CigarWorldDbContext>();
        }

        [Test]
        public async Task AddCigarilloShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            var Model = new AddHumidorViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4,
                Height = 3,
                Length = 11,
                Weight = 33,
            };

            Assert.DoesNotThrowAsync(async () => await service.AddHumidorAsync(Model));
        }

        [Test]
        public async Task RemoveCigarilloShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            var Model = new AddHumidorViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4,
                Height = 3,
                Length = 11,
                Weight = 33,
            };

            Assert.DoesNotThrowAsync(async () => await service.AddHumidorAsync(Model));
            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));
        }


        [Test]
        public async Task GetAllAShtraysShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllHumidorAsync(userId));

            var ashtray = await service.GetAllHumidorAsync(userId);

            var expectedCount = 1;

            var actualCount = ashtray.Count();

            Assert.IsTrue(actualCount == expectedCount);
            Assert.IsFalse(actualCount < expectedCount);
        }
    }
}
