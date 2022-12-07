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
    public class CigarController : AdminController
    {
        private readonly ICigarService cigarService;

        public CigarController(ICigarService _cigarService)
        {
            cigarService = _cigarService;
        }

        [HttpGet]
        public async Task<IActionResult> AddCigar()
        {
            var model = new AddCigarViewModel()
            {
                StrengthTypes = await cigarService.GetStrengthTypeAsync()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddCigar(AddCigarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await cigarService.AddCigarsAsync(model);

                TempData[GlobalAddMessage] = "You added Cigar Successfully!";

                return RedirectToAction("Cigar", "Cigar", new { area = "" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }


        public async Task<IActionResult> RemoveFromDataBase(int cigarId)
        {
            await cigarService.RemoveFromDatabaseAsync(cigarId);

            TempData[GlobalDeleteMessage] = "You Delited Cigar Successfully!";

            return RedirectToAction("Cigar", "Cigar", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var targetCigar = await cigarService.GetInformationForCigar(Id);



            var model = new EditCigarViewModel()
            {
                Id = Id,
                Brand = targetCigar.Brand,
                CountryOfManufacturing = targetCigar.CountryOfManufacturing,
                ImageUrl = targetCigar.ImageUrl,
                Comment = targetCigar.Comment,
                Format = targetCigar.Format,
                StrengthId = targetCigar.StrengthId,
                Length = targetCigar.Length,
                Ring = targetCigar.Ring,
                SmokingDuration = targetCigar.SmokingDuration,
                StrengthTypes = targetCigar.StrengthTypes,

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int Id, EditCigarViewModel targetCigar
            )
        {
            if (targetCigar == null)
            {
                return View();
            }

            cigarService.EditCigarInformation(targetCigar);

            TempData[GlobalDeleteMessage] = "You Edited Cigar Successfully!";

            return RedirectToAction("Cigar", "Cigar", new { area = "" });
        }
    }
}
