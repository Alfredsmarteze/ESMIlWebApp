﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Entites
{
    public class TransportUnit
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public string? PhoneNumber01 { get; set; }
        public string? PhoneNumber02 { get; set; }
        public string? Ambition { get; set; }
        public string? Gender { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? LGA { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateJoinESM { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? HostelAddress { get; set; }
        public string? HomeAddress { get; set; }
        public string? CourseOfStudy { get; set; }
        public string? Unit { get; set; }
        public string? PreviousUnit { get; set; }
        public string? PositionInFamily { get; set; }
        public string? SocialMediaAddress { get; set; }
        public string? Photo { get; set; }
    }
}
