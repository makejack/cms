using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fluid;
using Fluid.Ast;
using Fluid.Values;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace www.veinid365.cn.Fluid
{
    public class RequestViewBlockRegistering : IFluidRegisitering
    {

        private readonly IServiceProvider _serviceProvider;

        public RequestViewBlockRegistering(IServiceProvider provider)
        {
            _serviceProvider = provider;
        }

        public void Register(FluidParser parser)
        {
            parser.RegisterExpressionBlock("view", async (value, statements, writer, encoder, context) =>
            {
                var valueResult = value.EvaluateAsync(context);
                var id = valueResult.Result.ToNumberValue();

                using (var scope = _serviceProvider.CreateScope())
                {
                    var repo = scope.ServiceProvider.GetService<IRepositoryDefault<PageContent>>();

                    var content = await repo.Query().Include(e => e.DownloadFiles).Where(e => e.Id == id).FirstOrDefaultAsync();
                    context.SetValue("Data", content);

                }

                await statements.RenderStatementsAsync(writer, encoder, context);

                return Completion.Normal;
            });
        }
    }
}