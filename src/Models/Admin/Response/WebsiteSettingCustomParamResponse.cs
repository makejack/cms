using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class WebsiteSettingCustomParamResponse : AggregateModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public CustomParamTypes Type { get; set; }
    }
}