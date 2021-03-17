using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models.Admin;
// using X.PagedList;

namespace www.veinid365.cn.Controllers
{
    // public class NewsController : Controller
    // {
    //     private readonly IRepositoryDefault<News> _repo;

    //     public NewsController(IRepositoryDefault<News> repo)
    //     {
    //         _repo = repo;
    //     }

    //     [HttpGet]
    //     public IActionResult Index([FromQuery] PaginationRequest request)
    //     {
    //         var query = _repo.Query().OrderByDescending(e => e.Id);
    //         var data = query.ToPagedList(request.Page, request.Limit);

    //         return View(data);
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<IActionResult> Detail(int id)
    //     {
    //         var news = await _repo.FirstOrDefaultAsync(id);
    //         if (news == null) return NotFound();

    //         return View(news);
    //     }
    // }
}