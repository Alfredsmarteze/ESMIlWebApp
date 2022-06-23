using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModel
{
    public class PrayerUnitDTO
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string PhoneNumber01 { get; set; }
        public string PhoneNumber02 { get; set; }
        public string Gender { get; set; }
        public string StateOfOrigin { get; set; }
        public string LGA { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateJoinESM { get; set; }
        public string HostelAddress { get; set; }
        public string HomeAddress { get; set; }
        public string CourseOfStudy { get; set; }
        public string Unit { get; set; }
        public string PreviousUnit { get; set; }
        public string PositionInFamily { get; set; }
        public string SocialMediaAddress { get; set; }
        public string Photo { get; set; }
        public string? Ambition { get; set; }

        public string strDateOfBirth { get { if (DateOfBirth.HasValue) { return DateOfBirth.Value.ToString("MM/dd/yyyy"); } else { return string.Empty; } } }
        public string strDateJoinESM { get { if (DateJoinESM.HasValue) { return DateJoinESM.Value.ToString("MM/dd/yyyy"); } else { return string.Empty; } } }
    }

    public class PrayerUnitDTOData
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Gender { get; set; }
        public string Ambition { get; set; }
        public string PhoneNumber01 { get; set; }
        public string PhoneNumber02 { get; set; }
        public string? Email { get; set; }
        public string DateOfBirth { get; set; }
        public string DateJoinESM { get; set; }
        public string HostelAddress { get; set; }
        public string HomeAddress { get; set; }
        public string? CourseOfStudy { get; set; }
        public string Unit { get; set; }
        public string StateOfOrigin { get; set; }
        public string LGA { get; set; }
        public string PreviousUnit { get; set; }
        public string PositionInFamily { get; set; }
        public string SocialMediaAddress { get; set; }
        public IFormFile Image { get; set; }
        public string Photo { get; set; }
    }
}
