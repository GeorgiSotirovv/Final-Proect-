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
    public class CigarServiceTests
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
                .AddSingleton<ICigarService, CigarService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<CigarWorldDbContext>();

        }

        [Test]
        public async Task AddCigarilloShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarService>();

            var Model = new AddCigarViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                Format = "Somting",
                Length = 2,
                Ring = 2,
                SmokingDuration = 2,
                StrengthId = 2
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarsAsync(Model));
        }

        [Test]
        public async Task RemoveCigarilloShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarService>();

            var Model = new AddCigarViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                Format = "Somting",
                Length = 2,
                Ring = 2,
                SmokingDuration = 2,
                StrengthId = 2
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarsAsync(Model));
            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));
        }

        [Test]
        public async Task GetTypesShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarService>();

            var type = await service.GetStrengthTypeAsync();

            Assert.IsTrue(type.Count() == 3);
        }

        [Test]
        public async Task GetAllCigarsShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllCigarsAsync(userId));

            var cigar = await service.GetAllCigarsAsync(userId);

            var expectedCount = 1;

            var actualCount = cigar.Count();

            Assert.IsTrue(actualCount == expectedCount);
            Assert.IsFalse(actualCount < expectedCount);
        }
    }
}
