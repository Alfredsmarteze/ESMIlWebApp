using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.Controllers.UnitManagement
{
    public class UnitManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateNewPrayer() => View();
    }
}
