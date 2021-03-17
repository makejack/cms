using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Request
{
    public class WebsiteCustomFormCreateEditRequest
    {
        public int Id { get; set; }
        public int NavMenuId { get; set; }
        public string Name { get; set; }
        public CustomParamTypes Type { get; set; }
        public bool IsRequired { get; set; }
        public bool IsShowList { get; set; }
    }
}