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
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string HostelAddress { get; set; }
        public string HomeAddress { get; set; }
        public string CourseOfStudy { get; set; }
        public string Unit { get; set; }
        public string PreviousUnit { get; set; }
        public string PositionInFamily { get; set; }
        public string SocialMediaAddress { get; set; }
        public string Photo { get; set; }
         
        public string strDateOfBirth { get { if (DateOfBirth.HasValue) { return DateOfBirth.Value.ToString("dd/MM/yyyy"); } else { return string.Empty; } } }
    }

    public class PrayerUnitDTOData
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string phoneNumber01 { get; set; }
        public string phoneNumber02 { get; set; }
        public string? email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string hostelAddress { get; set; }
        public string homeAddress { get; set; }
        public string courseOfStudy { get; set; }
        public string unit { get; set; }
        public string previousUnit { get; set; }
        public string positionInFamily { get; set; }
        public string socialMediaAddress { get; set; }
        public IFormFile Image { get; set; }
        public string photo { get; set; }
    }
}
