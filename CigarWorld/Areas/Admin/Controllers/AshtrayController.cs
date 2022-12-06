using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static CigarWorld.WebConstants;

namespace CigarWorld.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AshtrayController : AdminController
    {
        private readonly IAshtrayService ashtrayService;

        public AshtrayController(IAshtrayService _AshtrayService)
        {
            ashtrayService = _AshtrayService;
        }


        [HttpGet]
        public async Task<IActionResult> AddAshtray()
        {
            var model = new AddAshtrayViewModel()
            {
                AshtrayTypes = await ashtrayService.GetTypesAsync()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddAshtray(AddAshtrayViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await ashtrayService.AddAshtraysAsync(model);

                return RedirectToAction("Ashtray", "Ashtray", new {area = ""});
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }


        public async Task<IActionResult> RemoveFromDataBase(int ashtrayId)
        {
            await ashtrayService.RemoveFromDatabaseAsync(ashtrayId);

            TempData[GlobalDeleteMessage] = "You Delited Ashtray Successfully!";

            return RedirectToAction("Ashtray", "Ashtray", new { area = "" });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var targetAshtary = await ashtrayService.GetInformationForAshtray(Id);



            var model = new EditAshtrayViewModel()
            {
                Id = Id,
                Brand = targetAshtary.Brand,
                Comment = targetAshtary.Comment,
                CountryOfManufacturing = targetAshtary.CountryOfManufacturing,
                AshtrayTypes = targetAshtary.AshtrayTypes,
                ImageUrl = targetAshtary.ImageUrl,
                TypeId = targetAshtary.TypeId
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int Id, EditAshtrayViewModel targetAshtary)
        {
            ashtrayService.EditAshtaryInformation(targetAshtary);

            return RedirectToAction("Ashtray", "Ashtray", new { area = "" });
        }
    }
}                            