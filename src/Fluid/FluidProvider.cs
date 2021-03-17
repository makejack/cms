using System.IO;
using System.Linq;
using System;
using Fluid;
using System.Threading.Tasks;
using Fluid.Values;

namespace www.veinid365.cn.Fluid
{
    public class FluidProvider
    {
        private readonly FluidParser _parser;
        private readonly IServiceProvider _provider;

        public FluidProvider(FluidParser parser, IServiceProvider provider)
        {
            _parser = parser;
            _provider = provider;

            var baseType = typeof(IFluidRegisitering);
            var allTypes = this.GetType().Assembly.GetTypes();
            var registertype = allTypes.Where(e => e.IsClass && baseType.IsAssignableFrom(e)).ToList();
            foreach (var item in registertype)
            {
                ((IFluidRegisitering)provider.GetService(item)).Register(_parser);
            }
        }


        public TemplateOptions CreateTemplateOptions()
        {
            var options = new TemplateOptions();

            var baseType = typeof(IFluidFilter);
            var assembly = this.GetType().Assembly;
            var allTypes = assembly.GetTypes();
            var filterTypes = allTypes.Where(e => e.IsClass && !e.IsAbstract && baseType.IsAssignableFrom(e)).ToList();
            foreach (var item in filterTypes)
            {
                ((IFluidFilter)Activator.CreateInstance(item)).AddFilter(options);
            }

            baseType = typeof(IFluidMemberRegister);
            var memberRegisterTypes = allTypes.Where(e => e.IsClass && baseType.IsAssignableFrom(e)).ToList();
            foreach (var item in memberRegisterTypes)
            {
                ((IFluidMemberRegister)Activator.CreateInstance(item)).Register(options);
            }

            return options;
        }


        public async Task<string> LoadTemplateAsync(string path, object model = null, TemplateOptions options = null)
        {
            if (options == null)
            {
                options = TemplateOptions.Default;
            }
            if (File.Exists(path))
            {
                var htmlContent = File.ReadAllText(path);
                if (_parser.TryParse(htmlContent, out var template, out var error))
                {
                    TemplateContext templateContext = model == null ? new TemplateContext(options) : new TemplateContext(model, options);
                    return await template.RenderAsync(templateContext);
                }
                return error;
            }
            return string.Empty;
        }

    }
}