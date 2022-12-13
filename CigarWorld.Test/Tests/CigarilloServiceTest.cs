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

        [Test]
        public async Task EditShouldWork()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var editModel = new EditAshtrayViewModel()
            {
                Id = 1,
                Brand = "somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
                TypeId = 1,
            };

            //Assert.DoesNotThrow(async => await service.EditAshtaryInformation(editModel));

        }

        [Test]
        public async Task AddAShtrayFavoritesAsyncAshtrayShouldWork()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var Model = new Ashtray()
            {
                Id = 1,
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
            };

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            await service.AddAshtrayToFavoritesAsync(Model.Id, userId);

            Assert.DoesNotThrowAsync(async () => await service.AddAshtrayToFavoritesAsync(Model.Id, userId));
        }

        [Test]
        public async Task GetAllAshtrayAsyncShouldWork()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var Model = new AddAshtrayViewModel()
            {
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
            };
            var secondModel = new AddAshtrayViewModel()
            {
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
            };

            await service.AddAshtraysAsync(Model);
            await service.AddAshtraysAsync(secondModel);


            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            //await service.AddAshtrayToFavoritesAsync(Model.Id, userId);

            Assert.DoesNotThrowAsync(async () => await service.GetAllAshtrayAsync(userId));
        }

        [Test]
        public async Task AddReviewShouldWork()
        {
            var service = serviceProvider.GetService<IAshtrayService>();
            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var Model = new AshtrayDetailsViewModel()
            {
                Id = 1,

            };

            service.AddAshtrayToFavoritesAsync(Model.Id, userId);

            //Assert.DoesNotThrow( service.AddReview(Model, userId));
        }

        [Test]
        public async Task GetMineAshtrayAsyncShouldWork()
        {
            var service = serviceProvider.GetService<IAshtrayService>();
            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var Model = new AddAshtrayViewModel()
            {
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
            };

            Assert.DoesNotThrow(async () => await service.GetMineAshtrayAsync(userId));
        }




        [TearDown]
        public void TearDown()
        {
            //dbContext.Dispose();
        }
    }
}
