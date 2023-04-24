using DataStructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IProgrammeTableRepository
    {
        Task<bool> AddOrUpdateProgrammeTableAsync(ProgrammeTableData programmeTableData);
        IQueryable<ProgrammeTableDTO> GetAllProgrammeTableAsync();
    }
}
