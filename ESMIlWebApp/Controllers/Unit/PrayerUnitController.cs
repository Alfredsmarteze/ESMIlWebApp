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
                int skip = start != null ? int.Parse(start) : 0;
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
                totalRecord = prayerRecord.Count;
                prayerRecord=prayerRecord.OrderByDescending(s=>s.Id).ToList();
                if (pageSize !=-1)
                {
                    prayerRecord = prayerRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                }
                return Json(new { draw = draw, recordsFiltered = totalRecord, recordTotal = totalRecord, data = prayerRecord });

            }
            catch (Exception e)
            {

               errorMessage = e.Message;
            }
            return Json(new ResponseModel{ message = $" Error:\a {errorMessage}" });
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
