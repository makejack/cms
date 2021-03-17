using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Models.Admin.Request
{
    public class AuthRegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}