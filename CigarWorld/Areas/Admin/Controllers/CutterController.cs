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
    public class CutterController : Controller
    {
        private readonly ICutterService cutterService;

        public CutterController(ICutterService _cutterService)
        {
            cutterService = _cutterService;
        }


        [HttpGet]
        public async Task<IActionResult> AddCutter()
        {
            var model = new AddCutterViewModel()
            {
                CutterTypes = await cutterService.GetTypesAsync()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddCutter(AddCutterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await cutterService.AddCutterAsync(model);

                TempData[GlobalAddMessage] = "You added Cutter Successfully!";

                return RedirectToAction("Cutter", "Cutter", new { area = "" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var targetAshtary = await cutterService.GetInformationForCutter(Id);

            var model = new EditCutterViewModel()
            {
                Id = Id,
                Brand = targetAshtary.Brand,
                Comment = targetAshtary.Comment,
                CountryOfManufacturing = targetAshtary.CountryOfManufacturing,
                CutterTypes = targetAshtary.CutterTypes,
                ImageUrl = targetAshtary.ImageUrl,
                TypeId = targetAshtary.TypeId
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int Id, EditCutterViewModel targetCutter)
        {
            cutterService.EditCutterInformation(targetCutter);

            return RedirectToAction("Cutter", "Cutter", new { area = "" });
        }


        public async Task<IActionResult> RemoveFromDataBase(int cutterId)
        {
            await cutterService.RemoveFromDatabaseAsync(cutterId);

            TempData[GlobalDeleteMessage] = "You Delited Cutter Successfully!";

            return RedirectToAction("Cutter", "Cutter", new { area = "" });
        }
    }
}
