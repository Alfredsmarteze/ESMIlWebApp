using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModel
{
    public class FirstTimerDTO
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Othernames { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime? JoiningVisitingDate { get; set; }
        public string? ReasonOfComing { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string strDate
        {
            get
            {
                if (JoiningVisitingDate.HasValue)
                {
                    return JoiningVisitingDate.Value.ToString("MM/dd/yyy"); } else
                {
                    return string.Empty;
                } } }
    }
    public class FirstTimerData
        {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Othernames { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentName { get; set; }
        public string? JoiningVisitingDate { get; set; }
        public string? ReasonOfComing { get; set; }
    }
}
