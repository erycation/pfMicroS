

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class AuditLogsService : IAuditLogsService
    {

        private readonly IConfiguration _configuration;

        public AuditLogsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<LogFilesDto> GetLogFiles()
        {

            var logFilesDto = new List<LogFilesDto>();
            var folderConfiguration = _configuration.GetSection("LogFolderConfig").Get<LogFolderConfig>();

            DirectoryInfo directory = new DirectoryInfo(@folderConfiguration.FolderName);

            FileInfo[] Files = directory.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();

            foreach (FileInfo file in Files)
            {
                logFilesDto.Add(new LogFilesDto { FileName = file.Name, DateCreated = file.CreationTime, FullPathName = folderConfiguration.VirtualDirectorateUrl + "" + file.Name, FileSize = file.Length });

            }

            return logFilesDto;
        }

        public void DeleteLogFiles()
        {

            var logFilesDto = new List<LogFilesDto>();
            var folderConfiguration = _configuration.GetSection("LogFolderConfig").Get<LogFolderConfig>();

            DirectoryInfo directory = new DirectoryInfo(@folderConfiguration.FolderName);

            FileInfo[] Files = directory.GetFiles().Where(p => p.CreationTime < System.DateTime.Now.AddDays(30)).ToArray();

            foreach (FileInfo file in Files)
            {
                file.Delete();
                
            }
        }
    }
}
