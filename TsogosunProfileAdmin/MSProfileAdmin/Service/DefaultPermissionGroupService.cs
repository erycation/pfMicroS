

using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class DefaultPermissionGroupService : IDefaultPermissionGroupService
    {

        private readonly IDefaultPermissionGroupRepository _defaultPermissionGroupRepository;

        public DefaultPermissionGroupService(IDefaultPermissionGroupRepository defaultPermissionGroupRepository)
        {
            _defaultPermissionGroupRepository = defaultPermissionGroupRepository;
        }

        public List<DefaultPermissionGroup> GetAllDefaultPermissionGroups()
        {
            return _defaultPermissionGroupRepository.GetDefaultPermissionGroups();
        }

        public List<DefaultPermissionGroup> GetActiveDefaultPermissionGroups(int siteId)
        {
            return _defaultPermissionGroupRepository.GetDefaultPermissionGroups().Where(p => p.Active == true && p.SiteID == siteId).ToList();
        }

        public void AddDefaultPermissionGroup(int userID, int defaultGroupID)
        {
            _defaultPermissionGroupRepository.AddDefaultPermissionGroup(userID, defaultGroupID);
        }
    }
}
