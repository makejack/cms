using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models.Admin;
using www.veinid365.cn.Models.Admin.Request;
using www.veinid365.cn.Models.Admin.Response;

namespace www.veinid365.cn.Controllers.Admin
{
    // [Authorize]
    // [ApiController]
    // [Route("api/admin/news")]
    // [Produces("application/json")]
    // public class NewsController : ControllerBase
    // {
    //     private readonly IRepositoryDefault<News> _repo;
    //     private readonly IMapper _mapper;

    //     public NewsController(IRepositoryDefault<News> repo, IMapper mapper)
    //     {
    //         _repo = repo;
    //         _mapper = mapper;
    //     }

    //     [HttpGet("list")]
    //     public async Task<Result> List([FromQuery] PaginationRequest request)
    //     {
    //         var queryable = _repo.Query();
    //         var totalRows = await queryable.CountAsync();
    //         var datas = await queryable.OrderByDescending(e => e.Id).Skip((request.Page - 1) * request.Limit).Take(request.Limit).ToListAsync();

    //         return Result.Ok(new PaginationResponse(totalRows, _mapper.Map<List<NewsListResponse>>(datas)));
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<Result> Detail(int id)
    //     {
    //         var news = await _repo.FirstOrDefaultAsync(id);
    //         if (news == null) return Result.Fail(ResultCodes.IdInvalid);

    //         return Result.Ok(_mapper.Map<NewsDetailResponse>(news));
    //     }

    //     [HttpPost]
    //     public async Task<Result> Create([FromBody] NewsCreateRequest request)
    //     {
    //         var news = new News(request.ImageUrl, request.Title, request.Content, request.IsPublished);

    //         await _repo.InsertAsync(news);

    //         return Result.Ok();
    //     }

    //     [HttpPut]
    //     public async Task<Result> Edit([FromBody] NewsEditRequest request)
    //     {
    //         var news = await _repo.FirstOrDefaultAsync(request.Id);
    //         if (news == null) return Result.Fail(ResultCodes.IdInvalid);

    //         news.Edit(request.ImageUrl, request.Title, request.Content, request.IsPublished);

    //         await _repo.UpdateAsync(news);

    //         return Result.Ok();
    //     }

    //     [HttpDelete("{id}")]
    //     public async Task<Result> Delete(int id)
    //     {
    //         var news = await _repo.FirstOrDefaultAsync(id);
    //         if (news == null) return Result.Fail(ResultCodes.IdInvalid);

    //         await _repo.RemoveAsync(news);

    //         return Result.Ok();
    //     }
    // }
}