using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CigarWorld.Controllers
{
    public class LighterController : Controller
    {
        private readonly ILighterService lighterService;

        public LighterController(ILighterService _lighterService)
        {
            lighterService = _lighterService;
        }

        [HttpGet]
        public async Task<IActionResult> Lighter()
        {
            var model = await lighterService.GetAllAsync();

            return View(model);
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

                return RedirectToAction(nameof(Lighter));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

        public async Task<IActionResult> AddFavoriteLighter(int lighterId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await lighterService.AddFavoriteLighterAsync(lighterId, userId);
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

                var model = lighterService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(LighterDetailsViewModel targetLighter)
        {
            var curUser = this.User.Identity.Name;

            lighterService.AddReview(targetLighter, curUser);

            return RedirectToAction("Details", "Lighter", new { id = targetLighter.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int lighterId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await lighterService.RemoveFromFavoritesAsync(lighterId, userId);

            return RedirectToAction("MyCollection", "MyProfile");
        }

        public async Task<IActionResult> RemoveFromDataBase(int lighterId)
        {
            await lighterService.RemoveFromDatabaseAsync(lighterId);

            return RedirectToAction("Lighter", "Lighter");
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
        public IActionResult Edit(int Id, EditLighterViewModel targetAshtary)
        {
            lighterService.EditLighterInformation(targetAshtary);

            return RedirectToAction("Lighter", "Lighter");
        }

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetLighterId = lighterService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Lighter", new { id = targetLighterId });
        }
    }
}
