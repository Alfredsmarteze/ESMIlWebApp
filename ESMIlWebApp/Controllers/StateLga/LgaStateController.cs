using Microsoft.AspNetCore.Mvc;
using Infrastructure.Interface;
using ESMIlWebApp.Ultilities;
using ESMIlWebApp.Models;
using DataStructure.ViewModel;
using System.Net;
using Newtonsoft.Json;
using System.Data.Entity;

namespace ESMIlWebApp.Controllers.StateLga
{
    
    public class LgaStateController : Controller
    {
        private readonly IUnitRepository _repository;
        private readonly ILogger<LgaStateController> _logger;
        private string errorMessage = string.Empty;

        public LgaStateController(IUnitRepository repository, ILogger<LgaStateController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetLga(string statename)
        {
            var exceptionMessage = string.Empty;

            try
            {
                if (statename == null)
                {
                    return Json(new ResponseModel { message = "Bad request" });
                }
                var ret = _repository.GetState(statename);

                return Json(ret);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                errorMessage = ex.Message;
            }
            return Json(new ResponseModel { hasError = true, message = $" Errror Message: {errorMessage}", statusCode = (int)HttpStatusCode.NotImplemented });
        }
    }
}
