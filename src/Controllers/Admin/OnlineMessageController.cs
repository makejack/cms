using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models.Admin;
using www.veinid365.cn.Models.Admin.Response;

namespace www.veinid365.cn.Controllers.Admin
{
    // [Authorize]
    // [ApiController]
    // [Route("api/admin/onlinemessage")]
    // [Produces("application/json")]
    // public class OnlineMessageController : ControllerBase
    // {
    //     private readonly IRepositoryDefault<OnlineMessage> _repo;
    //     private readonly IMapper _mapper;

    //     public OnlineMessageController(IRepositoryDefault<OnlineMessage> repo, IMapper mapper)
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

    //         return Result.Ok(new PaginationResponse(totalRows, _mapper.Map<List<OnlineMessageListResponse>>(datas)));
    //     }
    // }
}