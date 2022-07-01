
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface IUserRepository
    {
        List<UserDetailsDto> GetDetailsByUsername(string username);
        User GetUserByUsername(string username);
        User GetUserById(int userId);
        List<User> GetUsersByUnitsId(int unitId);
        void UpdateUser(User user);
        User AddUser(User user);
        List<User> GetAllUser(RequestUser requestUser);
        List<TitleDto> GetUserTitle();
        void Save();

    }
}

