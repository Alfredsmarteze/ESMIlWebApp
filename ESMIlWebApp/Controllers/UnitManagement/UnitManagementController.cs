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
        public IActionResult PrayerUnit()=>View();

        [HttpGet]
        public IActionResult CreateNewPrayer() => View();

        public IActionResult UpdateprayerUnit()
        {
            var model = new PrayerUnitDTO();
            var rowId = Request.Form["updateRecordId"].FirstOrDefault();
            if (rowId is not null)
            {
                var id = int.Parse(rowId);
                model = _unitRepository.ListAllPrayerUnitData().Where(s => s.Id == id).FirstOrDefault();
            }
            return View();
        }

        public IActionResult ViewPrayerUni()
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
    }
}
