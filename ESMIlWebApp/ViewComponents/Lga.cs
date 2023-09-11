using DataStructure.ViewModel;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.ViewComponents
{
    [ViewComponent(Name ="Lga")]
    public class Lga:ViewComponent
    {
        private readonly IUnitRepository _unitRepository;
        public Lga(IUnitRepository unitRepository)
        {
            this._unitRepository = unitRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var getLga = GetAllLga();
            return View(getLga);
        }
        List<LgaDTO> GetAllLga() 
        {
          return _unitRepository.ListLga().ToList();
        }
    }
}
