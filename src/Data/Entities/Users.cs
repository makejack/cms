using System;
using System.ComponentModel.DataAnnotations;
using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Data.Entities
{
    public class Users : Aggregate
    {
        public Users()
        {
        }

        public Users(string userName, string passwordHash, string tel, string email, Roles role)
        {
            this.UserName = userName;
            this.PasswordHash = passwordHash;
            this.Tel = tel;
            this.Email = email;
            this.Role = role;
            this.LastLoginTime = DateTime.Now;
        }

        [Required]
        [MaxLength(512)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(512)]
        public string PasswordHash { get; set; }
        [MaxLength(512)]
        public string Tel { get; set; }
        [MaxLength(512)]
        public string Email { get; set; }
        public Roles Role { get; set; }
        public DateTime LastLoginTime { get; set; }


        public void ChangePwd(string newPwdHash)
        {
            this.PasswordHash = newPwdHash;
        }

        public void UpdateLoginTime()
        {
            this.LastLoginTime = DateTime.Now;
        }

        internal void Edit(string tel, string email)
        {
            this.Tel = tel;
            this.Email = email;
        }
    }
}