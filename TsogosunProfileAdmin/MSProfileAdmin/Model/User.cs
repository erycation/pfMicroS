using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tsogosun.com.MSProfileAdmin.Model
{
    [Table("mUser")]
    public class User
    {
        public User()
        {
            this.UserPermissions = new HashSet<UserPermission>();
        }
        [Key]
        public int UserID { get; set; }
        public int SiteID { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public bool isActive { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual Site Site { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
        [NotMapped]
        public string Status
        {
            get
            { return isActive == true ? "Active" : "Not Active" ; }
        }
    }
}


