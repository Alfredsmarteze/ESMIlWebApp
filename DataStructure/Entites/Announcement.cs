﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Entites
{
    public class Announcement
    {
        public int Id { get; set; }
        public string AnnouncementOne { get; set; }
        public string AnnouncementTwo { get; set; }
        public string AnnouncementThree { get; set; }
        public string? Announcer { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public byte[]? EventImage { get; set; }
        public byte[]? DisplayImage { get; set; }
        public byte[]? DisplayImage2 { get; set; }
        public byte[]? DisplayImage3 { get; set; }
    }
}
