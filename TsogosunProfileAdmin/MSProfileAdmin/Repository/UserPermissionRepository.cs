

using Microsoft.EntityFrameworkCore;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class UserPermissionRepository : IUserPermissionRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public UserPermissionRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public UserPermission GetUserPermissionByUserApplicationSectionId(int userId, int siteId, int applicationId, int sectionId)
        {

            return _dbContext.UserPermissions.FirstOrDefault(u => u.UserID == userId && 
                                                               u.SiteID == siteId &&
                                                                u.ApplicationID == applicationId &&
                                                                 u.ApplicationSectionID == sectionId);

        }

        public void AddUserPermission(UserPermission userPermission)
        {

            _dbContext.UserPermissions.Add(userPermission);

        }

        public void UpdateUserPermission(UserPermission userPermission)
        {

            _dbContext.Entry(userPermission).State = EntityState.Modified;

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
