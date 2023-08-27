using DataStructure.ViewModel;
using ESMIlWebApp.Ultilities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System.Net;

namespace ESMIlWebApp.Controllers.Unit
{
    public class FirstTimerController : Controller
    {
        private readonly IUnitRepository _repository;
        private readonly ILogger<FirstTimerController> _logger;
        private string errorMessage=string.Empty;
        public FirstTimerController(IUnitRepository repository, ILogger<FirstTimerController> logger)
        {
            _repository=repository;
            _logger=logger; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllFirstTimer()
        {
                string errorMessage;
                try
                {
                    var draw = Request.Form["draw"].FirstOrDefault();
                    var start = Request.Form["start"].FirstOrDefault();
                    var length = Request.Form["length"].FirstOrDefault();

                    var search = Request.Form["search[value]"].FirstOrDefault();

                    int pageSize = length != null ? Convert.ToInt32(length) : 0;
                    int skip = start != null ? Convert.ToInt32(start) : 0;
                    int totalRecord = 0;

                    var firstTimerRecord = _repository.ListAllFirstTimerAsync().ToList();

                    if (!string.IsNullOrWhiteSpace(search.ToString()))
                    {
                        firstTimerRecord = firstTimerRecord.Where(s => s.Surname.ToLower().Contains(search)
                          || s.Othernames.ToLower().Contains(search)
                          || s.FacultyName.ToLower().Contains(search)
                          || s.DepartmentName.ToLower().Contains(search)
                          || s.ReasonOfComing.ToLower().Contains(search)
                          || s.Gender.ToLower().Contains(search)
                          || s.PhoneNumber.ToLower().Contains(search)
                          || s.strDate.ToLower().Contains(search)).ToList();
                    }
                    totalRecord = firstTimerRecord.Count();
                    firstTimerRecord = firstTimerRecord.OrderByDescending(s => s.Id).ToList();
                    if (pageSize != -1)
                    {
                        firstTimerRecord = firstTimerRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                    }
                    return Json(new
                    {
                        draw = draw,
                        recordsFiltered = totalRecord,
                        recordsTotal = totalRecord,
                        data = firstTimerRecord
                    });

                }
                catch (Exception e)
                {
                    _logger.LogError("Error", e.Message);
                    errorMessage = e.Message;
                }
                return Json(new ResponseModel {hasError = true, message = $" Error:\a {errorMessage}" });
            

        }
        
        [HttpPost]
        public async Task<IActionResult> AddUpdateFirstTimer(string payload)
        {             
            try
            {
               if (payload != null)
                 payload = EncryptionExtensions.EncryptStringAES(payload);
                var  payloadd = EncryptionExtensions.DecryptStringAES(payload);
                var newModel = JsonConvert.DeserializeObject<FirstTimerData>(payloadd);
                var saveFirstTimer = await _repository.AddOrUpdateFirstTimerAsync(newModel);
                if (saveFirstTimer)
                {
                    if (newModel.Id>0)
                    {
                        return Json(new ResponseModel { message = $"Successfully Updated {newModel.Surname}'s Record", hasError = false, statusCode = (int)HttpStatusCode.OK });
                    }
                    return Json(new ResponseModel { message = $"{newModel.Surname} Has Been Added Successfully", hasError = false, statusCode = (int)HttpStatusCode.OK });
                }
                else
                {
                    return Json(new ResponseModel { message = "Not successful", hasError = true, statusCode = (int)HttpStatusCode.BadRequest });
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel {hasError = true, message = $"Error\n{errorMessage}", statusCode = (int)HttpStatusCode.BadRequest });
        }
    }
}
