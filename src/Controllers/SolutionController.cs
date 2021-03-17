using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models;
using www.veinid365.cn.Models.Admin;
// using X.PagedList;

namespace www.veinid365.cn.Controllers
{
    // public class SolutionController : Controller
    // {
    //     private readonly IRepositoryDefault<Solution> _repo;

    //     public SolutionController(IRepositoryDefault<Solution> repo)
    //     {
    //         _repo = repo;
    //     }

    //     [HttpGet]
    //     public IActionResult Index([FromQuery] CategoryQueryRequest request)
    //     {
    //         var query = _repo.Query();
    //         if (request.CategoryId.HasValue)
    //         {
    //             query = query.Where(e => e.CategoryId == request.CategoryId);
    //         }
    //         var data = query.OrderByDescending(e => e.Id).ToPagedList(request.Page, request.Limit);

    //         return View(data);
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<IActionResult> Detail(int id)
    //     {
    //         var product = await _repo.FirstOrDefaultAsync(id);
    //         if (product == null) return NotFound();

    //         return View(product);
    //     }
    // }
}