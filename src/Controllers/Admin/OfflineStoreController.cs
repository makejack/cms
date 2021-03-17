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
    // [Route("api/admin/offlinestore")]
    // [Produces("application/json")]
    // public class OfflineStoreController : ControllerBase
    // {
    //     private readonly IRepositoryDefault<OfflineStore> _repo;
    //     private readonly IMapper _mapper;

    //     public OfflineStoreController(IRepositoryDefault<OfflineStore> repo, IMapper mapper)
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

    //         return Result.Ok(new PaginationResponse(totalRows, _mapper.Map<List<OfflineStoreListResponse>>(datas)));
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<Result> Detail(int id)
    //     {
    //         var offlineStore = await _repo.FirstOrDefaultAsync(id);
    //         if (offlineStore == null) return Result.Fail(ResultCodes.IdInvalid);

    //         return Result.Ok(_mapper.Map<OfflineStoreDetailResponse>(offlineStore));
    //     }

    //     [HttpPost]
    //     public async Task<Result> Create([FromBody] OfflineStoreCreateRequest request)
    //     {
    //         var offlineStore = new OfflineStore(request.ImageUrl, request.StoreName);

    //         await _repo.InsertAsync(offlineStore);

    //         return Result.Ok();
    //     }

    //     [HttpPut]
    //     public async Task<Result> Edit([FromBody] OfflineStoreEditRequest request)
    //     {
    //         var offlineStore = await _repo.FirstOrDefaultAsync(request.Id);
    //         if (offlineStore == null) return Result.Fail(ResultCodes.IdInvalid);

    //         offlineStore.Edit(request.ImageUrl, request.StoreName);

    //         await _repo.UpdateAsync(offlineStore);

    //         return Result.Ok();
    //     }

    //     [HttpDelete("{id}")]
    //     public async Task<Result> Delete(int id)
    //     {
    //         var offlineStore = await _repo.FirstOrDefaultAsync(id);
    //         if (offlineStore == null) return Result.Fail(ResultCodes.IdInvalid);

    //         await _repo.RemoveAsync(offlineStore);

    //         return Result.Ok();
    //     }
    // }
}