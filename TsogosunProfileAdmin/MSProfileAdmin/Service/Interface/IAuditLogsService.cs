
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IAuditLogsService
    {
        List<LogFilesDto> GetLogFiles();
        void DeleteLogFiles();

    }
}
