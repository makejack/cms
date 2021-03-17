using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Models.Admin.Request
{
    public class AuthLoginRequest
    {
        [Required(ErrorMessage = "请输入账号")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}