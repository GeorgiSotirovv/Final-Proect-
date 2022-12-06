using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.DetailsModels;
using static CigarWorld.WebConstants;

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

            TempData[GlobalAddToFavoritesMessage] = "You added Cigar Pocket Case to your collection successfully!";

            return RedirectToAction("CigarPocketCase", "CigarCase");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            try
            {
                var curUser = this.User.Identity.Name;

                var model = cigarCaseService.GetDetailsAsync(Id, curUser).Result;
                return View(model);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(CigarCaseDetailsViewModel targetCPC)
        {
            var curUser = this.User.Identity.Name;

            cigarCaseService.AddReview(targetCPC, curUser);

            return RedirectToAction("Details", "CigarCase", new { id = targetCPC.Id });
        }


        public async Task<IActionResult> RemoveFromCollection(int CPCId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await cigarCaseService.RemoveFromFavoritesAsync(CPCId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Cigar Pocket Case from your collection successfully!";

            return RedirectToAction("MyCollection", "MyProfile");
        }

        

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetAshtrayId = cigarCaseService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "CigarCase", new { id = targetAshtrayId });
        }
    }
}
