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

        public IActionResult GetAllPrayerUnit()
        {
            try
            {
                var length = Request.Form["length"].FirstOrDefault();
                var draw= Request.Form["draw"].FirstOrDefault();
                var start=Request.Form["start"].FirstOrDefault();

                var search=Request.Form["search[value]"].FirstOrDefault().FirstOrDefault();

                int pageSize = length != null ? int.Parse(length) : 0;
                int size = start != null ? int.Parse(start) : 0;
                int totalRecord = 0;

                var prayerRecord=_repository.ListAllPrayerUnitData().ToList();

                if (!string.IsNullOrWhiteSpace(search.ToString()))
                {
                    prayerRecord = prayerRecord.Where(s => s.Surname.ToLower().Contains(search)
                      || s.Firstname.ToLower().Contains(search)
                      || s.Middlename.ToLower().Contains(search)
                      || s.PhoneNumber01.ToLower().Contains(search)
                      || s.PhoneNumber02.ToLower().Contains(search)
                      ||s.Email.ToLower().Contains(search)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
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
                    return Json(new ResponseModel { hasError = false, message = "Operation successful", statusaCode = (int)HttpStatusCode.OK }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
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
