using DataStructure.ViewModel;
using ESMIlWebApp.Ultilities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ESMIlWebApp.Controllers.Unit
{
    public class ESMAFController : Controller
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IQueryRepository _queryRepository;
        private readonly ILogger<ESMAFController> _logger;
        string errorMessage = string.Empty;
        public ESMAFController(ILogger<ESMAFController> logger, IUnitRepository unitRepository, IQueryRepository queryRepository)
        {
            _unitRepository = unitRepository;
            _queryRepository = queryRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddOrUpdateEsmaf(string payload)
        {

            try
            {
                if (payload != null)
                    payload = EncryptionExtensions.EncryptStringAES(payload);
                var payloadd = EncryptionExtensions.DecryptStringAES(payload);
                var model = JsonConvert.DeserializeObject<EsmafData>(payloadd);
              //  var getId = _queryRepository.GetId(model.Id);
                
                var saveEsmaf =await _unitRepository.AddOrUpdateESMAfAsync(model);
                if (model.Id>0)
                {
                    return Json(new ResponseModel { message = $"{model.Surname}'s record successfully updated ", hasError = false, statusCode = (int)HttpStatusCode.OK });
                }
                return Json(new ResponseModel { message = $"{model.Surname} has been added successfully", hasError = false, statusCode = (int)HttpStatusCode.OK });
            }
            catch (Exception e)
            {

                _logger.LogError("Error", e);
                errorMessage = e.InnerException.Message;
            }
            return Json(new ResponseModel { message = $"Error Message {Environment.NewLine}{errorMessage}", hasError = true, statusCode = (int)HttpStatusCode.BadRequest });
        }

        public IActionResult GetAllEsmaf()
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

                    var esmafRecord = _unitRepository.ListAllEsmafAsync().ToList();

                    if (!string.IsNullOrWhiteSpace(search.ToString()))
                    {
                        esmafRecord = esmafRecord.Where(s => s.Surname.ToLower().Contains(search)
                          || s.Othernames.ToLower().Contains(search)
                          || s.PhoneNumber.ToLower().Contains(search)
                          || s.strngYearOfEntry.ToLower().Contains(search)
                          || s.strngYearOfGraduation.ToLower().Contains(search)
                          || s.Gender.ToLower().Contains(search)
                          || s.PhoneNumber.ToLower().Contains(search)
                          ||s.Email.ToLower().Contains(search)
                          || s.CourseOfStudy.ToLower().Contains(search)).ToList();
                    }
                    totalRecord = esmafRecord.Count();
                    esmafRecord = esmafRecord.OrderByDescending(s => s.Id).ToList();
                    if (pageSize != -1)
                    {
                        esmafRecord = esmafRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                    }
                    return Json(new
                    {
                        draw = draw,
                        recordsFiltered = totalRecord,
                        recordsTotal = totalRecord,
                        data = esmafRecord
                    });

                }
                catch (Exception e)
                {
                    _logger.LogError("Error", e.Message);
                    errorMessage = e.InnerException.Message;
                }
                return Json(new ResponseModel { message = $" Error:\a {errorMessage}" });
            

        }

    }
}
