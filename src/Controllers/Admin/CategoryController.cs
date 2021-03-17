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
using www.veinid365.cn.Data.Shared;
using www.veinid365.cn.Models.Admin;
using www.veinid365.cn.Models.Admin.Request;
using www.veinid365.cn.Models.Admin.Response;

namespace src.Controllers.Admin
{
    // [Authorize]
    // [ApiController]
    // [Route("api/admin/category")]
    // [Produces("application/json")]
    // public class CategoryController : ControllerBase
    // {
    //     private readonly IRepositoryDefault<Category> _repo;
    //     private readonly IMapper _mapper;

    //     public CategoryController(IRepositoryDefault<Category> repo, IMapper mapper)
    //     {
    //         _repo = repo;
    //         _mapper = mapper;
    //     }

    //     [HttpGet("all")]
    //     public async Task<Result> All(CategoryTypes type)
    //     {
    //         var datas = await _repo.Query().Where(e => e.Type == type).ToListAsync();

    //         return Result.Ok(_mapper.Map<List<CategoryResponse>>(datas));
    //     }

    //     [HttpGet("list")]
    //     public async Task<Result> List([FromQuery] PaginationRequest request)
    //     {
    //         var queryable = _repo.Query();
    //         var totalRows = await queryable.CountAsync();
    //         var datas = await queryable.OrderByDescending(e => e.Id).Skip((request.Page - 1) * request.Limit).Take(request.Limit).ToListAsync();

    //         return Result.Ok(new PaginationResponse(totalRows, _mapper.Map<List<CategoryResponse>>(datas)));
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<Result> Detail(int id)
    //     {
    //         var news = await _repo.FirstOrDefaultAsync(id);
    //         if (news == null) return Result.Fail(ResultCodes.IdInvalid);

    //         return Result.Ok(_mapper.Map<CategoryResponse>(news));
    //     }

    //     [HttpPost]
    //     public async Task<Result> Create([FromBody] CategoryCreateRequest request)
    //     {
    //         var category = new Category(request.Title, request.Type);

    //         await _repo.InsertAsync(category);

    //         return Result.Ok();
    //     }

    //     [HttpPut]
    //     public async Task<Result> Edit([FromBody] CategoryEditRequest request)
    //     {
    //         var category = await _repo.FirstOrDefaultAsync(request.Id);
    //         if (category == null) return Result.Fail(ResultCodes.IdInvalid);

    //         category.Edit(request.Title, request.Type);

    //         await _repo.UpdateAsync(category);

    //         return Result.Ok();
    //     }

    //     [HttpDelete("{id}")]
    //     public async Task<Result> Delete(int id)
    //     {
    //         var category = await _repo.Query()
    //         .Include(e => e.Products)
    //         .Include(e => e.Solutions)
    //         .FirstOrDefaultAsync(e => e.Id == id);
    //         if (category == null) return Result.Fail(ResultCodes.IdInvalid);
    //         if (category.Products.Count > 0) return Result.Fail(ResultCodes.RequestParamError, "分类已在使用在无法删除");
    //         if (category.Solutions.Count > 0) return Result.Fail(ResultCodes.RequestParamError, "分类已在使用在无法删除");

    //         await _repo.RemoveAsync(category);

    //         return Result.Ok();
    //     }
    // }
}