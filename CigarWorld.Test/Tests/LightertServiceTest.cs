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
        public async Task AddLighterShouldWork()
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
        public async Task RemoveLighterShouldWork()
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
    }
}
