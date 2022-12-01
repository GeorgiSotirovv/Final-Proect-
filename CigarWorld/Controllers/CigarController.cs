using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CigarWorld.Controllers
{
    public class CigarController : Controller
    {
        private readonly ICigarService cigarService;

        public CigarController(ICigarService _cigarService)
        {
            cigarService = _cigarService;
        }


        [HttpGet]
        public async Task<IActionResult> Cigar()
        {
            var model = await cigarService.GetAllCigarsAsync();

            return View(model);

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

                return RedirectToAction(nameof(Cigar));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> AddFavoriteCigar(int cigarId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await cigarService.AddFavoriteCigarAsync(cigarId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Cigar", "Cigar");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            try
            {
                var curUser = this.User.Identity.Name;

                var model = cigarService.GetDetailsAsync(Id, curUser).Result;
                return View(model);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(CigarDetailsViewModel targetCigar)
        {
            var curUser = this.User.Identity.Name;

            //cigarService.AddReview(targetAshtray, curUser);

            return RedirectToAction("Details", "Ashtray", new { id = targetCigar.Id });
        }


        public async Task<IActionResult> RemoveFromDataBase(int cigarId)
        {
            await cigarService.RemoveFromDatabaseAsync(cigarId);

            return RedirectToAction("Cigar", "Cigar");
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
        public IActionResult Edit(int Id, EditCigarViewModel targetAshtary)
        {
            cigarService.EditCigarInformation(targetAshtary);

            return RedirectToAction("Cigar", "Cigar");
        }
    }
}
