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
        private readonly ILogger<ESMAFController> _logger;
        string errorMessage = string.Empty;
        public ESMAFController(ILogger<ESMAFController> logger, IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
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
                errorMessage = e.Message;
            }
            return Json(new ResponseModel { message = $"Error\n{errorMessage}", hasError = true, statusCode = (int)HttpStatusCode.BadRequest });
        }
    }
}
