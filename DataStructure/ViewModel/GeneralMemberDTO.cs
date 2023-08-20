using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModel
{
   public  class GeneralMemberDTO
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Othername { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? HouseAddress { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? LGA { get; set; }
        public string? HostelAddress { get; set; }
        public string? SocialMediaAddress { get; set; }
        public string? CourseOfStudy { get; set; }
        public string? Faculty { get; set; }
        public string? Ambition { get; set; }
        public DateTime? YearOfEntry { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? YearJoinESM { get; set; }
        public string strYearOfEntry { get { if (YearOfEntry.HasValue) { return YearOfEntry.Value.ToString("MM/dd/yyyy"); } else { return string.Empty; } } }
        public string strYearJoinESM { get { if (YearJoinESM.HasValue) { return YearJoinESM.Value.ToString("MM/dd/yyyy"); } else { return string.Empty; } } } 
        public string strDateOfBirth { get { if (DateOfBirth.HasValue) { return DateOfBirth.Value.ToString("MM/dd/yyyy"); } else { return string.Empty; } } } 
    }

    public class GeneralMemberData
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Othername { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? HouseAddress { get; set; }
        public string? HostelAddress { get; set; }
        public string? SocialMediaAddress { get; set; }
        public string? Ambition { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? LGA { get; set; }
        public string? CourseOfStudy { get; set; }
        public string? Faculty { get; set; }
        public string YearOfEntry { get; set; }
        public string YearJoinESM { get; set; }
        public string DateOfBirth { get; set; }
    }

    
}
