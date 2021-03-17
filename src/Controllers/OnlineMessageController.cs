using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models;
using www.veinid365.cn.Models.Admin;

namespace src.Controllers
{
    // public class OnlineMessageController : Controller
    // {
    //     private readonly IRepositoryDefault<OnlineMessage> _repo;

    //     public OnlineMessageController(IRepositoryDefault<OnlineMessage> repo)
    //     {
    //         _repo = repo;
    //     }

    //     [HttpPost("create")]
    //     public async Task<IActionResult> Create([FromForm] OnlineMessageCreateRequest request)
    //     {
    //         var onlineMessage = new OnlineMessage(request.UserName, request.Tel, request.Email, request.Message);

    //         await _repo.InsertAsync(onlineMessage);

    //         return Ok(Result.Ok());
    //     }
    // }
}