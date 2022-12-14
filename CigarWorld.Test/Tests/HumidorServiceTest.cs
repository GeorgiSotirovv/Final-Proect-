using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
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
        public async Task AddHumidorShouldWorkCorrectly()
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

            var count = dbContext.CreateContext().Humidors.Count();

            Assert.That(count == 2);
        }

        [Test]
        public async Task RemoveHumidorShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));

            var count = dbContext.CreateContext().Humidors.Count();

            Assert.That(count == 0);
        }


        [Test]
        public async Task GetAllHumidorsShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllHumidorAsync(userId));

            var humidor = await service.GetAllHumidorAsync(userId);

            var expectedCount = 1;

            var actualCount = humidor.Count();

            Assert.IsTrue(actualCount == expectedCount);
        }


        [Test]
        public async Task AddReviewShouldAddReviewForOneHumidor()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var model = new HumidorDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToHumidor = "Somting",
                UserName = "Gosho",
                MaterialOfManufacture = "Oac",
                Capacity = 4,
                Height = 3,
                Length = 11,
                Weight = 33,
            };

            var review = service.AddReview(model, userId);

            Assert.IsNotNull(review);
            Assert.IsTrue(review.Id == 1);

            var count = dbContext.CreateContext().HumidorReviews.Count();

            Assert.That(count == 2);
        }


        [Test]
        public async Task GetInformationForHumidorMethodShouldReturnModelForHumidor()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            var Model = new EditHumidorViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4,
                Height = 3,
                Length = 11,
                Weight = 33,
            };

            Assert.DoesNotThrowAsync(async () => await service.GetInformationForHumidor(Model.Id));
        }

        [Test]
        public async Task RemoveReviewShouldRemoveReviewFromDatabase()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            var model = new HumidorDetailsViewModel()
            {
                Id = 1,
                Brand = "Lubinski",
                CountryOfManufacturing = "China",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToHumidor = "Somting",
                UserName = "Gosho",
                MaterialOfManufacture = "Oac",
                Capacity = 4,
                Height = 3,
                Length = 11,
                Weight = 33,
            };

            service.DeleteReview(1);

            var count = dbContext.CreateContext().HumidorReviews.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetDetailsAsyncMethodShoildReturnDetailsForHumidor()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            string username = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var info = await service.GetDetailsAsync(1, username);

            Assert.IsTrue(info.Brand == "The Hampton");
            Assert.IsTrue(info.CountryOfManufacturing == "Cuba");
            Assert.IsTrue(info.Comment == "This remarkable black lacquer piece features a diamond pattern bonded leather inlay w/ red accent stitching.");
            Assert.IsTrue(info.ImageUrl == "https://www.cigarhumidors-online.com/media/catalog/product/cache/1/image/430x295/9df78eab33525d08d6e5fb8d27136e95/h/m/hmptnblu6.jpg");
        }


        [Test]
        public async Task EditHumidorMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            var Model = new AddHumidorViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                MaterialOfManufacture = "Somting",
                Capacity = 4,
                Height = 3,
                Length = 11,
                Weight = 33,
            };

            await service.AddHumidorAsync(Model);

            var editModel = new EditHumidorViewModel()
            {
                Id = 1,
                Brand = "Sucess",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4,
                Height = 3,
                Length = 11,
                Weight = 33,
            };

            service.EditHumidorInformation(editModel);

            var humidor = dbContext.CreateContext().Humidors
                .Where(x => x.Id == editModel.Id)
                .FirstOrDefault();

            Assert.IsNotNull(humidor);
            Assert.That(humidor.Brand, Is.EqualTo(editModel.Brand));
        }

        [Test]
        public async Task EditHumidorReviewMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            var model = new HumidorDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToHumidor = "Somting",
                UserName = "Gosho",
                MaterialOfManufacture = "Oac",
                Capacity = 4,
                Height = 3,
                Length = 11,
                Weight = 33,
            };

            service.AddReview(model, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var changedReview = "Somting";

            service.EditReview(model.Id, changedReview);

            var humidorReview = dbContext.CreateContext().HumidorReviews
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();

            Assert.IsNotNull(humidorReview);
            Assert.That(humidorReview.Review, Is.EqualTo(changedReview));
        }

        [Test]
        public async Task AddHumidorToCollectionMEthodShouldSaveInDatabaseYourFavoriteHumidor()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            await service.AddFavoriteHumidorAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");


            var currentDbContext = dbContext.CreateContext().UserHumidors
                .FirstOrDefault();

            Assert.IsNotNull(currentDbContext);
            Assert.That(currentDbContext.HumidorId > 0);
        }

        [Test]
        public async Task RemoveHumidorFromCollectionMethodShouldRemoveFromDatabaseYourFavoriteHumidor()
        {
            var service = serviceProvider.GetService<IHumidorsService>();

            await service.AddFavoriteHumidorAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var secondCurrentDbContext = dbContext.CreateContext().UserHumidors
                .FirstOrDefault();

            Assert.IsNotNull(secondCurrentDbContext);
            Assert.That(secondCurrentDbContext.HumidorId > 0);

            await service.RemoveFromFavoritesAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var currentDbContext = dbContext.CreateContext().UserHumidors
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
