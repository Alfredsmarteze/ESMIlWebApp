using ESMIlWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.ViewComponents
{
    [ViewComponent(Name = "pastunitcordinator")]
    public class PastUnitCordinator : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = UnitCord();
            return View(result);
        }


        List<PastUnitCordinatorModel> UnitCord()
        {

            List<PastUnitCordinatorModel> pastUnitCordinators = new List<PastUnitCordinatorModel>()
            {
               new PastUnitCordinatorModel {Value = "Select Unit" },
               new PastUnitCordinatorModel {Value="President"},
               new PastUnitCordinatorModel {Value="Secretary"},
               new PastUnitCordinatorModel {Value="Treasurer"},
               new PastUnitCordinatorModel {Value ="BibleStudyCordinator" },
               new PastUnitCordinatorModel {Value="PrayerUnitCordinator"},
               new PastUnitCordinatorModel {Value="ChoralUnitCordinator"},
               new PastUnitCordinatorModel {Value="DramaUnitCordinator"},
               new PastUnitCordinatorModel {Value="WelfareUnitCordinator"},
               new PastUnitCordinatorModel {Value="DMEUnitCordinator"},
               new PastUnitCordinatorModel {Value="TechnicalUnitCordinator"},
               new PastUnitCordinatorModel {Value="UsheringUnitCordinator"},
               new PastUnitCordinatorModel {Value="PublicityUnitCordinator"},
               new PastUnitCordinatorModel {Value="TransportUnitCordinator"},
               new PastUnitCordinatorModel {Value="SisterUnitCordinator"},
               new PastUnitCordinatorModel {Value="BrotherUnitCordinator"},
            };
            return pastUnitCordinators.ToList();
        }
    }
}
