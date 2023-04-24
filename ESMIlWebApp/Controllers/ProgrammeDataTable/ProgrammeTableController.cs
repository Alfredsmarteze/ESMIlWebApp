using DataContextStructure;
using DataStructure.ViewModel;
using ESMIlWebApp.Ultilities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ESMIlWebApp.Controllers.ProgrammeDataTable
{
   // [Route("api/[controller]")]
   // [ApiController]
    public class ProgrammeTableController : ControllerBase
    {
        private readonly IProgrammeTableRepository _programmeTableRepository;
        private readonly ILogger<ProgrammeTableController> _logger;
        private readonly ESMContext _context;
        string errorMessage;
      public  ProgrammeTableController(IProgrammeTableRepository programmeTableRepository, ILogger<ProgrammeTableController> logger, ESMContext context) 
        {
            this._programmeTableRepository=programmeTableRepository;
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
                return Ok(new
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
            return Ok(new ResponseModel { message = $" Error:\a {errorMessage}" });
        }

        public async Task<IActionResult> AddOrUpdateProgrammeData(string payload)
        {
            try
            {
                //  byte[] con = Convert.FromBase64String(payload);
                // var coon = con.ToString();
                var payloadd = EncryptionExtensions.EncryptStringAES(payload);
                payload = EncryptionExtensions.DecryptStringAES(payload);
                var newModel = JsonConvert.DeserializeObject<ProgrammeTableData>(payload);
                var saveProgrammeData = await _programmeTableRepository.AddOrUpdateProgrammeTableAsync(newModel);

                if (saveProgrammeData)
                {
                    return Ok(new ResponseModel { hasError = false, message = "Operation successful", statusCode = (int)HttpStatusCode.OK });
                }
                else
                {
                    return Ok(new ResponseModel { hasError = true, message = "Operation not successful", statusCode = (int)HttpStatusCode.InternalServerError });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex.Message);
                errorMessage = ex.Message;
            }
            return Ok(new ResponseModel { message = $"Error Message: {errorMessage}", statusCode = (int)HttpStatusCode.Conflict });
        }
    }
}
