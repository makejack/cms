using System.Threading.Tasks;
using Fluid;
using Fluid.Values;

namespace www.veinid365.cn.Fluid
{
    public class RowFilter : FluidFilterBase
    {
        public RowFilter() : base("row")
        {
        }

        public override void AddFilter(TemplateOptions options)
        {
            if (!options.Filters.TryGetValue(Name, out var row))
            {
                options.Filters.AddFilter(Name, Row);
            }
        }

        private ValueTask<FluidValue> Row(FluidValue input, FilterArguments arguments, TemplateContext context)
        {
            var id = input.ToNumberValue();
            var limit = arguments.At(0).ToNumberValue();

            return ObjectValue.Create(new ListRequest { MenuId = (int)id, Limit = (int)limit }, context.Options);
        }
    }
}