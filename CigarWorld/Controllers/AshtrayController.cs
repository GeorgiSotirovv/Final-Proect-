using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CigarWorld.Controllers
{
    [Authorize]
    public class AshtrayController : Controller
    {
        private readonly IAshtrayService ashtrayService;

        public AshtrayController(IAshtrayService _AshtrayService)
        {
            ashtrayService = _AshtrayService;
        }

        [HttpGet]
        public async Task<IActionResult> Ashtray()
        {
            var model = await ashtrayService.GetAllAshtrayAsync();

            return View(model);
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

                return RedirectToAction("Cigar", "Cigar");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> AddFavoriteAshtray(int ashtrayId)
        {

            try
            {
                
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await ashtrayService.AddAshtrayToFavoritesAsync(ashtrayId, userId);
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

                var model = ashtrayService.GetDetailsAsync(Id, curUser).Result;
                return View(model);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(AshtrayDetailsViewModel targetAshtray)
        {
            var curUser = this.User.Identity.Name;

            ashtrayService.AddReview(targetAshtray, curUser);

            return RedirectToAction("Details", "Ashtray", new { id = targetAshtray.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int Id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await ashtrayService.RemoveFromFavoritesAsync(Id, userId);

            return RedirectToAction("Cigar", "Cigar");
        }

        public async Task<IActionResult> RemoveFromDataBase(int ashtrayId)
        {
            await ashtrayService.RemoveFromDatabaseAsync(ashtrayId);

            return RedirectToAction("Ashtray", "Ashtray");
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
            ashtrayService.EdidAshtaryInformation(targetAshtary);

            return RedirectToAction("Ashtray", "Ashtray");
        }

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetAshtrayId = ashtrayService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Ashtray", new { id = targetAshtrayId });
        }
    }
}
