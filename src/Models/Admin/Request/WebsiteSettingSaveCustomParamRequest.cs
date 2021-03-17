using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Request
{
    public class WebsiteSettingSaveCustomParamRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public CustomParamTypes Type { get; set; }
    }
}