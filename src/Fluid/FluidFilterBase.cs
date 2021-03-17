using Fluid;

namespace www.veinid365.cn.Fluid
{
    public abstract class FluidFilterBase : IFluidFilter
    {
        protected FluidFilterBase(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public abstract void AddFilter(TemplateOptions options);
    }
}