using DataContextStructure;
using DataStructure.ViewModel;
using ESMIlWebApp.Ultilities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ESMIlWebApp.Controllers.ProgrammeDataTable
{
    public class ProgrammeTableDataController : Controller
    {
        private readonly IProgrammeTableRepository _programmeTableRepository;
        private readonly ILogger<ProgrammeTableDataController> _logger;
        private readonly ESMContext _context;
        string errorMessage;
        public ProgrammeTableDataController(IProgrammeTableRepository programmeTableRepository, ILogger<ProgrammeTableDataController> logger, ESMContext context)
        {
            this._programmeTableRepository = programmeTableRepository;
            this._logger = logger;
            this._context = context;
        }
        public IActionResult GetAllProgrammeData()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();

                var search = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int totalRecord = 0;

                var programmeDataRecord = _programmeTableRepository.GetAllProgrammeTableAsync().ToList();

                if (!string.IsNullOrWhiteSpace(search.ToString()))
                {
                    programmeDataRecord = programmeDataRecord.Where(s => s.Speaker.ToLower().Contains(search)
                      || s.Cordinator.ToLower().Contains(search)
                      || s.Programme.ToLower().Contains(search)
                      || s.Note.ToLower().Contains(search)
                      || s.strDate.ToLower().Contains(search)).ToList();

                }
                totalRecord = programmeDataRecord.Count();
                programmeDataRecord = programmeDataRecord.OrderByDescending(s => s.Id).ToList();
                //prayerRecord = prayerRecord.OrderBy(s=>s.Id).ToList();
                if (pageSize != -1)
                {
                    programmeDataRecord = programmeDataRecord.OrderByDescending(s => s.Id).Skip(skip).Take(pageSize).ToList();
                }
                return Json(new
                {
                    draw = draw,
                    recordsFiltered = totalRecord,
                    recordsTotal = totalRecord,
                    data = programmeDataRecord
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Error", e.Message);
                errorMessage = e.Message;
            }
            return Json(new ResponseModel { message = $" Error:\a {errorMessage}" });
        }

        public async Task<IActionResult> AddOrUpdateProgrammeData(string payload)
        {
            try
            {
                //  byte[] con = Convert.FromBase64String(payload);
                // var coon = con.ToString();
                 payload = EncryptionExtensions.EncryptStringAES(payload);
             var payloadd = EncryptionExtensions.DecryptStringAES(payload);
                var newModel = JsonConvert.DeserializeObject<ProgrammeTableData>(payloadd);
                var saveProgrammeData = await _programmeTableRepository.AddOrUpdateProgrammeTableAsync(newModel);

                if (saveProgrammeData)
               // {
                    return Json(new ResponseModel { hasError = false, message = "Operation successful", statusCode = (int)HttpStatusCode.OK });
               // }
               // else
              // {
                    return Json(new ResponseModel { hasError = true, message = "Operation not successful", statusCode = (int)HttpStatusCode.InternalServerError });
               //}
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex.Message);
                errorMessage = ex.Message;
            }
            return Json(new ResponseModel { message = $"Error Message: {errorMessage}", statusCode = (int)HttpStatusCode.Conflict });
        }
    }
}
