using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Entites
{
    public class GeneralMember
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Othername { get; set; }
        public string? Gender { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? Lga { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? HouseAddress { get; set; }
        public string? HostelAddress { get; set; }
        public string? SocialMediaAddress { get; set; }
        public string? CourseOfStudy { get; set; }
        public string? Faculty { get; set; }
        public string? Ambition { get; set; }
        public DateTime YearOfEntry { get; set; }
        public DateTime YearOfGraduation { get; set; }
        public DateTime YearJoinESM { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Image { get; set; }
    }
}
