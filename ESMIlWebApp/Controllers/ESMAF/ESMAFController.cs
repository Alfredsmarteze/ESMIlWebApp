using DataStructure.ViewModel;
using ESMIlWebApp.Ultilities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ESMIlWebApp.Controllers.ESMAF
{
    public class ESMAFController : Controller
    {
        private readonly IEsmafRepository _esmafQueryRepository;
        private readonly ILogger<GeneralMemberController> _logger;
        string errorMessage = string.Empty;
        public ESMAFController(ILogger<GeneralMemberController> logger, IEsmafRepository queryRepository)
        {
            _esmafQueryRepository = queryRepository;
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

                var saveEsmaf = await _esmafQueryRepository.AddOrUpdateESMAfAsync(model);
                if (model.Id > 0)
                {
                    return Json(new ResponseModel { message = $"{model.Surname}'s record successfully updated ", hasError = false, statusCode = (int)HttpStatusCode.OK });
                }
                return Json(new ResponseModel { message = $"{model.Surname} has been added successfully", hasError = false, statusCode = (int)HttpStatusCode.OK });
            }
            catch (Exception e)
            {

                _logger.LogError("Error", e);
                errorMessage = e.Message;
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

                var esmafRecord = _esmafQueryRepository.ListAllEsmafAsync().ToList();

                if (!string.IsNullOrWhiteSpace(search.ToString()))
                {
                    esmafRecord = esmafRecord.Where(s => s.Surname.ToLower().Contains(search)
                      || s.Othernames.ToLower().Contains(search)
                      || s.PhoneNumber.ToLower().Contains(search)
                      || s.strngYearOfEntry.ToLower().Contains(search)
                      || s.strngYearOfGraduation.ToLower().Contains(search)
                      || s.Gender.ToLower().Contains(search)
                      || s.PhoneNumber.ToLower().Contains(search)
                      || s.Email.ToLower().Contains(search)
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
                    draw,
                    recordsFiltered = totalRecord,
                    recordsTotal = totalRecord,
                    data = esmafRecord
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel {hasError = true, message = $" Error:\a {errorMessage}" });


        }

        public IActionResult GetAllPastExecutive() 
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

                var pastExecutiveRecord = _esmafQueryRepository.ListAllPastExecutive().ToList();

                if (!string.IsNullOrWhiteSpace(search.ToString()))
                {
                    pastExecutiveRecord = pastExecutiveRecord.Where(s => s.SurnameExcos.ToLower().Contains(search)
                      || s.OthernameExcos.ToLower().Contains(search)
                      || s.Phone.ToLower().Contains(search)
                      || s.Office.ToLower().Contains(search)
                      || s.Gender.ToLower().Contains(search)
                      || s.AcademicSectionDate.ToLower().Contains(search)
                      || s.Email.ToLower().Contains(search)).ToList();
                }
                totalRecord = pastExecutiveRecord.Count();
                pastExecutiveRecord = pastExecutiveRecord.OrderByDescending(s => s.Id).ToList();
                if (pageSize != -1)
                {
                    pastExecutiveRecord = pastExecutiveRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                }
                return Json(new
                {
                    draw,
                    recordsFiltered = totalRecord,
                    recordsTotal = totalRecord,
                    data = pastExecutiveRecord
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel {hasError = true, message = $" Error:\a {errorMessage}" });
        }

    }
}
