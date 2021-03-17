using System.Security;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Data.Shared;
using www.veinid365.cn.Models;
using www.veinid365.cn.Utils;
using Fluid;
using Fluid.Ast;
using www.veinid365.cn.Fluid;
using www.veinid365.cn.Services;
using MimeKit;

namespace www.veinid365.cn.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IRepositoryDefault<WebsiteSetting> _websiteSettingRepo;
        private readonly IRepositoryDefault<NavMenu> _menuRepo;
        private readonly IRepositoryDefault<PageContent> _contentRepo;
        private readonly IRepositoryDefault<WebsiteCustomForm> _formRepo;
        private readonly IRepositoryDefault<WebsiteCustomFormValue> _formValueRepo;
        private readonly IRepositoryDefault<Users> _userRepo;
        private readonly FluidProvider _fluidProvider;
        private readonly IEmailService _emailService;

        public HomeController(IWebHostEnvironment env,
                              IRepositoryDefault<WebsiteSetting> websiteSettingRepo,
                              IRepositoryDefault<NavMenu> menuRepo,
                              IRepositoryDefault<PageContent> contentRepo,
                              IRepositoryDefault<WebsiteCustomForm> formRepo,
                              IRepositoryDefault<WebsiteCustomFormValue> formValueRepo,
                              IRepositoryDefault<Users> userRepo,
                              FluidProvider fluidProvider,
                              IEmailService emailService)
        {
            _env = env;
            _websiteSettingRepo = websiteSettingRepo;
            _menuRepo = menuRepo;
            _contentRepo = contentRepo;
            _formRepo = formRepo;
            _formValueRepo = formValueRepo;
            _userRepo = userRepo;
            _fluidProvider = fluidProvider;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index([FromQuery] HomeRequest request)
        {
            var templatePath = Path.Combine(_env.WebRootPath, CommonConstant.UploadFolder, CommonConstant.UploadTemplateFolder);
            var templateFileName = string.Empty;

            var setting = await _websiteSettingRepo.Query()
            .Include(e => e.WebsiteCustomParams)
            .FirstOrDefaultAsync();
            if (setting == null) return NotFound();

            var allMenus = await _menuRepo.Query().Where(e => !e.IsHidden).ToListAsync();
            var navMenus = allMenus.Where(e => !e.ParentId.HasValue).ToList();
            GenerateChildMenus(allMenus, navMenus);

            var viewModel = new HomeViewModel(setting, navMenus);

            if (request.Mid > 0) //菜单
            {
                viewModel.Id = request.Mid;

                var menu = allMenus.FirstOrDefault(e => e.Id == request.Mid);
                if (menu == null) return NotFound();
                templateFileName = menu.ContentTemplateFile;

                ResetTitleKeyDesc(viewModel, menu);

                SetBanner(allMenus, viewModel, menu);

                var categoryMenus = GenerateCategorys(allMenus, menu);

                switch (menu.Model)
                {
                    case NavMenuModels.SinglePage:
                        var singleContent = await _contentRepo.Query().FirstOrDefaultAsync(e => e.NavMenuId == menu.Id);
                        viewModel.Data = new HomeSingleViewModel(categoryMenus, singleContent);
                        break;
                    case NavMenuModels.CustomForm:
                        var formContent = await _formRepo.Query().Where(e => e.NavMenuId == menu.Id).OrderBy(e => e.Id).ToListAsync();
                        viewModel.Data = new HomeSingleViewModel(categoryMenus, formContent);
                        break;
                    default:
                        IQueryable<PageContent> queryable;
                        int totalRow = 0;
                        List<PageContent> contentList;
                        if (menu.ParentId.HasValue)
                        {
                            queryable = _contentRepo.Query().Where(e => e.NavMenuId == menu.Id && e.IsPublished);
                        }
                        else
                        {
                            if (categoryMenus.Count > 0)
                            {
                                var childrenMenuIds = categoryMenus.Select(e => e.Id);
                                queryable = _contentRepo.Query().Where(e => e.IsPublished && childrenMenuIds.Contains(e.NavMenuId));
                            }
                            else
                            {
                                queryable = _contentRepo.Query().Where(e => e.NavMenuId == menu.Id && e.IsPublished);
                            }
                        }
                        totalRow = await queryable.CountAsync();
                        contentList = await queryable.OrderByDescending(e => e.Id)
                        .Skip((request.Page - 1) * request.Limit).Take(request.Limit)
                        .ToListAsync();

                        viewModel.Data = new HomePaginationViewModel(totalRow,
                                                                     request.Page,
                                                                     request.Limit,
                                                                     categoryMenus,
                                                                     contentList);

                        templateFileName = menu.ListTemplateFile;
                        break;
                }

            }
            else if (request.Vid > 0) //视图
            {
                viewModel.Id = request.Vid;

                var content = await _contentRepo.Query()
                .Include(e => e.DownloadFiles)
                .FirstOrDefaultAsync(e => e.Id == request.Vid);
                if (content == null) return NotFound();

                content.IncreasePageviews();
                await _contentRepo.UpdateProperyAsync(content, nameof(content.Pageviews));

                var menu = allMenus.FirstOrDefault(e => e.Id == content.NavMenuId);
                if (menu == null) return NotFound();
                templateFileName = menu.ContentTemplateFile;

                var prev = await _contentRepo.Query().Where(e => e.Id < content.Id && e.NavMenuId == menu.Id).OrderByDescending(e => e.Id).Select(e => new HomeDetailAdjacentViewModel
                {
                    Id = e.Id,
                    Title = e.Title
                }).FirstOrDefaultAsync();
                var next = await _contentRepo.Query().Where(e => e.Id > content.Id && e.NavMenuId == menu.Id).OrderBy(e => e.Id).Select(e => new HomeDetailAdjacentViewModel
                {
                    Id = e.Id,
                    Title = e.Title
                }).FirstOrDefaultAsync();

                ResetTitleKeyDesc(viewModel, menu, content.Title);

                SetBanner(allMenus, viewModel, menu);

                var categoryMenus = GenerateCategorys(allMenus, menu);

                viewModel.Data = new HomeDetailViewModel(categoryMenus, content, prev, next);
            }
            else
            {
                templateFileName = "index.html";
            }

            var options = _fluidProvider.CreateTemplateOptions();
            var html = await _fluidProvider.LoadTemplateAsync(Path.Combine(templatePath, templateFileName), viewModel, options);

            return View(new HomeHtmlViewModel(html));
        }

        /// <summary>
        /// 生成子菜单
        /// </summary>
        /// <param name="allMenus"></param>
        /// <param name="menus"></param>
        private void GenerateChildMenus(List<NavMenu> allMenus, List<NavMenu> menus)
        {
            foreach (var item in menus)
            {
                item.Children = allMenus.Where(e => e.ParentId == item.Id).OrderBy(e => e.Order).ToList();
                if (item.Children.Count > 0)
                {
                    GenerateChildMenus(allMenus, item.Children);
                }
            }
        }

        /// <summary>
        /// 重新设置标题、SEO关键词、SEO描述
        /// </summary>
        /// <param name="model"></param>
        /// <param name="menu"></param>
        private void ResetTitleKeyDesc(HomeViewModel model, NavMenu menu, string title = null)
        {
            model.Setting.WebsiteTitle = string.IsNullOrEmpty(title) ? menu.MenuName : title;
            if (!string.IsNullOrEmpty(menu.WebsiteKeywords) || !string.IsNullOrEmpty(menu.WebsiteDescription))
            {
                model.Setting.WebsiteKeywords = menu.WebsiteKeywords;
                model.Setting.WebsiteDescription = menu.WebsiteDescription;
            }
        }

        /// <summary>
        /// 设置横幅
        /// </summary>
        /// <param name="allMenus"></param>
        /// <param name="model"></param>
        /// <param name="menu"></param>
        private void SetBanner(List<NavMenu> allMenus, HomeViewModel model, NavMenu menu)
        {
            if (!string.IsNullOrEmpty(menu.BannerImg))
            {
                model.BannerUrl = menu.BannerImg;
            }

            if (menu.ParentId.HasValue)
            {
                var parentMenu = allMenus.Where(e => e.Id == menu.ParentId).FirstOrDefault();

                this.SetBanner(allMenus, model, parentMenu);
            }
        }

        /// <summary>
        /// 生成分类
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="menu"></param>
        /// <returns></returns>
        private List<HomeCategoryViewModel> GenerateCategorys(List<NavMenu> allMenus, NavMenu menu)
        {
            var childrentMenus = new List<NavMenu>();
            if (menu.ParentId.HasValue)
            {
                childrentMenus = allMenus.Where(e => e.ParentId == menu.ParentId).OrderBy(e => e.Order).ToList();
            }
            else
            {
                childrentMenus = allMenus.Where(e => e.ParentId == menu.Id).OrderBy(e => e.Order).ToList();
            }

            var categorys = new List<HomeCategoryViewModel>();
            foreach (var item in childrentMenus)
            {
                categorys.Add(new HomeCategoryViewModel
                {
                    Id = item.Id,
                    Title = item.MenuName,
                    IsActive = item.Id == menu.Id
                });
            }
            return categorys;
        }

        [HttpPost("form")]
        public async Task<IActionResult> Form([FromForm] HomeFormRequest request)
        {
            if (request == null) return NoContent();
            var menuName = await _menuRepo.Query().Where(e => e.Id == request.Id).Select(e => e.MenuName).FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(menuName)) return NotFound();

            var formValue = new WebsiteCustomFormValue(request.Id, request.Value);
            await _formValueRepo.InsertAsync(formValue);

            var users = await _userRepo.Query().Where(e => !string.IsNullOrEmpty(e.Email)).ToListAsync();
            if (users.Count > 0)
            {
                var addresses = new List<MailboxAddress>();
                foreach (var item in users)
                {
                    addresses.Add(new MailboxAddress(item.UserName, item.Email));
                }

                await _emailService.SendRangeAsync(addresses, menuName, $"您有新的{menuName}内容请及时查看。");
            }

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
