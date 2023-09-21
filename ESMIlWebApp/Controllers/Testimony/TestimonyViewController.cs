using DataStructure.ViewModel;
using Infrastructure.Interface;
using Infrastructure.Service;
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

        [Route("Update/Testimony")]
        public IActionResult UpdateTestimony()
        {
            var model = new TestimonyDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId == null)
            {
                ViewBag.NoRecordFound = "No record found";
                return View();
            }
            var id = int.Parse(rowId);
            model = testimony.ListAllTestimony().Where(s => s.Id == id).FirstOrDefault();

            return View(model);
        }
        [Route("View/Testimony")]
        public IActionResult ViewTestimony()
        {
            var model = new TestimonyDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId == null)
            {
                ViewBag.NoRecordFound = "No record found";
                return View();
            }
            var id = int.Parse(rowId);
            model = testimony.ListAllTestimony().Where(s => s.Id == id).FirstOrDefault();

            return View(model);
        }
    }
}
