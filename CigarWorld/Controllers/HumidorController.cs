using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CigarWorld.Controllers
{
    public class HumidorController : Controller
    {
        private readonly IHumidorsService humidorsService;

        public HumidorController(IHumidorsService _humidorsService)
        {
            humidorsService = _humidorsService;
        }

        [HttpGet]
        public async Task<IActionResult> Humidor()
        {
            var model = await humidorsService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddHumidor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHumidor(AddHumidorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await humidorsService.AddHumidorAsync(model);

                return RedirectToAction(nameof(Humidor));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

        public async Task<IActionResult> AddFavoriteHumidor(int humidorId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await humidorsService.AddFavoriteHumidorAsync(humidorId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Humidor", "Humidor");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            try
            {
                var curUser = this.User.Identity.Name;

                var model = humidorsService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(HumidorDetailsViewModel Humidor)
        {
            var curUser = this.User.Identity.Name;

            humidorsService.AddReview(Humidor, curUser);

            return RedirectToAction("Details", "Humidor", new { id = Humidor.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int humidorId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await humidorsService.RemoveFromFavoritesAsync(humidorId, userId);

            return RedirectToAction("MyCollection", "MyProfile");
        }
        public async Task<IActionResult> RemoveFromDataBase(int humidorId)
        {
            await humidorsService.RemoveFromDatabaseAsync(humidorId);

            return RedirectToAction("Humidor", "Humidor");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var targetAshtary = await humidorsService.GetInformationForHumidor(Id);



            var model = new EditHumidorViewModel()
            {
                Id = Id,
                Brand = targetAshtary.Brand,
                Comment = targetAshtary.Comment,
                CountryOfManufacturing = targetAshtary.CountryOfManufacturing,
                ImageUrl = targetAshtary.ImageUrl,
                Capacity = targetAshtary.Capacity,
                Weight = targetAshtary.Weight,
                Length = targetAshtary.Length,
                MaterialOfManufacture = targetAshtary.MaterialOfManufacture,
                Height = targetAshtary.Height
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int Id, EditHumidorViewModel targetAshtary)
        {
            humidorsService.EditHumidorInformation(targetAshtary);

            return RedirectToAction("Humidor", "Humidor");
        }

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetHumidorId = humidorsService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Humidor", new { id = targetHumidorId });
        }
    }
}
