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
    // [Authorize]
    // [ApiController]
    // [Route("api/admin/solution")]
    // [Produces("application/json")]
    // public class SolutionController : ControllerBase
    // {
    //     private readonly IRepositoryDefault<Solution> _repo;
    //     private readonly IMapper _mapper;

    //     public SolutionController(IRepositoryDefault<Solution> repo, IMapper mapper)
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

    //         return Result.Ok(new PaginationResponse(totalRows, _mapper.Map<List<SolutionListResponse>>(datas)));
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<Result> Detail(int id)
    //     {
    //         var solution = await _repo.FirstOrDefaultAsync(id);
    //         if (solution == null) return Result.Fail(ResultCodes.IdInvalid);

    //         return Result.Ok(_mapper.Map<SolutionDetailResponse>(solution));
    //     }

    //     [HttpPost]
    //     public async Task<Result> Create([FromBody] SolutionCreateRequest request)
    //     {
    //         var solution = new Solution(request.CategoryId, request.ImageUrl, request.Title, request.Content, request.IsPublished);

    //         await _repo.InsertAsync(solution);

    //         return Result.Ok();
    //     }

    //     [HttpPut]
    //     public async Task<Result> Edit([FromBody] SolutionEditRequest request)
    //     {
    //         var solution = await _repo.FirstOrDefaultAsync(request.Id);
    //         if (solution == null) return Result.Fail(ResultCodes.IdInvalid);

    //         solution.Edit(request.CategoryId, request.ImageUrl, request.Title, request.Content, request.IsPublished);

    //         await _repo.UpdateAsync(solution);

    //         return Result.Ok();
    //     }

    //     [HttpDelete("{id}")]
    //     public async Task<Result> Delete(int id)
    //     {
    //         var solution = await _repo.FirstOrDefaultAsync(id);
    //         if (solution == null) return Result.Fail(ResultCodes.IdInvalid);

    //         await _repo.RemoveAsync(solution);

    //         return Result.Ok();
    //     }
    // }
}