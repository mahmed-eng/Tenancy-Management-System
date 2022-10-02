using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TenantManagementSystem.Models
{
    public class FileUpload
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public IEnumerable<FileUpload> FileList { get; set; }
    }
}