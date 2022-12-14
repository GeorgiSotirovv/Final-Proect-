using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.Reviews;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.BaseModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.MyFavoriteViewModels;
using CigarWorld.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CigarWorld.Test.Tests
{
    public class AshtrayServiceTests
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
                .AddSingleton<IAshtrayService, AshtrayService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<CigarWorldDbContext>();
        }

        [Test]
        public async Task AddAshtrayShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var Model = new AddAshtrayViewModel()
            {
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
                TypeId = 1,
            };

            Assert.DoesNotThrowAsync(async () => await service.AddAshtraysAsync(Model));
        }

        [Test]
        public async Task RemoveAshtrayShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var Model = new AddAshtrayViewModel()
            {

                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
            };

            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));
        }

        [Test]
        public async Task GetAllAShtraysShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllAshtrayAsync(userId));

            var ashtray = await service.GetAllAshtrayAsync(userId);

            var expectedCount = 1;

            var actualCount = ashtray.Count();

            Assert.IsTrue(actualCount == expectedCount);
            Assert.IsFalse(actualCount < expectedCount);
        }

        [Test]
        public async Task AddReviewShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var model = new AshtrayDetailsViewModel()
            {
                Id = 1,
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
                AddReviewToAshtray = "Somting",
                Type = "Somting",
                UserName = "Gosho"
            };

            var review = service.AddReview(model, userId); // may be

            Assert.IsNotNull(review);
            Assert.IsTrue(review.Id == 1);
        }

        [Test]
        public async Task AddAshtrayToFavoritesAsyncSouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var Model = new EditAshtrayViewModel()
            {
                Id = 1,
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
                TypeId = 1,
            };

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.AddAshtrayToFavoritesAsync(Model.Id, userId));
        }



        [Test]
        public async Task GetInformationForAshtraySouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var Model = new EditAshtrayViewModel()
            {
                Id = 1,
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
                TypeId = 1,
            };

            Assert.DoesNotThrowAsync(async () => await service.GetInformationForAshtray(Model.Id));
        }

        [Test]
        public async Task RemoveReviewShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var model = new AshtrayDetailsViewModel()
            {
                Id = 1,
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Really nice and colorful ashtray.",
                AddReviewToAshtray = "Somting",
                Type = "Somting",
                UserName = "Gosho"
            };

            Assert.DoesNotThrowAsync(async () =>  service.DeleteReview(1)); // gypsi 
        }


        [Test]
        public async Task GetTypesShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var type = await service.GetTypesAsync();

            Assert.IsTrue(type.Count() == 2);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
