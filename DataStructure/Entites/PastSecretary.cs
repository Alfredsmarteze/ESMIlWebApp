using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Entites
{
    public class PastSecretary
    {
        public int Id { get; set; }
        public string? SurnameExcos { get; set; }
        public string? OthernameExcos { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? AcademicSectionDate { get; set; }
        [ForeignKey("EsmafId")]
        public ESMAF ESMAF { get; set; }
        public int EsmafId { get; set; }
    }
}
