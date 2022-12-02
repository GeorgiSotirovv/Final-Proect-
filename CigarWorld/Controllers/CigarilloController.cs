using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CigarWorld.Controllers
{
    public class CigarilloController : Controller
    {
        private readonly ICigarilloService cigarilloService;


        public CigarilloController(ICigarilloService _cigarilloService)
        {
            cigarilloService = _cigarilloService;
        }

        [HttpGet]
        public async Task<IActionResult> Cigarillo()
        {
            var model = await cigarilloService.GetAllCigarillosAsync();

            return View(model);
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

                return RedirectToAction(nameof(Cigarillo));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> AddFavoriteCigarillo(int cigarilloId)
        {

            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await cigarilloService.AddFavoriteCigarilloAsync(cigarilloId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Cigarillo", "Cigarillo");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            try
            {
                var curUser = this.User.Identity.Name;

                var model = cigarilloService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(CigarilloDetailsViewModel targetCigarillo)
        {
            var curUser = this.User.Identity.Name;

            cigarilloService.AddReview(targetCigarillo, curUser);

            return RedirectToAction("Details", "Cigarillo", new { id = targetCigarillo.Id });
        }

        public async Task<IActionResult> RemoveFromDataBase(int cigarilloId)
        {
            await cigarilloService.RemoveFromDatabaseAsync(cigarilloId);

            return RedirectToAction("Cigarillo", "Cigarillo");
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

            return RedirectToAction("CigarCase", "Cigarillo");
        }

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetAshtrayId = cigarilloService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Cigarillo", new { id = targetAshtrayId });
        }
    }
}
