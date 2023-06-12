using DataStructure.ViewModel;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.Controllers.ProgrammeDataTableView
{
    public class ProgrammeDataTableViewController : Controller
    {
        private readonly IProgrammeTableRepository _programmeTableRepository;
        public ProgrammeDataTableViewController(IProgrammeTableRepository programmeTableRepository)
        {
            _programmeTableRepository = programmeTableRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("New/Programme")]
        public IActionResult AddProgramme()=>View();

        [HttpGet]
        [Route("AllProgramme")]
        public IActionResult AllProgramme()=>View();
        [HttpGet]
        [Route("ViewOurProgramme")]
        public IActionResult OurProgramme() => View();

        [Route("Update/Programme")]
        public IActionResult UpdateProgramme() 
        {
            var model = new ProgrammeTableDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId ==null)
            {
                ViewBag.NoRecordFound = "No record found";
                return View();
            }
            var id = int.Parse(rowId);
            model=_programmeTableRepository.GetAllProgrammeTableAsync().Where(s=>s.Id==id).FirstOrDefault();

            return View(model);
        }

        public IActionResult ViewProgramme() 
        {
            var model= new ProgrammeTableDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId !=null)
            {
                var id= int.Parse(rowId);
                model=_programmeTableRepository.GetAllProgrammeTableAsync().Where(s=>s.Id==id).FirstOrDefault();
            }
            return View(model);
        }
    }
}
