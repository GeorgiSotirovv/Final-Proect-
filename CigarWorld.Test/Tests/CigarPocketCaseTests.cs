using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.BaseModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
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
        public async Task AddCigarCaseMethodShouldAddCigarCaseToDatabaseCorrectly()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var Model = new AddCigarPocketCaseViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                Capacity = 4,
                MaterialOfManufacture = "Somting"
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarCasesAsync(Model));

            var count = dbContext.CreateContext().CigarPocketCases.Count();

            Assert.That(count == 2);
        }

        [Test]
        public async Task RemoveCigarCaseMethodShouldDeleteFromDataBaseCorrectly()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));

            var count = dbContext.CreateContext().CigarPocketCases.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetAllCigarCasesMethodShouldGetAllCigarCases()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllAsyncCigarCase(userId));

            var CPC = await service.GetAllAsyncCigarCase(userId);

            var expectedCount = 1;

            var actualCount = CPC.Count();

            Assert.IsTrue(actualCount == expectedCount);
        }


        [Test]
        public async Task AddReviewShouldAddReviewForOneCigarCase()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var model = new CigarCaseDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToCigarPocketCase = "Somting",
                UserName = "Gosho",
                Capacity = 1,
                MaterialOfManufacture = "Somting"
            };

            var review = service.AddReview(model, userId);

            Assert.IsNotNull(review);
            Assert.IsTrue(review.Id == 1);

            var count = dbContext.CreateContext().CigarPocketCases.Count();

            Assert.That(count == 1);
        }


        [Test]
        public async Task GetInformationForCigarCaseMethodShouldReturnModelForCigarCase()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var Model = new EditCigarPocketCaseViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
            };

            Assert.DoesNotThrowAsync(async () => await service.GetInformationForCigarPocketCase(Model.Id));
        }

        [Test]
        public async Task RemoveReviewShouldRemoveReviewFromDatabase()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var model = new CigarCaseDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                UserName = "Gosho",
                MaterialOfManufacture = "Somting",
                Capacity = 3,
                AddReviewToCigarPocketCase = "Somting"
            };

            service.DeleteReview(1);

            var count = dbContext.CreateContext().CigarPocketCaseReviews.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetDetailsAsyncMethodShoildReturnDetailsForCigarCase()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            string username = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var info = await service.GetDetailsAsync(1, username);

            Assert.IsTrue(info.Brand == "Visol");
            Assert.IsTrue(info.CountryOfManufacturing == "Germany");
            Assert.IsTrue(info.Comment == "Expertly crafted with the small cigar smoker in mind, the premium quality Visol Landon Carbon Fiber Mini Cigar Case allows you toss away your ugly cigarillo boxes and carry up to 4- little stogies in style..");
            Assert.IsTrue(info.ImageUrl == "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRev3HE7yrOrEkefMQhkif-qti8T5pm9262jQ&usqp=CAU");
        }


        [Test]
        public async Task EditCigarCaseMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var Model = new AddCigarPocketCaseViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                Capacity = 1,
                MaterialOfManufacture = "Somting"
            };

            await service.AddCigarCasesAsync(Model);

            var editModel = new EditCigarPocketCaseViewModel()
            {
                Id = 1,
                Brand = "Sucess",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                Capacity = 1,
                MaterialOfManufacture = "Somting"
            };

            service.EditCigarPocketCaseInformation(editModel);

            var CPC = dbContext.CreateContext().CigarPocketCases
                .Where(x => x.Id == editModel.Id)
                .FirstOrDefault();

            Assert.IsNotNull(CPC);
            Assert.That(CPC.Brand, Is.EqualTo(editModel.Brand));
        }

        [Test]
        public async Task EditCigarCaseReviewMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var model = new CigarCaseDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToCigarPocketCase= "Somting",
                UserName = "Gosho",
                Capacity= 1,
                MaterialOfManufacture = "Somting"
            };

            service.AddReview(model, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var changedReview = "Somting";

            service.EditReview(model.Id, changedReview);

            var CPCReview = dbContext.CreateContext().CigarPocketCaseReviews
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();

            Assert.IsNotNull(CPCReview);
            Assert.That(CPCReview.Review, Is.EqualTo(changedReview));
        }

        [Test]
        public async Task AddCigarCaseToCollectionMEthodShouldSaveInDatabaseYourFavoriteCigarCase()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            await service.AddCigarCaseToFavoritesAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");


            var currentDbContext = dbContext.CreateContext().UserCigarPocketCases
                .FirstOrDefault();

            Assert.IsNotNull(currentDbContext);
            Assert.That(currentDbContext.CigarPocketCaseId > 0);
        }

        [Test]
        public async Task RemoveCigarPocketCaseFromCollectionMethodShouldRemoveFromDatabaseYourFavoriteCigarPocketCase()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            await service.AddCigarCaseToFavoritesAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var secondCurrentDbContext = dbContext.CreateContext().UserCigarPocketCases
                .FirstOrDefault();

            Assert.IsNotNull(secondCurrentDbContext);
            Assert.That(secondCurrentDbContext.CigarPocketCaseId > 0);

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
