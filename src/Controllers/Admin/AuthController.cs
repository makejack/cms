using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models.Admin;
using www.veinid365.cn.Models.Admin.Request;
using www.veinid365.cn.Models.Admin.Response;
using www.veinid365.cn.Services;

namespace www.veinid365.cn.Controllers.Admin
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/admin/auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _tokenService;
        private readonly IRepositoryDefault<Users> _repo;
        private readonly IMapper _mapper;

        public AuthController(IJwtTokenService tokenService, IRepositoryDefault<Users> repo, IMapper mapper)
        {
            _tokenService = tokenService;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<Result> Login([FromBody] AuthLoginRequest request)
        {
            var user = await _repo.Query().FirstOrDefaultAsync(e => e.UserName == request.UserName);
            if (user == null)
            {
                return Result.Fail(ResultCodes.IdInvalid);
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Result.Fail(ResultCodes.PasswordError);
            }

            var token = _tokenService.GenerateJwtToken(user);

            user.UpdateLoginTime();

            await _repo.UpdateAsync(user);

            return Result.Ok(new AuthLoginResponse(token, _mapper.Map<UserResponse>(user)));
        }

        [HttpPost("register")]
        public async Task<Result> Register([FromBody] AuthRegisterRequest request)
        {
            var count = await _repo.Query().CountAsync();
            if (count != 0) return Result.Fail(ResultCodes.RequestParamError, "不允许注册");
            var isAny = await _repo.Query().AnyAsync(e => e.UserName == request.UserName);
            if (isAny)
            {
                return Result.Fail(ResultCodes.UserExists);
            }

            var user = new Users(request.UserName, BCrypt.Net.BCrypt.HashPassword(request.Password), request.Tel, request.Email, Data.Shared.Roles.Admin);
            await _repo.InsertAsync(user);

            return Result.Ok();
        }
    }
}