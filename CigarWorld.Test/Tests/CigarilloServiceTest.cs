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
    public class CigarilloServiceTest
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
                .AddSingleton<ICigarilloService, CigarilloService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<CigarWorldDbContext>();
        }

        [Test]
        public async Task AddCigarilloShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var Model = new AddCigarilloViewModel()
            {
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
                FiterId = 1,
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarilloAsync(Model));
        }

        [Test]
        public async Task RemoveCigarilloShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var Model = new AddCigarilloViewModel()
            {
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
                FiterId = 1,
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarilloAsync(Model));
            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));
        }


        [Test]
        public async Task GetTypesShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var type = await service.GetTypesAsync();

            Assert.IsTrue(type.Count() == 5);
        }


        [Test]
        public async Task GetAllCigarillosShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllCigarillosAsync(userId));

            var cigarillo = await service.GetAllCigarillosAsync(userId);

            var expectedCount = 1;

            var actualCount = cigarillo.Count();

            Assert.IsTrue(actualCount == expectedCount);
            Assert.IsFalse(actualCount < expectedCount);
        }


        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
