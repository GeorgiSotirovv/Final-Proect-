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
        public async Task AddCigarilloShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var Model = new AddCigarilloViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting.",
                FiterId = 1,
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarilloAsync(Model));

            var count = dbContext.CreateContext().Cigarillo.Count();

            Assert.That(count == 2);
        }

        [Test]
        public async Task RemoveCigarilloShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var Model = new AddCigarilloViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                FiterId = 1,
            };

            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));

            var count = dbContext.CreateContext().Cigarillo.Count();

            Assert.That(count == 0);
        }


        [Test]
        public async Task GetTypesShouldGetAllTupes()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var type = await service.GetTypesAsync();

            Assert.IsTrue(type.Count() == 5);
        }


        [Test]
        public async Task GetAllCigarillosMethodShouldGetAllCigarillos()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllCigarillosAsync(userId));

            var cigarillo = await service.GetAllCigarillosAsync(userId);

            var expectedCount = 1;

            var actualCount = cigarillo.Count();

            Assert.IsTrue(actualCount == expectedCount);
        }

        [Test]
        public async Task AddReviewShouldAddReviewForOneCigarillo()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var model = new CigarilloDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting.",
                UserName = "Gosho",
                Filter = "Cherry",
                AddReviewToCigarillo = "Somting",
            };

            var review = service.AddReview(model, userId);

            Assert.IsNotNull(review);
            Assert.IsTrue(review.Id == 1);

            var count = dbContext.CreateContext().CigarilloReviews.Count();

            Assert.That(count == 2);
        }

        [Test]
        public async Task GetInformationForCigarilloMethodShouldReturnModelForCigarillo()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var Model = new EditCigarilloViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting.",
                FiterId = 1
                
            };

            Assert.DoesNotThrowAsync(async () => await service.GetInformationForCigarillo(Model.Id));
        }

        [Test]
        public async Task RemoveReviewShouldRemoveReviewFromDatabase()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var model = new CigarilloDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                UserName = "Gosho"
            };

            service.DeleteReview(1);

            var count = dbContext.CreateContext().CigarilloReviews.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetDetailsAsyncMethodShoildReturnDetailsForCigarillo()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            string username = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var info = await service.GetDetailsAsync(1, username);

            Assert.IsTrue(info.Brand == "Clubmaster");
            Assert.IsTrue(info.CountryOfManufacturing == "Germany");
            Assert.IsTrue(info.Comment == "This Cigarillos have a very nice taste and nice flavor.");
            Assert.IsTrue(info.ImageUrl == "https://i.colnect.net/f/4259/015/Clubmaster-Mini.jpg");
        }

        [Test]
        public async Task EditCigarilloMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var Model = new AddCigarilloViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                FiterId = 1
            };

            await service.AddCigarilloAsync(Model);

            var editModel = new EditCigarilloViewModel()
            {
                Id = 1,
                Brand = "Sucess",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                FiterId = 1,
            };

            service.EditCigarilloInformation(editModel);

            var cigarillo = dbContext.CreateContext().Cigarillo
                .Where(x => x.Id == editModel.Id)
                .FirstOrDefault();

            Assert.IsNotNull(cigarillo);
            Assert.That(cigarillo.Brand, Is.EqualTo(editModel.Brand));
        }

        [Test]
        public async Task EditCigarilloReviewMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            var model = new CigarilloDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToCigarillo = "Somting",
                Filter = "Somting",
                UserName = "Gosho"
            };

            service.AddReview(model, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var changedReview = "Somting";

            service.EditReview(model.Id, changedReview);

            var cigarilloReview = dbContext.CreateContext().CigarilloReviews
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();

            Assert.IsNotNull(cigarilloReview);
            Assert.That(cigarilloReview.Review, Is.EqualTo(changedReview));
        }

        [Test]
        public async Task AddCigarilloToCollectionMEthodShouldSaveInDatabaseYourFavoriteCigarillo()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            await service.AddFavoriteCigarilloAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");


            var currentDbContext = dbContext.CreateContext().UserCigarillos
                .FirstOrDefault();

            Assert.IsNotNull(currentDbContext);
            Assert.That(currentDbContext.CigarilloId > 0);
        }

        [Test]
        public async Task RemoveCigarilloFromCollectionMethodShouldRemoveFromDatabaseYourFavoriteCigarillo()
        {
            var service = serviceProvider.GetService<ICigarilloService>();

            await service.AddFavoriteCigarilloAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var secondCurrentDbContext = dbContext.CreateContext().UserCigarillos
                .FirstOrDefault();

            Assert.IsNotNull(secondCurrentDbContext);
            Assert.That(secondCurrentDbContext.CigarilloId > 0);

            await service.RemoveFromFavoritesAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var currentDbContext = dbContext.CreateContext().UserCigarillos
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
