using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure.ViewModel;

namespace Infrastructure.Interface
{
    public interface IUnitRepository
    {
        IQueryable<StateDTO> ListState();
        Task<bool> AddOrUpdatePrayerUnitAsync(PrayerUnitDTOData prayerUnitDTO);
        IQueryable<PrayerUnitDTO> ListAllPrayerUnitData();
        string DeletePrayerUnit(int ids);
    }
}
