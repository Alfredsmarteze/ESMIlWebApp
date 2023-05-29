using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.Models
{
    [ViewComponent(Name ="ProgrammeStatus")]
    public class ProgrammeStatus: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            var result= ProgrammeStatusList();
            return View(result);
        }
         List<ProgrammeStatusModel> ProgrammeStatusList()
        {

            List<ProgrammeStatusModel> programmeStatusModels = new List<ProgrammeStatusModel>()
            {
                new ProgrammeStatusModel{Value="Select Status"},
                new ProgrammeStatusModel{Value="Done"},
                new ProgrammeStatusModel{Value="Pending"}
            };
            return programmeStatusModels.ToList();
        }
    }
}
