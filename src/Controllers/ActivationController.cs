using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models;

namespace www.veinid365.cn.Controllers
{
    // public class ActivationController : Controller
    // {
    //     private readonly IRepositoryDefault<WarrantyActivation> _repo;

    //     public ActivationController(IRepositoryDefault<WarrantyActivation> repo)
    //     {
    //         _repo = repo;
    //     }

    //     [HttpPost]
    //     public async Task<IActionResult> Save([FromForm] ActivationSaveRequest request)
    //     {
    //         var warrantyActivation = new WarrantyActivation(request.SerialNumber, request.UserName, request.AgentName, request.PurchaseDate, request.Email, request.Tel, request.ImgUrl);

    //         await _repo.InsertAsync(warrantyActivation);

    //         return Ok();
    //     }
    // }
}