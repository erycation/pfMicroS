
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class SiteRepository : ISiteRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public SiteRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<Site> GetAllSites()
        {
            return _dbContext.Sites.ToList();
        }
    }
}
