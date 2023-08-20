using DataStructure.ViewModel;
using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.Controllers.Testimony
{
    public class GeneralMemberDataViewController : Controller
    {
        private readonly IGeneralMemberRepository _generalMemberRepository;

        public GeneralMemberDataViewController(IGeneralMemberRepository generalMemberRepository) 
        {
        this._generalMemberRepository = generalMemberRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("All/GeneralMember")]
        public IActionResult AllGeneralMember() => View();
        [HttpGet]
        [Route("GeneralMember")]
        public IActionResult GeneralMember() => View();
        [HttpGet]
        [Route("New/GeneralMember")]
        public IActionResult CreateGeneralMember() => View();

        [Route("Update/GeneralMember/Data")]
        public IActionResult UpdateGeneralMember()
        {
            var model = new GeneralMemberDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId == null)
            {
                ViewBag.NoRecordFound = "No Record Found.";
                return View();
            }
            var id = int.Parse(rowId);
            model = _generalMemberRepository.ListAllGeneralMember().Where(s => s.Id == id).FirstOrDefault();
            return View(model);
        }

        [Route("View/GeneralMember/Data")]
        public IActionResult ViewGeneralMember()
        {
            var model = new GeneralMemberDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId == null)
            {
                ViewBag.NoRecordFound = "No Record Found.";
                return View();
            }
            var id = int.Parse(rowId);
            model = _generalMemberRepository.ListAllGeneralMember().Where(s => s.Id == id).FirstOrDefault();
            return View(model);
        }
    }
}
