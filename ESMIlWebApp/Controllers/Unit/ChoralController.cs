using Microsoft.AspNetCore.Mvc;
using Infrastructure.Interface;
using ESMIlWebApp.Ultilities;
using ESMIlWebApp.Models;
using DataStructure.ViewModel;
using System.Net;
using Newtonsoft.Json;
//using System.Web.Mvc;

namespace ESMIlWebApp.Controllers.Unit
{
    // [Area("Unit")]
    public class ChoralController : Controller
    {
        private readonly IUnitRepository _repository;
        private readonly ILogger<ChoralController> _logger;
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private string errorMessage = string.Empty;

        public ChoralController(IUnitRepository repository, ILogger<ChoralController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _logger = logger;
            _iWebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllChoralUnit()
        {
            try
            {
                //var length = Request.Form["length"].FirstOrDefault();
                //var draw= Request.Form["draw"].FirstOrDefault();
                //var start=Request.Form["start"].FirstOrDefault();
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();

                var search = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int totalRecord = 0;

                var choralUnitRecord = _repository.GetAllChoralUnitsAsync().ToList();

                if (!string.IsNullOrWhiteSpace(search.ToString()))
                {
                    choralUnitRecord = choralUnitRecord.Where(s => s.Surname.ToLower().Contains(search)
                      || s.Firstname.ToLower().Contains(search)
                      || s.Middlename.ToLower().Contains(search)
                      || s.PhoneNumber01.ToLower().Contains(search)
                      || s.PhoneNumber02.ToLower().Contains(search)
                      || s.Ambition.ToLower().Contains(search)
                      || s.CourseOfStudy.ToLower().Contains(search)
                      || s.strDateJoinESM.ToLower().Contains(search)
                      || s.strDateOfBirth.ToLower().Contains(search)
                      || s.Gender.ToLower().Contains(search)
                      || s.StateOfOrigin.ToLower().Contains(search)
                      || s.PreviousUnit.ToLower().Contains(search)
                      || s.PositionInFamily.ToLower().Contains(search)
                      || s.SocialMediaAddress.ToLower().Contains(search)
                      || s.Unit.ToLower().Contains(search)
                      || s.LGA.ToLower().Contains(search)
                      || s.HostelAddress.ToLower().Contains(search)
                      || s.HomeAddress.ToLower().Contains(search)
                      || s.Email.ToLower().Contains(search)).ToList();
                }
                totalRecord = choralUnitRecord.Count();
                choralUnitRecord = choralUnitRecord.OrderByDescending(s => s.Id).ToList();
                //prayerRecord = prayerRecord.OrderBy(s=>s.Id).ToList();
                if (pageSize != -1)
                {
                    choralUnitRecord = choralUnitRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                }
                return Json(new
                {
                    draw = draw,
                    recordsFiltered = totalRecord,
                    recordsTotal = totalRecord,
                    data = choralUnitRecord
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel {hasError = true, message = $" Error:\a {errorMessage}" });
        }
        public async Task<IActionResult> AddOrUpdateChoralUnitData(string payload)
        {
            try
            {
                var model = new ChoralUnitData();

                payload = EncryptionExtensions.DecryptStringAES(payload);
                var newModel = JsonConvert.DeserializeObject<ChoralUnitData>(payload);
                var saveChoralUnitData = await _repository.AddOrUpdateChoralUnitAsync(newModel);

                if (saveChoralUnitData)
                {
                    if (newModel.Id>0) 
                    return Json(new ResponseModel { hasError = false, message = $"Successfully updated {newModel.Firstname} record", statusCode = (int)HttpStatusCode.OK });
                    return Json(new ResponseModel { hasError = false, message = $"Successfully added {newModel.Firstname} to choral unit", statusCode = (int)HttpStatusCode.OK });
                }
                else
                {
                    return Json(new ResponseModel { hasError = true, message = "Operation not successful", statusCode = (int)HttpStatusCode.InternalServerError });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex.Message);
                errorMessage = ex.Message;
            }
            return Json(new ResponseModel { hasError = true, message = $"Error: {errorMessage}", statusCode = (int)HttpStatusCode.Conflict });
        }


        public IActionResult ActionButton(int payload)
        {
            var exceptionMessage = string.Empty;

            try
            {
                if (payload == null)
                {
                    return Json(new ResponseModel { message = "Bad request" });
                }

                _repository.DeleteChoralUnitById(payload);

                return Json(new ResponseModel { hasError = false, message = "Operation completed successfully", statusCode = (int)HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                errorMessage = ex.Message;
            }
            return Json(new ResponseModel {hasError = true, message = $" Errror: {errorMessage}", statusCode = (int)HttpStatusCode.NotImplemented });
        }
    }
}
