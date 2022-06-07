using DataStructure.ViewModel;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.Controllers.UnitManagement
{

    public class UnitManagementController : Controller
    {
        private IUnitRepository _unitRepository;
        public UnitManagementController(IUnitRepository unitRepository)
        { 
            _unitRepository=unitRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("BibleStudyUnit/Members")]
        public IActionResult BibleStudyUnit() => View();
        
        [HttpGet]
        [Route("New/BibleStudyUnit/Data")]
        public IActionResult CreateNewBibleUnit()=>View();
      
        [Route("Update/BibleStudyUnit/Data")]
        public IActionResult UpdateBibleStudyUnit()
        { 
            var model=new BibleStudyUnitDTO();
            var rowId=Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId !=null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.GetAllBibleStudyUnitsAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }
        
        [Route("View/BibleStudyUnit/Data")]
        public IActionResult ViewBibleStudyUnit()
        {
            var model = new BibleStudyUnitDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.GetAllBibleStudyUnitsAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [HttpGet]
        [Route("PrayerUnit/Members")]
        public IActionResult PrayerUnit()=>View();

        [HttpGet]
        [Route("New/PrayerUnit/Data")]
        public IActionResult CreateNewPrayer() => View();

        [Route("Update/PrayerUnit/Data")]
        public IActionResult UpdateprayerUnit()
        {
            var model = new PrayerUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId != null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllPrayerUnitData().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [Route("View/PrayerUnit/Data")]
        public IActionResult ViewPrayerUnit()
        {
            var model = new PrayerUnitDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model=_unitRepository.ListAllPrayerUnitData().Where(s=>s.Id==id).FirstOrDefault();
            }
            return View(model);
        }

        [HttpGet]
        [Route("ChoralUnit/Members")]
        public IActionResult ChoralUnit() => View();

        [HttpGet]
        [Route("New/ChoralUnit/Data")]
        public IActionResult CreateNewChoral() => View();

        [Route("Update/ChoralUnit/Data")]
        public IActionResult UpdateChoralUnit()
        {
            var model = new ChoralUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId != null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.GetAllChoralUnitsAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [Route("View/ChoralUnit/Data")]
        public IActionResult ViewChoralUnit()
        {
            var model = new ChoralUnitDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.GetAllChoralUnitsAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }
        
        [HttpGet]
        [Route("DMEUnit/Members")]
        public IActionResult DmeUnit() => View();

        [HttpGet]
        [Route("New/DMEUnit/Data")]
        public IActionResult CreateNewDme() => View();

        [Route("Update/DMEUnit/Data")]
        public IActionResult UpdateDmeUnit()
        { 
         var model= new DmeUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId !=null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllDmeUnitData().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }
                       
        [HttpGet]
        [Route("View/DMEUnit/Data")]
        public IActionResult ViewDmeUnit()
        {
            var model = new DmeUnitDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId !=null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllDmeUnitData().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }
        
        [HttpGet]
        [Route("New/PublicityUnit/Data")]
        public IActionResult CreateNewPublicityUnit()=> View();
        public IActionResult UpdatePublicityUnit()
        {
            var model = new PublicityAndEditorialUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllPublicityUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }
        
        [Route("View/PublicityUnit/Data")]
        public IActionResult ViewPublicityUnit()
        { 
            var model= new PublicityAndEditorialUnitDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllPublicityUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [HttpGet]
        [Route("Publicity/Members")]
        public IActionResult PublicityUnit()=>View();
    }
}
