using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Services
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(Users user);
    }
}