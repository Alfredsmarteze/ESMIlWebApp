using DataStructure.ViewModel;
using ESMIlWebApp.Ultilities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Net;

namespace ESMIlWebApp.Controllers.ESMAF
{
    public class GeneralMemberController : Controller
    {
        private readonly IGeneralMemberRepository _generalMemberRepository;
        private readonly ILogger<GeneralMemberController> _logger;
        string errorMessage = string.Empty;
        public GeneralMemberController(ILogger<GeneralMemberController> logger, IGeneralMemberRepository generalMemberRepository)
        {
            _generalMemberRepository = generalMemberRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddOrUpdateGeneralMember(string payload)
        {

            try
            {
                if (payload != null)
                    //payload = EncryptionExtensions.EncryptStringAES(payload);
                 payload = EncryptionExtensions.DecryptStringAES(payload);
                var model = JsonConvert.DeserializeObject<GeneralMemberData>(payload);

                var saveEsmaf = await _generalMemberRepository.AddOrUpdateGeneralMember(model);
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

        public IActionResult GetAllGeneralMember()
        {
            string errorMessage;
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                //switch (length)
                //{
                //    case "oyo":
                //        _generalMemberRepository.ListAllGeneralMember();
                //         break;
                //    case "Ondo":
                //    default:
                //     break;
                //}
                var search = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int totalRecord = 0;

                var generalMemberRecord = _generalMemberRepository.ListAllGeneralMember().ToList();

                if (!string.IsNullOrWhiteSpace(search.ToString()))
                {
                    generalMemberRecord = generalMemberRecord.Where(s =>s.Surname.ToLower().Contains(search)
                      || s.Firstname.ToLower().Contains(search)
                      || s.Othername.ToLower().Contains(search)
                      || s.PhoneNumber.ToLower().Contains(search)
                      || s.strYearJoinESM.ToLower().Contains(search)
                      || s.strYearOfEntry.ToLower().Contains(search)
                      || s.strYOG.ToLower().Contains(search)
                      || s.strDateOfBirth.ToLower().Contains(search)
                      || s.Gender.ToLower().Contains(search)
                      || s.HostelAddress.ToLower().Contains(search)
                      || s.SocialMediaAddress.ToLower().Contains(search)
                      ||s.LGA.ToLower().Contains(search)
                      || s.StateOfOrigin.ToLower().Contains(search)
                      || s.HouseAddress.ToLower().Contains(search)
                      || s.Email.ToLower().Contains(search)
                      || s.Faculty.ToLower().Contains(search)
                      || s.CourseOfStudy.ToLower().Contains(search)).ToList();
                }
                totalRecord = generalMemberRecord.Count();
                generalMemberRecord = generalMemberRecord.OrderByDescending(s => s.Id).ToList();
                if (pageSize != -1)
                {
                    generalMemberRecord = generalMemberRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                }
                return Json(new
                {
                    draw,
                    recordsFiltered = totalRecord,
                    recordsTotal = totalRecord,
                    data = generalMemberRecord
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
