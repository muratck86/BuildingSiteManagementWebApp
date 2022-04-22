using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingSiteManagementWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
