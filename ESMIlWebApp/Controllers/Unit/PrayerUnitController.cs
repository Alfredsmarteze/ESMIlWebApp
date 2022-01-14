using Microsoft.AspNetCore.Mvc;
using Infrastructure.Interface;
using ESMIlWebApp.Ultilities;
using DataStructure.ViewModel;
using System.Net;


namespace ESMIlWebApp.Controllers.Unit
{
    
    public class PrayerUnitController : Controller
    {
        private readonly IUnitRepository _repository;
        private string errorMessage=string.Empty;

        public PrayerUnitController(IUnitRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdatePrayerUnitData()
        {
            try
            {
                var model = new PrayerUnitDTOData();


                var savePrayerUnitData = await _repository.AddOrUpdatePrayerUnit(model);
            if(savePrayerUnitData)
             {
                    return Json(new ResponseModel { hasError = false, message = "Operation Successful", statusaCode = (int)HttpStatusCode.OK });
             }
                else
                {
                    return Json(new ResponseModel { hasError = true, message = "Operation not successful", statusaCode = (int)HttpStatusCode.InternalServerError });
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return Json(new ResponseModel { message = $"Error: {errorMessage}", statusaCode = (int)HttpStatusCode.Conflict });
        }
    }
}
