using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using CigarWorld.Models.EditViewModels;

namespace CigarWorld.Controllers
{
    public class CigarCaseController : Controller
    {
        private readonly ICigarCaseService cigarCaseService;

        public CigarCaseController(ICigarCaseService _cigarCaseService)
        {
            cigarCaseService = _cigarCaseService;
        }

        [HttpGet]
        public async Task<IActionResult> CigarPocketCase()
        {
            var model = await cigarCaseService.GetAllAsyncCigarCase();

            return View(model);
        }

        [HttpGet]
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

                return RedirectToAction(nameof(CigarPocketCase));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }


        public async Task<IActionResult> AddFavoriteCigarPocketCase(int cigarPocketCaseId)
        {

            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await cigarCaseService.AddCigarCaseToFavoritesAsync(cigarPocketCaseId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Cigar","Cigar");
        }

        public IActionResult Details(int Id)
        {
            try
            {
                var model = cigarCaseService.GetDetailsAsync(Id).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> RemoveFromCollection(int CPCId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //await cigarCaseService.RemoveFromCollectionAsync(CPCId, userId);

            return RedirectToAction("Cigar", "Cigar");
        }

        public async Task<IActionResult> RemoveFromDataBase(int cigarPocketCaseId)
        {
            await cigarCaseService.RemoveFromDatabaseAsync(cigarPocketCaseId);

            return RedirectToAction("CigarPocketCase", "CigarCase");
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
            cigarCaseService.EditCigarPocketCaseInformation(targetCPC);

            return RedirectToAction("CigarPocketCase", "CigarCase");
        }
    }
}
