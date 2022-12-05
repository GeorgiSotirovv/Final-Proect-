using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CigarWorld.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/[controller]/[Action]/{id}")]
    [Authorize(Roles = "Admin")]
    public abstract class AdminController : Controller
    {

    }
}
