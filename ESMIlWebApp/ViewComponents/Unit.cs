using ESMIlWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.ViewComponents
{
    [ViewComponent(Name ="Unit")]
    public class Unit: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = UnitList();
            return View(result);
        }
        List<UnitModel> UnitList()
        {
            List<UnitModel> result = new List<UnitModel>()
         {
         new UnitModel{ Value="Select Unit"},
         new UnitModel{ Value="Prayer"},
         new UnitModel{ Value="DME"},
         new UnitModel{ Value="Bible Study"},
         new UnitModel{ Value="Welfare"},
         new UnitModel{ Value="Choral"},
         new UnitModel{ Value="Technical"},
         new UnitModel{ Value="Transport"},
         new UnitModel{ Value="Prayer"},
         };
            return result.ToList();
        }

    }
}
