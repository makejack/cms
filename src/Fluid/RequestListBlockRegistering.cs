using System;
using System.Linq;
using Fluid;
using Fluid.Ast;
using Fluid.Values;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models;

namespace www.veinid365.cn.Fluid
{
    public class RequestListBlockRegistering : IFluidRegisitering
    {
        private readonly IServiceProvider _serviceProvider;

        public RequestListBlockRegistering(IServiceProvider provider)
        {
            _serviceProvider = provider;
        }

        public void Register(FluidParser parser)
        {
            parser.RegisterExpressionBlock("list", async (value, statements, writer, encoder, context) =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var contentRepo = scope.ServiceProvider.GetService<IRepositoryDefault<PageContent>>();
                    var menuRepo = scope.ServiceProvider.GetService<IRepositoryDefault<NavMenu>>();

                    var menuId = 0;
                    var limit = 0;
                    var valueResult = value.EvaluateAsync(context);
                    if (valueResult.Result.Type == FluidValues.Object)
                    {
                        var obj = (ListRequest)valueResult.Result.ToObjectValue();
                        menuId = obj.MenuId;
                        limit = obj.Limit;
                    }
                    else if (valueResult.Result.Type == FluidValues.Number)
                    {
                        menuId = (int)valueResult.Result.ToNumberValue();
                    }

                    var menu = await menuRepo.Query().FirstOrDefaultAsync(e => e.Id == menuId);
                    if (menu == null) return Completion.Normal;
                    
                    IQueryable<PageContent> query = null;
                    if (menu.ParentId.HasValue)
                    {
                        query = contentRepo.Query().OrderByDescending(e => e.Id).Where(e => e.NavMenuId == menuId);
                    }
                    else
                    {
                        var menuIds = await menuRepo.Query().Where(e => e.ParentId == menuId).Select(e => e.Id).ToListAsync();
                        if (menuIds.Count > 0)
                        {
                            query = contentRepo.Query().OrderByDescending(e => e.Id).Where(e => menuIds.Contains(e.NavMenuId));
                        }
                        else
                        {
                            query = contentRepo.Query().OrderByDescending(e => e.Id).Where(e => e.NavMenuId == menuId);
                        }
                    }
                    if (limit > 0)
                    {
                        query = query.Take(limit);
                    }
                    var content = await query.ToListAsync();

                    context.SetValue("Data", new RequestListBlockResponse(menu.Id, menu.MenuName, menu.EnMenuName, content));

                }

                await statements.RenderStatementsAsync(writer, encoder, context);

                return Completion.Normal;
            });
        }
    }
}