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
        public async Task AddCigarilloShouldWork()
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
        public async Task RemoveCigarilloShouldWork()
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
    }
}
