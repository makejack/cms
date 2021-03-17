using System;
using System.Linq;
using Fluid;
using Fluid.Ast;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Models;

namespace www.veinid365.cn.Fluid
{
    public class RequestMenuBlockRegistering : IFluidRegisitering
    {
        private readonly IServiceProvider _serviceProvider;

        public RequestMenuBlockRegistering(IServiceProvider provider)
        {
            _serviceProvider = provider;
        }

        public void Register(FluidParser parser)
        {
            parser.RegisterExpressionBlock("menu", async (value, statements, writer, encoder, context) =>
               {
                   var valueResult = value.EvaluateAsync(context);
                   var menuId = valueResult.Result.ToNumberValue();

                   using (var scope = _serviceProvider.CreateScope())
                   {
                       var contentRepo = scope.ServiceProvider.GetService<IRepositoryDefault<PageContent>>();
                       var menuRepo = scope.ServiceProvider.GetService<IRepositoryDefault<NavMenu>>();

                       var menu = await menuRepo.Query().FirstOrDefaultAsync(e => e.Id == menuId);
                       if (menu == null) return Completion.Normal;
                       var content = await contentRepo.Query().Where(e => e.NavMenuId == menuId).FirstOrDefaultAsync();
                       if (content == null) return Completion.Normal;
                       context.SetValue("Data", new RequestListBlockResponse(menu.Id, menu.MenuName, menu.EnMenuName, content));

                   }

                   await statements.RenderStatementsAsync(writer, encoder, context);

                   return Completion.Normal;
               });
        }
    }
}