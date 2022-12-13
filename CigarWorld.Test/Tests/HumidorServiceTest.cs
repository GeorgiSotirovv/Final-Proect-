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
        public async Task AddCigarilloShouldWork()
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
        public async Task RemoveCigarilloShouldWork()
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
    }
}
