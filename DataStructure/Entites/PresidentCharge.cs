using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Entites
{
    public class PresidentCharge
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Charge { get; set; }
        public string Session { get; set; }
        public DateTime? ChargeDate { get; set; }
        public string CourseOfStudy { get; set; }
        public string Faculty { get; set; }
    }
}
