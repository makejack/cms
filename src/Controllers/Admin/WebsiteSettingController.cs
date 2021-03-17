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
    [Route("api/admin/websitesetting")]
    [Produces("application/json")]
    public class WebsiteSettingController : ControllerBase
    {
        private readonly IRepositoryDefault<WebsiteSetting> _repo;
        private readonly IMapper _mapper;

        public WebsiteSettingController(IRepositoryDefault<WebsiteSetting> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<Result> Get()
        {
            var setting = await _repo.Query().Include(e => e.WebsiteCustomParams).FirstOrDefaultAsync();
            if (setting == null)
                setting = new WebsiteSetting();

            return Result.Ok(_mapper.Map<WebsiteSettingResponse>(setting));
        }

        [HttpPost]
        public async Task<Result> Save([FromBody] WebsiteSettingSaveRequest request)
        {
            WebsiteSetting setting = null;
            if (request.Id > 0)
            {
                setting = await _repo.Query()
                .Include(e => e.WebsiteCustomParams)
                .FirstOrDefaultAsync(e => e.Id == request.Id);
                setting.Edit(request, _mapper.Map<List<WebsiteCustomParam>>(request.WebsiteCustomParams));
                await _repo.UpdateAsync(setting);
            }
            else
            {
                setting = _mapper.Map<WebsiteSetting>(request);
                await _repo.InsertAsync(setting);
            }

            return Result.Ok();
        }
    }
}