using System;
using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class UserResponse : AggregateModel
    {
        public string UserName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}