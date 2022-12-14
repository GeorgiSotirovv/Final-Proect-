using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
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
    public class LightertServiceTest
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
                .AddSingleton<ILighterService, LighterService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<CigarWorldDbContext>();

        }

        [Test]
        public async Task AddLighterShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ILighterService>();

            var Model = new AddLighterViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
            };

            Assert.DoesNotThrowAsync(async () => await service.AddLighterAsync(Model));
        }

        [Test]
        public async Task RemoveLighterShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ILighterService>();

            var Model = new AddLighterViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
            };

            Assert.DoesNotThrowAsync(async () => await service.AddLighterAsync(Model));
            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));
        }


        [Test]
        public async Task GetAllLightersShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ILighterService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllLighterAsync(userId));

            var lighter = await service.GetAllLighterAsync(userId);

            var expectedCount = 1;

            var actualCount = lighter.Count();

            Assert.IsTrue(actualCount == expectedCount);
            Assert.IsFalse(actualCount < expectedCount);
        }
    }
}
