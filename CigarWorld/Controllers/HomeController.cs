using CigarWorld.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CigarWorld.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}