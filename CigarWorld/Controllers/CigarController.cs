using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CigarWorld.WebConstants;

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

            TempData[GlobalAddToFavoritesMessage] = "You added Cigar to your collection successfully!";

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

            cigarService.AddReview(targetCigar, curUser);

            return RedirectToAction("Details", "Cigar", new { id = targetCigar.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int cigarId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await cigarService.RemoveFromFavoritesAsync(cigarId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Cigar from your collection successfully!";

            return RedirectToAction("MyCollection", "MyProfile");
        }

   

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetCigarId = cigarService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Cigar", new { id = targetCigarId });
        }
    }
}
