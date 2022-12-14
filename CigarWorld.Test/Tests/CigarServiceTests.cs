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
    public class CigarServiceTests
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
                .AddSingleton<ICigarService, CigarService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<CigarWorldDbContext>();

        }

        [Test]
        public async Task AddCigarilloShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarService>();

            var Model = new AddCigarViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                Format = "Somting",
                Length = 2,
                Ring = 2,
                SmokingDuration = 2,
                StrengthId = 2
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarsAsync(Model));

            var count = dbContext.CreateContext().Cigars.Count();

            Assert.That(count == 2);
        }

        [Test]
        public async Task RemoveCigarsMethodShouldDeleteFromDataBaseCorrectly()
        {
            var service = serviceProvider.GetService<ICigarService>();

            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));

            var count = dbContext.CreateContext().Cigars.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetTypesShouldReturnAllTypes()
        {
            var service = serviceProvider.GetService<ICigarService>();

            var type = await service.GetStrengthTypeAsync();

            Assert.IsTrue(type.Count() == 3);
        }

        [Test]
        public async Task GetAllCigarsMethodShouldGetAllCigars()
        {
            var service = serviceProvider.GetService<ICigarService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllCigarsAsync(userId));

            var cigar = await service.GetAllCigarsAsync(userId);

            var expectedCount = 1;

            var actualCount = cigar.Count();

            Assert.IsTrue(actualCount == expectedCount);
        }

        [Test]
        public async Task AddReviewShouldAddReviewForOneCigar()
        {
            var service = serviceProvider.GetService<ICigarService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var model = new CigarDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToCigar = "Somting",
                StrengthType = "Somting",
                UserName = "Gosho",
                Format = "Somting",
                Length = 33,
                Ring = 3,
                SmokingDuration = 66
            };

            var review = service.AddReview(model, userId);

            Assert.IsNotNull(review);
            Assert.IsTrue(review.Id == 1);

            var count = dbContext.CreateContext().CigarReviews.Count();

            Assert.That(count == 2);
        }

        [Test]
        public async Task GetInformationForCigarMethodShouldReturnModelForCigar()
        {
            var service = serviceProvider.GetService<ICigarService>();

            var Model = new EditCigarViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                StrengthId = 1,
                Format = "Somting",
                Length = 33,
                Ring = 3,
                SmokingDuration = 66
            };

            Assert.DoesNotThrowAsync(async () => await service.GetInformationForCigar(Model.Id));
        }

        [Test]
        public async Task RemoveReviewShouldRemoveReviewFromDatabase()
        {
            var service = serviceProvider.GetService<ICigarService>();

            var model = new CigarDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToCigar = "Somting",
                StrengthType = "Somting",
                UserName = "Gosho",
                Format = "Somting",
                Length = 33,
                Ring = 3,
                SmokingDuration = 66
            };

            service.DeleteReview(1);

            var count = dbContext.CreateContext().CigarReviews.Count();

            Assert.That(count == 0);
        }

        [Test]
        public async Task GetDetailsAsyncMethodShoildReturnDetailsForCigar()
        {
            var service = serviceProvider.GetService<ICigarService>();

            string username = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            var info = await service.GetDetailsAsync(1, username);

            Assert.IsTrue(info.Brand == "Cohiba");
            Assert.IsTrue(info.CountryOfManufacturing == "Cuba");
            Assert.IsTrue(info.Comment == "This cigar is very unice. The taste, smoke from she and the flavor make the cigar a very special.");
            Assert.IsTrue(info.ImageUrl == "https://kalimancaribe.com/images/thumbnails/650/366/detailed/5/COHIBA_BEHIKE_BHK_52.jpg");
            Assert.IsTrue(info.Format == "Vitola");
            Assert.IsTrue(info.Length == 119);
        }

        [Test]
        public async Task EditCigarMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<ICigarService>();

            var Model = new AddCigarViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                Format = "Somting",
                Length = 2,
                Ring = 2,
                SmokingDuration = 2,
                StrengthId = 2
            };

            await service.AddCigarsAsync(Model);

            var editModel = new EditCigarViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                Format = "Somting",
                Length = 2,
                Ring = 2,
                SmokingDuration = 66,
                StrengthId = 2
            };

            service.EditCigarInformation(editModel);

            var cigar = dbContext.CreateContext().Cigars
                .Where(x => x.Id == editModel.Id)
                .FirstOrDefault();

            Assert.IsNotNull(cigar);
            Assert.That(cigar.Brand, Is.EqualTo(editModel.Brand));
        }

        [Test]
        public async Task EditCigarReviewMethodShouldEditValueInDatabase()
        {
            var service = serviceProvider.GetService<ICigarService>();

            var model = new CigarDetailsViewModel()
            {
                Id = 1,
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg",
                Comment = "Somting",
                AddReviewToCigar = "Somting",
                StrengthType = "Somting",
                UserName = "Gosho",
                Format = "Somting",
                Length = 33,
                Ring = 3,
                SmokingDuration = 66
            };

            service.AddReview(model, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var changedReview = "Somting";

            service.EditReview(model.Id, changedReview);

            var cigar = dbContext.CreateContext().CigarReviews
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();

            Assert.IsNotNull(cigar);
            Assert.That(cigar.Review, Is.EqualTo(changedReview));
        }

        [Test]
        public async Task AddCigarToCollectionMEthodShouldSaveInDatabaseYourFavoriteCigar()
        {
            var service = serviceProvider.GetService<ICigarService>();

            await service.AddFavoriteCigarAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");


            var currentDbContext = dbContext.CreateContext().UserCigars
                .FirstOrDefault();

            Assert.IsNotNull(currentDbContext);
            Assert.That(currentDbContext.CigarId > 0);
        }

        [Test]
        public async Task RemoveCigarFromCollectionMethodShouldRemoveFromDatabaseYourFavoriteCigar()
        {
            var service = serviceProvider.GetService<ICigarService>();

            await service.AddFavoriteCigarAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var secondCurrentDbContext = dbContext.CreateContext().UserCigars
                .FirstOrDefault();

            Assert.IsNotNull(secondCurrentDbContext);
            Assert.That(secondCurrentDbContext.CigarId > 0);

            await service.RemoveFromFavoritesAsync(1, "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            var currentDbContext = dbContext.CreateContext().UserCigars
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
