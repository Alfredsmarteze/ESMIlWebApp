using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.Controllers.Testimony
{
    public class ESMAFDataViewController : Controller
    {
        private readonly IEsmafRepository _esmafRepository;

        public ESMAFDataViewController(IEsmafRepository esmafRepository) 
        {
        this._esmafRepository = esmafRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("All/PastExecutive")]
        public IActionResult AllPastExecutive() => View();
    }
}
