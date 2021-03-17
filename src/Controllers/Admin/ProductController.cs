using System.Collections.Generic;
using System.Security;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    // [Route("api/admin/product")]
    // [Produces("application/json")]
    // public class ProductController : ControllerBase
    // {
    //     private readonly IRepositoryDefault<Product> _repo;
    //     private readonly IMapper _mapper;

    //     public ProductController(IRepositoryDefault<Product> repo, IMapper mapper)
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

    //         return Result.Ok(new PaginationResponse(totalRows, _mapper.Map<List<ProductListResponse>>(datas)));
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<Result> Get(int id)
    //     {
    //         var product = await _repo.FirstOrDefaultAsync(id);
    //         if (product == null) return Result.Fail(ResultCodes.IdInvalid);

    //         return Result.Ok(_mapper.Map<ProductGetResponse>(product));
    //     }

    //     [HttpPost]
    //     public async Task<Result> Create([FromBody] ProductCreateRequest request)
    //     {
    //         var product = new Product(request.CategoryId, request.ImageUrl, request.Title, request.Content, request.IsPublished);

    //         await _repo.InsertAsync(product);

    //         return Result.Ok(request);
    //     }

    //     [HttpPut]
    //     public async Task<Result> Edit([FromBody] ProductEditRequest request)
    //     {
    //         var product = await _repo.FirstOrDefaultAsync(request.Id);
    //         if (product == null) return Result.Fail(ResultCodes.IdInvalid);

    //         product.Edit(request.CategoryId, request.ImageUrl, request.Title, request.Content, request.IsPublished);

    //         await _repo.UpdateAsync(product);

    //         return Result.Ok();
    //     }

    //     [HttpDelete("{id}")]
    //     public async Task<Result> Delete(int id)
    //     {
    //         var product = await _repo.FirstOrDefaultAsync(id);
    //         if (product == null) return Result.Fail(ResultCodes.IdInvalid);

    //         await _repo.RemoveAsync(product);

    //         return Result.Ok();
    //     }
    // }
}