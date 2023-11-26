using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.FileUpload
{
    public class UploadFile
    {
        public IFormFile? File{get;set;}
        public string? FileData { get;set;}
    }
}
