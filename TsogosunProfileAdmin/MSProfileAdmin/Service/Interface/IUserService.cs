
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Shared.Utils;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IUserService
    {
        List<UserDetailsDto> GetDetailsByUsername(string username);
        UserApplicationSectionDto GetUserApplicationSectionById(int userId);
        UserDto GetUserByUsername(string username);
        UserDto GetUserById(int userId);
        List<UserDto> GetUsersByUnitsId(int unitId);
        List<UserDto> GetAllUser(RequestUser requestUser);
        List<TitleDto> GetUserTitle();     
        void UpdateUser(UserDto userDto);
        UserDto AddUser(User user, int permisionGroupId);
    }
}
