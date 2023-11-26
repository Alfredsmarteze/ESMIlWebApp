using Microsoft.AspNetCore.Mvc;
using Infrastructure.Interface;
using ESMIlWebApp.Ultilities;
using System.Net;
using DataStructure.ViewModel;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Identity;
using DataStructure;
using NuGet.Protocol;
using System.Text;
using System.IO;
using Cake.Core.IO;
using DataStructure.FileUpload;

namespace ESMIlWebApp.Controllers.AdmnControl
{
    public class AdminControlController : Controller
    {
        private readonly IAdminControl _adminControl;
        private readonly ILogger<AdminControlController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager; 
        private string errorMessage = string.Empty;
        public AdminControlController(SignInManager<ApplicationUser> signInManager, IAdminControl adminControl, ILogger<AdminControlController> logger)
        {
            _signInManager= signInManager;
            _adminControl = adminControl;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetPresidentCharge()
        {
            try
            {
                var ret = _adminControl.GetPresidentCharge();
                object df=ret;
                return Json(ret);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel { hasError = true, message = $"Error\n{errorMessage}", statusCode = (int)HttpStatusCode.BadRequest });
        }
        [HttpPost]
        public IActionResult GetAnnouncementOne()
        {
            try
            {
                var ret = _adminControl.GetAnnouncementOne();
                return Json(ret);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel { hasError = true, message = $"Error\n{errorMessage}", statusCode = (int)HttpStatusCode.BadRequest });
        }
        [HttpPost]
        public IActionResult GetAnnouncementTwo()
        {
            try
            {
                var ret = _adminControl.GetAnnouncementTwo();
                
                return Json(ret);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel { hasError = true, message = $"Error\n{errorMessage}", statusCode = (int)HttpStatusCode.BadRequest });
        }
        [HttpPost]
        public IActionResult GetAnnouncementThree()
        {
            try
            {
                var ret = _adminControl.GetAnnouncementThree();
                
                return Json(ret);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel { hasError = true, message = $"Error\n{errorMessage}", statusCode = (int)HttpStatusCode.BadRequest });
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCharge(string payload) 
        {
            try
            {
                if (payload != null)
                    payload = EncryptionExtensions.EncryptStringAES(payload);
                var payloadd = EncryptionExtensions.DecryptStringAES(payload);
                var newModel = JsonConvert.DeserializeObject<PresidentChargeData>(payloadd);
                var saveFirstTimer =await  _adminControl.AddOrUpdatePresidentCharge(newModel);
                if (saveFirstTimer)
                {
                    if (newModel.Id > 0)
                    {
                        return Json(new ResponseModel { message = $"Successfully Updated Record", hasError = false, statusCode = (int)HttpStatusCode.OK });
                    }
                    return Json(new ResponseModel { message = $"{newModel.Firstname} charge successfully saved!", hasError = false, statusCode = (int)HttpStatusCode.OK });
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
            return Json(new ResponseModel { hasError = true, message = $"Error\n{errorMessage}", statusCode = (int)HttpStatusCode.BadRequest });
        }

        [HttpPost]
        public async Task<IActionResult> EventImageDisplay(string payload)
        {
            try
            {
                if (payload != null)
                    payload = EncryptionExtensions.EncryptStringAES(payload);
                var payloadd = EncryptionExtensions.DecryptStringAES(payload);
                //  JsonConvert.DeserializeObject < typeof(payloadd) > (Encoding.UTF8.GetString(payloadd));
            //    byte[] jsonString = Encoding.UTF32.GetString(payloadd);

                byte[] serializedObject = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payloadd));
            //    var dffdf = System.IO.File.ReadAllText(payloadd);
                var newModel = JsonConvert.DeserializeObject<EventImageData>(System.IO.File.ReadAllText(payloadd));//(JsonConvert.DeserializeObject<string>(payloadd));// ToString();

                var saveEventImage = await _adminControl.AddOrUpdateEventImage(newModel);
                if (saveEventImage)
                {
                    if (newModel.Id > 0)
                    {
                        return Json(new ResponseModel { message = $"Successfully Updated Image", hasError = false, statusCode = (int)HttpStatusCode.OK });
                    }
                    return Json(new ResponseModel { message = $"Successfully saved Image!", hasError = false, statusCode = (int)HttpStatusCode.OK });
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
            return Json(new ResponseModel { hasError = true, message = $"Error\n{errorMessage}", statusCode = (int)HttpStatusCode.BadRequest });
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateAnnouncement(UploadFile payload)
        {
            try 
            {
              //  if (payload != null)
                //var ppayload = EncryptionExtensions.EncryptStringAES(payload.FileData);
                //var payloadd = EncryptionExtensions.DecryptStringAES(ppayload);
                var newModel = JsonConvert.DeserializeObject<AnnouncementData>(payload.FileData);
                newModel.Announcer = User.Identity.Name;
                if (payload.File.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        payload.File.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        newModel.Photo = fileBytes;
                    }
                }
                var saveAnnouncement = await _adminControl.AddOrUpdateAnnouncement(newModel);
                if (saveAnnouncement)
                {
                    if (newModel.Id > 0)
                    {
                        return Json(new ResponseModel { message = $"Successfully Updated Record", hasError = false, statusCode = (int)HttpStatusCode.OK });
                    }
                    return Json(new ResponseModel { message = $"Successfully saved!", hasError = false, statusCode = (int)HttpStatusCode.OK });
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
            return Json(new ResponseModel { hasError = true, message = $"Error\n{errorMessage}", statusCode = (int)HttpStatusCode.BadRequest });
        }

        public IActionResult GetAllAnnouncement()
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

                var announementRecord = _adminControl.ListAllAnnouncement().ToList();

                if (!string.IsNullOrWhiteSpace(search.ToString()))
                {
                    announementRecord = announementRecord.Where(s => s.AnnouncementOne.ToLower().Contains(search)
                      || s.AnnouncementTwo.ToLower().Contains(search)
                      || s.AnnouncementThree.ToLower().Contains(search)
                      || s.strAnnouncementDate.ToLower().Contains(search)
                      || s.Announcer.ToLower().Contains(search)).ToList();
                }
                totalRecord = announementRecord.Count();
                announementRecord = announementRecord.OrderByDescending(s => s.Id).ToList();
                if (pageSize != -1)
                {
                    announementRecord = announementRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                }
                return Json(new
                {
                    draw = draw,
                    recordsFiltered = totalRecord,
                    recordsTotal = totalRecord,
                    data = announementRecord
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel { hasError = true, message = $" Error:\n {errorMessage}" });


        }
        public IActionResult GetAllPresidentCharge()
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

                var presidentChargeRecord = _adminControl.ListAllPresidentChargeAsync().ToList();

                if (!string.IsNullOrWhiteSpace(search.ToString()))
                {
                    presidentChargeRecord = presidentChargeRecord.Where(s => s.Surname.ToLower().Contains(search)
                      || s.Firstname.ToLower().Contains(search)
                      || s.CourseOfStudy.ToLower().Contains(search)
                      || s.Charge.ToLower().Contains(search)
                      || s.Faculty.ToLower().Contains(search)
                      || s.Session.ToLower().Contains(search)
                      || s.strChargeDate.ToLower().Contains(search)).ToList();
                }
                totalRecord = presidentChargeRecord.Count();
                presidentChargeRecord = presidentChargeRecord.OrderByDescending(s => s.Id).ToList();
                if (pageSize != -1)
                {
                    presidentChargeRecord = presidentChargeRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                }
                return Json(new
                {
                    draw = draw,
                    recordsFiltered = totalRecord,
                    recordsTotal = totalRecord,
                    data = presidentChargeRecord
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel { hasError = true, message = $" Error:\n {errorMessage}" });


        }
    }
}
