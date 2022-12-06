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
    public class CigarilloController : AdminController
    {
        private readonly ICigarilloService cigarilloService;

        public CigarilloController(ICigarilloService _cigarilloService)
        {
            cigarilloService = _cigarilloService;
        }
        [HttpGet]
        public async Task<IActionResult> AddCigarillo()
        {
            var model = new AddCigarilloViewModel()
            {
                FilterTypes = await cigarilloService.GetTypesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCigarillo(AddCigarilloViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await cigarilloService.AddCigarilloAsync(model);

                TempData[GlobalAddMessage] = "You added Cigarillo Successfully!";

                return RedirectToAction("Cigarillo", "Cigarillo", new { area = "" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> RemoveFromDataBase(int cigarilloId)
        {
            await cigarilloService.RemoveFromDatabaseAsync(cigarilloId);

            TempData[GlobalDeleteMessage] = "You Delited Cigarillo Successfully!";

            return RedirectToAction("Cigarillo", "Cigarillo", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var targetAshtary = await cigarilloService.GetInformationForCigarillo(Id);



            var model = new EditCigarilloViewModel()
            {
                Id = Id,
                Brand = targetAshtary.Brand,
                Comment = targetAshtary.Comment,
                CountryOfManufacturing = targetAshtary.CountryOfManufacturing,
                FilterTypes = targetAshtary.FilterTypes,
                ImageUrl = targetAshtary.ImageUrl,
                FiterId = targetAshtary.FiterId
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int Id, EditCigarilloViewModel targetCigarillo)
        {
            cigarilloService.EditCigarilloInformation(targetCigarillo);

            return RedirectToAction("Cigarillo", "Cigarillo", new { area = "" });
        }

    }
}
