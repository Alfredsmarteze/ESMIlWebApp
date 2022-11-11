using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Entites
{
    public class FirstTimer
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Othernames { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string FacultyName{get; set; }   
        public string DepartmentName { get; set; }
        public DateTime? JoiningVisitingDate { get; set; }
        public string? ReasonOfComing { get; set; }
    }
}
