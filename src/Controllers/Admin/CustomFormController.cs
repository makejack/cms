using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models.Admin;
using www.veinid365.cn.Models.Admin.Request;
using www.veinid365.cn.Models.Admin.Response;

namespace www.veinid365.cn.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("api/admin/customform")]
    [Produces("application/json")]
    public class CustomFormController : ControllerBase
    {
        private readonly IRepositoryDefault<WebsiteCustomForm> _repo;
        private readonly IRepositoryDefault<WebsiteCustomFormValue> _formValueRepo;
        private readonly IMapper _mapper;

        public CustomFormController(IRepositoryDefault<WebsiteCustomForm> repo,
                                    IRepositoryDefault<WebsiteCustomFormValue> formValueRepo,
                                    IMapper mapper)
        {
            _repo = repo;
            _formValueRepo = formValueRepo;
            _mapper = mapper;
        }

        [HttpGet("table")]
        public async Task<Result> Table([FromQuery] WebsiteCustomFormListRequest request)
        {
            var headers = await _repo.Query()
            .Where(e => e.NavMenuId == request.MenuId && e.IsShowList)
            .ToListAsync();

            var query = _formValueRepo.Query().Where(e => e.NavMenuId == request.MenuId);
            var totalRows = await query.CountAsync();
            var data = await query.OrderByDescending(e => e.Id)
            .Skip((request.Page - 1) * request.Limit).Take(request.Limit)
            .ToListAsync();

            return Result.Ok(new WebsiteCustomFormTableResponse(_mapper.Map<List<WebsiteCustomFormTableHeaderResponse>>(headers), new PaginationResponse(totalRows, _mapper.Map<List<WebsiteCustomFormValueListResponse>>(data))));
        }

        [HttpDelete("value/{id}")]
        public async Task<Result> DeleteValue(int id)
        {
            var value = await _formValueRepo.FirstOrDefaultAsync(id);
            if (value == null) return Result.Fail(ResultCodes.IdInvalid);

            await _formValueRepo.RemoveAsync(value);

            return Result.Ok();
        }
    }
}