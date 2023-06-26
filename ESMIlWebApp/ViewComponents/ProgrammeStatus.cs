using ESMIlWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.ViewComponents
{
    [ViewComponent(Name = "ProgrammeStatus")]
    public class ProgrammeStatus : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = GetStatus();
            return View(result);
        }

        List<ProgrammeStatusModel> GetStatus()
        {
            List<ProgrammeStatusModel> reason = new List<ProgrammeStatusModel>()
            {
                new ProgrammeStatusModel{Value="Select value"},
                new ProgrammeStatusModel{Value="Done"},
                new ProgrammeStatusModel{Value="Pending"},
            };
            return reason.ToList();
        }
    }
}
