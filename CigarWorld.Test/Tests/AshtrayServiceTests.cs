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
        public async Task AddAshtrayMethodShouldAddAshtrayToDatabaseCorrectly()
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

            var count = dbContext.CreateContext().Ashtrays.Count();

            Assert.That(count == 2);
        }

        [Test]
        public async Task RemoveAshtrayMethodShouldDeleteFromDataBaseCorrectly()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));

            var count = dbContext.CreateContext().Ashtrays.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetAllAShtraysMethodShouldGetAllAshtrays()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllAshtrayAsync(userId));

            var ashtray = await service.GetAllAshtrayAsync(userId);

            var expectedCount = 1;

            var actualCount = ashtray.Count();

            Assert.IsTrue(actualCount == expectedCount);
        }


        [Test]
        public async Task GetTypesMethodShouldReturnAllTypes()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            var type = await service.GetTypesAsync();

            Assert.IsTrue(type.Count() == 2);
        }

        [Test]
        public async Task AddReviewShouldAddReviewForOneAshtray()
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

            var review = service.AddReview(model, userId); 

            Assert.IsNotNull(review);
            Assert.IsTrue(review.Id == 1);

            var count = dbContext.CreateContext().AshtrayReviews.Count();

            Assert.That(count == 2);
        }


        [Test]
        public async Task GetInformationForAshtrayMethodShouldReturnModelForAshtray()
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
        public async Task RemoveReviewShouldRemoveReviewFromDatabase()
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

            service.DeleteReview(1);

            var count = dbContext.CreateContext().AshtrayReviews.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetDetailsAsyncMethodShoildReturnDetailsForAshtray()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            string username = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var info =  await service.GetDetailsAsync(1, username);

            Assert.IsTrue(info.Brand == "Lubinski");
            Assert.IsTrue(info.CountryOfManufacturing == "China");
            Assert.IsTrue(info.Comment == "Really nice and colorful ashtray.");
            Assert.IsTrue(info.ImageUrl == "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg");
        }


        [Test]
        public async Task EditAshtrayMethodShouldEditValueInDatabase()
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

            await service.AddAshtraysAsync(Model);

            var editModel = new EditAshtrayViewModel()
            {
                Id = 1,
                Brand = "Sucess",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                TypeId = 1,
            };

            service.EditAshtaryInformation(editModel);

            var ashtray = dbContext.CreateContext().Ashtrays
                .Where(x => x.Id == editModel.Id)
                .FirstOrDefault();

            Assert.IsNotNull(ashtray);
            Assert.That(ashtray.Brand, Is.EqualTo(editModel.Brand));
        }

        [Test]
        public async Task EditAshtrayReviewMethodShouldEditValueInDatabase()
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

            service.AddReview(model, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var changedReview = "Somting";

            service.EditReview(model.Id, changedReview);

            var ashtrayReview = dbContext.CreateContext().AshtrayReviews
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();

            Assert.IsNotNull(ashtrayReview);
            Assert.That(ashtrayReview.Review, Is.EqualTo(changedReview));
        }

        [Test]
        public async Task AddAshtrayToCollectionMEthodShouldSaveInDatabaseYourFavoriteAshtray()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            await service.AddAshtrayToFavoritesAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");


            var currentDbContext = dbContext.CreateContext().UserAshtrays
                .FirstOrDefault();

            Assert.IsNotNull(currentDbContext);
            Assert.That(currentDbContext.AshtrayId > 0);
        }

        [Test]
        public async Task RemoveAshtrayFromCollectionMethodShouldRemoveFromDatabaseYourFavoriteAshtray()
        {
            var service = serviceProvider.GetService<IAshtrayService>();

            await service.AddAshtrayToFavoritesAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var secondCurrentDbContext = dbContext.CreateContext().UserAshtrays
                .FirstOrDefault();

            Assert.IsNotNull(secondCurrentDbContext);
            Assert.That(secondCurrentDbContext.AshtrayId > 0);

            await service.RemoveFromFavoritesAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var currentDbContext = dbContext.CreateContext().UserAshtrays
                .FirstOrDefault();

            Assert.IsNull(currentDbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
