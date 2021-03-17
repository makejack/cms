using AutoMapper;
using www.veinid365.cn.Extensions;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Models.Admin.Response;

namespace www.veinid365.cn.MapperProfiles
{
    public class DefaultMap : Profile
    {
        public DefaultMap()
        {
            CreateMap<Users, UserResponse>();
            CreateMap<News, NewsDetailResponse>();
            CreateMap<News, NewsListResponse>();
            CreateMap<Product, ProductGetResponse>();
            CreateMap<Product, ProductListResponse>();
            CreateMap<Solution, SolutionListResponse>();
            CreateMap<Solution, SolutionDetailResponse>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<OnlineMessage, OnlineMessageListResponse>();
            CreateMap<OfflineStore, OfflineStoreListResponse>();
            CreateMap<OfflineStore, OfflineStoreDetailResponse>();

            CreateMap<WebsiteSetting, WebsiteSettingResponse>();
            CreateMap<WebsiteCustomParam, WebsiteSettingCustomParamResponse>();
            CreateMap<NavMenu, NavMenuListResponse>()
            .ForMember(s => s.ModelDescription, o => o.MapFrom(s => s.Model.GetDescription()));
            CreateMap<NavMenu, NavMenuDetailResponse>();
            CreateMap<PageContent, PageContentListResponse>()
            .ForMember(s => s.MenuName, o => o.MapFrom(s => s.NavMenu.MenuName))
            .ForMember(s => s.MenuModel, o => o.MapFrom(s => s.NavMenu.Model));
            CreateMap<PageContent, PageContentDetailResponse>();
            CreateMap<DownloadFile, DownloadFilelResponse>();
            CreateMap<WebsiteCustomForm, WebsiteCustomFormListResponse>()
            .ForMember(s => s.TypeDescription, o => o.MapFrom(s => s.Type.GetDescription()));
            CreateMap<WebsiteCustomForm, WebsiteCustomFormTableHeaderResponse>();
            CreateMap<WebsiteCustomFormValue, WebsiteCustomFormValueListResponse>();
        }
    }
}