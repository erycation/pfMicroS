
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class DefaultPermissionGroupRepository : IDefaultPermissionGroupRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public DefaultPermissionGroupRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<DefaultPermissionGroup> GetDefaultPermissionGroups()
        {
            return _dbContext.DefaultPermissionGroups.ToList();
        }

        public void AddDefaultPermissionGroup(int userID, int defaultGroupID)
        {
            
                _dbContext.Database.ExecuteSqlRaw("pINS_DefaultUser @UserID, @DefaultGroupID", 
                                                    new SqlParameter("@UserID", userID), 
                                                        new SqlParameter("@DefaultGroupID", defaultGroupID));
           
        }
    }
}
