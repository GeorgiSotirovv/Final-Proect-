using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static CigarWorld.WebConstants;

namespace CigarWorld.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HumidorController : AdminController
    {
        private readonly IHumidorsService humidorsService;

        public HumidorController(IHumidorsService _humidorsService)
        {
            humidorsService = _humidorsService;
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

                TempData[GlobalAddMessage] = "You added Humidor Successfully!";

                return RedirectToAction("Humidor", "Humidor", new { area = "" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

        public async Task<IActionResult> RemoveFromDataBase(int humidorId)
        {
            await humidorsService.RemoveFromDatabaseAsync(humidorId);

            TempData[GlobalDeleteMessage] = "You Delited Humidor Successfully!";

            return RedirectToAction("Humidor", "Humidor", new { area = "" });
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

            return RedirectToAction("Humidor", "Humidor", new { area = "" });
        }
    }
}
