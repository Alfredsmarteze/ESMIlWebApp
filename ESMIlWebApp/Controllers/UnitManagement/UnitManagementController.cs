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
            _unitRepository = unitRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [Route("New/FirstTimer")]
        public IActionResult CreateFirstTimer()=>View();

        [HttpGet]
        [Route("AllFirstTimer")]
        public IActionResult FirstTimer()=>View();

        [Route("Update/FirstTimer/Data")]
        public IActionResult UpdateFirstTimer()
        { 
            var model= new FirstTimerDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId == null)
            {
                ViewBag.NoRecordFound = "No Record Found.";
                return View();
            }
            var id = int.Parse(rowId);
            model = _unitRepository.ListAllFirstTimerAsync().Where(s => s.Id == id).FirstOrDefault();
            return View(model);
        }

        [Route("View/FirstTimer/Data")]
        public IActionResult ViewFirstTimer()
        {
            var model = new FirstTimerDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId != null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllFirstTimerAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [HttpGet]
        [Route("BibleStudyUnit/Members")]
        public IActionResult BibleStudyUnit() => View();

        [HttpGet]
        [Route("New/BibleStudyUnit/Data")]
        public IActionResult CreateNewBibleUnit() => View();

        [Route("Update/BibleStudyUnit/Data")]
        public IActionResult UpdateBibleStudyUnit()
        {
            var model = new BibleStudyUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId != null)
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
        public IActionResult PrayerUnit() => View();

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
                model = _unitRepository.ListAllPrayerUnitData().Where(s => s.Id == id).FirstOrDefault();
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
            var model = new DmeUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId != null)
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
            if (rowId != null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllDmeUnitData().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [HttpGet]
        [Route("New/PublicityUnit/Data")]
        public IActionResult CreateNewPublicityUnit() => View();
        
        [Route("Update/PublicityUnit/Data")]
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

        [HttpGet, Route("New/TechnicalUnit/Data")]
        public IActionResult CreateNewTechnicalUnit() => View();
        
        [Route("Update/TechnicalUnit/Data")]
        public IActionResult UpdateTechnicalUnit()
        {
            var model = new TechnicalUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllTechnicalUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [Route("View/TechnicalUnit/Data")]
        public IActionResult ViewTechnicalUnit()
        {
            var model = new TechnicalUnitDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllTechnicalUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [HttpGet]
        [Route("Technical/Members")]
        public IActionResult TechnicalUnit() => View();

        [HttpGet, Route("New/welfareUnit/Data")]
        public IActionResult CreateNewWelfareUnit() => View();

        [Route("Update/WelfareUnit/Data")]
        public IActionResult UpdateWelfareUnit()
        {
            var model = new WelfareUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllWelfareUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [Route("View/WelfareUnit/Data")]
        public IActionResult ViewWelfareUnit()
        {
            var model = new WelfareUnitDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllWelfareUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [HttpGet]
        [Route("Welfare/Members")]
        public IActionResult WelfareUnit() => View();

        [HttpGet, Route("New/UsheringUnit/Data")]
        public IActionResult CreateNewUsheringUnit() => View();

        [Route("Update/UsheringUnit/Data")]
        public IActionResult UpdateUsheringUnit()
        {
            var model = new UsheringUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllUsheringUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [Route("View/UsheringUnit/Data")]
        public IActionResult ViewUsheringUnit()
        {
            var model = new UsheringUnitDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllUsheringUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [HttpGet, Route("Ushering/Members")]
        public IActionResult UsheringUnit() => View();


        [HttpGet, Route("New/TransportUnit/Data")]
        public IActionResult CreateNewTransportUnit() => View();

        [Route("Update/TransportUnit/Data")]
        public IActionResult UpdateTransportUnit()
        {
            var model = new TransportUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllTransportUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [Route("View/TransportUnit/Data")]
        public IActionResult ViewTransportUnit()
        {
            var model = new TransportUnitDTO();
            var rowId = Request.Form["viewRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllTransportUnitAsync().Where(s => s.Id == id).FirstOrDefault();
            }
            return View(model);
        }

        [HttpGet, Route("Transport/Members")]
        public IActionResult TransportUnit() => View();

    }
}
