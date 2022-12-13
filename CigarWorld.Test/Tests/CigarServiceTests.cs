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
        public async Task AddCigarilloShouldWork()
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
        public async Task RemoveCigarilloShouldWork()
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
    }
}
