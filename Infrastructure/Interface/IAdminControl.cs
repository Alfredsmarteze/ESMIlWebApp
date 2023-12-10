using DataStructure.Entites;
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
        Task<bool> AddOrUpdateEventImage(EventImageData eventImageData);
        IQueryable GetPresidentCharge();
        Announcement GetAnnouncementOne();
        Announcement DisplayImage();
        byte[] ConvertImage(string sBase);
        IQueryable<PresidentChargeDTO> ListAllPresidentChargeAsync();
        Task<bool> AddOrUpdateAnnouncement(AnnouncementData announcementData);
        IQueryable<AnnouncementDTO> ListAllAnnouncement();
    }
}
