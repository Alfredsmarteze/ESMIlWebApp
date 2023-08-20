using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.Controllers.Testimony
{
    public class TestimonyViewController : Controller
    {
        private readonly ITestimonyRepository testimony;

        public TestimonyViewController(ITestimonyRepository testimony) 
        {
        this.testimony = testimony;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("New/Testimony")]
        public IActionResult CreateNewTestimony() => View();
        [HttpGet]
        [Route("All/Testimony")]
        public IActionResult AllTestimony() => View();
    }
}
