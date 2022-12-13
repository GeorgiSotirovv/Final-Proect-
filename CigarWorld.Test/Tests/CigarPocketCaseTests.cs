using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.BaseModels;
using CigarWorld.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CigarWorld.Test.Tests
{
    public class CigarPocketCaseTests
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
                .AddSingleton<ICigarCaseService, CigarCaseService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<CigarWorldDbContext>();
        }

        [Test]
        public async Task AddCigarPocketCaseShouldWork()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var Model = new AddCigarPocketCaseViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarCasesAsync(Model));
        }

        [Test]
        public async Task RemoveCigarPocketCaseShouldWork()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var Model = new AddCigarPocketCaseViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarCasesAsync(Model));
            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));
        }
    }
}
