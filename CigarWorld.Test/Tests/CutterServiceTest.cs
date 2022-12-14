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
        public async Task AddCutterShouldWorkCorrectly()
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

            var count = dbContext.CreateContext().Cutters.Count();

            Assert.That(count == 2);
        }

        [Test]
        public async Task RemoveCutterShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICutterService>();

            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));

            var count = dbContext.CreateContext().Cutters.Count();

            Assert.That(count == 0);
        }


        [Test]
        public async Task GetAllCuttersShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICutterService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetCuttersAllAsync(userId));

            var cutter = await service.GetCuttersAllAsync(userId);

            var expectedCount = 1;

            var actualCount = cutter.Count();

            Assert.IsTrue(actualCount == expectedCount);
        }

        [Test]
        public async Task GetTypesShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICutterService>();

            var type = await service.GetTypesAsync();

            Assert.IsTrue(type.Count() == 3);
        }

        [Test]
        public async Task AddReviewShouldAddReviewForOneCutter()
        {
            var service = serviceProvider.GetService<ICutterService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var model = new CutterDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToCutter = "Somting",
                Type = "Somting",
                UserName = "Gosho"
            };

            var review = service.AddReview(model, userId);

            Assert.IsNotNull(review);
            Assert.IsTrue(review.Id == 1);

            var count = dbContext.CreateContext().CutterReviews.Count();

            Assert.That(count == 2);
        }


        [Test]
        public async Task GetInformationForCutterMethodShouldReturnModelForCutter()
        {
            var service = serviceProvider.GetService<ICutterService>();

            var Model = new EditCutterViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                TypeId = 1,
            };

            Assert.DoesNotThrowAsync(async () => await service.GetInformationForCutter(Model.Id));
        }

        [Test]
        public async Task RemoveReviewShouldRemoveReviewFromDatabase()
        {
            var service = serviceProvider.GetService<ICutterService>();

            service.DeleteReview(1);

            var count = dbContext.CreateContext().CutterReviews.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetDetailsAsyncMethodShoildReturnDetailsForCutter()
        {
            var service = serviceProvider.GetService<ICutterService>();

            string username = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var info = await service.GetDetailsAsync(1, username);

            Assert.IsTrue(info.Brand == "Cohiba");
            Assert.IsTrue(info.CountryOfManufacturing == "Chuba");
            Assert.IsTrue(info.Comment == "Really nice and sharp cutter.");
            Assert.IsTrue(info.ImageUrl == "https://mikescigars.com/media/catalog/product/cache/0fe343e181b5504db207ac8c729e73b7/h/t/Cohiba-Cutter-each.jpg");
        }


        [Test]
        public async Task EditCutterMethodShouldEditValueInDatabase()
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

            await service.AddCutterAsync(Model);

            var editModel = new EditCutterViewModel()
            {
                Id = 1,
                Brand = "Sucess",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                TypeId = 1,
            };

            service.EditCutterInformation(editModel);

            var cutters = dbContext.CreateContext().Cutters
                .Where(x => x.Id == editModel.Id)
                .FirstOrDefault();

            Assert.IsNotNull(cutters);
            Assert.That(cutters.Brand, Is.EqualTo(editModel.Brand));
        }

        [Test]
        public async Task EditCutterReviewMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<ICutterService>();

            var model = new CutterDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToCutter = "Somting",
                Type = "Somting",
                UserName = "Gosho"
            };

            service.AddReview(model, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var changedReview = "Somting";

            service.EditReview(model.Id, changedReview);

            var cutterReview = dbContext.CreateContext().CutterReviews
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();

            Assert.IsNotNull(cutterReview);
            Assert.That(cutterReview.Review, Is.EqualTo(changedReview));
        }

        [Test]
        public async Task AddCutterToCollectionMEthodShouldSaveInDatabaseYourFavoriteCutter()
        {
            var service = serviceProvider.GetService<ICutterService>();

            await service.AddFavoriteCutterAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");


            var currentDbContext = dbContext.CreateContext().UserCutters
                .FirstOrDefault();

            Assert.IsNotNull(currentDbContext);
            Assert.That(currentDbContext.CutterId > 0);
        }
    }
}
