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
        Task<bool> AddOrUpdatePrayerUnit(PrayerUnitDTOData model);
    }
}
