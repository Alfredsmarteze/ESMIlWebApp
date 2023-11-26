using DataStructure.ViewModel;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.Controllers.AdmnControl
{
    public class AdminControlViewController : Controller
    {
        private readonly IAdminControl adminControl;
        public AdminControlViewController(IAdminControl adminControl) 
        {
            this.adminControl=adminControl;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("New/EventImage")]
        public IActionResult EventImage() => View();
        [HttpGet]
        [Route("New/Announcement")]
        public IActionResult CreateNewAnnouncement() => View();
        [HttpGet]
        [Route("All/Announcement")]
        public IActionResult AllAnnouncement() => View();
        [Route("Update/Announcement")]
        public IActionResult UpdateAnnouncement()
        {
            var model = new AnnouncementDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId == null)
            {
                ViewBag.NoRecordFound = "No record found";
                return View();
            }
            var id = int.Parse(rowId);
            model = adminControl.ListAllAnnouncement().Where(s => s.Id == id).FirstOrDefault();

            return View(model);
        }
        [Route("View/Announcement")]
        public IActionResult ViewAnnouncement()
        {
            var model = new AnnouncementDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId != null)
            {
                var id = int.Parse(rowId);
                model = adminControl.ListAllAnnouncement().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }
        [HttpGet]
        [Route("New/Charge")]
        public IActionResult CreateNewPresidentCharge() => View();
        [HttpGet]
        [Route("All/Charge")]
        public IActionResult AllPresidentCharge() => View();
       
        [Route("Update/PresidentCharge")]
        public IActionResult UpdatePresidentCharge()
        {
            var model = new PresidentChargeDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId == null)
            {
                ViewBag.NoRecordFound = "No record found";
                return View();
            }
            var id = int.Parse(rowId);
            model = adminControl.ListAllPresidentChargeAsync().Where(s => s.Id == id).FirstOrDefault();

            return View(model);
        }
        [Route("View/PresidentCharge")]
        public IActionResult ViewPresidentCharge()
        {
            var model = new PresidentChargeDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId != null)
            {
                var id = int.Parse(rowId);
                model = adminControl.ListAllPresidentChargeAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }
    }
}
