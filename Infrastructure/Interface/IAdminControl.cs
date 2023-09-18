using DataStructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
   public  interface IAdminControl
    {
        Task<bool> AddOrUpdatePresidentCharge(PresidentChargeData presidentChargeData);
        IQueryable GetPresidentCharge();
        IQueryable GetAnnouncementOne();
        IQueryable GetAnnouncementTwo();
        IQueryable GetAnnouncementThree();
        IQueryable<PresidentChargeDTO> ListAllPresidentChargeAsync();
        Task<bool> AddOrUpdateAnnouncement(AnnouncementData announcementData);
        IQueryable<AnnouncementDTO> ListAllAnnouncement();
    }
}
