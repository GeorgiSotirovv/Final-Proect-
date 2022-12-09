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
    public class LighterController : AdminController
    {

        private readonly ILighterService lighterService;

        public LighterController(ILighterService _lighterService)
        {
            lighterService = _lighterService;
        }


        [HttpGet]
        public async Task<IActionResult> AddLighter()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddLighter(AddLighterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await lighterService.AddLighterAsync(model);

                TempData[GlobalAddMessage] = "You Added Lighter Successfully!";

                return RedirectToAction("Lighter", "Lighter", new { area = "" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }


        public async Task<IActionResult> RemoveFromDataBase(int lighterId)
        {
            await lighterService.RemoveFromDatabaseAsync(lighterId);

            TempData[GlobalDeleteMessage] = "You Delited Lighter Successfully!";

            return RedirectToAction("Lighter", "Lighter", new { area = "" });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var targetAshtary = await lighterService.GetInformationForLighter(Id);

            var model = new EditLighterViewModel()
            {
                Id = Id,
                Brand = targetAshtary.Brand,
                Comment = targetAshtary.Comment,
                CountryOfManufacturing = targetAshtary.CountryOfManufacturing,
                ImageUrl = targetAshtary.ImageUrl,
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int Id, EditLighterViewModel targetLighter)
        {   
            if (targetLighter == null)
            {
                return View();
            }

            lighterService.EditLighterInformation(targetLighter);

            TempData[GlobalDeleteMessage] = "You Edited Lighter Successfully!";

            return RedirectToAction("Lighter", "Lighter", new { area = "" });
        }

    }
}
