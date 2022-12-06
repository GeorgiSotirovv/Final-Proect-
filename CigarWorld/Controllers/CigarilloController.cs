using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static CigarWorld.WebConstants;

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

            TempData[GlobalAddToFavoritesMessage] = "You added Cigarillo to your collection successfully!";

            return RedirectToAction("Cigarillo", "Cigarillo");
        }

        public async Task<IActionResult> RemoveFromCollection(int cigarilloId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await cigarilloService.RemoveFromFavoritesAsync(cigarilloId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Cigarillo from your collection successfully!";

            return RedirectToAction("MyCollection", "MyProfile");
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

        

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetAshtrayId = cigarilloService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Cigarillo", new { id = targetAshtrayId });
        }
    }
}
