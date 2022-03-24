using DataStructure.ViewModel;
using ESMIlWebApp.Models;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESMIlWebApp.ViewComponents
{
    [ViewComponent(Name ="State")]
    public class StateOfOrigin:ViewComponent
    {
        private readonly IUnitRepository _repository;
        public StateOfOrigin(IUnitRepository repository)
        { 
            this._repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = GetState();
            return View(result);
        }
        List<StateDTO> GetState()
        {
            return  _repository.ListState().ToList();
        }


    }
}
