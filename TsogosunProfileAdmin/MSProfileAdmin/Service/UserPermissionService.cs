

using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;
using tsogosun.com.MSProfileAdmin.Shared.Utils;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserPermissionRepository _userPermissionRepository;

        public UserPermissionService(IUserPermissionRepository userPermissionRepository)
        {
            _userPermissionRepository = userPermissionRepository;
        }
        public OutputResults AddUserPermission(UserPermission userPermission)
        {

            var requestUserPermission = new UserPermission
            {
                UserID = userPermission.UserID,
                SiteID = userPermission.SiteID,
                ApplicationID = userPermission.ApplicationID,
                ApplicationSectionID = userPermission.ApplicationSectionID,
                isActive = true
            };

            var responseUserPermission = _userPermissionRepository.GetUserPermissionByUserApplicationSectionId(requestUserPermission.UserID,
                                                                                                                requestUserPermission.SiteID, 
                                                                                                                requestUserPermission.ApplicationID,
                                                                                                                requestUserPermission.ApplicationSectionID);

            if(responseUserPermission != null)
            {
                responseUserPermission.isActive = true;
                _userPermissionRepository.UpdateUserPermission(responseUserPermission);
                _userPermissionRepository.Save();
                return new OutputResults { Success = true };
            }

            _userPermissionRepository.AddUserPermission(requestUserPermission);
            _userPermissionRepository.Save();
            return new OutputResults { Success = true };
        }

        public OutputResults DeactivateUserPermission(UserPermission userPermission)
        {

            var responseUserPermission = _userPermissionRepository.GetUserPermissionByUserApplicationSectionId(userPermission.UserID,
                                                                                                                  userPermission.SiteID,
                                                                                                                  userPermission.ApplicationID,
                                                                                                                  userPermission.ApplicationSectionID);

            
                responseUserPermission.isActive = false;
                _userPermissionRepository.UpdateUserPermission(responseUserPermission);
                _userPermissionRepository.Save();
                return new OutputResults { Success = true };
            
        }
    }
}

