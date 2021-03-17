using System.Security;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Extensions;
using www.veinid365.cn.Models.Admin;
using www.veinid365.cn.Models.Admin.Request;
using www.veinid365.cn.Data.Shared;
using www.veinid365.cn.Models.Admin.Response;

namespace www.veinid365.cn.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("api/admin/user")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryDefault<Users> _repo;
        private readonly IMapper _mapper;

        public UserController(IRepositoryDefault<Users> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<Result> List()
        {
            var users = await _repo.Query().OrderByDescending(e => e.Id).ToListAsync();

            return Result.Ok(_mapper.Map<List<UserResponse>>(users));
        }

        [HttpGet("{id}")]
        public async Task<Result> Get(int id)
        {
            var user = await _repo.Query().FirstOrDefaultAsync(e => e.Id == id);
            if (user == null) return Result.Fail(ResultCodes.IdInvalid);

            return Result.Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpPost("changepwd")]
        public async Task<Result> ChangePwd([FromBody] UserChangePwdRequest request)
        {
            var userId = HttpContext.GetUserId();
            var user = await _repo.FirstOrDefaultAsync(userId);

            if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, user.PasswordHash))
                return Result.Fail(ResultCodes.PasswordError);

            user.ChangePwd(BCrypt.Net.BCrypt.HashPassword(request.NewPassword));

            await _repo.SaveAsync();

            return Result.Ok();
        }

        [HttpPost]
        public async Task<Result> Create([FromBody] AuthRegisterRequest request)
        {
            var userId = HttpContext.GetUserId();
            var isAdmin = await _repo.Query().AnyAsync(e => e.Id == userId && e.Role == Roles.Admin);
            if (!isAdmin) return Result.Fail(ResultCodes.RequestParamError, "只允许管理员操作");

            var isAny = await _repo.Query().AnyAsync(e => e.UserName == request.UserName);
            if (isAny)
            {
                return Result.Fail(ResultCodes.UserExists);
            }

            var user = new Users(request.UserName,
                                 BCrypt.Net.BCrypt.HashPassword(request.Password),
                                 request.Tel,
                                 request.Email,
                                 Data.Shared.Roles.User);
            await _repo.InsertAsync(user);

            return Result.Ok();
        }

        [HttpPut]
        public async Task<Result> Edit([FromBody] UserEditRequest request)
        {
            var userId = HttpContext.GetUserId();
            var isAdmin = await _repo.Query().AnyAsync(e => e.Id == userId && e.Role == Roles.Admin);
            if (!isAdmin) return Result.Fail(ResultCodes.RequestParamError, "只允许管理员操作");

            var user = await _repo.Query().FirstOrDefaultAsync(e => e.Id == request.Id);
            if (user == null) return Result.Fail(ResultCodes.IdInvalid);

            user.Edit(request.Tel, request.Email);

            await _repo.UpdateAsync(user);

            return Result.Ok();
        }

        [HttpDelete("{id}")]
        public async Task<Result> Delete(int id)
        {
            var userId = HttpContext.GetUserId();
            var isAdmin = await _repo.Query().AnyAsync(e => e.Id == userId && e.Role == Roles.Admin);
            if (!isAdmin) return Result.Fail(ResultCodes.RequestParamError, "只允许管理员操作");
            var user = await _repo.Query().FirstOrDefaultAsync(e => e.Id == id);
            if (user == null) return Result.Fail(ResultCodes.IdInvalid);
            if (user.Role == Roles.Admin) return Result.Fail(ResultCodes.RequestParamError, "管理员不允许删除");

            await _repo.RemoveAsync(user);

            return Result.Ok();
        }
    }
}