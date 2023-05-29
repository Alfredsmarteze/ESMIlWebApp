using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModel
{
    public class ProgrammeTableDTO
    {
        public int Id { get; set; }
        public string Speaker { get; set; }
        public string Programme { get; set; }
        public string Cordinator { get; set; }
        public string Note { get; set; }
        public string ProgrammeStatus { get; set; }
        public DateTime? ProgrammeDate { get; set; }
        public string strDate { get { if (ProgrammeDate.HasValue) { return ProgrammeDate.Value.ToString("MM/dd/yyyy"); } else return string.Empty; } }   
    }

    public class ProgrammeTableData 
    {
        public int Id { get; set; }
        public string Speaker { get; set; }
        public string Programme { get; set; }
        public string Cordinator { get; set; }
        public string Note { get; set; }
        public string ProgrammeDate { get; set; }
        public string ProgrammeStatus { get; set; }
    }
}
