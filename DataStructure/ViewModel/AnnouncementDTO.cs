using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModel
{
    public class AnnouncementDTO
    {
        
            public int Id { get; set; }
            public string AnnouncementOne { get; set; }
            public string AnnouncementTwo { get; set; }
            public string AnnouncementThree { get; set; }
            public DateTime? AnnouncementDate { get; set; }
            public string Announcer { get; set; }

            public string strAnnouncementDate
            {
                get
                {
                    if (AnnouncementDate.HasValue)
                    {
                        return AnnouncementDate.Value.ToString("MM/dd/yyyy");
                    }
                    else { return string.Empty; }
                } }
        

    }
    public class AnnouncementData
    {
        public int Id { get; set; }
        public string AnnouncementOne { get; set; }
        public string AnnouncementTwo { get; set; }
        public string AnnouncementThree { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public string Announcer { get; set; }
    }
}
