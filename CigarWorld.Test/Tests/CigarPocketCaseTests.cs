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
        public async Task AddCigarPocketCaseShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var Model = new AddCigarPocketCaseViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarCasesAsync(Model));
        }

        [Test]
        public async Task RemoveCigarPocketCaseShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var Model = new AddCigarPocketCaseViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4
            };

            Assert.DoesNotThrowAsync(async () => await service.AddCigarCasesAsync(Model));
            Assert.DoesNotThrowAsync(async () => await service.RemoveFromDatabaseAsync(1));
        }



        [Test]
        public async Task EditShouldWork()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            var Model = new AddCigarPocketCaseViewModel()
            {
                Brand = "Somting",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4
            };

            await service.AddCigarCasesAsync(Model);

            Assert.IsTrue(Model.Brand == "Somting");

            var editModel = new EditCigarPocketCaseViewModel()
            {
                Id =1,
                Brand = "Sucess",
                CountryOfManufacturing = "Somting",
                ImageUrl = "Somting",
                Comment = "Somting",
                MaterialOfManufacture = "Oac",
                Capacity = 4
            };

            Assert.DoesNotThrowAsync(async () => await service.EditCigarPocketCase(editModel.Id));
        }

        //[Test]
        //public Task AddReviewShouldWork()
        //{
        //    var service = serviceProvider.GetService<ICigarCaseService>();

        //    string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

        //    var CPC = new CigarCaseDetailsViewModel
        //    {
        //        Id = 1,
        //        Brand = "Sucess",
        //        CountryOfManufacturing = "Somting",
        //        ImageUrl = "Somting",
        //        Comment = "Somting",
        //        MaterialOfManufacture = "Oac",
        //        Capacity = 4
        //    };

        //    Assert.Positive( service.AddReview(CPC, userId).);
        //}


        [Test]
        public async Task GetAllCigarsPocketCasesShouldWorkCorrectly()
        {
            var service = serviceProvider.GetService<ICigarCaseService>();

            string userId = "ff8c4ff1-b3a1-4d41-8d8c-4de59272dec5";

            Assert.DoesNotThrowAsync(async () => await service.GetAllAsyncCigarCase(userId));

            var CPC = await service.GetAllAsyncCigarCase(userId);

            var expectedCount = 1;

            var actualCount = CPC.Count();

            Assert.IsTrue(actualCount == expectedCount); 
            Assert.IsFalse(actualCount < expectedCount);
        }
    }
}
