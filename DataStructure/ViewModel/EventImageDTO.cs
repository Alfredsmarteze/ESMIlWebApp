using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModel
{
    public class EventImageDTO
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public byte[] EventDescriptionImage { get; set; }

    }
    public class EventImageData
    {
        public int Id { get; set; }
       
        public string EventName { get; set; }
        public IFormFile File { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
