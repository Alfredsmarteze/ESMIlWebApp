using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Entites
{
    public class ESMAF
    {
        [Key]
        public  int? Id { get; set; }
        public string? Surname { get; set; }
        public string? Othernames { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? HouseAddress { get; set; }
        public string? CourseOfStudy { get; set; }
        public string? Faculty { get; set; }
        public int  YearOfEntry { get; set; }
        public int YearOfGraduation { get; set; }
        public string? UnitServed { get; set; }
        public int AcademicSessionDate { get; set; }
        public int AcademicSessionDate2 { get; set; }
        public byte Image { get; set; }
        public int? PastId { get; set; }
    }
    
}
