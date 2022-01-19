using Microsoft.AspNetCore.Mvc;
using Infrastructure.Interface;
using ESMIlWebApp.Ultilities;
using DataStructure.ViewModel;
using System.Net;
using Newtonsoft.Json;
//using System.Web.Mvc;

namespace ESMIlWebApp.Controllers.Unit
{
 [Area("Unit")]   
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
        public async Task<IActionResult> AddOrUpdatePrayerUnitData(string payload)
        {
            try
            {
                var model = new PrayerUnitDTOData();

                payload = EncryptionExtensions.DecryptStringAES(payload);
                var newModel = JsonConvert.DeserializeObject<PrayerUnitDTOData>(payload);

                var savePrayerUnitData = await _repository.AddOrUpdatePrayerUnitAsync(newModel);
                
                if (savePrayerUnitData)
             {
                    return Json(new ResponseModel { hasError = false, message = "Operation Successful", statusaCode = (int)HttpStatusCode.OK }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
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
