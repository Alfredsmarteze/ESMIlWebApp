using DataStructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IEsmafRepository
    {
        Task<bool> AddOrUpdateESMAfAsync(EsmafData pastExecutiveData);
        IQueryable<ESMAFDTO> ListAllEsmafAsync();
        IQueryable<PastExecutiveDTO> ListAllPastExecutive();
    }
}
