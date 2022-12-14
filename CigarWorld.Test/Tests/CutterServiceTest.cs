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
    public class CutterServiceTest
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
                .AddSingleton<ICutterService, CutterService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<CigarWorldDbContext>();

        }

        [Test]
        public async Task AddCutterShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICutterService>();

            var Model = new AddCutterViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                TypeId = 1
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCutterAsync(Model));
        }

        [Test]
        public async Task RemoveCutterShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICutterService>();

            var Model = new AddCutterViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                TypeId = 1
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCutterAsync(Model));
            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));
        }


        [Test]
        public async Task GetAllCuttersShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICutterService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetCuttersAllAsync(userId));

            var cutter = await service.GetCuttersAllAsync(userId);

            var expectedCount = 1;

            var actualCount = cutter.Count();

            Assert.IsTrue(actualCount == expectedCount);
            Assert.IsFalse(actualCount < expectedCount);
        }

        [Test]
        public async Task GetTypesShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICutterService>();

            var type = await service.GetTypesAsync();

            Assert.IsTrue(type.Count() == 3);
        }
    }
}
