using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    [Route("api/admin/navmenu")]
    [Produces("application/json")]
    public class NavMenuController : ControllerBase
    {
        private readonly IRepositoryDefault<NavMenu> _repo;
        private readonly IMapper _mapper;

        public NavMenuController(IRepositoryDefault<NavMenu> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<Result> List()
        {
            var allMenus = await _repo.Query().ToListAsync();

            var topMenus = _mapper.Map<List<NavMenuListResponse>>(allMenus.Where(e => e.ParentId == null).OrderBy(e => e.Order).ToList());
            GenerateMenus(allMenus, topMenus);

            return Result.Ok(topMenus);
        }

        private void GenerateMenus(List<NavMenu> allMenus, List<NavMenuListResponse> menus)
        {
            foreach (var item in menus)
            {
                item.Children = _mapper.Map<List<NavMenuListResponse>>(allMenus.Where(e => e.ParentId == item.Id).OrderBy(e => e.Order).ToList());
                if (item.Children.Count > 0)
                {
                    GenerateMenus(allMenus, item.Children);
                }
            }
        }

        [HttpGet("{id}")]
        public async Task<Result> Detail(int id)
        {
            var navMenu = await _repo.Query()
            .Include(e => e.WebsiteCustomForms)
            .FirstOrDefaultAsync(e => e.Id == id);
            if (navMenu == null) return Result.Fail(ResultCodes.IdInvalid);

            return Result.Ok(_mapper.Map<NavMenuDetailResponse>(navMenu));
        }

        [HttpPost]
        public async Task<Result> Create([FromBody] NavMenuCreateEditRequest request)
        {
            var navMenu = _mapper.Map<NavMenu>(request);
            await _repo.InsertAsync(navMenu);

            return Result.Ok();
        }

        [HttpPut]
        public async Task<Result> Edit([FromBody] NavMenuCreateEditRequest request)
        {
            var navMenu = await _repo.Query()
            .Include(e => e.WebsiteCustomForms)
            .FirstOrDefaultAsync(e => e.Id == request.Id);

            navMenu.Edit(request.ParentId,
                         request.Order,
                         request.Type,
                         request.ExternalUrl,
                         request.MenuName,
                         request.EnMenuName,
                         request.IsHidden,
                         request.BannerImg,
                         request.WebsiteKeywords,
                         request.WebsiteDescription,
                         request.Model,
                         request.ListTemplateFile,
                         request.ContentTemplateFile,
                         _mapper.Map<List<WebsiteCustomForm>>(request.WebsiteCustomForms));

            await _repo.UpdateAsync(navMenu);

            return Result.Ok();
        }

        [HttpPut("order")]
        public async Task<Result> ChangeOrder(int id, int order)
        {
            var menu = await _repo.FirstOrDefaultAsync(id);
            if (menu == null) return Result.Fail(ResultCodes.IdInvalid);

            menu.ChangeOrder(order);

            await _repo.UpdateAsync(menu);

            return Result.Ok();
        }

        [HttpDelete("{id}")]
        public async Task<Result> Delete(int id)
        {
            var navMenu = await _repo.Query().Include(e => e.Children).FirstOrDefaultAsync(e => e.Id == id);
            if (navMenu == null) return Result.Fail(ResultCodes.IdInvalid);
            if (navMenu.Children.Count > 0) return Result.Fail(ResultCodes.RequestParamError, "菜单包含子子项无法删除");

            await _repo.RemoveAsync(navMenu);

            return Result.Ok();
        }
    }
}