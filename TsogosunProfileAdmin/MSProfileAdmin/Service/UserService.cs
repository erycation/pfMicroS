
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;
using tsogosun.com.MSProfileAdmin.Shared.Enum;
using tsogosun.com.MSProfileAdmin.Shared.Helpers;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IDefaultPermissionGroupService _defaultPermissionGroupService;

        public UserService(IUserRepository userRepository,
                            IDefaultPermissionGroupService defaultPermissionGroupService)
        {
            _userRepository = userRepository;
            _defaultPermissionGroupService = defaultPermissionGroupService;
        }

        public UserDto AddUser(User user, int permisionGroupId)
        {
            var userDtoDetails = GetUserByUsername(user.Username);
            if(userDtoDetails.Username != null)
                throw new AppException($"Username {user.Username} already exist");
   
            var responseUser = _userRepository.AddUser(user);
            _userRepository.Save();
            _defaultPermissionGroupService.AddDefaultPermissionGroup(responseUser.UserID, permisionGroupId);
            return new UserDto(responseUser);

        }
        public List<UserDetailsDto> GetDetailsByUsername(string username)
        {
            return _userRepository.GetDetailsByUsername(username);
        }

        public UserApplicationSectionDto GetUserApplicationSectionById(int userId)
        {

            var applications = new List<ApplicationDto>();

            var userApplicationSectionDto = new UserApplicationSectionDto();

            userApplicationSectionDto.UserDto = new UserDto(_userRepository.GetUserById(userId));

            var userDetails = GetDetailsByUsername(userApplicationSectionDto?.UserDto?.Username);

            if (userDetails[0].ReturnCode == 0)
            {
                foreach (var userDetail in userDetails)
                {
                    if (!applications.Exists(a => a.ApplicationName == userDetail.ApplicationName))
                    {
                        var sectionItems = userDetails.Where(a => a.ApplicationName == userDetail.ApplicationName);

                        var sections = new List<SectionDto>();

                        foreach (var section in sectionItems)
                        {
                            if (!sections.Exists(s => s.SectionName == section.SectionName))
                            {

                                var sites = new List<SiteDto>();

                                var siteItem = userDetails.Where(a => a.SectionName == section.SectionName);

                                foreach (var site in siteItem)
                                {
                                    sites.Add(new SiteDto { SiteID = site.SiteID, SiteName = site.SiteName, SiteFullName = site.SiteFullName });
                                }

                                sections.Add(new SectionDto { SectionId = section.SectionID, SectionName = section.SectionName, IsSectionMenuItem = section.IsSectionMenuItem, WebsiteSectionRoute = section.WebsiteSectionRoute, Sites = sites });

                            }
                        }

                        applications.Add(new ApplicationDto { ApplicationId = userDetail.ApplicationID, ApplicationName = userDetail.ApplicationName, IsApplicationMenuItem = userDetail.IsApplicationMenuItem, WebsiteRoute = userDetail.WebsiteRoute, Sections = sections });
                    }                    
                }

                userApplicationSectionDto.CanViewPersonalDetails = userDetails.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.PersonalDetails.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                userApplicationSectionDto.CanUpdatePatron = userDetails.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.UpdatePatron.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                userApplicationSectionDto.CanViewGamingPoints = userDetails.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.GamingDetails.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                userApplicationSectionDto.CanViewKPI = userDetails.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.KPI.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                userApplicationSectionDto.CanViewOffers = userDetails.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.Offers.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                userApplicationSectionDto.CanViewVIP = userDetails.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.VIP.ToString().ToLower()).FirstOrDefault() == null ? false : true;
               
                userApplicationSectionDto.Applications = applications;
            }
            return userApplicationSectionDto;
        }

        public UserDto GetUserById(int userId)
        {
            var userDto = _userRepository.GetUserById(userId);
            return userDto != null ? new UserDto(userDto) : new UserDto();
        }

        public UserDto GetUserByUsername(string username)
        {
            var userDto = _userRepository.GetUserByUsername(username);
            return userDto != null ? new UserDto(userDto) :  new UserDto();

        }

        public List<UserDto> GetUsersByUnitsId(int unitId)
        {
            var users = _userRepository.GetUsersByUnitsId(unitId);
            var usersDto = new List<UserDto>();

            foreach(var user in users)
            {
                usersDto.Add(new UserDto(user));
            }

            return usersDto;
        }

        public List<UserDto> GetAllUser(RequestUser requestUser)
        {
            var users = _userRepository.GetAllUser(requestUser);
            var usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                usersDto.Add(new UserDto(user));
            }

            return usersDto;
        }

        public List<TitleDto> GetUserTitle()
        {
            return _userRepository.GetUserTitle();
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = _userRepository.GetUserById(userDto.UserID);
            user.Firstname = userDto.Firstname;
            user.Surname = userDto.Surname;
            user.isActive = userDto.isActive;
            _userRepository.UpdateUser(user);
            _userRepository.Save();
        }
    }
}
