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
        public async Task AddCutterShouldWork()
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
        public async Task RemoveCutterShouldWork()
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
    }
}
