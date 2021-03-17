using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Data.Shared;
using www.veinid365.cn.Models;
using www.veinid365.cn.Models.Admin;
// using X.PagedList;

namespace www.veinid365.cn.Controllers
{
    // public class ProductController : Controller
    // {
    //     private readonly IRepositoryDefault<Product> _repo;
    //     private readonly IRepositoryDefault<Category> _categoryRepo;

    //     public ProductController(IRepositoryDefault<Product> repo, IRepositoryDefault<Category> categoryRepo)
    //     {
    //         _repo = repo;
    //         _categoryRepo = categoryRepo;
    //     }

    //     [HttpGet]
    //     public async Task<IActionResult> Index([FromQuery] CategoryQueryRequest request)
    //     {
    //         var categorys = await _categoryRepo.Query().Where(e => e.Type == CategoryTypes.Product).ToListAsync();

    //         var query = _repo.Query();
    //         if (request.CategoryId.HasValue)
    //         {
    //             query = query.Where(e => e.CategoryId == request.CategoryId);
    //         }
    //         var data = query.OrderByDescending(e => e.Id).ToPagedList(request.Page, request.Limit);

    //         return View(new ProductIndexViewModel(categorys, data));
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