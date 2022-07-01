using System;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class UserDto
    {
        public UserDto(User user)
        {
            UserID = user.UserID;
            SiteID = user.SiteID;
            Username = user.Username;
            isActive = user.isActive;
            Status = user.Status;
            DateCreated = user.DateCreated;
            SiteFullName = user?.Site?.SiteFullName;
            Firstname = user.Firstname;
            Surname = user.Surname;
        }

        public UserDto()
        {

        }
        public int UserID { get; set; }
        public int SiteID { get; set; }
        public string Username { get; set; }
        public bool isActive { get; set; }
        public DateTime DateCreated { get; set; }
        public string SiteFullName { get; set; }
        public string Status { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
    }
}
