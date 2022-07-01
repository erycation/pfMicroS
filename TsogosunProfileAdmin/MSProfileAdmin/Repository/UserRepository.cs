

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Request;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public UserRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public User AddUser(User user)
        {

            var reqUser = new User
            {
                SiteID = user.SiteID,
                Username = user.Username,
                Firstname = user.Firstname,
                Surname = user.Surname,
                isActive = true
            };

            _dbContext.Users.Add(reqUser);

            return reqUser;
        }

        public List<UserDetailsDto> GetDetailsByUsername(string username)
        {

           return _dbContext.UserDetailsDtos.FromSqlRaw("pSEL_UserDetails @UserName",
                                                                        new SqlParameter("@UserName", username)).ToList();

        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.SingleOrDefault(u => u.UserID == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Username == username);
        }

        public List<User> GetUsersByUnitsId(int unitId)
        {
            return _dbContext.Users.Where(u => u.SiteID == unitId).ToList();
        }

        public List<User> GetAllUser(RequestUser requestUser)
        {
            var usersQuery = _dbContext.Users.Where(u => u.SiteID == requestUser.UnitId).ToList();

            if(!string.IsNullOrEmpty(requestUser.Username))
            {
                usersQuery = usersQuery.Where(u => u.Username.ToLower().Contains(requestUser.Username.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(requestUser.Firstname))
            {
                usersQuery = usersQuery.Where(u => u.Firstname.ToLower().Contains(requestUser.Firstname.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(requestUser.Surname))
            {
                usersQuery = usersQuery.Where(u => u.Surname.ToLower().Contains(requestUser.Surname.ToLower())).ToList();
            }

            return usersQuery;

        }

        public List<TitleDto> GetUserTitle()
        {

            return _dbContext.TitleDtos.FromSqlRaw("pPDETAILS_GetTitles").ToList();

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
        }
    }
}
