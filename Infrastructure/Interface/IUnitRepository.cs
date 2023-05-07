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
        Task AddUpdateESMAfAsync<T>(T pastExecutiveData);
        Task<bool> AddOrUpdateESMAfAsync(EsmafData pastExecutiveData);
        Task<bool> AddOrUpdateFirstTimerAsync(FirstTimerData firstTimerData);
        Task<bool> AddOrUpdateTransportUnitAsync(TransportUnitData transportUnitData);
        Task<bool> AddOrUpdateUsheringUnitAsync(UsheringUnitData usheringUnitData);
        Task<bool> AddOrUpdateTechnicalUnitAsync(TechnicalUnitData technicalUnitData);
        Task<bool> AddOrUpdateWelfareUnitAsync(WelfareUnitData welfareUnitDTO);
        Task<bool> AddOrUpdatePublicityUnit(PublicityUnitData publicityUnitData);
        Task<bool> AddOrUpdateDMEUnitAsync(DMEUnitData dMEUnitData);
        Task<bool> AddOrUpdateBibleStudyUnitAsync(BibleStudyUnitData bibleStudyUnitData);
        Task<bool> AddOrUpdatePrayerUnitAsync(PrayerUnitDTOData prayerUnitDTO);
        Task<bool> AddOrUpdateChoralUnitAsync(ChoralUnitData choralUnitData);
        IQueryable<FirstTimerDTO> ListAllFirstTimerAsync();
        IQueryable<ESMAFDTO>ListAllEsmafAsync();
        IQueryable<TransportUnitDTO> ListAllTransportUnitAsync();
        IQueryable<UsheringUnitDTO> ListAllUsheringUnitAsync();
        IQueryable<TechnicalUnitDTO> ListAllTechnicalUnitAsync();
        IQueryable<WelfareUnitDTO> ListAllWelfareUnitAsync();
        IQueryable<PublicityAndEditorialUnitDTO> ListAllPublicityUnitAsync();
        IQueryable<DmeUnitDTO> ListAllDmeUnitData();
        IQueryable<BibleStudyUnitDTO> GetAllBibleStudyUnitsAsync();
        IQueryable<ChoralUnitDTO> GetAllChoralUnitsAsync();
        IQueryable<PrayerUnitDTO> ListAllPrayerUnitData();
        string DeleteTransportUnitById(int id);
        string DeleteUsheringUnitById(int id); 
        string DeleteTechnicalUnitById(int id);
        string DeleteWelfareUnitById(int id);
        string DeletePublicityUnitById(int id);
        string DeleteDmeUnitById(int id);
        string DeleteBibleStudyUnitById(int id);
        string DeleteChoralUnitById(int id);
        string DeletePrayerUnitById(int ids);
        IQueryable<StateDTO> ListState();
        IQueryable<LgaDTO> ListLga();   
        
        
        
    }
}
