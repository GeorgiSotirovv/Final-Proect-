using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
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
        public async Task AddLighterShouldWorkCorrectly()
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

            var count = dbContext.CreateContext().Lighters.Count();

            Assert.That(count == 2);
        }

        [Test]
        public async Task RemoveLighterShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ILighterService>();

            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));

            var count = dbContext.CreateContext().Lighters.Count();

            Assert.That(count == 0);
        }


        [Test]
        public async Task GetAllLightersShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ILighterService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllLighterAsync(userId));

            var lighter = await service.GetAllLighterAsync(userId);

            var expectedCount = 1;

            var actualCount = lighter.Count();

            Assert.IsTrue(actualCount == expectedCount);
        }

        [Test]
        public async Task AddReviewShouldAddReviewForOneLighter()
        {
            var service = serviceProvider.GetService<ILighterService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var model = new LighterDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToLighter = "Somting",
                UserName = "Gosho"
            };

            var review = service.AddReview(model, userId);

            Assert.IsNotNull(review);
            Assert.IsTrue(review.Id == 1);

            var count = dbContext.CreateContext().LighterReviews.Count();

            Assert.That(count == 2);
        }


        [Test]
        public async Task GetInformationForLighterMethodShouldReturnModelForLighter()
        {
            var service = serviceProvider.GetService<ILighterService>();

            var Model = new EditLighterViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
            };

            Assert.DoesNotThrowAsync(async () => await service.GetInformationForLighter(Model.Id));
        }

        [Test]
        public async Task RemoveReviewShouldRemoveReviewFromDatabase()
        {
            var service = serviceProvider.GetService<ILighterService>();

            var model = new LighterDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToLighter = "Somting",
                UserName = "Gosho"
            };

            service.DeleteReview(1);

            var count = dbContext.CreateContext().LighterReviews.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetDetailsAsyncMethodShoildReturnDetailsForLighter()
        {
            var service = serviceProvider.GetService<ILighterService>();

            string username = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var info = await service.GetDetailsAsync(1, username);

            Assert.IsTrue(info.Brand == "Cohiba");
            Assert.IsTrue(info.CountryOfManufacturing == "Cuba");
            Assert.IsTrue(info.Comment == "Very nice lighter.");
            Assert.IsTrue(info.ImageUrl == "https://lacasadelhabano-thehague.com/wp-content/uploads/2020/10/briquet-ligne-2-cohiba-016110-01.png");
        }


        [Test]
        public async Task EditLighterMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<ILighterService>();

            var Model = new AddLighterViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
            };

            await service.AddLighterAsync(Model);

            var editModel = new EditLighterViewModel()
            {
                Id = 1,
                Brand = "Sucess",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
            };

            service.EditLighterInformation(editModel);

            var lighter = dbContext.CreateContext().Lighters
                .Where(x => x.Id == editModel.Id)
                .FirstOrDefault();

            Assert.IsNotNull(lighter);
            Assert.That(lighter.Brand, Is.EqualTo(editModel.Brand));
        }

        [Test]
        public async Task EditLighterReviewMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<ILighterService>();

            var model = new LighterDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToLighter = "Somting",
                UserName = "Gosho"
            };

            service.AddReview(model, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var changedReview = "Somting";

            service.EditReview(model.Id, changedReview);

            var lighterReview = dbContext.CreateContext().LighterReviews
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();

            Assert.IsNotNull(lighterReview);
            Assert.That(lighterReview.Review, Is.EqualTo(changedReview));
        }

        [Test]
        public async Task AddLighterToCollectionMethodShouldSaveInDatabaseYourFavoriteLighter()
        {
            var service = serviceProvider.GetService<ILighterService>();

            await service.AddFavoriteLighterAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");


            var currentDbContext = dbContext.CreateContext().UserLighters
                .FirstOrDefault();

            Assert.IsNotNull(currentDbContext);
            Assert.That(currentDbContext.LighterId > 0);
        }

        [Test]
        public async Task RemoveLighterFromCollectionMethodShouldRemoveFromDatabaseYourFavoriteLighter()
        {
            var service = serviceProvider.GetService<ILighterService>();

            await service.AddFavoriteLighterAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var secondCurrentDbContext = dbContext.CreateContext().UserLighters
                .FirstOrDefault();

            Assert.IsNotNull(secondCurrentDbContext);
            Assert.That(secondCurrentDbContext.LighterId > 0);

            await service.RemoveFromFavoritesAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var currentDbContext = dbContext.CreateContext().UserLighters
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
