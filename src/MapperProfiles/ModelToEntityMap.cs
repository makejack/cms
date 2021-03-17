using AutoMapper;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Models.Admin.Request;

namespace www.veinid365.cn.MapperProfiles
{
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap()
        {
            CreateMap<WebsiteSettingSaveRequest, WebsiteSetting>();
            CreateMap<WebsiteSettingSaveCustomParamRequest, WebsiteCustomParam>();
            CreateMap<NavMenuCreateEditRequest, NavMenu>();
            CreateMap<WebsiteCustomFormCreateEditRequest, WebsiteCustomForm>();
            CreateMap<PageContentCreateEditRequest, PageContent>();
            CreateMap<DownloadFileRequest, DownloadFile>();
        }
    }
}