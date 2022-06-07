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
        Task<bool> AddOrUpdatePublicityUnit(PublicityUnitData publicityUnitData);
        Task<bool> AddOrUpdateDMEUnitAsync(DMEUnitData dMEUnitData);
        Task<bool> AddOrUpdateBibleStudyUnitAsync(BibleStudyUnitData bibleStudyUnitData);
        Task<bool> AddOrUpdatePrayerUnitAsync(PrayerUnitDTOData prayerUnitDTO);
        Task<bool> AddOrUpdateChoralUnitAsync(ChoralUnitData choralUnitData);
        IQueryable<PublicityAndEditorialUnitDTO> ListAllPublicityUnitAsync();
        IQueryable<DmeUnitDTO> ListAllDmeUnitData();
        IQueryable<BibleStudyUnitDTO> GetAllBibleStudyUnitsAsync();
        IQueryable<ChoralUnitDTO> GetAllChoralUnitsAsync();
        IQueryable<PrayerUnitDTO> ListAllPrayerUnitData();
        string DeletePublicityUnit(int id);
        string DeleteDmeUnit(int id);
        string DeleteBibleStudyUnit(int id);
        string DeleteChoralUnit(int id);
        string DeletePrayerUnit(int ids);
        IQueryable<StateDTO> ListState();
        
        
        
    }
}
