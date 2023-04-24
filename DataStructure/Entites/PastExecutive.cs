﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Entites
{
    public class PastExecutive
    {
        
        public int Id { get; set; }
        public string? SurnameExcos { get; set; }
        public string? OthernameExcos { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set;  }
        public string? Office { get; set; }
        public string? AcademicSectionDate { get; set; }
        //public DateTime? AcademicSectionDate2 { get; set; }
        //public DateTime? FullAcademicSectionDate { get; set; }
        public ESMAF ESMAF { get; set; }
        [Key]
        public int EsmafId { get; set; }
    }
}