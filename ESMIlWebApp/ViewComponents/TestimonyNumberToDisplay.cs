using ESMIlWebApp.Models;
using Microsoft.AspNetCore.Mvc; 
namespace ESMIlWebApp.ViewComponents
{
    [ViewComponent(Name= "TestimonyNumberToDisplay")]
    public class TestimonyNumberToDisplay: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = TestimonyNumberList();
            return View(result);
        }
        List<TestimonyNumberModel> TestimonyNumberList()
        {
            List<TestimonyNumberModel> result = new List<TestimonyNumberModel>()
            {new TestimonyNumberModel{ Value="Select Value"},
                new TestimonyNumberModel{ Value="2"},
                new TestimonyNumberModel{ Value="3"},
                new TestimonyNumberModel{ Value="4"},
                new TestimonyNumberModel{ Value="5"},
            };
            return result.ToList();
        }
    }
}
