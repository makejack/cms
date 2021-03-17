using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Data.Shared;
using www.veinid365.cn.Models.Admin;
using www.veinid365.cn.Models.Admin.Request;
using www.veinid365.cn.Models.Admin.Response;

namespace src.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("api/admin/pagecontent")]
    public class PageContentController : ControllerBase
    {
        private readonly IRepositoryDefault<PageContent> _repo;
        private readonly IRepositoryDefault<NavMenu> _menuRepo;
        private readonly IMapper _mapper;

        public PageContentController(IRepositoryDefault<PageContent> repo, IRepositoryDefault<NavMenu> menuRepo, IMapper mapper)
        {
            _repo = repo;
            _menuRepo = menuRepo;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<Result> List([FromQuery] PageContentListRequest request)
        {
            var query = _repo.Query();
            if (request.MenuId.HasValue && request.MenuId.Value > 0)
            {
                var menuIds = await _menuRepo.Query().Where(e => e.ParentId == request.MenuId).Select(e => e.Id).ToListAsync();
                if (menuIds.Count > 0)
                {
                    query = query.Where(e => menuIds.Contains(e.NavMenuId));
                }
                else
                {
                    query = query.Where(e => e.NavMenuId == request.MenuId);
                }
            }
            else
            {
                query = query.Where(e => e.NavMenu.Model != NavMenuModels.SinglePage);
            }
            var totalRows = await query.CountAsync();
            var data = await query.OrderByDescending(e => e.Id)
            .Include(e => e.NavMenu)
            .Skip((request.Page - 1) * request.Limit).Take(request.Limit)
            .ToListAsync();

            return Result.Ok(new PaginationResponse(totalRows, _mapper.Map<List<PageContentListResponse>>(data)));
        }

        [HttpGet("content/{menuId}")]
        public async Task<Result> Content(int menuId)
        {
            var pageContent = await _repo.Query().Where(e => e.NavMenuId == menuId).FirstOrDefaultAsync();
            if (pageContent == null)
            {
                pageContent = new PageContent();
            }

            return Result.Ok(_mapper.Map<PageContentDetailResponse>(pageContent));
        }

        [HttpGet("{id}")]
        public async Task<Result> Detail(int id)
        {
            var pageContent = await _repo.Query()
            .Include(e => e.DownloadFiles)
            .FirstOrDefaultAsync(e => e.Id == id);
            if (pageContent == null) return Result.Fail(ResultCodes.IdInvalid);

            return Result.Ok(_mapper.Map<PageContentDetailResponse>(pageContent));
        }

        [HttpPost]
        public async Task<Result> Create([FromBody] PageContentCreateEditRequest request)
        {
            var menu = await _menuRepo.FirstOrDefaultAsync(request.NavMenuId);
            if (menu == null) return Result.Fail(ResultCodes.IdInvalid, "菜单Id无效");
            if (string.IsNullOrEmpty(request.Title))
            {
                request.Title = menu.MenuName;
            }
            var pageContent = _mapper.Map<PageContent>(request);

            await _repo.InsertAsync(pageContent);

            return Result.Ok();
        }

        [HttpPut]
        public async Task<Result> Edit([FromBody] PageContentCreateEditRequest request)
        {
            var pageContent = await _repo.FirstOrDefaultAsync(request.Id);

            pageContent.Edit(request.NavMenuId,
                             request.Title,
                             request.Thumbnail,
                             request.Content,
                             request.IsPublished,
                             request.WebsiteTitle,
                             request.WebsiteKeywords,
                             request.WebsiteDescription,
                             _mapper.Map<List<DownloadFile>>(request.DownloadFiles));

            await _repo.UpdateAsync(pageContent);

            return Result.Ok();
        }

        [HttpDelete("{id}")]
        public async Task<Result> Delete(int id)
        {
            var pageContent = await _repo.FirstOrDefaultAsync(id);
            if (pageContent == null) return Result.Fail(ResultCodes.IdInvalid);

            await _repo.RemoveAsync(pageContent);

            return Result.Ok();
        }
    }
}