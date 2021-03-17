using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class AuthLoginResponse
    {
        public AuthLoginResponse(string token, UserResponse user)
        {
            this.Token = token;
            this.User = user;

        }
        public string Token { get; set; }

        public UserResponse User { get; set; }
    }
}