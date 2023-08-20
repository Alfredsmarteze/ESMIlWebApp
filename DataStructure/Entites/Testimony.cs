using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Entites
{
    public class Testimony
    {
        public int Id { get; set; } 
        public string? Surname { get; set; }
        public string? Firstname { get;set; }
        public string? Department{ get;set; }
        public string? TheGoodNews { get; set; }
        public DateTime TestimonyDate { get; set; }
    }
}
