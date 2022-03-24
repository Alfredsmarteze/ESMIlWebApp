using ESMIlWebApp.Models;
using Microsoft.AspNetCore.Mvc; 
namespace ESMIlWebApp.ViewComponents
{
    [ViewComponent(Name= "Gender")]
    public class Gender: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = GenderList();
            return View(result);
        }
        List<GenderModel> GenderList()
        {
            List<GenderModel> result = new List<GenderModel>()
            {
                new GenderModel{ value="M", type="Male"},
                new GenderModel{ value="F", type="Female"}
            };
            return result.ToList();
        }
    }
}
