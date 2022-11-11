using ESMIlWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.ViewComponents
{
    [ViewComponent(Name ="VisitingJoining")]
    public class ReasonOfComing:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = GetReason();
            return View(result);
        }

        List<ReasonOfComingModel> GetReason()
        {
            List<ReasonOfComingModel> reason = new List<ReasonOfComingModel>()
            {
                new ReasonOfComingModel{Value="Visiting", Type="Visiting"},
                new ReasonOfComingModel{Value="Joining", Type="Joining"},
            };
            return reason.ToList();
        }
    }
}
