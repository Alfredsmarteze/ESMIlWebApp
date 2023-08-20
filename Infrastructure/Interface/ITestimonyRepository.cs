using DataStructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface ITestimonyRepository
    {
        IQueryable<TestimonyDTO> ListAllTestimony();
        Task<bool> AddOrUpdateTestimony(TestimonyData testimonyData);
        Task<bool> AddTestimonyNumberToDisplay(TestimonyNumberData testimonyNumberData);
        IQueryable TestimonyNumberToDisplay();
        IQueryable GetTestimonyToDisplay(int c);
    }
}
