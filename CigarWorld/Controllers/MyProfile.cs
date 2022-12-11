using CigarWorld.Contracts;
using CigarWorld.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CigarWorld.Controllers
{
    public class MyProfile : Controller
    {
        
        private readonly IMyProfileService myProfileService;

        public MyProfile(IMyProfileService _myProfileService)
        {
            myProfileService = _myProfileService;
        }

        public async Task<IActionResult> MyCollection()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Ashtray", "Ashtray");
            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model =  myProfileService.GetAllFavoriteProductsViewModels(userId);

            return View(model);
        }
    }
}
