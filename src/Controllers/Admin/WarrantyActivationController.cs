using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models.Admin;

namespace www.veinid365.cn.Controllers.Admin
{
    /// <summary>
    /// 保修激活
    /// </summary>
    // [Authorize]
    // [ApiController]
    // [Route("api/admin/warrantyactivation")]
    // [Produces("application/json")]
    // public class WarrantyActivationController : ControllerBase
    // {
    //     private readonly IRepositoryDefault<WarrantyActivation> _repo;
    //     private readonly IMapper _mapper;

    //     public WarrantyActivationController(IRepositoryDefault<WarrantyActivation> repo, IMapper mapper)
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

    //         return Result.Ok(new PaginationResponse(totalRows, datas));
    //     }
    // }
}