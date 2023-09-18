using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.PartialViewDTO
{
    public class DTOPresidentCharge
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Charge { get; set; }
        public string Session { get; set; }
        public DateTime? ChargeDate { get; set; }
        public string CourseOfStudy { get; set; }
        public string Faculty { get; set; }

        public string strChargeDate { get { if (ChargeDate.HasValue) { return string.Format("MM/dd/yyyy"); } else return string.Empty; } }
    }
}
