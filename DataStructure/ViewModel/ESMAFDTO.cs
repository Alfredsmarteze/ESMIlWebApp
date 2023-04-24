﻿using DataStructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModel
{
    public class ESMAFDTO
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Othernames { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? HouseAddress { get; set; }
        public string? CourseOfStudy { get; set; }
        public string? Faculty { get; set; }
        public DateTime? YearOfEntry { get; set; }
        public DateTime? YearOfGraduation { get; set; }
        public string UnitServed { get; set; }
        public PastExecutive PastExcos { get; set; }
        public string strngYearOfEntry { get { if (YearOfEntry.HasValue) { return YearOfEntry.Value.ToString("MM/dd/yyyy"); } else return string.Empty; } }
        public string strngYearOfGraduation {get{ if (YearOfGraduation.HasValue) { return YearOfGraduation.Value.ToString("MM/dd/yyyy"); } else return string.Empty; } }
        
    }
    public class EsmafData
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Othernames { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? HouseAddress { get; set; }
        public string? CourseOfStudy { get; set; }
        public string? Faculty { get; set; }
        public string? YearOfEntry { get; set; }
        public string? YearOfGraduation { get; set; }
        public string AcademicSessionDate { get; set; }
        public string AcademicSessionDate2 { get; set; }
        public string UnitServed { get; set; }
        public string Office { get; set; }
        public PastExecutive PastExcos { get; set; }
        public enum GetPastExecutive
        {
            President = 1,
            Secretary = 2,
            Treasurer = 3,
            BibleStudyCordinator = 4,
            PrayerUnitCordinator = 5,
            ChoralUnitCordinator = 6,
            DramaUnitCordinator = 7,
            WelfareUnitCordinator = 8,
            DMEUnitCordinator = 9,
            TechnicalUnitCordinator = 10,
            UsheringUnitCordinator = 11,
            PublicityUnitCordinator = 12,
            TransportUnitCordinator = 13
        }
    }
}
