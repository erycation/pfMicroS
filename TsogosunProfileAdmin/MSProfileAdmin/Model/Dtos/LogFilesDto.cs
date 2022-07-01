
using System;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class LogFilesDto
    {
        public string FileName { get; set; }
        public DateTime DateCreated { get; set; }
        public string FullPathName { get; set; }
        public long FileSize { get; set; }

    }
}
