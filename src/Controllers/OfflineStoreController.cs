using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models.Admin;
// using X.PagedList;

namespace src.Controllers
{
    // public class OfflineStoreController : Controller
    // {
    //     private readonly IRepositoryDefault<OfflineStore> _repo;

    //     public OfflineStoreController(IRepositoryDefault<OfflineStore> repo)
    //     {
    //         _repo = repo;
    //     }


    //     [HttpGet]
    //     public IActionResult Index([FromQuery] PaginationRequest request)
    //     {
    //         var query = _repo.Query();
    //         var data = query.OrderByDescending(e => e.Id).ToPagedList(request.Page, request.Limit);

    //         return Ok(data);
    //     }

    // }
}