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
    public class CigarCaseController : AdminController
    {
        private readonly ICigarCaseService cigarCaseService;

        public CigarCaseController(ICigarCaseService _cigarCaseService)
        {
            cigarCaseService = _cigarCaseService;
        }

        public async Task<IActionResult> AddCigarPocketCase()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCigarPocketCase(AddCigarPocketCaseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await cigarCaseService.AddCigarCasesAsync(model);

                TempData[GlobalAddMessage] = "You added Cigar Pocket Case Successfully!";

                return RedirectToAction("CigarPocketCase", "CigarCase", new { area = "" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

        public async Task<IActionResult> RemoveFromDataBase(int cigarPocketCaseId)
        {
            await cigarCaseService.RemoveFromDatabaseAsync(cigarPocketCaseId);

            TempData[GlobalDeleteMessage] = "You Delited Cigar Pocket Case Successfully!";

            return RedirectToAction("CigarPocketCase", "CigarCase", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var targetAshtary = await cigarCaseService.GetInformationForCigarPocketCase(Id);



            var model = new EditCigarPocketCaseViewModel()
            {
                Id = Id,
                Brand = targetAshtary.Brand,
                Comment = targetAshtary.Comment,
                CountryOfManufacturing = targetAshtary.CountryOfManufacturing,
                MaterialOfManufacture = targetAshtary.MaterialOfManufacture,
                ImageUrl = targetAshtary.ImageUrl,
                Capacity = targetAshtary.Capacity,
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int Id, EditCigarPocketCaseViewModel targetCPC)
        {
            if (targetCPC == null)
            {
                return View();
            }

            cigarCaseService.EditCigarPocketCaseInformation(targetCPC);

            TempData[GlobalDeleteMessage] = "You Edited Cigar Pocket Case Successfully!";

            return RedirectToAction("CigarPocketCase", "CigarCase", new { area = "" });
        }
    }
}
