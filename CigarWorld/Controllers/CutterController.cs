using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CigarWorld.WebConstants;

namespace CigarWorld.Controllers
{

    public class CutterController : Controller
    {
        private readonly ICutterService cutterService;

        public CutterController(ICutterService _cutterService)
        {
            cutterService = _cutterService;
        }

        [HttpGet]
        public async Task<IActionResult> Cutter()
        {
            var model = await cutterService.GetAllAsync();

            return View(model);
        }

       
        public async Task<IActionResult> AddFavoriteCutter(int cutterId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await cutterService.AddFavoriteCutterAsync(cutterId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            TempData[GlobalAddToFavoritesMessage] = "You added Cutter to your collection successfully!";

            return RedirectToAction("Cutter", "Cutter");
        }


        public IActionResult Details(int Id)
        {
            try
            {
                var curUser = this.User.Identity.Name;

                var model = cutterService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(CutterDetailsViewModel targetCutter)
        {
            var curUser = this.User.Identity.Name;

            cutterService.AddReview(targetCutter, curUser);

            return RedirectToAction("Details", "Cutter", new { id = targetCutter.Id });
        }

        

        public async Task<IActionResult> RemoveFromCollection(int cutterId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await cutterService.RemoveFromFavoritesAsync(cutterId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Cutter from your collection successfully!";

            return RedirectToAction("MyCollection", "MyProfile");
        }

       

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetCutterId = cutterService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Cutter", new { id = targetCutterId });
        }
    }
}
