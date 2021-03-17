using Fluid;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Models;

namespace www.veinid365.cn.Fluid
{
    public class MemberRegister : IFluidMemberRegister
    {
        public void Register(TemplateOptions options)
        {
            options.MemberAccessStrategy.Register<PageContent>();
            options.MemberAccessStrategy.Register<HomeViewModel>();
            options.MemberAccessStrategy.Register<WebsiteSetting>();
            options.MemberAccessStrategy.Register<NavMenu>();
            options.MemberAccessStrategy.Register<DownloadFile>();
            options.MemberAccessStrategy.Register<WebsiteCustomForm>();
            options.MemberAccessStrategy.Register<WebsiteCustomParam>();
            options.MemberAccessStrategy.Register<HomeCategoryViewModel>();
            options.MemberAccessStrategy.Register<HomePaginationViewModel>();
            options.MemberAccessStrategy.Register<HomeSingleViewModel>();
            options.MemberAccessStrategy.Register<HomeDetailViewModel>();
            options.MemberAccessStrategy.Register<HomeDetailAdjacentViewModel>();
            options.MemberAccessStrategy.Register<RequestListBlockResponse>();

        }
    }
}