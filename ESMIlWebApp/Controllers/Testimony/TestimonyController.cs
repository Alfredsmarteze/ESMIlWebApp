using DataStructure.ViewModel;
using ESMIlWebApp.Controllers.Unit;
using ESMIlWebApp.Ultilities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Nancy;
using Newtonsoft.Json;

namespace ESMIlWebApp.Controllers.Testimony
{
    public class TestimonyController : Controller
    {
        private readonly ITestimonyRepository _repository;
        private readonly ILogger<TestimonyController> _logger;
        private string errorMessage = string.Empty;
        public TestimonyController(ITestimonyRepository repository, ILogger<TestimonyController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllTestimony()
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

                var testimonyRecord = _repository.ListAllTestimony().ToList();

                if (!string.IsNullOrWhiteSpace(search.ToString()))
                {
                    testimonyRecord = testimonyRecord.Where(s => s.Surname.ToLower().Contains(search)
                      || s.Firstname.ToLower().Contains(search)
                      || s.Department.ToLower().Contains(search)
                      || s.TheGoodNews.ToLower().Contains(search)
                      || s.strDate.ToLower().Contains(search)).ToList();
                }
                totalRecord = testimonyRecord.Count();
                testimonyRecord = testimonyRecord.OrderByDescending(s => s.Id).ToList();
                if (pageSize != -1)
                {
                    testimonyRecord = testimonyRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                }
                return Json(new
                {
                    draw = draw,
                    recordsFiltered = totalRecord,
                    recordsTotal = totalRecord,
                    data = testimonyRecord
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
        public async Task<IActionResult> AddUpdateTestimomy(string payload)
        {
            try
            {
                if (payload != null)
                    payload = EncryptionExtensions.EncryptStringAES(payload);
                var payloadd = EncryptionExtensions.DecryptStringAES(payload);
                var newModel = JsonConvert.DeserializeObject<TestimonyData>(payloadd);
                var saveFirstTimer = await _repository.AddOrUpdateTestimony(newModel);
                if (saveFirstTimer)
                {
                    if (newModel.Id > 0)
                    {
                        return Json(new ResponseModel { message = $"Successfully Updated {newModel.Surname}'s Record", hasError = false, statusCode = (int)HttpStatusCode.OK });
                    }
                    return Json(new ResponseModel { message = $"{newModel.Surname} testimony has been added successfully", hasError = false, statusCode = (int)HttpStatusCode.OK });
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


        [HttpPost]
        public async Task<IActionResult> TestimonyNumber(string payload)
        {
            try
            {
                if (payload != null)
                    payload = EncryptionExtensions.EncryptStringAES(payload);
                var payloadd = EncryptionExtensions.DecryptStringAES(payload);
                var newModel = JsonConvert.DeserializeObject<TestimonyNumberData>(payloadd);
                var save = await _repository.AddTestimonyNumberToDisplay(newModel);
                if (save)
                {
                    if (newModel.Id > 0)
                    {
                        return Json(new ResponseModel { message = $"Successfully Updated Record", hasError = false, statusCode = (int)HttpStatusCode.OK });
                    }
                    return Json(new ResponseModel { message = $" Only {newModel.Number} Testimonies will be shown in home page", hasError = false, statusCode = (int)HttpStatusCode.OK });
                }
                else
                {
                    return Json(new ResponseModel { message = "Request not successful", hasError = true, statusCode = (int)HttpStatusCode.BadRequest });
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
