using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModel
{
    public class TestimonyDTO
    {       public int Id { get; set; }
            public string Surname { get; set; }
            public string Firstname { get; set; }
            public string Department { get; set; }
            public string TheGoodNews { get; set; }
            public DateTime? TestimonyDate { get; set; }
        public string strDate { get { if (TestimonyDate.HasValue) { return TestimonyDate.Value.ToString("MM/dd/yyyy"); } else { return string.Empty; } } }
    }


    public class TestimonyData
    {
        public int Id {set;get;}
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Department { get; set; }
        public string TheGoodNews { get; set; }
        public string TestimonyDate { get; set; }
    }
}
