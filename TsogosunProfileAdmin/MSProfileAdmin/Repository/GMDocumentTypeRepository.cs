

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class GMDocumentTypeRepository : IGMDocumentTypeRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public GMDocumentTypeRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<GMDocumentTypeDto> GetDocumentTypesBySiteId(int siteId)
        {
            return _dbContext.GMDocumentTypeDtos.FromSqlRaw("pSel_DocumentTypes @SiteId",
                                                                        new SqlParameter("@SiteId", siteId)).ToList();
        }
    }
}
